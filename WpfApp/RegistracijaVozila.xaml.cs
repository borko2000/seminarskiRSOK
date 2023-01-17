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
    /// <summary>
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class RegistracijaVozila : Window
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
        private void btnDodaj_Click(object sender, RoutedEventArgs e) 
        {
            if (txtIDTeh.Text == "1")
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = " INSERT INTO registracije VALUES(@idvoz, @datum, @tab, @saob)";
                command.Parameters.AddWithValue("@idvoz", txtIDVozila.Text);
                command.Parameters.AddWithValue("@datum", dtPicker.SelectedDate);
                if (cbxTablice.IsChecked == true) command.Parameters.AddWithValue("@tab", "1"); else command.Parameters.AddWithValue("@tab", "0");
                if (cbxSaobracajna.IsChecked == true) command.Parameters.AddWithValue("@saob", "1"); else command.Parameters.AddWithValue("@saob", "0");
                command.Connection = connection;
                int provera = command.ExecuteNonQuery();
                if (provera > 0)
                {
                    MessageBox.Show("Podaci su uspešno upisani");
                    binDataGrid();
                }
            }
            else MessageBox.Show("Vozilo nije proslo tehnicki");
            
        }
        private void btnObrisi_Click(object sender, RoutedEventArgs e) 
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM [registracije] WHERE id = @idreg";
            command.Parameters.AddWithValue("@idreg", txtIDReg.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci su uspešno obrisani");
                binDataGrid();
            }
        }
        private void btnIzmeni_Click(object sender, RoutedEventArgs e) 
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE [registracije] SET id_vozila = @idvoz, datum = @datum, nove_tablice = @tab, nova_saobracajna = @saob WHERE id = @IDReg";
            command.Parameters.AddWithValue("@idvoz", txtIDVozila.Text);
            command.Parameters.AddWithValue("@datum", dtPicker.SelectedDate);
            command.Parameters.AddWithValue("@IDReg", txtIDReg.Text);
            if (cbxTablice.IsChecked == true) command.Parameters.AddWithValue("@tab", "1"); else command.Parameters.AddWithValue("@tab", "0");
            if (cbxSaobracajna.IsChecked == true) command.Parameters.AddWithValue("@saob", "1"); else command.Parameters.AddWithValue("@saob", "0");
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci su uspešno promenjeni");
                binDataGrid();
            }
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtIDReg.Text = dr["id"].ToString();
                txtIDVozila.Text = dr["id_vozila"].ToString();
                txtDatum.Text = dr["datum"].ToString();
                dtPicker.SelectedDate = Convert.ToDateTime(dr["datum"].ToString());
                if (dr["nove_tablice"].ToString() == "1") cbxTablice.IsChecked = true; else cbxTablice.IsChecked = false;
                if (dr["nova_saobracajna"].ToString() == "1") cbxSaobracajna.IsChecked = true; else cbxSaobracajna.IsChecked = false;
            }
        }
        public RegistracijaVozila()
        {
            InitializeComponent();
            binDataGrid();
        }

        private void binDataGrid()
        {
            // gornja tabela
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT vozila.id, vozila.tablice, vozila.model, vozila.marka, vozila.ime_vlasnika, vozila.prezime_vlasnika FROM vozila";
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("vozila");
            dataAdapter.Fill(dataTable);

            DataGrid_Vozila.ItemsSource = dataTable.DefaultView;

            // donja tabela
            
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM registracije";
            cmd.Connection = conn;
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(cmd);
            DataTable dataTable1 = new DataTable("reg");
            dataAdapter1.Fill(dataTable1);

            DataGrid.ItemsSource = dataTable1.DefaultView;
       }

      

        private void DataGrid_Vozila_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtIDVozila.Text = dr["id"].ToString();
            }
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT prosao_tehnicki FROM tehnicki_pregledi WHERE id_vozila = @idd;"; 

            command.Parameters.AddWithValue("@idd", txtIDVozila.Text);
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int var_proslo = reader.GetInt32(0);
            if (var_proslo == 0) MessageBox.Show("Vozilo nije proslo tehnicki!");
            else txtIDTeh.Text = var_proslo.ToString();
            binDataGrid();
        }
    }
}