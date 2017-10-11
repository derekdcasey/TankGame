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

namespace prototype1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double Sx;
        public static double Sy;
        public static double t;
        public static double gravity = 9.81;
        int speed;
        


        string currentKey = "";

        DispatcherTimer dtTimer = new DispatcherTimer();
        DispatcherTimer gTime = new DispatcherTimer();
        DispatcherTimer fallTimer = new DispatcherTimer();

        Vector offset;

        double rotateRadian;
        public static double newLocationX;
        public static double newLocationY;

        RotateTransform rotateTransform1;

        bool hasFired = false;
        bool playSound = false;
        bool playGraphic = false;

        
        
       


        public MainWindow()
        {

            InitializeComponent();
            rotateRadian = 0.0;
            
            dtTimer.Tick += GameLoop;
            dtTimer.Interval = TimeSpan.FromMilliseconds(1);
            dtTimer.Start();
            
            //gTime.Tick += Gravity;

            //gTime.Interval = TimeSpan.FromSeconds(power);
            //fallTimer.Tick += StartDescent;
            //fallTimer.Interval = TimeSpan.FromMilliseconds(1);
            label1.Content = 0;
            offset = VisualTreeHelper.GetOffset(ball);
            offset = VisualTreeHelper.GetOffset(player);
            offset = VisualTreeHelper.GetOffset(explosion);
           

            

           
        }


      

        void MoveImage()
        {
            if(CheckCollision(ball, enemyTank) == false || CheckCollision(ball, floor) == false)
            {
                speed = 5;
                t += .05;

                newLocationX += speed * Math.Cos(rotateRadian / 57.3) * t;
                newLocationY += speed * Math.Sin(rotateRadian / 57.3) * t - 0.5 * -gravity * Math.Pow(t,2);

          
            ball.Margin = new Thickness(newLocationX, newLocationY, 0, 0);
            
            
            }            
        }

       

     
            void PlayExplosionSound()
        {
            if (playSound == false)
            {
                playSound = true;
                SoundPlayer exSound = new SoundPlayer(@"D:\Code\TankGame\prototype1\prototype1\explosion09.wav");
                exSound.Play();
            }
        }
            
        void PlayExplosionGraphic()
        {
            if(playGraphic == false)
            {
                playGraphic = true;
                Point ballLoc = ball.PointToScreen(new Point(0, 0));

                SetLocation(explosion, new Point(ballLoc.X - (explosion.ActualWidth/2), ballLoc.Y - explosion.ActualHeight));
                explosion.Visibility = Visibility.Visible;
                DoubleAnimation da1 = new DoubleAnimation();
                da1.From = 1;
                da1.To = 0;
                da1.Duration = new Duration(TimeSpan.FromSeconds(.5));
                explosion.BeginAnimation(OpacityProperty, da1);
                
                
            }
        }

        void GameLoop(object sender, object e)//gameloop
        {
           


            if (CheckCollision(ball, enemyTank) || CheckCollision(ball, floor))
            {
                PlayExplosionSound();
                PlayExplosionGraphic();
                //TODO: set player 2 turn
                //reset player 1 variables and ball
                

                fallTimer.Stop();
                gTime.Stop();
                ResetP1Ball();
            }
            


            switch (currentKey)
            {
                case "up":
                   
                        rotateRadian -= 1.0;
                        if (rotateRadian < -360)
                            rotateRadian = 0;
                        label1.Content = rotateRadian.ToString();
                    
                    break;


                case "down":
                        rotateRadian += 1.0;
                        if (rotateRadian > 360)
                            rotateRadian = 0;
                        label1.Content = rotateRadian.ToString();
                    break;
                   
                case "space":
                    if (hasFired)
                    {
                        Point P1Barrel = ball.PointToScreen(new Point(0, 0));
                        SetLocation(smoke, new Point(GetLocation(player).X, (GetLocation(player).Y - (smoke.ActualHeight/2))));
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
            player.RenderTransform = rotateTransform1;
        }

        private void ResetP1Ball()
        {
            if(hasFired == true)
            {
            Canvas.SetLeft(ball, 125);
            Canvas.SetTop(ball, 599);
            hasFired = false;
            }
        }



        //public void createCannonBall()
        //{
        //    Rectangle ball = new Rectangle();
        //    ball.RadiusX = 49.5;
        //    ball.RadiusY = 49.5;
        //    ball.Name = "ball";
        //    c1.Children.Add(ball);
        //    Canvas.SetLeft(ball, 125);
        //    Canvas.SetTop(ball, 599);
        //}




        private bool CheckCollision(Rectangle obj1, Rectangle obj2)
        {
            Rect myRect = new Rect();
            myRect.Location = obj1.PointToScreen(new Point(0D,0D));
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


        //private void StartDescent(object sender, EventArgs e)
        //{

        //    ball.Margin = new Thickness(newLocationX -= .5, newLocationY += 4, 0, 0);
            
        //}
        //private void Gravity(object sender, EventArgs e)
        //{



        //    if (CheckCollision(ball, enemyTank) == false || CheckCollision(ball, floor) == false)
        //    {
        //        gTime.Stop();
        //        fallTimer.Start();

        //    }

        //}
            

      
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

                //if (e.Key == Key.Right)
                //{
                //    currentKey = "right";

                //}

                if (e.Key == Key.Space)
                {
                    currentKey = "space";
                   
                    hasFired = true;

                    //saving action to database  
                    string[] arr = { speed.ToString(), rotateRadian.ToString()};
                    Globals.game.P1Action = string.Join(",", arr);
                    Globals.game.P2Action = string.Join(",", arr);


                    DoubleAnimation da = new DoubleAnimation();
                    da.From = 1;
                    da.To = 0;
                    da.Duration = new Duration(TimeSpan.FromSeconds(1));
                    smoke.BeginAnimation(OpacityProperty, da);
                    SoundPlayer shootSOund = new SoundPlayer(@"D:\Code\TankGame\prototype1\prototype1\explosion01.wav");
                    shootSOund.Play();
                    
                    
                   
                }

            }

            
        }
          





        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {

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
    }






}
