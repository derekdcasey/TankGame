using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tbUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // DataB db;
        Database db;

        /////////////////////////////////////LOGIC VARS

        public static double Sx;
        public static double Sy;
        public static double t;
        public static double gravity = 9.81;
        public static int speed;



        string currentKey = "";

        DispatcherTimer dtTimer = new DispatcherTimer();
        DispatcherTimer gTime = new DispatcherTimer();
        DispatcherTimer fallTimer = new DispatcherTimer();

        Vector offset;

        double rotateRadian;
        public static double newLocationX;
        public static double newLocationY;

        Rectangle ball;

        RotateTransform rotateTransform1;

        bool hasFired = false;
        bool playSound = false;
        bool playGraphic = false;

        public MainWindow()
        {
            InitializeComponent();

           

            db = new Database();
            db.OpenConnection();
            //ReloadListView();

            //////////////////////////////////////////LOGIC
            
            rotateRadian = 0.0;

            dtTimer.Tick += GameLoop;
            dtTimer.Interval = TimeSpan.FromMilliseconds(1);
            dtTimer.Start();

            ball = new Rectangle()
            {
                Name = "ball",
                Width = 9,
                Height = 9,
                RadiusX = 4,
                RadiusY = 12.5,

                Fill = Brushes.Gray,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

            txtAngle.Text = "0";
            txtPower.Text = "0";
            offset = VisualTreeHelper.GetOffset(ball);
            offset = VisualTreeHelper.GetOffset(P1Turret);
            offset = VisualTreeHelper.GetOffset(explosion);


        }
       
        void MoveImage()
        {
            if (CheckCollision(ball, P2_tank) == false || CheckCollision(ball, rectGround) == false || CheckCollision(ball, rectCollider1) == false || CheckCollision(ball, rectCollider2) == false)
            {

                
                t += 0.05;

                newLocationX += speed/2 * Math.Cos(rotateRadian / 57.3) * t;
                newLocationY += speed * Math.Sin(rotateRadian / 57.3) * t - 0.5 * -gravity * Math.Pow(t, 2);


                ball.Margin = new Thickness(newLocationX, newLocationY, 0, 0);


            }


        }

        void PlayExplosionSound()
        {
            if (playSound == false)
            {
                playSound = true;
                SoundPlayer exSound = new SoundPlayer(@"C:\Users\ipd\Repos\TankBusters\tbUI\tbUI\explosion09.wav");
                exSound.Play();
            }
        }

        void PlayExplosionGraphic()
        {
            if (playGraphic == false)
            {
                playGraphic = true;
                Point ballLoc = ball.PointToScreen(new Point(0, 0));

                SetLocation(explosion, new Point(ballLoc.X - (explosion.ActualWidth / 2), ballLoc.Y - explosion.ActualHeight));
                explosion.Visibility = Visibility.Visible;
                DoubleAnimation da1 = new DoubleAnimation();
                da1.From = 1;
                da1.To = 0;
                da1.Duration = new Duration(TimeSpan.FromSeconds(.5));
                explosion.BeginAnimation(OpacityProperty, da1);


            }
        }

        void doDamage()
        {

        }
        void GameLoop(object sender, object e)//gameloop
        {





            if (hasFired)
            {
            Collision();
            }









            switch (currentKey)
            {
                case "up":
                    if(rotateRadian < 90 || rotateRadian > -90)
                    {
                    rotateRadian -= 1.0;
                    if (rotateRadian < -360)
                        rotateRadian = 0;
                    txtAngle.Text = rotateRadian.ToString();
                    }
                    break;




                case "down":
                    if (rotateRadian < 90 || rotateRadian > -90)
                    {
                        rotateRadian += 1.0;
                    if (rotateRadian > 360)
                        rotateRadian = 0;
                    txtAngle.Text = rotateRadian.ToString();
                    }
                    break;


                case "space":
                    if (hasFired)
                    {
                        Point P1Barrel = ball.PointToScreen(new Point(0, 0));
                        SetLocation(smoke, new Point(GetLocation(P1Turret).X, (GetLocation(P1Turret).Y - (smoke.ActualHeight / 2))));
                        smoke.Visibility = Visibility.Visible;

                        MoveImage();

                    }

                    break;
                default:
                    if (hasFired)
                    {
                        currentKey = "space";
                    }

                    break;

            }

            rotateTransform1 = new RotateTransform(rotateRadian);
            P1Turret.RenderTransform = rotateTransform1;


        }

        private void ResetP1Ball()
        {
            if (hasFired == true)
            {
                hasFired = false;
                ball.Visibility = Visibility.Hidden;
               // c1.Children.Remove(ball);
            }
        }

                
               



        public void CreateCannonBall()
        {   
            c1.Children.Add(ball);
            Canvas.SetLeft(ball, 96);
            Canvas.SetTop(ball, 476);
        }
            


        public void Collision()
        {

            

            if (CheckCollision(ball, rectGround))
            {
                PlayExplosionSound();
                PlayExplosionGraphic();
               
                ResetP1Ball();
                //TODO: set player 2 turn
                //reset player 1 variables and ball
            }


            if (CheckCollision(ball, rectCollider1))
            {
                PlayExplosionSound();
                PlayExplosionGraphic();
                ResetP1Ball();
            }
            

            if (CheckCollision(ball, rectCollider2))
            {
                PlayExplosionSound();
                PlayExplosionGraphic();
                ResetP1Ball();
            }

            if (CheckCollision(ball, P2_tank) == true)
            {
                PlayExplosionSound();
                PlayExplosionGraphic();
                rectP2_hp1.Visibility = Visibility.Hidden;
                ResetP1Ball();
            }
            

        }


        public bool CheckCollision(Rectangle obj1, Rectangle obj2)
        {

            
                Rect myRect = new Rect();

                myRect.Location = obj1.PointToScreen(new Point(0D, 0D));
                myRect.Size = new Size(obj1.Width, obj1.Height);

                Rect floorRect = new Rect();
                floorRect.Location = obj2.PointToScreen(new Point(0D, 0D));
                floorRect.Size = new Size(obj2.Width, obj2.Height);





                if (myRect.IntersectsWith(floorRect))
                {

                    return true;


                }
                else
                    return false;

            
        }

        Point GetLocation(Rectangle obj)
        {
            
            return new Point(Canvas.GetLeft(obj), Canvas.GetTop(obj));
        }
        void SetLocation(Image obj, Point objPnt)
        {
            Canvas.SetLeft(obj, objPnt.X);
            Canvas.SetTop(obj, objPnt.Y);
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (hasFired == false)
            {

                if (e.Key == Key.Up)
                {

                    currentKey = "up";


                }
                if (e.Key == Key.Down)
                {

                    currentKey = "down";

                }

                if (e.Key == Key.Right)
                {
                    currentKey = "right";

                    speed += 1;
                    txtPower.Text = speed.ToString();
                }
                if (e.Key == Key.Left)
                {
                    currentKey = "left";
                    speed -= 1;
                    txtPower.Text = speed.ToString();
                }


                if (e.Key == Key.Space)
                {


                    CreateCannonBall();

                    currentKey = "space";
                   
                    hasFired = true;

                    DoubleAnimation da = new DoubleAnimation();
                    da.From = 1;
                    da.To = 0;
                    da.Duration = new Duration(TimeSpan.FromSeconds(1));
                    smoke.BeginAnimation(OpacityProperty, da);
                    SoundPlayer shootSOund = new SoundPlayer(@"C:\Users\ipd\Repos\TankBusters\tbUI\tbUI\explosion01.wav");
                    shootSOund.Play();



                }

            }


        }






      



        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Up)
                currentKey = "";
            if (e.Key == Key.Down)
                currentKey = "";
            if (e.Key == Key.Right)
                currentKey = "";
            if (e.Key == Key.Left)
                currentKey = "";






        }

        private void slPower_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            
        }

        private void slAngle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

      
















        ////////////////////////////////////////////////SQL STUFF













    }
}




