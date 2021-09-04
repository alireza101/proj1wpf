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
    /// Interaction logic for adduser.xaml
    /// </summary>
    public partial class adduser : Window
    {
        public static String connectionString = @"data source=(local);initial catalog=DB_Wbayghani; integrated security=true";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd;
        DB_WbayghaniEntities db = new DB_WbayghaniEntities();
        SqlDataReader reader;

        public adduser()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            bool f = true;
            f = checkdata(f);
            if (f != false)
            {
                insert_t_login();
            }
        }

        private bool checkdata(bool f)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Select 'count'=count(*) from table_login where idusername=@U", con);
                cmd.Parameters.AddWithValue("@U", textBox1.Text.ToString());
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["count"].ToString() == "1")
                    {
                        MessageBox.Show("لطفا نام کاربری دیگری را انخاب کنید");
                        f = false;
                    }
                }

                reader.Close();
                reader.Dispose();
                cmd.Dispose();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return f;
        }

        private void insert_t_login()
            {
            if (textBox1.Text != null)
            {
                if (textBox2.Text != null)
                {
                    cmd = new SqlCommand("INSERT INTO table_login(idusername,idpassword)VALUES('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("با موفقیت اضافه شد");
                    cmd.Dispose();
                    con.Close();
                }
            }
        }
    }
}

    

