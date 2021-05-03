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
using System.Data.SqlClient;
using System.Configuration;
using Function;
namespace Multi_Login
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        private bool checklogin = false;
        string strConnect = "Data Source=(local);Initial Catalog=PROJECT_DBMS;Integrated Security=True";

        public bool Checklogin { get => checklogin; }

        public MainWindow()
        {
            InitializeComponent();
            con = new SqlConnection(strConnect);
            cmd = con.CreateCommand();
        }

       
        private bool VerifyUser(string username, string password)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT us.userID , us.userPassword FROM dbo._USER AS us" +
                " WHERE us.userID='" + username+ "' AND us.userPassword='" + Encrytion.Encrypt(password)+"'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                checklogin = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // DragMove();
        }



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
            if (VerifyUser(txtUsername.Text, txtPassword.Password))
            {
                MessageBox.Show("Login Successfully", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
          // Application.Current.Shutdown();
        }
    }
}
