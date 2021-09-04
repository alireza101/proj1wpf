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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        static int radio;
        SqlConnection con = new SqlConnection(MainWindow.connectionString);
        DB_WbayghaniEntities db = new DB_WbayghaniEntities();
        ObservableCollection<code> codes = new ObservableCollection<code>();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();

        SqlCommand cmd;
        public Window1()
        {
            InitializeComponent();

            manager.Visibility = Visibility.Hidden;
            //var employees = (from p in db.table_login
            //                 select new {
            //                     p.idpassword,
            //                     p.idusername,
            //                 }).ToList().First();


            //if (employees != null && employees.Count > 0)
            //{
            //txt_IdEmp.Text = employees[0].EmpID.ToString();
            //txt_FNameEmp.Text = employees[0].EmpFName;
            //txt_LNameEmp.Text = employees[0].EmpLName;
            //txt_TitleEmp.Text = employees[0].EmpTitle;
            con.Open();
            String quary = "";
            quary = "select  LOWER(idusername),LOWER(idpassword) from table_login where id =1";
            cmd = new SqlCommand(quary, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt1);
            //string pass=dt1.Columns[2].ToString();
            //string nam = dt1.Columns[1].ToString();
            string nam = dt1.Rows[0].Field<string>(0);
            string pass = dt1.Rows[0].Field<string>(1);
            cmd.Dispose();
            con.Close();
            dt.Clear();
            //string pass = employees.idpassword;
            //    string nam = employees.idusername;
            //}
            if (userinfo.CustomerName == nam)
            {
                if (userinfo.Customerpass == pass)
                {
                    manager.Visibility = Visibility.Visible;
                }
            }
            nameM.IsEnabled = false;
            Basin.IsEnabled = false;
            Property.IsEnabled = false;
            Block.IsEnabled = false;
            Building.IsEnabled = false;
            parvande.IsEnabled = false;
        }




        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //var t = db.code.Select(s=>s).ToList();
            //database.Items.Add(t);
            // t.name_build = "fdfsdfsf";
            // db.code.Add(t);
            // db.SaveChanges();
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void NumberValidationTextBox1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-7]");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void enteruser_Click(object sender, RoutedEventArgs e)
        {
            showfulldata showf = new showfulldata();
            showf.Show();
        }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
            if (radio == 0)
            {
                con.Open();
                String quary = "";
                if (Basin.Text.ToString() == "")
                {

                    quary = "SELECT N'تاریخ'=tb_date,N'حوضه'=tb_Basin,N'بلوک'=tb_Block,N'ملک'=tb_Property,N'اپارتمان'=tb_Building,N'نام مالک'=name_build,N'گیرنده'=Receiver ,N'شماره پرونده'=file_num,N'تاریخ بازگشت'=backtime FROM code WHERE accept=0 ORDER BY tb_date DESC";
                }
                else
                if (Block.Text.ToString() == "")
                {
                    quary = "SELECT N'تاریخ'=tb_date,N'حوضه'=tb_Basin,N'بلوک'=tb_Block,N'ملک'=tb_Property,N'اپارتمان'=tb_Building,N'نام مالک'=name_build,N'گیرنده'=Receiver ,N'شماره پرونده'=file_num,N'تاریخ بازگشت'=backtime FROM code WHERE tb_Basin = @ba and accept=0 ORDER BY tb_date DESC";

                }
                else
                 if (Property.Text.ToString() == "")
                {
                    quary = "SELECT N'تاریخ'=tb_date,N'حوضه'=tb_Basin,N'بلوک'=tb_Block,N'ملک'=tb_Property,N'اپارتمان'=tb_Building,N'نام مالک'=name_build,N'گیرنده'=Receiver ,N'شماره پرونده'=file_num ,N'تاریخ بازگشت'=backtime FROM code WHERE tb_Basin = @ba AND tb_Block = @bl and accept=0 ORDER BY tb_date DESC";

                }
                else
                if (Building.Text.ToString() == "")
                {
                    quary = "SELECT N'تاریخ'=tb_date,N'حوضه'=tb_Basin,N'بلوک'=tb_Block,N'ملک'=tb_Property,N'اپارتمان'=tb_Building,N'نام مالک'=name_build,N'گیرنده'=Receiver ,N'شماره پرونده'=file_num ,N'تاریخ بازگشت'=backtime FROM code WHERE tb_Basin = @ba AND tb_Block = @bl AND tb_Property = @p and accept=0 ORDER BY tb_date DESC";

                }
                else
                {
                    quary = "SELECT N'تاریخ'=tb_date,N'حوضه'=tb_Basin,N'بلوک'=tb_Block,N'ملک'=tb_Property,N'اپارتمان'=tb_Building,N'نام مالک'=name_build,N'گیرنده'=Receiver ,N'شماره پرونده'=file_num ,N'تاریخ بازگشت'=backtime FROM code WHERE tb_Basin = @ba AND tb_Block = @bl AND tb_Property = @p AND tb_Building=@bu and accept=0 ORDER BY tb_date DESC";

                }


                cmd = new SqlCommand(quary, con);
                cmd.Parameters.AddWithValue("@ba", Basin.Text.ToString());
                cmd.Parameters.AddWithValue("@bl", Block.Text.ToString());
                cmd.Parameters.AddWithValue("@p", Property.Text.ToString());
                cmd.Parameters.AddWithValue("@bu", Building.Text.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                database.ItemsSource = dt.DefaultView;
                cmd.Dispose();
                con.Close();
            }
            else if(radio == 1)
            {
                con.Open();
                String quary = "";
                quary = " SELECT N'تاریخ' = tb_date,N'حوضه' = tb_Basin,N'بلوک' = tb_Block,N'ملک' = tb_Property,N'اپارتمان' = tb_Building,N'نام مالک' = name_build,N'گیرنده' = Receiver ,N'شماره پرونده'=file_num,N'تاریخ بازگشت'=backtime FROM code WHERE name_build LIKE '%" + nameM.Text.ToString() + "%' and accept=0 ORDER BY tb_date DESC";
                cmd = new SqlCommand(quary, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                database.ItemsSource = dt.DefaultView;
                cmd.Dispose();
                con.Close();
            }
            else if(radio == 2)
            {
                con.Open();
                String quary = "";
                quary = " SELECT N'تاریخ' = tb_date,N'حوضه' = tb_Basin,N'بلوک' = tb_Block,N'ملک' = tb_Property,N'اپارتمان' = tb_Building,N'نام مالک' = name_build,N'گیرنده' = Receiver ,N'شماره پرونده'=file_num ,N'تاریخ بازگشت'=backtime FROM code WHERE file_num LIKE '%" + parvande.Text.ToString() + "%' and accept=0 ORDER BY tb_date DESC";
                cmd = new SqlCommand(quary, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                database.ItemsSource = dt.DefaultView;
                cmd.Dispose();
                con.Close();
            }
        }


        //ListCollectionView collectionview = new ListCollectionView(codes);
        //collectionview.Filter = (a) =>
        //  {
        //      code cod = a as code;
        //      if (cod.tb_Basin.ToString().Equals( Basin.ToString()))
        //      {
        //          if (cod.tb_Property.ToString().Equals( Property.ToString()))
        //          {
        //              if (cod.tb_Block.ToString().Equals(Block.ToString()))
        //              {
        //                  if (cod.tb_Building.ToString().Equals( Building.ToString()))
        //                      return true;
        //               return true;
        //              }
        //           return true;
        //          }
        //      }return false;
        //  };
        //database.ItemsSource = collectionview;


        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            searchall();
        }

        private void searchall()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT N'تاریخ'=tb_date,N'حوضه'=tb_Basin,N'بلوک'=tb_Block,N'ملک'=tb_Property,N'اپارتمان'=tb_Building,N'نام مالک'=name_build,N'گیرنده'=Receiver ,N'شماره پرونده'=file_num ,N'تاریخ بازگشت'=backtime FROM code where accept=0 ORDER BY tb_date DESC", con);
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


            //try
            //{
            //    var t = from p in db.code
            //            select new
            //            {
            //                p.tb_date,
            //                p.tb_Basin,
            //                p.tb_Block,
            //                p.tb_Property,
            //                p.tb_Building,
            //                p.name_build,
            //                p.Receiver
            //            };
            //    database.ItemsSource = t.ToString().ToList();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}


            //var t = db.code.Select(s => s).ToList();
            //database.ItemsSource = t;




        }

        private void r1_Checked(object sender, RoutedEventArgs e)
        {

            if (r1.IsChecked == true)
            {
                nameM.IsEnabled = false;
                Basin.IsEnabled = true;
                Property.IsEnabled = true;
                Block.IsEnabled = true;
                Building.IsEnabled = true;
                radio = 0;
                parvande.IsEnabled = false;

            }
            else if(r2.IsChecked==true)
            {
                nameM.IsEnabled = true;
                Basin.IsEnabled = false;
                Property.IsEnabled = false;
                Block.IsEnabled = false;
                Building.IsEnabled = false;
                radio = 1;
                parvande.IsEnabled = false;

            }
            else
            {
                nameM.IsEnabled = false;
                Basin.IsEnabled = false;
                Property.IsEnabled = false;
                Block.IsEnabled = false;
                Building.IsEnabled = false;
                radio = 2;
                parvande.IsEnabled = true;
            }


        }

        private void entpa_Click(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            win3.Show();

            
            searchall();
        }


       
        private void database_SelectedCellsChanged(object sender, MouseButtonEventArgs e)
        {
            DataRowView getgrid = (DataRowView)database.SelectedItem;
            //MessageBox.Show(getgrid["ملک"].ToString());
            MessageBoxResult result = MessageBox.Show("ایا پرونده برگشت؟", "Reset Message", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:

                        con.Open();
                        string quary = "UPDATE code SET accept=1 ,backtime=[dbo].[G2J](getdate(),'Saal/Maah/Rooz') WHERE tb_Basin = @ba AND tb_Block = @bl AND tb_Property = @p AND tb_Building=@bu  AND file_num=@falnum ";
                        cmd = new SqlCommand(quary, con);
                        cmd.Parameters.AddWithValue("@ba", getgrid["حوضه"].ToString());
                        cmd.Parameters.AddWithValue("@bl", getgrid["بلوک"].ToString());
                        cmd.Parameters.AddWithValue("@p", getgrid["ملک"].ToString());
                        cmd.Parameters.AddWithValue("@bu", getgrid["اپارتمان"].ToString());
                        cmd.Parameters.AddWithValue("@falnum", getgrid["شماره پرونده"].ToString());    
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        con.Close();
                        searchall();
                    
                    break;
                case MessageBoxResult.No:
                    //  MessageBox.Show("Oh well, too bad!", "My App");
                    break;
            }
            
        }

        private void manager_Click(object sender, RoutedEventArgs e)
        {
            manager win3 = new manager();
            win3.Show();
        }

      
    }
}




//try
//            {
//                //Open Connection...
//                con.Open();
//                //Write Query For Insert Data Into Table using Creating Object Of SqlCommand...
//                SqlCommand com = new SqlCommand("INSERT INTO code VALUES(" +
//        Convert.ToInt32(tb_Basin.Text) + ",'" + Convert.ToInt32(tb_Block.Text) + "'," + Convert.ToInt32(tb_Property.Text) + ")", conn);
//comm.ExecuteNonQuery();
//            }
//            catch (Exception ex)
//            {
//                //If Any Exception Will Occur then It Will Display That Message...
//                MessageBox.Show(ex.Message.ToString());
//            }
//            finally
//            {
//                //Finally Close the Connection...
//                conn.Close();
//                //Display Effect of New Added Row Into DataGridView...
//                BindMyData();
//            }