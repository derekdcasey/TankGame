using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tbUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // DataB db;
        Database db;

        public MainWindow()
        {
            InitializeComponent();
            db = new Database();
            db.OpenConnection();
            ReloadListView();
           
        }

        GameLogic user = new GameLogic();
        //dispatch timer tick method
        public void DispatchTimer_Tick()
        {

            
        }

        void ReloadListView()
        {
            List<string> pList = db.GetAllMessages();
            lvMessages.Items.Clear();

            foreach (string p in pList)
            {
                lvMessages.Items.Add(p);
            }
        }


        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string msg = txtChat.Text;
            db.AddMessage("Derek", msg);
            ReloadListView();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            db.DeleteMsgs("Derek");
        }
    }
}
