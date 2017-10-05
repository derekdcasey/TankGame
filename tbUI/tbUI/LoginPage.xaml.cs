using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tbUI
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        Database db = new Database();

        //  DispatcherTimer setup
        DispatcherTimer dispatcherTimer = new DispatcherTimer();              
        
        public LoginPage()
        {
            db.OpenConnection();
            InitializeComponent();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
           
        }

        //heartbeat with DispatchTimer to update game records every 10 seconds
        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            //  db.ActivePlayerAdded();
            
            Console.WriteLine("Tick");
        }

            private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User player = new User();

            string playername = tbUserLogin.Text;

            if (Regex.IsMatch(playername, "^[a-zA-Z0-9]+$"))
            {
                //  db.ExecuteQueries("SELECT Username FROM Users WHERE Username = @Username");
                if (playername.Length < 3 || playername.Length > 15)
                {
                    MessageBox.Show("Username must be between 3 and 15 characters long.", "Username Entry Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    //  DispatcherTimer setup                    
                        dispatcherTimer.Start();                   
                        player.Username = playername;
                        db.AddUser(player);
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();                                        
                }
            }
            else
            {
                MessageBox.Show("Username must be in letters and number with no spaces","Username Entry Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            //TODO: if username exists, select user
            // if username doesn't exist, insert new user


        }
    }
}
