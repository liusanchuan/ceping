using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using System.Globalization;
using MathNet.Numerics.LinearAlgebra.Double;

namespace SharpGLWinformsApplication1
{
    public partial class JudgmentMatrix : Form
    {
        // 定义委托
        public delegate void DataChangeHandler(object sender, DataChangeEventArgs args);
        // 声明事件
        public event DataChangeHandler DataChange;

        // 调用事件函数
        public void OnDataChange(object sender, DataChangeEventArgs args)
        {
            if (DataChange != null)
            {
                DataChange(this, args);
            }
        }
        private HistoryList his = null;
        private string[] array = null;
        public JudgmentMatrix()
        {
            InitializeComponent();
            his = new HistoryList();
            InitTextBoxRemind();
        }
 

        //得到最大特征向量
        public double[] getMaxEigenValues(double[,] array,int x)
        {
            var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            formatProvider.TextInfo.ListSeparator = " ";
            var matrix = DenseMatrix.OfArray(array);
            var evd = matrix.Evd();
            var b = new Complex[x];
            double[] d = new double[3];
            for (int i = 0; i < x; i++)
            {
                var a = evd.EigenValues.AbsoluteMaximumIndex();
                b[i] = evd.EigenVectors[i, a];
                d[i] = b[i].Real;
            }
            //歸一化
            double sum = d.Sum();
            for (var z = 0; z < x; z++)
            {
                d[z] /= sum;
            }

            return d;

        }


        //同步
        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../Debug/Judgemartia.xml");
            foreach (XmlNode Sd in doc.DocumentElement.ChildNodes)
            {
                if (Sd.Name == "b12")
                    Sd.InnerText= textBoxB12.Text;
                if (Sd.Name == "b13")
                    Sd.InnerText= textBoxB13.Text ;
                if (Sd.Name == "b23")
                    Sd.InnerText= textBoxB23.Text;
                if (Sd.Name == "c12")
                    Sd.InnerText= textBoxc12.Text;
                if (Sd.Name == "c13")
                    Sd.InnerText= textBoxc13.Text;
                if (Sd.Name == "c23")
                    Sd.InnerText= textBoxc23.Text;
                if (Sd.Name == "d12")
                    Sd.InnerText= textBoxD12.Text;
                if (Sd.Name == "d45")
                    Sd.InnerText= textBoxd45.Text;
                if (Sd.Name == "d46")
                    Sd.InnerText= textBoxd46.Text ;
                if (Sd.Name == "d56")
                    Sd.InnerText= textBoxd56.Text ;
                if (Sd.Name == "c45")
                    Sd.InnerText= textBoxc45.Text ;
                if (Sd.Name == "d78")
                    Sd.InnerText = textBoxD78.Text;
            }
            doc.Save("../Debug/Judgemartia.xml");

            // 触发事件， 传递自定义参数
            OnDataChange(this, new DataChangeEventArgs(textBox10.Text, textBox41.Text, textBox42.Text, textBox43.Text, textBox44.Text, textBox45.Text, textBox46.Text, textBox47.Text, textBox48.Text, textBox49.Text));
        }

        private void JudgmentMatrix_Load(object sender, EventArgs e)
        {
            calcul();
        }
        public void calcul(){

            Dictionary<string,double> dic =new Dictionary<string,double>();

            XmlDocument doc = new XmlDocument();
            doc.Load("../Debug/Judgemartia.xml");

            foreach (XmlNode Sd in doc.DocumentElement.ChildNodes)
            {
                if (Sd.Name == "b12"){
                    textBoxB12.Text = Sd.InnerText.Trim();
                dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "b13"){
                    textBoxB13.Text = Sd.InnerText.Trim();
                dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "b23"){
                    textBoxB23.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "c12"){
                    textBoxc12.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "c13"){
                    textBoxc13.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "c23"){
                    textBoxc23.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d12"){
                    textBoxD12.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d45"){
                    textBoxd45.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d46"){
                    textBoxd46.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d56"){
                    textBoxd56.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "c45"){
                    textBoxc45.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
                if (Sd.Name == "d78"){
                    textBoxD78.Text = Sd.InnerText.Trim();
                    dic.Add(Sd.Name,Convert.ToDouble(Sd.InnerText.Trim()));}
            }

            double[,] B = new double[3, 3]{{1,dic["b12"],dic["b13"]},
                                        {1/dic["b12"],1,dic["b23"]},
                                        {1/dic["b13"],1/dic["b23"],1}};
            double[,] C123 = new double[3, 3]{{1,dic["c12"],dic["c13"]},
                                        {1/dic["c12"],1,dic["c23"]},
                                        {1/dic["c13"],1/dic["c23"],1}};
            double[,] C45 = new double[2, 2]{
                                                {1,dic["c45"]},
                                                {1/dic["c45"],1}
            };
            double[,] D12 = new double[2,2]{{1,dic["d12"]},
                                        {1/dic["d12"],1}};
            double[,] D567 = new double[3, 3]{{1,dic["d45"],dic["d46"]},
                                        {1/dic["d45"],1,dic["d56"]},
                                        {1/dic["d46"],1/dic["d56"],1}};
            double[,] D89 = new double[2, 2]{{1,dic["d78"]},
                                                {1/dic["d78"],1}};
            var Qz_B = getMaxEigenValues(B, 3);//B1層權重
            var Qz_c123 = getMaxEigenValues(C123, 3);
            var Qz_C45 = getMaxEigenValues(C45, 2);
            var Qz_D12 = getMaxEigenValues(D12, 2);
            var Qz_D567 = getMaxEigenValues(D567, 3);
            var Qz_D89 = getMaxEigenValues(D89, 2);
            double[] Final_D = new double[9];
            Final_D[0] = Qz_B[0] * Qz_c123[0] * Qz_D12[0];
            Final_D[1] = Qz_B[0] * Qz_c123[0] * Qz_D12[1];
            Final_D[2] = Qz_B[0] * Qz_c123[1];
            Final_D[3] = Qz_B[0] * Qz_c123[2] * Qz_D567[0];
            Final_D[4] = Qz_B[0] * Qz_c123[2] * Qz_D567[1];
            Final_D[5] = Qz_B[0] * Qz_c123[2] * Qz_D567[2];

            
            //Final_D[6] = Qz_B[1] * Qz_C45[0] * Qz_D89[0];
            //Final_D[7] = Qz_B[1] * Qz_C45[0] * Qz_D89[1];
            //Final_D[8] = Qz_B[1] * Qz_C45[1];
            Final_D[6] = Qz_B[1];

            textBox10.Text = Final_D[0].ToString("N4");
            textBox41.Text = Final_D[1].ToString("N4");
            textBox42.Text = Final_D[2].ToString("N4");
            textBox43.Text = Final_D[3].ToString("N4");
            textBox44.Text = Final_D[4].ToString("N4");
            textBox45.Text = Final_D[5].ToString("N4");
            textBox46.Text = Final_D[6].ToString("N4");
            textBox47.Text = Final_D[7].ToString("N4");
            textBox48.Text = Final_D[8].ToString("N4");
            textBox49.Text = Qz_B[2].ToString("N4");
        }
        private void button1_Click(object sender, EventArgs e)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("../Debug/Judgemartia.xml");
            foreach (XmlNode Sd in doc.DocumentElement.ChildNodes)
            {
                if (Sd.Name == "b12")
                    Sd.InnerText = textBoxB12.Text;
                if (Sd.Name == "b13")
                    Sd.InnerText = textBoxB13.Text;
                if (Sd.Name == "b23")
                    Sd.InnerText = textBoxB23.Text;
                if (Sd.Name == "c12")
                    Sd.InnerText = textBoxc12.Text;
                if (Sd.Name == "c13")
                    Sd.InnerText = textBoxc13.Text;
                if (Sd.Name == "c23")
                    Sd.InnerText = textBoxc23.Text;
                if (Sd.Name == "d12")
                    Sd.InnerText = textBoxD12.Text;
                if (Sd.Name == "d45")
                    Sd.InnerText = textBoxd45.Text;
                if (Sd.Name == "d46")
                    Sd.InnerText = textBoxd46.Text;
                if (Sd.Name == "d56")
                    Sd.InnerText = textBoxd56.Text;
                if (Sd.Name == "c45")
                    Sd.InnerText = textBoxc45.Text;
                if (Sd.Name == "d78")
                    Sd.InnerText = textBoxD78.Text;
            }
            doc.Save("../Debug/Judgemartia.xml");
            calcul();
        }

        public string TextBox01Text
        {
            set { this.textBox10.Text = value; }
            get { return this.textBox10.Text; }
        }
        public string TextBox02Text
        {
            set { this.textBox41.Text = value; }
            get { return this.textBox41.Text; }
        }
        public string TextBox03Text
        {
            set { this.textBox42.Text = value; }
            get { return this.textBox42.Text; }
        }
        public string TextBox04Text
        {
            set { this.textBox43.Text = value; }
            get { return this.textBox43.Text; }
        }
        public string TextBox05Text
        {
            set { this.textBox44.Text = value; }
            get { return this.textBox44.Text; }
        }
        public string TextBox06Text
        {
            set { this.textBox45.Text = value; }
            get { return this.textBox45.Text; }
        }
        public string TextBox07Text
        {
            set { this.textBox46.Text = value; }
            get { return this.textBox46.Text; }
        }
        public string TextBox08Text
        {
            set { this.textBox47.Text = value; }
            get { return this.textBox47.Text; }
        }
        public string TextBox09Text
        {
            set { this.textBox48.Text = value; }
            get { return this.textBox48.Text; }
        }
        public string TextBox10Text
        {
            set { this.textBox49.Text = value; }
            get { return this.textBox49.Text; }
        }
        //public string TextBox11Text
        //{
        //    set { this.textBox50.Text = value; }
        //    get { return this.textBox50.Text; }
        //}

        void InitTextBoxRemind()
        {
            calcul();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)   //B12
        {
            check_Num(this.textBoxB12, this.textBox4);
        }
        //b13
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxB13, this.textBox7);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxB23, this.textBox8);
        }

        private bool CheckMatrix()
        {
            if (textBoxB12.Text.Trim().Length == 0 || textBoxB13.Text.Trim().Length == 0 || textBoxB23.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查A层判断矩阵");
                return false;
            }
            if (textBoxc12.Text.Trim().Length == 0 || textBoxc13.Text.Trim().Length == 0 || textBoxc23.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查B1层判断矩阵");
                return false;
            }
            if (textBoxD12.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查C1层判断矩阵");
                return false;
            }
            if (textBoxd45.Text.Trim().Length == 0 || textBoxd46.Text.Trim().Length == 0 || textBoxd56.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查C3层判断矩阵");
                return false;
            }
            if (textBoxc45.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查B2层判断矩阵");
                return false;
            }
            if (textBoxD78.Text.Trim().Length == 0)
            {
                MessageBox.Show("请检查C4层判断矩阵");
                return false;
            }
            return true;
        }

        private double[] normalize(double[][] m)
        {

            int row = m.Length;
            int column = m[2].Length;
            double[] Sum_column = new double[column];
            double[] w = new double[row];

            for (int i = 0; i < column; i++)
            {
                Sum_column[i] = 0;
                for (int j = 0; j < row; j++)
                {
                    Sum_column[i] += m[j][i];
                }
            }
            //进行归一化,计算特征向量W

            for (int i = 0; i < row; i++)
            {
                w[i] = 0;
                for (int j = 0; j < column; j++)
                {
                    w[i] += m[i][j] / Sum_column[j];
                }
                w[i] /= row;
            }
            return w;
        }
        private double[] normal(double[][] n)
        {

            int row = n.Length;
            int column = n[1].Length;
            double[] Sum_column = new double[column];
            double[] w = new double[row];

            for (int i = 0; i < column; i++)
            {
                Sum_column[i] = 0;
                for (int j = 0; j < row; j++)
                {
                    Sum_column[i] += n[j][i];
                }
            }
            //进行归一化,计算特征向量W

            for (int i = 0; i < row; i++)
            {
                w[i] = 0;
                for (int j = 0; j < column; j++)
                {
                    w[i] += n[i][j] / Sum_column[j];
                }
                w[i] /= row;
            }
            return w;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxc12, this.textBox14);
        }



        private void textBox13_TextChanged_1(object sender, EventArgs e)
        {
            check_Num(this.textBoxc13, this.textBox18);
        }



        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxc23, this.textBox19);
        }



        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxD12, this.textBox22);
        }

       
        //矩阵textbox限制输入  
        private void check_Num(TextBox inputText, TextBox outputText)
        {
            string pattern = @"^[0-9]*$";
            string param1 = null;
            Match m = Regex.Match(inputText.Text, pattern);   // 匹配正则表达式
            if (!m.Success || string.IsNullOrEmpty(inputText.Text))   // 输入的不是数字
            {
                inputText.Text = "1";   // textBox内容不变

                // 将光标定位到文本框的最后
                inputText.SelectionStart = inputText.Text.Length;
            }
            else   // 输入的是数字
            {

                if (Convert.ToDecimal(inputText.Text) >= 1 && Convert.ToDecimal(inputText.Text) <= 9 )
                {
                    param1 = inputText.Text;   // 将现在textBox的值保存下来
                    outputText.Text = (1.0 / Convert.ToDouble(inputText.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("请输入1到9之间的整数！");
                    inputText.Text = "";
                }
            }
        }
        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxd45, this.textBox27);
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxd46, this.textBox31);
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxd56, this.textBox32);
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxc45, this.textBox34);
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            check_Num(this.textBoxD78, this.textBox38);
        }

        



        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }








    }

    /// <summary>
    /// 自定义事件参数类型，根据需要可设定多种参数便于传递
    /// </summary>
    public class DataChangeEventArgs : EventArgs
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; } 
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }
        public string G { get; set; }
        public string I { get; set; }
        public string J { get; set; }
        public string H { get; set; }
      
        public DataChangeEventArgs(string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10)
        {
            A = s1;
            B = s2;
            C = s3;
            D = s4;
            E = s5;
            F = s6;
            G = s7;
            H = s8;
            I = s9;
            J = s10;

        }
    }

}
