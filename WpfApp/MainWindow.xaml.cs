using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp
{
    /*
        fajl kreiran 28.11.2022.
    */
    /// 
    public class admin_ulogovan_class
    {
        private static bool admin_ulogovan_data;
        private static int  id_ulogovanog_data;
        public static bool admin_login
        {   
            get
            {
                return admin_ulogovan_data;
            }
            set
            {
                admin_ulogovan_data = value;
            }
        }
        public static int id_ulogovanog
        {
            get
            {
                return id_ulogovanog_data;
            }
            set
            {
                id_ulogovanog_data = value;
            }
        }

    }
    public partial class MainWindow : Window
    {
        

        
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            string userid = txtUser.Text;
            string password = txtPass.Password;
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT username FROM korisnici WHERE username = '" + txtUser.Text + "'";
            command.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                SqlCommand command1 = new SqlCommand();
                command1.CommandText = "SELECT username, password FROM korisnici WHERE username = '" + txtUser.Text + "' AND password = '" + txtPass.Password + "'";
                command1.Connection = connection;
                SqlDataAdapter da1 = new SqlDataAdapter(command1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    int tmp_id = 0;
                    SqlCommand command2 = new SqlCommand();
                    command2.CommandText = "SELECT username, password, administrator FROM korisnici WHERE username = '" + txtUser.Text + "' AND password = '" + txtPass.Password + "'";
                    command2.Connection = connection;
                    SqlDataReader reader = command2.ExecuteReader();
                    reader.Read();
                    int tmppp_id = reader.GetInt32(2);
                    if (tmppp_id == 1) admin_ulogovan_class.admin_login = true;
                    reader.Close();
    //                MessageBox.Show(Convert.ToString(admin_ulogovan_class.admin_login));

                    command2 = new SqlCommand();
                    command2.CommandText = "SELECT id FROM korisnici WHERE username = '" + txtUser.Text + "' AND password = '" + txtPass.Password + "'";
                    command2.Connection = connection;
                    SqlDataReader tmpp_id = command2.ExecuteReader();
                    if (tmpp_id.HasRows)
                    {
                        tmpp_id.Read();
                        tmp_id = tmpp_id.GetInt32(0);
                        tmpp_id.Close();
                    }
                    
    //                MessageBox.Show(Convert.ToString(tmp_id));
             /*       if (dt2.Rows.Count > 0) 
                    {   
                        
                        admin_ulogovan_class.admin_login = true;
                    }

                */  MessageBox.Show("Uspešno ulogovan!");
                    admin_ulogovan_class.id_ulogovanog = tmp_id;
                    this.Visibility = Visibility.Hidden;
                    Admin obj = new Admin();
                    obj.Show();

                }
                else
                {
                    txtUser.Text = "";
                    txtPass.Password = "";
                    MessageBox.Show("Pogrešna lozinka!");
                }


            }
            else
            {
                txtUser.Text = "";
                txtPass.Password = "";
                MessageBox.Show("Pogrešan username!");
            }
            connection.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
    }
}
