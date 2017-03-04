        using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace SharpGLWinformsApplication1
{
    public partial class Liewenpinggu : UserControl
    {
        int[,] Position = new int[100, 100];
        int[] pencolor=new int[100];

        DataTable dt = new DataTable("Liewen");
        sqlConnection sqlconn= new sqlConnection();
        private string ConnectionString =null;

        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private string sql = null;
        private DataSet ds = null;
        private SqlDataAdapter da = null;
        public Liewenpinggu()
        {
            InitializeComponent();
            // 创建一个连接
            ConnectionString = sqlconn.str;
            conn = new SqlConnection(ConnectionString);
        }
        /**
       * 此方法为将数据库火箭发射平台裂纹库中的裂纹特征表的数据查询出来并放入DataSet中 
      **/
        private void Liewenpinggu_Load(object sender, EventArgs e)
        {

                        dt.Columns.Add("ID");
            dt.Columns.Add("X(坐标)");
            dt.Columns.Add("Y(坐标)");
            dt.Columns.Add("已修复");
            if (conn.State != ConnectionState.Open)
                conn.Close();
            ds = new DataSet();
            
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            sql = "SELECT * FROM  CrackInfo";
            // 创建数据适配器
            da = new SqlDataAdapter(sql, conn);
            // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            for(int number=0;number<dataGridView1.Rows.Count;number++){
                Position[number, 0] = Convert.ToInt32(dataGridView1.Rows[number].Cells[0].Value)/1000;
                Position[number, 1] = Convert.ToInt32(dataGridView1.Rows[number].Cells[1].Value)/1000;
            }
            string[] titleName ={
                                   "起点X坐标",
                                   "起点Y坐标",
                                    "裂纹深度",
                                    "裂纹长度",
                                    "是否已修复"
                               };
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.dataGridView1.Columns[i].HeaderCell.Value = titleName[i];
            }
            
            conn.Close();
        }
 

       

        //多条件查询 CrackInfo中信息
        private void button1_Click(object sender, EventArgs e)
        {
            JudgeInputText Judge = new JudgeInputText();
            if(!(Judge.judge(textBox1.Text.Trim())||
                Judge.judge(textBox15.Text.Trim())||
                Judge.judge(textBox16.Text)||
                Judge.judge(textBox3.Text)))
            {
                MessageBox.Show("输入字符为空或者非数字，请检查！");
                textBox1.Text = textBox3.Text=textBox15.Text=textBox16.Text="";

                return;
            }
            if(!(Judge.judge(textBox1.Text.Trim()))){
                textBox1.Text="";
            }
            if(!(Judge.judge(textBox15.Text.Trim()))){
                textBox15.Text="";
            }
            if(!Judge.judge(textBox16.Text.Trim())){
                textBox16.Text="";
            }
            if(!(Judge.judge(textBox3.Text.Trim()))){
                textBox3.Text="";
            }

            if (conn.State != ConnectionState.Open)
                conn.Close();
            try
            {
                ds = new DataSet();
                conn = new SqlConnection(ConnectionString);
                conn.Open();
                sql = "SELECT * FROM  CrackInfo ";
                string condition = "";
                if (textBox1.Text.Trim() != "")
                    condition = " [StartPoint X(°)] BETWEEN " + Convert.ToDouble(textBox1.Text) + "-1000 AND " + Convert.ToDouble(textBox1.Text) + "+1000";
                if (textBox15.Text.Trim() != "")
                {
                    if (condition.Length > 0)
                    {
                        condition += "AND [StartPoint Y(°)] BETWEEN " + Convert.ToDouble(textBox15.Text) + "-1000 AND " + Convert.ToDouble(textBox15.Text) + "+1000";

                    }
                    else
                    {
                        condition = " [StartPoint Y(°)] BETWEEN " + Convert.ToDouble(textBox15.Text) + "-1000 AND " + Convert.ToDouble(textBox15.Text) + "+1000";
                    }
                }
                if (textBox3.Text.Trim() != "")
                {
                    if (condition.Length > 0)
                    {
                        condition += "AND [CrackDepth(mm)] BETWEEN " + Convert.ToDouble(textBox3.Text) + "-5 AND " + Convert.ToDouble(textBox3.Text) + "+5";
                    }
                    else
                    {
                        condition = " [CrackDepth(mm)] BETWEEN " + Convert.ToDouble(textBox3.Text) + "-5 AND " + Convert.ToDouble(textBox3.Text) + "+5";
                    }
                }
                if (condition != "")
                    sql += " where " + condition;
                da = new SqlDataAdapter(sql, conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                int R = dataGridView1.Rows.Count ;
                conn.Close();
                if (R == 0)
                {
                    MessageBox.Show("相似裂纹数据查找无效！" ); 
                }
                else
                {
                    MessageBox.Show("已找到相似裂纹" + R + "条！");
                }           
                this.button3.Visible = true;
            }
            catch (Exception E)
            {
                MessageBox.Show("查找数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            pictureBox1.Refresh();
        }

        //插入裂纹数据
        private void button7_Click(object sender, EventArgs e)
        {
            JudgeInputText Judge=new JudgeInputText();
            if(!(Judge.judge(textBox1.Text.Trim())&&
                Judge.judge(textBox15.Text.Trim())&&
                Judge.judge(textBox16.Text)&&
                Judge.judge(textBox3.Text)))
            {
                MessageBox.Show("输入字符为空或者非数字，请检查！");
                return;
            }

            var count = 0;
            if (conn.State != ConnectionState.Open)
                conn.Close();
            if(Convert.ToDouble(textBox1.Text.Trim())>=7500||Convert.ToDouble(textBox1.Text.Trim())<=-7500||Convert.ToDouble(textBox15.Text.Trim())>=7500||Convert.ToDouble(textBox15.Text.Trim())<=-7500){
                MessageBox.Show("所输入坐标信息超出范围");
                textBox1.Text="";
                textBox15.Text="";
                return;
            }
            foreach (DataGridViewRow v in dataGridView1.Rows)
            {
                if (v.Cells[0].Value != null && v.Cells[1].Value != null && v.Cells[2].Value != null && v.Cells[3].Value != null )
                {
                            if (v.Cells[0].Value.ToString().Equals(textBox1.Text.Trim())
                                && v.Cells[1].Value.ToString().Equals(textBox15.Text.Trim())
                                //&& v.Cells[2].Value.ToString().Equals(textBox2.Text.Trim())
                                && v.Cells[2].Value.ToString().Equals(textBox3.Text.Trim())
                                //&& v.Cells[4].Value.ToString().Equals(textBox14.Text.Trim())
                                && v.Cells[3].Value.ToString().Equals(textBox16.Text.Trim()))
                                count++;
                        }
                    }
                    if (count >= 1)
                    {
                        MessageBox.Show("已存在相同数据");
                        return;
                    }
              
            

            try
            {

                sql = "insert into  CrackInfo  values('" + Convert.ToDouble(textBox1.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(textBox15.Text.Trim()).ToString() + "'," +
                   "'" + Convert.ToDouble(textBox3.Text.Trim()).ToString() + "'," +
                   "'" + Convert.ToDouble(textBox16.Text.Trim()).ToString() + "',0)";
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("数据插入成功");
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand();
                ds = new DataSet();
                sql = "SELECT * FROM  CrackInfo "; ;
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, " CrackInfo");
                this.dataGridView1.DataSource = ds.Tables[" CrackInfo"].DefaultView;


            }
            catch (Exception E)
            {
                MessageBox.Show("插入数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            pictureBox1.Refresh();

        }
        //删除裂纹数据
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();

                string sql = "delete from  CrackInfo where [StartPoint X(°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value + "'" +
                    "and [StartPoint Y(°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value + "'" +
                      "and [CrackDepth(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value + "'" +
                        "and [CrackLength(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value + "'";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                //  conn.Close();
                MessageBox.Show("数据删除成功");
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand();
                ds = new DataSet();
                sql = "SELECT * FROM  CrackInfo "; ;
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, " CrackInfo");
                this.dataGridView1.DataSource = ds.Tables[" CrackInfo"].DefaultView;
            }
            catch (Exception E)
            {
                MessageBox.Show("删除数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
            pictureBox1.Refresh();
        }

 

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            conn = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();
            ds = new DataSet();
            sql = "SELECT * FROM  CrackInfo "; ;
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, " CrackInfo");
            this.dataGridView1.DataSource = ds.Tables[" CrackInfo"].DefaultView;
            this.button3.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point[] linX ={
                             new Point(0,250),
                             new Point(500,250)
                         };
            Point[] LinY ={
                             new Point(250,0),
                             new Point(250,500)
                         };
            Pen P = new Pen(Color.Red, 3);

            g.DrawLine(Pens.Red, linX[0], linX[1]);
            g.DrawLine(Pens.Red, LinY[0], LinY[1]);

            g.DrawLine(Pens.Red, new Point(500,250),new Point(490,240));
            g.DrawLine(Pens.Red, new Point(500,250),new Point(490,260));

            
            for (int x = 0; x < 500; x++)
            {

                if (x<=250&&(250-x)% 31 == 0)
                {
                    g.DrawLine(Pens.Red, new Point(250, x), new Point(255, x ));

                    g.DrawLine(Pens.Red, new Point(x , 250), new Point(x, 245));
                    if (-x + 250 != 0)
                    {
                        g.DrawString(Convert.ToString(1000*(250-x)/31), new Font("微软雅黑", 7), Brushes.Red, 225, x - 5);
                    }
                    g.DrawString(Convert.ToString(-1000*(250 - x) /31), new Font("微软雅黑", 7), Brushes.Red, x, 250);

                }else if((x-250)%31==0){
                    g.DrawLine(Pens.Red, new Point(250, x), new Point(255, x));
                    g.DrawLine(Pens.Red, new Point(x, 250), new Point(x , 245));
                    if (-x + 250 != 0)
                    {
                        g.DrawString(Convert.ToString(-1000*(x-250) / 31), new Font("微软雅黑", 7), Brushes.Red, 225, x  - 5);
                    }
                    g.DrawString(Convert.ToString(1000*(x-250) /31), new Font("微软雅黑", 7), Brushes.Red, x , 250);
               
                }

            }
            for (int number = 0; number < dataGridView1.Rows.Count; number++)
            {
                Position[number, 0] = Convert.ToInt32(dataGridView1.Rows[number].Cells[0].Value) / 1000;
                Position[number, 1] = Convert.ToInt32(dataGridView1.Rows[number].Cells[1].Value) / 1000;
            }
                draw_4_circle(g);
        }
        private void draw_4_circle(Graphics g)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DrawCircle(g, Position[i, 0], Position[i, 1], Convert.ToString(i + 1), pencolor[i]);
            }
        }
        private void DrawCircle(Graphics g, float x, float y,string s,int pencolor)
        {
            x=x*31+250;
            y=-y*31+250;
            g.TranslateTransform(x, y);
            Pen IPen = new Pen(Color.Blue, 3);
            if (pencolor == 0)
            {
                IPen.Color = Color.Blue;
                g.DrawEllipse(IPen, -10, -10, 10, 10);
                g.DrawString(s, new Font("微软雅黑", 18), Brushes.Blue, 0, -20);

            }
            else
            {
                IPen.Color = Color.Red;
                g.DrawEllipse(IPen, -25, -25, 25, 25);
                g.DrawString(s, new Font("微软雅黑", 18), Brushes.Red, 0, -20);
            }
            g.ResetTransform();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            for (int c = 0; c < dataGridView1.Rows.Count; c++)
            {
                if (c == i)
                {
                    pencolor[c] = 1;
                }
                else
                {
                    pencolor[c] = 0;
                }
            }
            pictureBox1.Refresh();
            //如果选中修复一行，修复改为1
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {
                object ob = Convert.ToInt32(dataGridView1.CurrentCell.Value);
                if ((int)ob != 1)
                {
                    if (MessageBox.Show("此裂纹未修复='0'，是否修改为已修复='1'", "修复", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        sql = "update CrackInfo set repair=1 where [StartPoint X(°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value + "'" +
                        "and [StartPoint Y(°)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value + "'" +
                          "and [CrackDepth(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value + "'" +
                            "and [CrackLength(mm)]='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value + "'";
                        conn = new SqlConnection(ConnectionString);
                        cmd = new SqlCommand(sql, conn);
                        conn.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("数据更新成功");
                        }
                        catch (Exception E)
                        {
                            MessageBox.Show("更新数据库时发生错误：" + E.Message + "", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        conn = new SqlConnection(ConnectionString);
                        cmd = new SqlCommand();
                        ds = new DataSet();
                        sql = "SELECT * FROM  CrackInfo "; ;
                        da = new SqlDataAdapter(sql, conn);
                        da.Fill(ds, " CrackInfo");
                        this.dataGridView1.DataSource = ds.Tables[" CrackInfo"].DefaultView;
                    }

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}


