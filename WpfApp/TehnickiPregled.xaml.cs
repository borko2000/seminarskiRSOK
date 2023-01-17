using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Tehnicki.xaml
    /// </summary>
    public partial class TehnickiPregled : Window
    {
        public const int VREME_SPAVANJA = 500;
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
        {          this.Visibility = Visibility.Hidden;
            Admin obj = new Admin();
            obj.Show();
        }
        public TehnickiPregled()
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
                command.CommandText = "SELECT tehnicki_pregledi.id, vozila.tablice, vozila.model, vozila.marka, vozila.ime_vlasnika, vozila.prezime_vlasnika FROM tehnicki_pregledi, vozila WHERE tehnicki_pregledi.id_vozila = vozila.id";
                command.Connection = connection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable("tehnicki_pregledi");
                dataAdapter.Fill(dataTable);

                DataGrid.ItemsSource = dataTable.DefaultView;
            }

            private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                    txtIDTeh.Text = dr["id"].ToString();
            //        int [] uradjeno = 0;
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT provera_elektronike, provera_kocnica, provera_gasova, provera_snage, provera_limarije, provera_mehanike, provera_legalnosti FROM tehnicki_pregledi WHERE id = @idd;";
                    cmd.Parameters.AddWithValue("@idd", txtIDTeh.Text);
                    cmd.Connection = conn;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
            /*        uradjeno[0] = rdr.GetInt32(0);
                    uradjeno[1] = rdr.GetInt32(1);
                    uradjeno[2] = rdr.GetInt32(2);
                    uradjeno[3] = rdr.GetInt32(3);
                    uradjeno[4] = rdr.GetInt32(4);
                    uradjeno[5] = rdr.GetInt32(5);
                    uradjeno[6] = rdr.GetInt32(6);
               */   if(rdr.GetInt32(0) == 1) btnTeh1.Background = new SolidColorBrush(Colors.Green); else btnTeh1.Background = new SolidColorBrush(Colors.Red);
                    if (rdr.GetInt32(1) == 1) btnTeh2.Background = new SolidColorBrush(Colors.Green); else btnTeh2.Background = new SolidColorBrush(Colors.Red);
                if (rdr.GetInt32(2) == 1) btnTeh3.Background = new SolidColorBrush(Colors.Green); else btnTeh3.Background = new SolidColorBrush(Colors.Red);
                if (rdr.GetInt32(3) == 1) btnTeh4.Background = new SolidColorBrush(Colors.Green); else btnTeh4.Background = new SolidColorBrush(Colors.Red);
                if (rdr.GetInt32(4) == 1) btnTeh5.Background = new SolidColorBrush(Colors.Green); else btnTeh5.Background = new SolidColorBrush(Colors.Red);
                if (rdr.GetInt32(5) == 1) btnTeh6.Background = new SolidColorBrush(Colors.Green); else btnTeh6.Background = new SolidColorBrush(Colors.Red);
                if (rdr.GetInt32(6) == 1) btnTeh7.Background = new SolidColorBrush(Colors.Green); else btnTeh7.Background = new SolidColorBrush(Colors.Red);

                int brojac = 0;
                for(int i = 0; i < 7; i++) if (rdr.GetInt32(i) == 1) brojac++;
                if(brojac == 7)
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "UPDATE [tehnicki_pregledi] SET prosao_tehnicki = 1 WHERE id = @idd";
                    command.Parameters.AddWithValue("@idd", txtIDTeh.Text);
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Vozilo je uspesno proslo tehnicki!");
                }
             }
        }


        private void btnTeh1_Click(object sender, RoutedEventArgs e) // elektronika
        {
            int uradjeno = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT provera_elektronike FROM tehnicki_pregledi WHERE id = @idd;";
            cmd.Parameters.AddWithValue("@idd", txtIDTeh.Text);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            uradjeno = rdr.GetInt32(0);
            if (uradjeno == 0)
            {
             //   Cursor.Hide();
                uzvik.Visibility = Visibility.Visible;
                MessageBox.Show("Kontaktiram eksterni uredjaj!");
                //   Cursor.Show();
                Thread.Sleep(VREME_SPAVANJA);
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE [tehnicki_pregledi] SET provera_elektronike = 1 WHERE id = @idd";
                command.Parameters.AddWithValue("@idd", txtIDTeh.Text);
                command.Connection = connection;
                command.ExecuteNonQuery();
                
                MessageBox.Show("USPESNO!");
                uzvik.Visibility = Visibility.Hidden;
                btnTeh1.Background = new SolidColorBrush(Colors.Green);
                
                connection.Close();
                
            }
            else MessageBox.Show("Ovaj test je vec uradjen!");
            conn.Close();
        }

        private void btnTeh2_Click(object sender, RoutedEventArgs e) // kocnice 
        {
            int uradjeno = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT provera_kocnica FROM tehnicki_pregledi WHERE id = @idd;";
            cmd.Parameters.AddWithValue("@idd", txtIDTeh.Text);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            uradjeno = rdr.GetInt32(0);
            if (uradjeno == 0)
            {
                //   Cursor.Hide();
                uzvik.Visibility = Visibility.Visible;
                MessageBox.Show("Kontaktiram eksterni uredjaj!");
                //   Cursor.Show();
                Thread.Sleep(VREME_SPAVANJA);
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE [tehnicki_pregledi] SET provera_kocnica = 1 WHERE id = @idd";
                command.Parameters.AddWithValue("@idd", txtIDTeh.Text);
                command.Connection = connection;
                command.ExecuteNonQuery();

                MessageBox.Show("USPESNO!");
                uzvik.Visibility = Visibility.Hidden;
                btnTeh2.Background = new SolidColorBrush(Colors.Green);

                connection.Close();

            }
            else MessageBox.Show("Ovaj test je vec uradjen!");
            conn.Close();
        }

        private void btnTeh3_Click(object sender, RoutedEventArgs e) // gasovi
        {
            int uradjeno = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT provera_gasova FROM tehnicki_pregledi WHERE id = @idd;";
            cmd.Parameters.AddWithValue("@idd", txtIDTeh.Text);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            uradjeno = rdr.GetInt32(0);
            if (uradjeno == 0)
            {
                //   Cursor.Hide();
                uzvik.Visibility = Visibility.Visible;
                MessageBox.Show("Kontaktiram eksterni uredjaj!");
                //   Cursor.Show();
                Thread.Sleep(VREME_SPAVANJA);
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE [tehnicki_pregledi] SET provera_gasova = 1 WHERE id = @idd";
                command.Parameters.AddWithValue("@idd", txtIDTeh.Text);
                command.Connection = connection;
                command.ExecuteNonQuery();

                MessageBox.Show("USPESNO!");
                uzvik.Visibility = Visibility.Hidden;
                btnTeh3.Background = new SolidColorBrush(Colors.Green);

                connection.Close();

            }
            else MessageBox.Show("Ovaj test je vec uradjen!");
            conn.Close();
        }

        private void btnTeh4_Click(object sender, RoutedEventArgs e)  // limarija
        {
            int uradjeno = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT provera_limarije FROM tehnicki_pregledi WHERE id = @idd;";
            cmd.Parameters.AddWithValue("@idd", txtIDTeh.Text);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            uradjeno = rdr.GetInt32(0);
            if (uradjeno == 0)
            {
                //   Cursor.Hide();
                uzvik.Visibility = Visibility.Visible;
                MessageBox.Show("Kontaktiram eksterni uredjaj!");
                //   Cursor.Show();
                Thread.Sleep(VREME_SPAVANJA);
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE [tehnicki_pregledi] SET provera_limarije = 1 WHERE id = @idd";
                command.Parameters.AddWithValue("@idd", txtIDTeh.Text);
                command.Connection = connection;
                command.ExecuteNonQuery();

                MessageBox.Show("USPESNO!");
                uzvik.Visibility = Visibility.Hidden;
                btnTeh4.Background = new SolidColorBrush(Colors.Green);

                connection.Close();

            }
            else MessageBox.Show("Ovaj test je vec uradjen!");
            conn.Close();
        }

        private void btnTeh5_Click(object sender, RoutedEventArgs e) // snaga
        {
            int uradjeno = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT provera_snage FROM tehnicki_pregledi WHERE id = @idd;";
            cmd.Parameters.AddWithValue("@idd", txtIDTeh.Text);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            uradjeno = rdr.GetInt32(0);
            if (uradjeno == 0)
            {
                //   Cursor.Hide();
                uzvik.Visibility = Visibility.Visible;
                MessageBox.Show("Kontaktiram eksterni uredjaj!");
                //   Cursor.Show();
                Thread.Sleep(VREME_SPAVANJA);
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE [tehnicki_pregledi] SET provera_snage = 1 WHERE id = @idd";
                command.Parameters.AddWithValue("@idd", txtIDTeh.Text);
                command.Connection = connection;
                command.ExecuteNonQuery();

                MessageBox.Show("USPESNO!");
                uzvik.Visibility = Visibility.Hidden;
                btnTeh5.Background = new SolidColorBrush(Colors.Green);

                connection.Close();

            }
            else MessageBox.Show("Ovaj test je vec uradjen!");
            conn.Close();
        }

        private void btnTeh6_Click(object sender, RoutedEventArgs e) // legalnost
        {
            int uradjeno = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT provera_legalnosti FROM tehnicki_pregledi WHERE id = @idd;";
            cmd.Parameters.AddWithValue("@idd", txtIDTeh.Text);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            uradjeno = rdr.GetInt32(0);
            if (uradjeno == 0)
            {
                //   Cursor.Hide();
                uzvik.Visibility = Visibility.Visible;
                MessageBox.Show("Kontaktiram eksterni uredjaj!");
                //   Cursor.Show();
                Thread.Sleep(VREME_SPAVANJA);
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE [tehnicki_pregledi] SET provera_legalnosti = 1 WHERE id = @idd";
                command.Parameters.AddWithValue("@idd", txtIDTeh.Text);
                command.Connection = connection;
                command.ExecuteNonQuery();

                MessageBox.Show("USPESNO!");
                uzvik.Visibility = Visibility.Hidden;
                btnTeh6.Background = new SolidColorBrush(Colors.Green);

                connection.Close();

            }
            else MessageBox.Show("Ovaj test je vec uradjen!");
            conn.Close();
        }

        private void btnTeh7_Click(object sender, RoutedEventArgs e) // mehanika
        {
            int uradjeno = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT provera_mehanike FROM tehnicki_pregledi WHERE id = @idd;";
            cmd.Parameters.AddWithValue("@idd", txtIDTeh.Text);
            cmd.Connection = conn;
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            uradjeno = rdr.GetInt32(0);
            if (uradjeno == 0)
            {
                //   Cursor.Hide();
                uzvik.Visibility = Visibility.Visible;
                MessageBox.Show("Kontaktiram eksterni uredjaj!");
                //   Cursor.Show();
                Thread.Sleep(VREME_SPAVANJA);
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connKonekt"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UPDATE [tehnicki_pregledi] SET provera_mehanike = 1 WHERE id = @idd";
                command.Parameters.AddWithValue("@idd", txtIDTeh.Text);
                command.Connection = connection;
                command.ExecuteNonQuery();

                MessageBox.Show("USPESNO!");
                uzvik.Visibility = Visibility.Hidden;
                btnTeh7.Background = new SolidColorBrush(Colors.Green);

                connection.Close();

            }
            else MessageBox.Show("Ovaj test je vec uradjen!");
            conn.Close();
        }
    }
 }