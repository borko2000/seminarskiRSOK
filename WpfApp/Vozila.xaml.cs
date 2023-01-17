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

//fajl kreiran 1.12.2022. godine

namespace WpfApp
{
    public partial class Vozila : Window
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
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (regLabel.Text == "" || modelLabel.Text == "" || markaLabel.Text == "" || sasijaLabel.Text == "" || imeVlasnikaLabel.Text == "" || prezimeVlasnikaLabel.Text == "" ||
                snagaLabel.Text == "" || kubikazaLabel.Text == "" || godisteLabel.Text == "" || motorLabel.Text == "" || tezinaLabel.Text == "" || bojaLabel.Text == "") 
                MessageBox.Show("Sva polja moraju biti popunjena!");
            else
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO [vozila] VALUES(@tablice, @model, @marka, @br_sasije, @ime_vlasnika, @prezime_vlasnika, @snaga_vozila, @kubikaza_vozila, @godina_proizvodnje, @br_motora, @tezina_vozila,@boja_vozila)";
                command.Parameters.AddWithValue("@tablice", regLabel.Text);
                command.Parameters.AddWithValue("@model", modelLabel.Text);
                command.Parameters.AddWithValue("@marka", markaLabel.Text);
                command.Parameters.AddWithValue("@br_sasije", sasijaLabel.Text);
                command.Parameters.AddWithValue("@ime_vlasnika", imeVlasnikaLabel.Text);
                command.Parameters.AddWithValue("@prezime_vlasnika", prezimeVlasnikaLabel.Text);
                command.Parameters.AddWithValue("@snaga_vozila", snagaLabel.Text);
                command.Parameters.AddWithValue("@kubikaza_vozila", kubikazaLabel.Text);
                command.Parameters.AddWithValue("@godina_proizvodnje", godisteLabel.Text);
                command.Parameters.AddWithValue("@br_motora", motorLabel.Text);
                command.Parameters.AddWithValue("@tezina_vozila", tezinaLabel.Text);
                command.Parameters.AddWithValue("@boja_vozila", bojaLabel.Text);
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

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM [vozila] WHERE id = @IDVozila";
            command.Parameters.AddWithValue("@IDVozila", txtIDVozila.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci su uspešno obrisani");
                binDataGrid();
            }
            ponistiUnosTxt();
        }

   /*     private void btnIzmeni_Click(object sender, RoutedEventArgs e)
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
*/
        public Vozila()
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
            command.CommandText = "SELECT * FROM [vozila]";
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("vozila");
            dataAdapter.Fill(dataTable);
            DataGrid.ItemsSource = dataTable.DefaultView;
        }
        private void ponistiUnosTxt()
        {
            regLabel.Text = "";
            modelLabel.Text = "";
            markaLabel.Text = "";
            sasijaLabel.Text = "";
            imeVlasnikaLabel.Text = "";
            prezimeVlasnikaLabel.Text = "";
            motorLabel.Text = "";
            kubikazaLabel.Text = "";
            snagaLabel.Text = "";
            tezinaLabel.Text = "";
            godisteLabel.Text = "";
            bojaLabel.Text = "";
            
        }
        
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO [vozila] VALUES(@tablice, @model, @marka, @br_sasije, @ime_vlasnika, @prezime_vlasnika, @snaga_vozila, @kubikaza, @godiste, @br_motora, @tezina, @boja, @tehnicki, @registracija)";
            command.Parameters.AddWithValue("@tablice", regLabel.Text);
            command.Parameters.AddWithValue("@model", modelLabel.Text);
            command.Parameters.AddWithValue("@marka", markaLabel.Text);
            command.Parameters.AddWithValue("@br_sasije", sasijaLabel.Text);
            command.Parameters.AddWithValue("@ime_vlasnika", imeVlasnikaLabel.Text);
            command.Parameters.AddWithValue("@prezime_vlasnika", prezimeVlasnikaLabel.Text);
            command.Parameters.AddWithValue("@br_motora", motorLabel.Text);
            command.Parameters.AddWithValue("@kubikaza", kubikazaLabel.Text);
            command.Parameters.AddWithValue("@snaga_vozila", snagaLabel.Text);
            command.Parameters.AddWithValue("@tezina", tezinaLabel.Text);
            command.Parameters.AddWithValue("@godiste", godisteLabel.Text);
            command.Parameters.AddWithValue("@boja", bojaLabel.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci su uspešno upisani");
                binDataGrid();
            }
            ponistiUnosTxt();
        }
        
    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DataGrid dg = sender as DataGrid;
        DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtIDVozila.Text = dr["id"].ToString();
                regLabel.Text = dr["tablice"].ToString();
                modelLabel.Text = dr["model"].ToString();
                markaLabel.Text = dr["marka"].ToString();
                sasijaLabel.Text = dr["br_sasije"].ToString();
                imeVlasnikaLabel.Text = dr["ime_vlasnika"].ToString();
                prezimeVlasnikaLabel.Text = dr["prezime_vlasnika"].ToString();
                motorLabel.Text = dr["br_motora"].ToString();
                kubikazaLabel.Text = dr["kubikaza_vozila"].ToString();
                snagaLabel.Text = dr["snaga_vozila"].ToString();
                godisteLabel.Text = dr["godina_proizvodnje"].ToString();
                tezinaLabel.Text = dr["tezina_vozila"].ToString();
                bojaLabel.Text = dr["boja_vozila"].ToString();
            }
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (regLabel.Text == "" || modelLabel.Text == "" || markaLabel.Text == "" || sasijaLabel.Text == "" || imeVlasnikaLabel.Text == "" || prezimeVlasnikaLabel.Text == "" ||
                snagaLabel.Text == "" || kubikazaLabel.Text == "" || godisteLabel.Text == "" || motorLabel.Text == "" || tezinaLabel.Text == "" || bojaLabel.Text == "")
                MessageBox.Show("Sva polja moraju biti popunjena!");
            else
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE [vozila] SET tablice = @t, model = @md, marka = @mr, br_sasije = @brs, ime_vlasnika = @i, prezime_vlasnika = @pr, snaga_vozila = @sn, kubikaza_vozila = @kb, godina_proizvodnje = @gp, br_motora = @br, tezina_vozila = @tez, boja_vozila = @boja WHERE id = @IDVozila";
                command.Parameters.AddWithValue("@IDVozila", txtIDVozila.Text);
                command.Parameters.AddWithValue("@t", regLabel.Text);
                command.Parameters.AddWithValue("@md", modelLabel.Text);
                command.Parameters.AddWithValue("@mr", markaLabel.Text);
                command.Parameters.AddWithValue("@brs", sasijaLabel.Text);
                command.Parameters.AddWithValue("@i", imeVlasnikaLabel.Text);
                command.Parameters.AddWithValue("@pr", prezimeVlasnikaLabel.Text);
                command.Parameters.AddWithValue("@sn", snagaLabel.Text);
                command.Parameters.AddWithValue("@kb", kubikazaLabel.Text);
                command.Parameters.AddWithValue("@gp", godisteLabel.Text);
                command.Parameters.AddWithValue("@br", motorLabel.Text);
                command.Parameters.AddWithValue("@tez", tezinaLabel.Text);
                command.Parameters.AddWithValue("@boja", bojaLabel.Text);

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

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            Admin objMainWindow = new Admin();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }

        private void TehRadioBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ovo je read only! Ako nije prosao ne mozes dodati!");
        }
    }
}
