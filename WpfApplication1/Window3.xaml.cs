using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        //private ScrollViewer _scvComboBox = null;
        SqlConnection con=new SqlConnection(connectionString);
        SqlCommand cmd;
        DB_WbayghaniEntities db = new DB_WbayghaniEntities();
        SqlDataReader reader;

        public static String connectionString = @"data source=(local);initial catalog=DB_Wbayghani; integrated security=true";

        public Window3()
        {
            InitializeComponent();
            loadcombobax();
            CBname.Items.Clear();
            

        }
    //    cmd = new SqlCommand("SELECT namerole,rolee from dbo.namerole AS n INNER JOIN dbo.rrole AS r ON(n.role = r.id)WHERE r.rolee = N'" + CB.Text.ToString().Trim() + "'", con);
    //        con.Open();
    //        reader = cmd.ExecuteReader();
    //        while (reader.Read())
    //        {
    //            CBname.Items.Add(reader["namerole"]);
    //        }

    //cmd.Dispose();
    //        con.Close();
    //        MessageBox.Show(CB.Text.ToString().Trim());
        //public void loadcbname()
        //{
        //    cmd = new SqlCommand("SELECT namerole,rolee from dbo.namerole AS n INNER JOIN dbo.rrole AS r ON(n.role = r.id)WHERE r.rolee = N'"+CB.Text.ToString().Trim()+"'", con);
        //    con.Open();
        //    reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        CBname.Items.Add(reader["namerole"]);
        //    }

        //    cmd.Dispose();
        //    con.Close();
        //    MessageBox.Show(CB.Text.ToString().Trim());
        //}
        public void loadcombobax()
        {   cmd = new SqlCommand("select rolee from rrole", con);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CB.Items.Add(reader["rolee"]);
            }
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //1~((dt)CB.SelectedItem).Role;
            //2~CB.ItemsSource = db.Role.ToList();
            //3~CB.DataContext =dt.;
            //4~DataRow row = dt.NewRow();
            //row[0] = 0;
            //row [1]= "please select";
            //dt.Rows.InsertAt(row, 0);
            //CB.DataContext = dt;
            cmd.Dispose();
            con.Close();
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

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            try
            {
                

                if (Basin.Text.Equals("") || Property.Text.Equals("") || Block.Text.Equals("") || CB.Text.ToString().Equals("") || (CBname.Text.ToString().Equals("") && nameCB.Text.ToString().Equals("")))
                {
                    MessageBox.Show(" فیلد ها رو پر کنید");

                }
                else
                {
                    string quary1= "Select 'count'=count(*) from code where tb_Basin = @ba AND tb_Block = @bl AND tb_Property = @p AND tb_Building=@bu AND accept=0";
                    cmd = new SqlCommand(quary1, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@ba", Basin.Text.ToString());
                    cmd.Parameters.AddWithValue("@bl", Block.Text.ToString());
                    cmd.Parameters.AddWithValue("@p", Property.Text.ToString());
                    cmd.Parameters.AddWithValue("@bu", Building.Text.ToString());
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["count"].ToString() !="0")
                        {
                            MessageBox.Show("کد نوسازی از قبل وجود دارد");
                            count++;
                        }
                    }
                    cmd.Dispose();
                    con.Close();


                    quary1 = "Select 'count'=count(*) from code where file_num=@falnum AND accept=0";
                    cmd = new SqlCommand(quary1, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@falnum", parvandenum.Text.ToString());
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["count"].ToString() != "0")
                        {
                            MessageBox.Show("شماره پرونده از قبل وجود دارد");
                            count++;
                        }
                    }
                    cmd.Dispose();
                    con.Close();

                    if (count == 0)
                    {
                        if (Building.Text.Equals(""))
                        {
                            Building.Text = "0";
                        }
                        if (parvandenum.Text.Equals(null))
                        {
                            parvandenum.Text = "0";
                        }
                        if (checkBox.IsChecked == true)
                        {
                            if (CB.SelectedIndex.Equals(0))
                            {
                                cmd = new SqlCommand("INSERT INTO code(tb_Basin,tb_Block,tb_Property,tb_Building,name_build,Receiver,file_num,accept)VALUES(" + Basin.Text.ToString() + "," + Block.Text.ToString() + "," + Property.Text.ToString() + "," + Building.Text.ToString() + ",'" + name.Text.ToString() + "','" + nameCB.Text.ToString() + "'," + parvandenum.Text.ToString() + ","+1+")", con);

                            }
                            else
                            {
                                cmd = new SqlCommand("INSERT INTO code(tb_Basin,tb_Block,tb_Property,tb_Building,name_build,Receiver,file_num,accept)VALUES(" + Basin.Text.ToString() + "," + Block.Text.ToString() + "," + Property.Text.ToString() + "," + Building.Text.ToString() + ",'" + name.Text.ToString() + "','" + CBname.Text.ToString() + "'," + parvandenum.Text.ToString() +","+1+ ")", con);
                            }
                        }
                        else
                        {
                            if (CB.SelectedIndex.Equals(0))
                            {
                                cmd = new SqlCommand("INSERT INTO code(tb_Basin,tb_Block,tb_Property,tb_Building,name_build,Receiver,file_num)VALUES(" + Basin.Text.ToString() + "," + Block.Text.ToString() + "," + Property.Text.ToString() + "," + Building.Text.ToString() + ",'" + name.Text.ToString() + "','" + nameCB.Text.ToString() + "'," + parvandenum.Text.ToString() + ")", con);
                            }
                            else
                            {
                                cmd = new SqlCommand("INSERT INTO code(tb_Basin,tb_Block,tb_Property,tb_Building,name_build,Receiver,file_num)VALUES(" + Basin.Text.ToString() + "," + Block.Text.ToString() + "," + Property.Text.ToString() + "," + Building.Text.ToString() + ",'" + name.Text.ToString() + "','" + CBname.Text.ToString() + "'," + parvandenum.Text.ToString() + ")", con);
                            }
                        }
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("با موفقیت اضافه شد");
                        cmd.Dispose();
                        con.Close();
                        Basin.Text = null;
                        Property.Text = null;
                        Block.Text = null;
                        //CBname.Items.Clear();
                        //CB.Items.Clear();
                        name.Text = null;
                        Building.Text = null;
                        nameCB.Text = null;
                        parvandenum.Text = null;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nameCB.IsEnabled = false;
            CBname.IsEnabled = true;

            CBname.Items.Clear();
            cmd = new SqlCommand("SELECT namerole,rolee from dbo.namerole AS n INNER JOIN dbo.rrole AS r ON(n.role = r.id)WHERE r.rolee = N'" + CB.SelectedItem.ToString() + "'", con);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CBname.Items.Add(reader["namerole"]);
            }

            cmd.Dispose();
            con.Close();
            //MessageBox.Show(CB.SelectedIndex.ToString());
            if (CB.SelectedIndex.Equals(0))
            {
                CBname.IsEnabled = false;
                nameCB.IsEnabled = true;
            }

        }









        //private void myComboBox_DropDownOpened(object sender, EventArgs e)
        //{
        //    if (comboBox.SelectedIndex == -1 && _scvComboBox != null)
        //    {
        //        _scvComboBox.ScrollToHome();
        //    }
        //}

        //private void myComboBox_ScrollChanged(object sender, ScrollChangedEventArgs e)
        //{
        //    if (_scvComboBox == null)
        //    {
        //        _scvComboBox = e.OriginalSource as ScrollViewer;
        //        _scvComboBox.ScrollChanged -= myComboBox_ScrollChanged;
        //    }
        //}
    }
}
