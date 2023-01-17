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
using System.Windows.Shapes;

namespace WpfApp
{
    
    public partial class Admin : Window
    {
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

        
        public Admin()
        {
            InitializeComponent();
            string var_ime = "", var_prezime = "";
            btnRadnici.Visibility = Visibility.Hidden;
            if (admin_ulogovan_class.admin_login == true) btnRadnici.Visibility = Visibility.Visible;
   


            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ime, prezime FROM korisnici WHERE id = '" + admin_ulogovan_class.id_ulogovanog + "'";
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            var_ime = reader.GetString(0);
            var_prezime = reader.GetString(1);
            txtDobrodosli.Text = "Dobrodošli " + var_ime + " " + var_prezime + "!";
            connection.Close();
            reader.Close();

            int zanimanje = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT pozicija FROM korisnici WHERE id = '" + admin_ulogovan_class.id_ulogovanog + "'";
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            zanimanje = rdr.GetInt32(0);
            if (zanimanje != 2) btnTehnicki.Visibility = Visibility.Hidden;
            else if (zanimanje == 2) btnReg.Visibility = Visibility.Hidden;
            conn.Close();
        }

        private void btnRadnici_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Radnik obj = new Radnik();
            obj.Show();
        }

        private void btnTehnicki_Click(object sender, RoutedEventArgs e)
        {
            
            this.Visibility = Visibility.Hidden;
            TehnickiPregled obj = new TehnickiPregled();
            obj.Show();
        
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            RegistracijaVozila obj = new RegistracijaVozila();
            obj.Show();
       }

        private void btnVozila_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Vozila v = new Vozila();
            v.Show();
             
        }

        private void btnTermin_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Termin v = new Termin();
            v.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            MainWindow v = new MainWindow();
            v.Show();
        }
    }
}

