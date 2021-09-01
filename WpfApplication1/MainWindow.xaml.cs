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
namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
      public  static  String connectionString = @"data source=(local);initial catalog=DB_Wbayghani; integrated security=true";

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            String message = "ورود نامعتبر است";
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("Select 'count'=count(*) from table_login where idusername=@U And idpassword=@P", con);
                cmd.Parameters.AddWithValue("@U", username.Text.ToString());
                cmd.Parameters.AddWithValue("@P", password.Password.ToString());
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["count"].ToString() == "1")
                    {
                        message = "1";
                        userinfo.CustomerName = username.Text.ToString();
                        userinfo.Customerpass = password.Password.ToString();
                    }
                }

                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
            }
            if (message == "1")
            {
                Window1 win1 = new Window1();

                win1.Show();
                this.Close();
            }
            else
            {
                // message = "(" + password.Password.ToString() + ")" + username.Text.ToString();
                MessageBox.Show(message, "Info");
                username.Clear();
                password.Clear();
            }
        }


   
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
