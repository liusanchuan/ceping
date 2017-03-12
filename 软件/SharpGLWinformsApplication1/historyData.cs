        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Windows.Documents;



namespace SharpGLWinformsApplication1
{
    public partial class historyData : UserControl
    {
        List<Double>series;
        List<List<Double>> Ser=new List<List<Double>>();
        List<String> X;
        List<List<String>> X_all=new List<List<string>>();
        public int Pub_cedian =1;
        bool[] check_box = new bool[4]{ true,
                                    true,
                                    true,
                                    true};
        
        public historyData()
        {
            InitializeComponent();
            RefreshDataGridView();
        }
        private string ConnectionString=null;       
        private SqlConnection conn = null;
        //private SqlCommand cmd = null;
        private string sql = null;
        private DataSet ds = null;
        private SqlDataAdapter da = null;
        string[] titleName =
        {
            "加注/发射",
            "时间"
        };

        private void historyData_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();

        }

        //查找数据
        private void button1_Click_1(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        private void dataSelect(){
            
            sqlConnection sqlstring = new sqlConnection();
            ConnectionString = sqlstring.getconn();
            try
            {
                ds = new DataSet();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                sql = "SELECT * FROM LData ";
                string condition = "";

                //if (dateTimePicker1.Text != "" && dateTimePicker2.Text != "")
                //{
                //    condition = " LaunchTime BETWEEN " + "'" + dateTimePicker1.Value.Date.ToString("yyyy/MM/dd") + "'" + "AND" + "'" + dateTimePicker2.Value.Date.ToString("yyyy/MM/dd") + "'";
                //}
                if (Combo_insert_times.Text != "")
                {
                    condition = " LaunchTime BETWEEN " + "'" + Convert.ToDateTime(Combo_insert_times.Text).Date.ToString("yyyy/MM/dd") + "'" + "AND" + "'" + Convert.ToDateTime(Combo_insert_times.Text).Date.AddDays(1).ToString("yyyy/MM/dd") + "'";

                    //condition = " LaunchTime = " + "'" + Convert.ToDateTime(Combo_insert_times.Text).Date.ToString("yyyy/MM/dd") + "'";
                }
              if (comboBox3.Text != ""&&comboBox3.Text!="全部")
              {
                  if (condition.Length > 0)
                  {
                      condition += " AND AddOrFly = " + "'" + comboBox3.Text + "'";
                  }
                  else
                  {
                      condition = " AddOrFly = " + "'" + comboBox3.Text + "'";
                  }
              }
 
                if (condition != "")
                    sql += " where " + condition;
                
                da = new SqlDataAdapter(sql, conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);


                    for (int Bui = 0; Bui < dataGridView1.Columns.Count; Bui++)
                    {
                        dataGridView1.Columns[Bui].SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (Bui < 2)
                        {
                            dataGridView1.Columns[Bui].HeaderCell.Value = titleName[Bui];
                        }
                        String old_columns_name = Convert.ToString(dataGridView1.Columns[Bui].HeaderCell.Value);
                        if (old_columns_name.Substring(0, 1) == "S")
                        {
                            dataGridView1.Columns[Bui].HeaderCell.Value = "测点" + old_columns_name.Substring(1) + "-应力";
                        }
                        else if (old_columns_name.Substring(0, 1) == "T")
                        {
                            dataGridView1.Columns[Bui].HeaderCell.Value = "测点" + old_columns_name.Substring(1) + "-温度";
                        }
                        else if (old_columns_name.Substring(0, 2) == "ZD")
                        {
                            dataGridView1.Columns[Bui].HeaderCell.Value = "测点" + old_columns_name.Substring(2) + "-震动";
                        }
                        else if (old_columns_name.Substring(0, 2) == "BX")
                        {
                            dataGridView1.Columns[Bui].HeaderCell.Value = "测点" + old_columns_name.Substring(2) + "-变形";

                        }
                    }
                conn.Close();

       
            }
            catch (Exception E)
            {
                MessageBox.Show("查找数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            List<String>  item_set=new List<String>();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                String time_item = Convert.ToString(Convert.ToDateTime(dataGridView1.Rows[i].Cells[1].Value).ToString("yyyy/MM/dd"));
                if (item_set.Count==0)
                {
                    item_set.Add(time_item);
                }
                bool flag = false;
                for(int t=0;t<item_set.Count;t++){
                    if (time_item == item_set[t])
                    {
                        flag = true;
                    }
                }
                if (flag == false) item_set.Add(time_item);
            }

            //Combo_insert_times.Items.Clear();
            List<String> list_a=new List<string>();
            for (int i = 0; i < Combo_insert_times.Items.Count; i++)
            {
                list_a.Add(Combo_insert_times.Items[i].ToString());
            }

            List<String> list_temp = item_set.Except(list_a).ToList();
            //list_a.AddRange(list_temp);
            foreach(String y in list_temp){
                Combo_insert_times.Items.Add(y);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        private void RefreshDataGridView(){
            //先刷新选择数据
            dataSelect();
            
            string mystr = comboBox2.Text;
            if (mystr != "")
            {
                for (int i = 2; i < dataGridView1.ColumnCount; i++)
                {
                    dataGridView1.Columns[i].Visible = false;
                }


                for (int Cedian = 1; Cedian < 11; Cedian++)
                {
                    string str;
                    if (Cedian < 10)
                    {
                        str = "测点0" + Cedian;
                    }
                    else
                    {
                        str = "测点" + Cedian;
                    }

                    if (mystr == str)
                    {
                        dataGridView1.Columns[Cedian + 1].Visible = true;
                        dataGridView1.Columns[Cedian + 11].Visible = true;
                        dataGridView1.Columns[Cedian + 21].Visible = true;
                        dataGridView1.Columns[Cedian + 31].Visible = true;
                        Pub_cedian = Cedian;
                        chart1.Series[0].Name = "测点"+ Cedian+"-应力" ;
                        chart1.Series[1].Name = "测点" + Cedian + "-温度";
                        chart1.Series[2].Name = "测点" + Cedian + "-震动";
                        chart1.Series[3].Name = "测点" + Cedian + "-变形";
                        //groupBox2.Text = mystr + groupBox2.Text;
                    }
                }
            }
            int seriesNum = 0;
            Ser.Clear();
            X_all.Clear();
            //X = new String[dataGridView1.Rows.Count];
            for (int i = 2; i < dataGridView1.ColumnCount; i++)
            {
                
                if (dataGridView1.Columns[i].Visible == true)
                {
                    //series[seriesNum] = new Double[dataGridView1.Rows.Count];
                    if (check_box[seriesNum])
                    {
                        series = new List<Double>();
                        X = new List<string>();
                        for (int F = 0; F < dataGridView1.Rows.Count; F++)
                        {
                            if (dataGridView1.Rows[F].Cells[i].Value.ToString().Length != 0)
                            {
                                series.Add(Convert.ToDouble(dataGridView1.Rows[F].Cells[i].Value));
                                X.Add(Convert.ToString(Convert.ToDateTime(dataGridView1.Rows[F].Cells[1].Value).ToString("yyyy/MM/dd hh:mm:ss")));
                            }

                        }
                        Ser.Add(series);
                        X_all.Add(X);
                    }
                    seriesNum++;
                    if (seriesNum >3)
                    {
                        break;
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            RefreshDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {

            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请选择数据目录");
                    return;
                }
                try
                {
                    String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source=" + textBox1.Text + ";" +
                    "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                    //实例化一个Oledbconnection类(实现了IDisposable,要using)
                    using (OleDbConnection ole_conn = new OleDbConnection(sConnectionString))
                    {
                        ole_conn.Open();
                        DataSet ds = new DataSet();
                        using (OleDbCommand ole_cmd = ole_conn.CreateCommand())
                        {
                            //类似SQL的查询语句这个[Sheet1$对应Excel文件中的一个工作表]
                            ole_cmd.CommandText = "select * from [Sheet1$]";
                            OleDbDataAdapter adapter = new OleDbDataAdapter(ole_cmd);

                            adapter.Fill(ds, "Sheet1");
                            dataGridView2.DataSource = ds.Tables[0].DefaultView;
                            sqlConnection sqlstring = new sqlConnection();
                            string str = sqlstring.getconn();
                            SqlConnection con = new SqlConnection(str); //创建连接对象
                            con.Open(); //打开连接
                            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
                            bulkcopy.DestinationTableName = "dbo.LData";
                            bulkcopy.WriteToServer(ds.Tables[0]);
                            MessageBox.Show("添加信息成功！");
                        }
                    }
                    RefreshDataGridView();
                }
                catch (Exception E)
                {
                    MessageBox.Show("添加未成功:" + E);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
                MessageBoxButtons messagebutton = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show("点击确认将会清空所有的信息", "请谨慎操作", messagebutton);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SqlConnection sqlcon = new SqlConnection(ConnectionString);
                    sqlcon.Open();
                    string sqlstring = "truncate table LData";
                    SqlCommand sqlcom = sqlcon.CreateCommand();
                    sqlcom.CommandText = sqlstring;
                    sqlcom.ExecuteNonQuery();
                    sqlcon.Close();

                }
                RefreshDataGridView();
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.FileName = Environment.SpecialFolder.MyComputer.ToString();
                FD.InitialDirectory = "C:";

            FD.Filter = "Excel file(*.xls;*.xlsx)|*.xls;*.xlsx";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = FD.FileName;
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = "1989/1/11 星期三 16:41";
            dateTimePicker2.Text = "2017/1/11 星期三 16:41";
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;
            Combo_insert_times.SelectedItem = null;

            int m;
            for (m = 2; m < dataGridView1.Columns.Count; m++)
            {
                dataGridView1.Columns[m].Visible = true;
            }

            ds = new DataSet();
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            sql = "SELECT * FROM LData";
            // 创建数据适配器
            da = new SqlDataAdapter(sql, conn);
            // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();
            RefreshDataGridView();
        }

        
        history_data_series his_series = new history_data_series();
        private void button5_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
            if (Ser.Count==0)
            {
                MessageBox.Show("没有可显示的曲线,请勾选一个显示项目！");
                return;
            }
            if (history_series_from.history_series_fo == 0)
            {

                his_series.Show();
                his_series.Visible = true;
                history_series_from.history_series_fo = 1;
            }
            if (history_series_from.history_series_fo == 2)
            {
                his_series.Visible = true;
                history_series_from.history_series_fo = 1;
            }
            his_series.add_aChild(Ser, Pub_cedian, X_all,check_box);
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            FileFormat ff = new FileFormat();
            ff.Show();
        }

        private void Combo_insert_times_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                check_box[0] = true;
            }
            else
            {
                check_box[0] = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                check_box[1] = true;
            }
            else
            {
                check_box[1] = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                check_box[2] = true;
            }
            else
            {
                check_box[2] = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                check_box[3] = true;
            }
            else
            {
                check_box[3] = false;
            }
        }
    
    }   
}