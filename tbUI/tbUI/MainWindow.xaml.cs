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

        
        public static double t;
        public static double gravity = 9.81;
        int speed { get; set; }

        int playernumber = 1;
       


        string currentKey = "";

        DispatcherTimer dtTimer = new DispatcherTimer();
        DispatcherTimer reset = new DispatcherTimer();
        

        Vector offset;

        double rotateRadian;
        public static double newLocationX;
        public static double newLocationY;

        
        RotateTransform rotateTransform1;

        bool hasFired = false;
        bool p1BallHasCollided= false;
       

        public MainWindow()
        {
            InitializeComponent();

         

            db = new Database();
            db.OpenConnection();
            //ReloadListView();

            //////////////////////////////////////////LOGIC
            
            rotateRadian = 0.0;

            dtTimer.Tick += GameLoop;
            dtTimer.Interval = TimeSpan.FromMilliseconds(16);
            dtTimer.Start();

          


            txtAngle.Text = "0";
            txtPower.Text = "0";
            offset = VisualTreeHelper.GetOffset(Ball_p1);
            offset = VisualTreeHelper.GetOffset(P1Turret);
            offset = VisualTreeHelper.GetOffset(P1_tank);

            offset = VisualTreeHelper.GetOffset(ball_P2);
            
            offset = VisualTreeHelper.GetOffset(P2_tank);

            offset = VisualTreeHelper.GetOffset(explosion);
            offset = VisualTreeHelper.GetOffset(smoke);
            offset = VisualTreeHelper.GetOffset(mountain);
            
            


        }
       
        void MoveImage()
        {
            if (p1BallHasCollided == false)
            {
            

                t += 0.05;

                newLocationX += speed/2 * Math.Cos(rotateRadian / 57.3) * t;
                newLocationY += speed * Math.Sin(rotateRadian / 57.3) * t - 0.5 * -gravity * Math.Pow(t, 2);

                if(playernumber ==1)
                Ball_p1.Margin = new Thickness(newLocationX, newLocationY, 0, 0);

                if(playernumber ==2)
                    ball_P2.Margin = new Thickness(newLocationX, newLocationY, 0, 0);
            }


        }

        void PlayExplosionSound()
        {
<<<<<<< HEAD
          
                SoundPlayer exSound = new SoundPlayer(@"D:\Code\TankGame\tbUI\tbUI\explosion09.wav");
=======
            if (playSound == false)
            {
                playSound = true;
                SoundPlayer exSound = new SoundPlayer(@"C:\Users\ipd\Repos\TankBusters\tbUI\tbUI\explosion09.wav");
>>>>>>> f92d51b8ae4fef150fb4c876428e74e155685a87
                exSound.Play();
            
        }

        void PlayExplosionGraphic()
        {
                Point Ball_p1Loc = Ball_p1.PointToScreen(new Point(0D, 0D));

                SetLocation(explosion, new Point(Ball_p1Loc.X- 400, Ball_p1Loc.Y - 200));
                explosion.Visibility = Visibility.Visible;
                DoubleAnimation da1 = new DoubleAnimation();
                da1.From = 1;
                da1.To = 0;
                da1.Duration = new Duration(TimeSpan.FromSeconds(1));
                explosion.BeginAnimation(OpacityProperty, da1);

        }
            

        

        void doDamage()
        {   //p1hp - 1;
            //if(p1hp =2)
            rectP1hp_1.Visibility = Visibility.Hidden;
            //if(p1hp =1)
            rectP1hp_2.Visibility = Visibility.Hidden;
            //if(p1hp =0)
            rectP1hp_3.Visibility = Visibility.Hidden;
            //p1hp - 1;
            //change state to GO p2 wins
            //if(p1hp =2)
            rectP2_hp1.Visibility = Visibility.Hidden;
            //if(p1hp =1)
            rectP2_hp2.Visibility = Visibility.Hidden;
            //if(p1hp =0)
            rectP2_hp3.Visibility = Visibility.Hidden;
            //change state to GO p1 wins
        }

        void GameLoop(object sender, object e)//gameloop
        {





           
            if (hasFired==true && p1BallHasCollided == false)
            {
               
                    InstantiateRectsAndCollision();
                    Point P1Barrel = Ball_p1.PointToScreen(new Point(0, 0));
                    SetLocation(smoke, new Point(GetLocation(P1Turret).X, (GetLocation(P1Turret).Y - (smoke.ActualHeight / 2))));
                    smoke.Visibility = Visibility.Visible;

                    MoveImage();
                
            }
       










            switch (currentKey)
            {
                case "up":
                  
                    rotateRadian -= 1.0;
                    if (rotateRadian < -360)
                        rotateRadian = 0;
                    txtAngle.Text = rotateRadian.ToString();
                    
                    break;




                case "down":
                    
                        rotateRadian += 1.0;
                    if (rotateRadian > 360)
                        rotateRadian = 0;
                    txtAngle.Text = rotateRadian.ToString();
                    
                    break;


               

            }
            if(playernumber == 1)
            {
            rotateTransform1 = new RotateTransform(rotateRadian);
            P1Turret.RenderTransform = rotateTransform1;
            }

            if (playernumber == 2) {
                rotateTransform1 = new RotateTransform(rotateRadian);
            P2Turret.RenderTransform = rotateTransform1;
            }

        }

      












        public void InstantiateRectsAndCollision()
        {
            Rect p1BallRect = new Rect();
            
            p1BallRect.Location = Ball_p1.PointToScreen(new Point(0D, 0D));
            p1BallRect.Size = new Size(Ball_p1.Width, Ball_p1.Height);

            Rect groundRect = new Rect();

            groundRect.Location = Ground.PointToScreen(new Point(0D, 0D));
            groundRect.Size = new Size(Ground.Width, Ground.Height);

            Rect p2TankRect = new Rect();

            p2TankRect.Location = P2_tank.PointToScreen(new Point(0D, 0D));
            p2TankRect.Size = new Size(P2_tank.Width, P2_tank.Height);

            Rect leftMountRect = new Rect();

            leftMountRect.Location = mountain.PointToScreen(new Point(0D, 0D));
            leftMountRect.Size = new Size(mountain.Width, mountain.Height);




            //Rect p1TankRect = new Rect();

            //p1TankRect.Location = P1_tank.PointToScreen(new Point(0D, 0D));
            //p1TankRect.Size = new Size(P1_tank.Width, P1_tank.Height);
            if (p1BallRect.IntersectsWith(p2TankRect))
            {
                rectP2_hp1.Visibility = Visibility.Hidden;

                p1BallHasCollided = true;




                PlayExplosionSound();
                PlayExplosionGraphic();



              

                hasFired = false;
                Ball_p1.Margin = new Thickness(0, 0, 0, 0);
                Canvas.SetLeft(Ball_p1, 95);
                Canvas.SetTop(Ball_p1, 477);


                //TODO set player 2s turn

                //debug timer for now


                reset.Tick += resetCollider;
                reset.Interval = TimeSpan.FromSeconds(3);
                reset.Start();

                t =0;

                newLocationX = 0;
                newLocationY = 0;
                speed = 0;
                
            }


            if (p1BallRect.IntersectsWith(groundRect) || p1BallRect.IntersectsWith(leftMountRect))
            {

                //Ball_p1.Visibility = Visibility.Hidden;



                p1BallHasCollided = true;




                PlayExplosionSound();
                PlayExplosionGraphic();



                hasFired = false;
                Ball_p1.Margin = new Thickness(0, 0, 0, 0);
                Canvas.SetLeft(Ball_p1, 95);
                Canvas.SetTop(Ball_p1, 477);


                //TODO set player 2s turn

                //debug timer for now
                t = 0;

                newLocationX = 0;
                newLocationY = 0;
                speed = 0;
                txtPower.Text = speed.ToString();
                reset.Tick += resetCollider;
                reset.Interval = TimeSpan.FromSeconds(3);
                reset.Start();
            }

        }
      

    
        private void resetCollider(object sender, EventArgs e)
        {
            p1BallHasCollided = false;
            
            reset.Stop();
            c1.UpdateLayout();
            lvMessages.Items.Add("Reset");
            
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
                    
                    currentKey = "space";
                   
                    hasFired = true;

                    DoubleAnimation da = new DoubleAnimation();
                    da.From = 1;
                    da.To = 0;
                    da.Duration = new Duration(TimeSpan.FromSeconds(1));
                    smoke.BeginAnimation(OpacityProperty, da);
<<<<<<< HEAD
                    SoundPlayer shootSOund = new SoundPlayer(@"D:\Code\TankGame\tbUI\tbUI\explosion01.wav");
=======
                    SoundPlayer shootSOund = new SoundPlayer(@"C:\Users\ipd\Repos\TankBusters\tbUI\tbUI\explosion01.wav");
>>>>>>> f92d51b8ae4fef150fb4c876428e74e155685a87
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
            if (e.Key == Key.Space)
                currentKey = "";






        }

 

     

     


















        ////////////////////////////////////////////////SQL STUFF













    }
}




