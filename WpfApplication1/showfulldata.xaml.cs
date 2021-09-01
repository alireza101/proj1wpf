using System;
using System.Collections.Generic;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for showfulldata.xaml
    /// </summary>
    public partial class showfulldata : Window
    {
        SqlConnection con = new SqlConnection(Window3.connectionString);
        SqlCommand cmd;
        DB_WbayghaniEntities db = new DB_WbayghaniEntities();
        public showfulldata()
        {
            InitializeComponent();
        }
        
        private void loaddata()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT N'تاریخ'=tb_date,N'حوضه'=tb_Basin,N'بلوک'=tb_Block,N'ملک'=tb_Property,N'اپارتمان'=tb_Building,N'نام مالک'=name_build,N'گیرنده'=Receiver,N'شماره پرونده'=file_num FROM code ORDER BY tb_date DESC", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                database.ItemsSource = dt.DefaultView;
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void exitfulldata_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGrid_Loadedata(object sender, RoutedEventArgs e)
        {
            loaddata();
        }
    }
}
