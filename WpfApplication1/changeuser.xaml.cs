using System;
using System.Collections.Generic;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for changeuser.xaml
    /// </summary>
    public partial class changeuser : Window
    {
        public static String connectionString = @"data source=(local);initial catalog=DB_Wbayghani; integrated security=true";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd;
        DB_WbayghaniEntities db = new DB_WbayghaniEntities();
        SqlDataReader reader;

        public changeuser()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                    cmd = new SqlCommand("SELECT * from table_login where idusername=N'" + comboBox.SelectedItem.ToString() + "'", con);
                    con.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        textBox.Text = (reader["idpassword"].ToString());
                    }

                    cmd.Dispose();
                    con.Close();
                
            }
            catch (Exception ex)
            {
                
            }
        }

        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            cmd = new SqlCommand("select idusername from table_login", con);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox.Items.Add(reader["idusername"]);
            }

            cmd.Dispose();
            con.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            string quary = "update table_login set idpassword=N'" + textBox.Text.ToString() + "' where idusername= N'" + comboBox.SelectedItem.ToString() + "'";
            cmd = new SqlCommand(quary, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            MessageBox.Show("رمز کاربر با موفقیت تغییر کرد");
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            if (comboBox.SelectedItem.ToString() == "admin")
            {
                MessageBox.Show(" ادمین را نمی توان پاک کرد");
            }
            else
            {
                string quary = "delete from table_login where idusername= N'" + comboBox.SelectedItem.ToString() + "'";
                cmd = new SqlCommand(quary, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                MessageBox.Show("کابر با موفقیت حذف شد");
                comboBox.Items.Remove(comboBox.SelectedItem);
            }
            
        }
    }
}
