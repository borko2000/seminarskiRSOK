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
    /// <summary>
    /// Interaction logic for Termin.xaml
    /// </summary>
    public partial class Termin : Window
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
        public Termin()
        {
            InitializeComponent();
            binDataGrid();
        }
        

        private void binDataGrid()
        {
            // za donju tabelu
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM [termini]";
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("termini");
            dataAdapter.Fill(dataTable);
            DataGrid.ItemsSource = dataTable.DefaultView;
            // za gornju
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT id, br_sasije FROM vozila";
            cmd.Connection = conn;
            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable1 = new DataTable("vozila");
            dAdapter.Fill(dataTable1);
            DataGridMala.ItemsSource = dataTable1.DefaultView;

            
        }

        private void ponistiUnosTxt()
        {
        /*    txtIme.Text = "";
            txtPrezime.Text = "";
            txtTablice.Text = "";
        */
        }
        private void btnDodaj_Click(object sender, RoutedEventArgs e) 
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();

            command.CommandText = " INSERT INTO tehnicki_pregledi VALUES(@idvoz, 0, 0, 0, 0, 0, 0, 0, 0); ";
      /*    " INSERT INTO [termini] VALUES((SELECT tehnicki_pregledi.id FROM tehnicki_pregledi LEFT JOIN termini ON tehnicki.id_vozila = termini.id_vozila WHERE tehnicki_pregledi.id_vozila = @idvoz" +
   "), @idvoz, @dt);";
        */  command.Parameters.AddWithValue("@idvoz", txtIDVozila.Text);
            command.Parameters.AddWithValue("@dt", dtPicker.SelectedDate);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera > 0)
            {
                binDataGrid();
                
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO[termini] VALUES((SELECT MAX(tehnicki_pregledi.id) FROM tehnicki_pregledi), @idvoz, @dt);";

           cmd.Parameters.AddWithValue("@idvoz", txtIDVozila.Text);
            cmd.Parameters.AddWithValue("@dt", dtPicker.SelectedDate);
            cmd.Connection = conn;
            provera = cmd.ExecuteNonQuery();
            if (provera > 0)
            {
                binDataGrid();
                MessageBox.Show("Podaci su uspešno upisani");
            }

            ponistiUnosTxt();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                 
            }
        }
        private void DataGridMala_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtIDVozila.Text = dr["id"].ToString();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM [termini] WHERE id = @idtermina;" +
                " DELETE FROM tehnicki_pregledi WHERE id = @idteh;";
            command.Parameters.AddWithValue("@idtermina", txtIDTermina.Text);
            command.Parameters.AddWithValue("@idteh", txtIDTeh.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera > 0)
            {
                MessageBox.Show("Podaci su uspešno obrisani");
                binDataGrid();
            }
            ponistiUnosTxt();

        }
        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE [termini] SET id_vozila = @idvoz, datum = @dt WHERE id = @IDter";
            command.Parameters.AddWithValue("@IDter", txtIDTermina.Text);
            command.Parameters.AddWithValue("@idvoz", txtIDVozila.Text);
            command.Parameters.AddWithValue("@dt", dtPicker.SelectedDate);
            
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
}

