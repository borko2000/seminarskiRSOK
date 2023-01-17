using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
    public partial class Radnik : Window
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

         private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Admin obj = new Admin();
            obj.Show();
        }

        private void btnDodajRadnika_Click(object sender, RoutedEventArgs e)
        {
            if (korisnickoLabel.Text == "" || lozinkaLabel.Text == "" || imeLabel.Text == "" || prezimeLabel.Text == "")
                MessageBox.Show("Sva polja moraju biti popunjena!");
            if (salterRadioBtn.IsChecked == false && tehnicarRadioBtn.IsChecked == false) MessageBox.Show("Izaberi poziciju!");
            else
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO [korisnici] VALUES(@username, @password, @ime, @prezime, @admin, @pozicija)";
                command.Parameters.AddWithValue("@username", korisnickoLabel.Text);
                command.Parameters.AddWithValue("@password", lozinkaLabel.Text);
                command.Parameters.AddWithValue("@ime", imeLabel.Text);
                command.Parameters.AddWithValue("@prezime", prezimeLabel.Text);
                if (adminRadioBtn.IsChecked == true) command.Parameters.AddWithValue("@admin", "1");
                else command.Parameters.AddWithValue("@admin", "0");
                if (salterRadioBtn.IsChecked == true) command.Parameters.AddWithValue("@pozicija", "1");
                if (tehnicarRadioBtn.IsChecked == true) command.Parameters.AddWithValue("@pozicija", "2");


                command.Connection = connection;
                int provera = command.ExecuteNonQuery();
                if (provera == 1)
                {
                    MessageBox.Show("Podaci su uspešno upisani");
                    binDataGrid();
                }
                ponistiUnosTxt();
            }
                
            
        }

        private void btnObrisiRadnika_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM [korisnici] WHERE id = @IDRadnika";
            command.Parameters.AddWithValue("@IDRadnika", txtIDRadnika.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci su uspešno obrisani");
                binDataGrid();
            }
            ponistiUnosTxt();
        }

        private void btnIzmeniRadnika_Click(object sender, RoutedEventArgs e)
        {
            if (korisnickoLabel.Text == "" || lozinkaLabel.Text == "" || imeLabel.Text == "" || prezimeLabel.Text == "") MessageBox.Show("Sva polja moraju biti popunjena!");
            else
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE [korisnici] SET ime = @Ime, prezime = @Prezime, username = @Username, password = @Password, administrator = @Admin, pozicija = @Pozicija WHERE id = @IDRadnika";
                command.Parameters.AddWithValue("@IDRadnika", txtIDRadnika.Text);
                command.Parameters.AddWithValue("@Ime", imeLabel.Text);
                command.Parameters.AddWithValue("@Prezime", prezimeLabel.Text);
                command.Parameters.AddWithValue("@Username", korisnickoLabel.Text);
                command.Parameters.AddWithValue("@Password", lozinkaLabel.Text);
                if (adminRadioBtn.IsChecked == true) command.Parameters.AddWithValue("@Admin", "1");
                else command.Parameters.AddWithValue("@Admin", "0");
                if (salterRadioBtn.IsChecked == true) command.Parameters.AddWithValue("@Pozicija", "1");
                if (tehnicarRadioBtn.IsChecked == true) command.Parameters.AddWithValue("@Pozicija", "2");
                command.Connection = connection;
                int provera = command.ExecuteNonQuery();
                if (provera == 1)
                {
                    MessageBox.Show("Podaci su uspešno promenjeni");
                    binDataGrid();
                }
                ponistiUnosTxt();
            }
            
        }
        public Radnik()
        {
            InitializeComponent();
            binDataGrid();
        }

            private void binDataGrid()
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM [korisnici]";
                command.Connection = connection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("korisnici");
                dataAdapter.Fill(dataTable);
                DataGrid.ItemsSource = dataTable.DefaultView;
            }

            private void ponistiUnosTxt()
            {
                imeLabel.Text = " ";
                prezimeLabel.Text = " ";
                korisnickoLabel.Text = " ";
                lozinkaLabel.Text = " ";
            adminRadioBtn.IsChecked = false;
            salterRadioBtn.IsChecked = false;
            tehnicarRadioBtn.IsChecked = false;
            }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                
                txtIDRadnika.Text = dr["id"].ToString();
                imeLabel.Text = dr["ime"].ToString();
                prezimeLabel.Text = dr["prezime"].ToString();
                korisnickoLabel.Text = dr["username"].ToString();
                lozinkaLabel.Text = dr["password"].ToString();
                if (dr["administrator"].ToString() == "1") adminRadioBtn.IsChecked = true; else adminRadioBtn.IsChecked = false;
                if (dr["pozicija"].ToString() == "1") salterRadioBtn.IsChecked = true; else salterRadioBtn.IsChecked = false;
                if (dr["pozicija"].ToString() == "2") tehnicarRadioBtn.IsChecked = true; else tehnicarRadioBtn.IsChecked = false;

            }
        }

        private void salterRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            salterRadioBtn.IsChecked = true;
            tehnicarRadioBtn.IsChecked = false;
        }

        private void tehnicarRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            salterRadioBtn.IsChecked = false;
            tehnicarRadioBtn.IsChecked = true;
        }       
    }
}