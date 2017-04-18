using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Numerics;
using System.Globalization;
using System.Data.SqlClient;


namespace SharpGLWinformsApplication1
{
    public partial class realiable : UserControl
    {
        public string[] name ={
                                 "应力",
                                 "震动",
                                 "形变",
                                 "裂纹",
                                 "材料参数",
                                 "涂层烧蚀量",
                                 "传动阻力",
                                 "电机扭矩",
                                 "制动力矩",
                                 "液压及电控"
                             };
        public realiable()
        {
            InitializeComponent();
            his = new HistoryList();
        }

        public static Decimal str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11;
        public static string eventual;
        private HistoryList his = null;

        private void button2_Click(object sender, EventArgs e)
        {
            YLZ.Text = "";
            ZDL.Text = "";
            //YTZH.Text = "";
            XBL.Text = "";
            LWXW.Text = "";
            CLCS.Text = "";
            SSL.Text = "";
            CLCS.Text = "";
            CDZL.Text = "";
            DJNJ.Text = "";
            ZDLJ.Text = "";
            YYJDK.Text = "";
            /*YYDK.Text = "";
            AQXS.Text = "";*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JudgmentMatrix Judgmentmatrix = new JudgmentMatrix();
            Judgmentmatrix.DataChange += new JudgmentMatrix.DataChangeHandler(DataChanged);
            Judgmentmatrix.ShowDialog();
            Judgmentmatrix.Dispose();           
        }
        
        public void DataChanged(object sender, DataChangeEventArgs args)
        {
            // 更新窗体控件
            textBox1.Text = args.A;
            textBox2.Text = args.B;
            textBox3.Text = args.C;
            textBox4.Text = args.D;
            textBox5.Text = args.E;
            textBox6.Text = args.F;
            textBox7.Text = args.G;
            textBox8.Text = args.H;
            textBox9.Text = args.I;
            textBox10.Text = args.J; 
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            N_LiShuDu newLSd = new N_LiShuDu();
            newLSd.Show();
        }

 

        private bool CheckAssessParameter()
        {
            if (YLZ.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入应力值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(YLZ.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入应力值");
                    return false;
                }
            }
            if (YYJDK.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入应力值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(YYJDK.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入应力值");
                    return false;
                }
            }


            if (ZDL.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入振动量");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(ZDL.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入振动量");
                    return false;
                }
            }

            if (XBL.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入形变量");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(XBL.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入形变量");
                    return false;
                }
            }

            if (LWXW.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入裂纹形位");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(LWXW.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入裂纹形位");
                    return false;
                }
            }

            if (CLCS.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入材料参数");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(CLCS.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入材料参数");
                    return false;
                }
            }

            if (SSL.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入涂层烧蚀量");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(SSL.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入涂层烧蚀量");
                    return false;
                }
            }

            if (CDZL.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入传动阻力");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(CDZL.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入传动阻力");
                    return false;
                }
            }

            if (DJNJ.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入电机扭矩");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(DJNJ.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入电机扭矩");
                    return false;
                }
            }

            if (ZDLJ.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入制动力矩");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(ZDLJ.Text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show("请正确输入制动力矩");
                    return false;
                }
            }


            return true;
        }
        public double[,] ReadXmlData()
        {


            double[,] dtrow_CZB = new double[6, 10];
            string str = "../Debug/LiShuduBiao400.xml";
            if(XMLConnectionr.str=="800")
                str= "../Debug/LiShuduBiao800.xml";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(str);
            XmlNodeList nodeList = xmldoc.SelectSingleNode("NewXML").ChildNodes;
            int x = 0;
            foreach (XmlNode Xn in nodeList)
            {
                XmlElement xe = (XmlElement)Xn;
                for (int B = 0; B < name.Length; B++)
                {
                    dtrow_CZB[x,B] = Convert.ToDouble(xe.GetAttribute(name[B]));
                }
                x++;
            }
            return dtrow_CZB;
        }


        public double[,] GetLishudu(double[] InputData)
        {

            double[,] LiShuDu_Ckz=ReadXmlData();    //this array is used to save the the map inthe XML;
            //把五段数据转变成四段数据
            double[,] N_LiShuDu = new double[LiShuDu_Ckz.GetLongLength(0)-1,LiShuDu_Ckz.GetLongLength(1)];
            for (int i = 0; i < LiShuDu_Ckz.GetLength(1); i++)
            {
                N_LiShuDu[0, i] = LiShuDu_Ckz[0, i];
                for (int j = 1; j < LiShuDu_Ckz.GetLength(0)-1; j++)
                {
                    N_LiShuDu[j,i] = N_LiShuDu[j-1,i]+ 2 * (LiShuDu_Ckz[j,i] - N_LiShuDu[j-1,i]);
                }
            }

            double[,] _LiShuDu=new double[10,5];        //form left big to right little
                        //定义负相关的参数对应的列
            int[] FuXiangGuan_Columns ={
                                            0,1,2,3,5,6
                                      };
            for (int x = 0; x < InputData.Length; x++)
            {
                for(int y=0;y<N_LiShuDu.GetLength(0)-1;y++){
                    bool ZorF = false;
                    foreach (int C in FuXiangGuan_Columns)
                    {
                        if (x == C)
                        {
                            ZorF = true;
                        }
                    }
                    if (ZorF == true)//负相关
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (InputData[x] >= N_LiShuDu[y, x] && InputData[x] < N_LiShuDu[y + 1, x])
                            {
                                double inner = InputData[x] - N_LiShuDu[y + 1, x];
                                double border = N_LiShuDu[y, x] - N_LiShuDu[y + 1, x];
                                //double width=0.4*border;
                                _LiShuDu[x, y] = inner / border;
                                _LiShuDu[x, y + 1] = 1 - _LiShuDu[x, y];
                            }
                        }
                    }
                    else
                    {
                        //正相关
                        for (int i = 0; i < 6; i++)
                        {
                            if (InputData[x] <= N_LiShuDu[y, x] && InputData[x] > N_LiShuDu[y + 1, x])
                            {
                                double inner = InputData[x] - N_LiShuDu[y + 1, x];
                                double border = N_LiShuDu[y, x] - N_LiShuDu[y + 1, x];
                                //double width=0.4*border;
                                _LiShuDu[x, y] = inner / border;
                                _LiShuDu[x, y + 1] = 1 - _LiShuDu[x, y];
                            }
                        }
                    }



                }
            }
            return _LiShuDu;

        }
        private void Read_SQL_Data()
        {
            try
            {
                DataSet ds = new DataSet();
                sqlConnection sc = new sqlConnection();

                SqlConnection conn = new SqlConnection(sc.str);
                conn.Open();
                string sql = "SELECT * FROM  AccessInputValue";
                // 创建数据适配器
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                // 创建一个数据集对象并填充数据，然后将数据显示在DataGrid控件中
                da.Fill(ds);
                int i = 0;
                YLZ.Text =  ds.Tables[0].Rows[0][i++].ToString().Trim();
                ZDL.Text= ds.Tables[0].Rows[0][i++].ToString().Trim();
                XBL.Text=ds.Tables[0].Rows[0][i++].ToString().Trim();
                LWXW.Text=ds.Tables[0].Rows[0][i++].ToString().Trim();
                CLCS.Text=ds.Tables[0].Rows[0][i++].ToString().Trim();
                SSL.Text=ds.Tables[0].Rows[0][i++].ToString().Trim();
                CDZL.Text=ds.Tables[0].Rows[0][i++].ToString().Trim();
                DJNJ.Text=ds.Tables[0].Rows[0][i++].ToString().Trim();
                ZDLJ.Text=ds.Tables[0].Rows[0][i++].ToString().Trim();
                YYJDK.Text = ds.Tables[0].Rows[0][i++].ToString().Trim();
            }catch(Exception e){

            }
        }
        private void Save_SQL_Data()
        {
            try
            {

                string sql = "insert into  AccessInputValue  values('" + Convert.ToDouble(YLZ.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(ZDL.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(XBL.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(LWXW.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(CLCS.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(SSL.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(CDZL.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(DJNJ.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(ZDLJ.Text.Trim()).ToString() + "'," +
                    "'" + Convert.ToDouble(YYJDK.Text.Trim()).ToString() + "')";

                sqlConnection sc = new sqlConnection();

                SqlConnection conn = new SqlConnection(sc.str);
                SqlCommand cmd = new SqlCommand("delete from AccessInputValue", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception E)
            {

            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //Save_SQL_Data();
            sqlConnection sc = new sqlConnection();
            string[] saveData=new string[]{
                YLZ.Text.Trim().ToString(),
                ZDL.Text.Trim().ToString(),
                XBL.Text.Trim().ToString(),
                LWXW.Text.Trim().ToString(),
                CLCS.Text.Trim().ToString(),
                SSL.Text.Trim().ToString(),
                CDZL.Text.Trim().ToString(),
                DJNJ.Text.Trim().ToString(),
                ZDLJ.Text.Trim().ToString(),
                YYJDK.Text.Trim().ToString()
            };

            JudgeInputText Judge = new JudgeInputText();
            for (int i = 0; i < saveData.Length; i++)
            {
                if (Judge.judge(saveData[i]) == false)
                {
                    MessageBox.Show("输入的内容为空或者不是数字数字，请检查！！");
                    return;
                }

            }

            double[,] LiShuDu_Ckz = ReadXmlData();    //this array is used to save the the map inthe XML;
            double[] array = new double[LiShuDu_Ckz.GetLength(0)];
            for (int i = 0; i < LiShuDu_Ckz.GetLength(1); i++)
            {
                for (int k = 0; k < LiShuDu_Ckz.GetLength(0); k++)
                {
                    array[k] = LiShuDu_Ckz[k, i];
                }
                if (!(Convert.ToDouble(saveData[i]) > array.Min() && Convert.ToDouble(saveData[i]) < array.Max()))
                {

                    MessageBox.Show("输入的:" + name[i] + " 数据不在其隶属度范围（" + array.Min() + "," + array.Max() + "）内，请检查！！",name[i]+"数据有误");
                    return;
                }
            }
            sc.Save_SQL_Data(saveData,"AssessInputValue");
            calculate(0);//模式为0，参数任意
        }
        private void calculate(int Mode,int Canshu=0)
        {
            //判断输入的信息是否合格
            if (!CheckAssessParameter())
                return;
            double[] InputData ={
                                    Convert.ToDouble(YLZ.Text),
                                    Convert.ToDouble(ZDL.Text),
                                    //Convert.ToDouble(YTZH.Text),
                                    Convert.ToDouble(XBL.Text) ,
                                    Convert.ToDouble(LWXW.Text),
                                    Convert.ToDouble(CLCS.Text),
                                    Convert.ToDouble(SSL.Text) ,
                                    Convert.ToDouble(CDZL.Text),
                                    Convert.ToDouble(DJNJ.Text),
                                    Convert.ToDouble(ZDLJ.Text),
                                    Convert.ToDouble(YYJDK.Text)
                               };
             Double densy=0;
            Double AddUp=0;
                if(Mode==1){
                    Double[,] dd= ReadXmlData();
                    AddUp=(dd[0,Canshu]-dd[dd.GetLength(0)-1,Canshu])/20;
                    densy = dd[0, Canshu];
                }
            for (int i = 0; i < 20; i++)
            {
                if (Mode == 1)
                {
                    InputData[Canshu] = densy - AddUp * i;
                }
                double[,] LSD_martiax = GetLishudu(InputData);

                var matrix = DenseMatrix.OfArray(LSD_martiax);
                JudgmentMatrix JM = new JudgmentMatrix();

                var vector = DenseVector.OfArray(
                        new double[] { 
                        Convert.ToDouble(JM.TextBox01Text.Trim()),
                        Convert.ToDouble(JM.TextBox02Text.Trim()),
                        Convert.ToDouble(JM.TextBox03Text.Trim()),
                        Convert.ToDouble(JM.TextBox04Text.Trim()),
                        Convert.ToDouble(JM.TextBox05Text.Trim()),
                        Convert.ToDouble(JM.TextBox06Text.Trim()),
                        Convert.ToDouble(JM.TextBox07Text.Trim()),
                        Convert.ToDouble(JM.TextBox08Text.Trim()),
                        Convert.ToDouble(JM.TextBox09Text.Trim()),
                        Convert.ToDouble(JM.TextBox10Text.Trim())
                    }
                    );

                var get = vector * matrix;
                var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                formatProvider.TextInfo.ListSeparator = " ";
                string s = matrix.ToString("#0.00\t", formatProvider);
                labelmatrix.Text = s;
                s = get.ToString("#0.0000\t", formatProvider);
                labelmatrix.Text = labelmatrix.Text + s;
                double[] MapOfGet = { 90, 70, 50, 30, 10 };
                double sum = 0;

                for (int n = 0; n < 5; n++)
                {
                    double step = MapOfGet[n] * get[n];
                    sum += step;
                    labelmatrix.Text = labelmatrix.Text + step + " ";
                }
                if (Mode == 0)
                {
                    PrintOutResult(sum);
                    return;
                }
                else if (Mode == 1)
                {
                    CanShuBianhuaZhi.Cal[i] = sum;
                    CanShuBianhuaZhi.x[i] = InputData[Canshu];
                }
            }
            CanshuTU ctu = new CanshuTU();
            ctu.Show();
            
        }

        private void PrintOutResult(double sum){
            string[] evenComp = new string[]{
                "\n性能良好:可安全发射。\n",
                "\n性能较好:可正常发射。\n",
                "\n性能一般:可发射。\n",
                "\n性能较差:请及时检查,\n不建议发射。\n",
                "\n性能最差:禁止发射！！！\n请进行维修。\n"
            };
            int dengji = 4-(int)sum / 20;
            if (dengji < 0)
            {
                dengji = 0;
            }
            eventual = "结果：" + sum+evenComp[dengji]+"\n";
            ReliabilityAssessResult Reliabilityassessresult = new ReliabilityAssessResult();
            Reliabilityassessresult.ShowDialog();
            Reliabilityassessresult.Dispose();                
        }

        private void realiable_Load(object sender, EventArgs e)
        {
            //Read_SQL_Data();
            sqlConnection sc = new sqlConnection();
            string[] ReadData = sc.Read_SQL_Data("AssessInputValue");
            if (ReadData[1]!=null)
            {
                int i = 0;
                try
                {
                    YLZ.Text = ReadData[i++];
                    ZDL.Text = ReadData[i++];
                    XBL.Text = ReadData[i++];
                    LWXW.Text = ReadData[i++];
                    CLCS.Text = ReadData[i++];
                    SSL.Text = ReadData[i++];
                    CDZL.Text = ReadData[i++];
                    DJNJ.Text = ReadData[i++];
                    ZDLJ.Text = ReadData[i++];
                    YYJDK.Text = ReadData[i++];
                }
                catch (Exception EE)
                {

                }
            }

            comboBox1.SelectedIndex = 0;


            JudgmentMatrix JM = new JudgmentMatrix();


            this.textBox1.Text = JM.TextBox01Text;
            this.textBox2.Text = JM.TextBox02Text;
            this.textBox3.Text = JM.TextBox03Text;
            this.textBox4.Text = JM.TextBox04Text;
            this.textBox5.Text = JM.TextBox05Text;
            this.textBox6.Text = JM.TextBox06Text;
            this.textBox7.Text = JM.TextBox07Text;
            this.textBox8.Text = JM.TextBox08Text;
            this.textBox9.Text = JM.TextBox09Text;
            this.textBox10.Text = JM.TextBox10Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            XMLConnectionr.str=comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculate(1, 0);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            calculate(1, 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            calculate(1, 2);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            calculate(1, 3);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            calculate(1, 4);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            calculate(1, 5);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            calculate(1, 6);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            calculate(1, 7);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            calculate(1, 8);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            calculate(1, 9);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            InputYingliZhi inputYinglizhi = new InputYingliZhi();
            inputYinglizhi.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

    }
}


