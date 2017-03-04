        using SharpGLWinformsApplication1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SharpGLWinformsApplication1
{
    public partial class KuoZhanSuLv : UserControl
    {
        public KuoZhanSuLv()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection sc = new sqlConnection();
            string[] saveData = new string[]{
                textBox1_D_Kth.Text.Trim().ToString(),
                textBox2_E.Text.Trim().ToString(),
                textBox3_KC_max.Text.Trim().ToString(),
                textBox4_KC_min.Text.Trim().ToString(),
                textBox5_Kc.Text.Trim().ToString(),
                textBox1_a0.Text.Trim().ToString()
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
                sc.Save_SQL_Data(saveData, "ExpandVelocity");
            double E = Convert.ToDouble(textBox2_E.Text);
            double D_kth = Convert.ToDouble(textBox1_D_Kth.Text),
                Kc = Convert.ToDouble(textBox5_Kc.Text), 
                KCmax = Convert.ToDouble(textBox3_KC_max.Text),
                KCmin = Convert.ToDouble(textBox4_KC_min.Text),
                D_KC, D_K, R;
            
            R = KCmax / KCmin;
            double a0 , a1; //积分上下
            a0 = Convert.ToDouble(textBox1_a0.Text);
            a1=(1/Math.PI)*Math.Pow((Kc/(1.12*KCmax)),2);
            double H;  //步长
            double sum = 0;
            H = Math.Abs(a0 - a1) / 10000;
            D_KC = KCmax - KCmin;


            for (double i = 0; i < 10000; i++)
            {
                double a = a0 + H * (i + 0.5);
                D_K = D_KC * Math.Sqrt(Math.PI * a);
                double s1 = H * (Math.Pow(E, 2) / 48 * Math.Pow(D_K + D_kth, -0.5) * Math.Pow((1 / D_K - 1 / ((1 - R) * Kc)), 1.5));
                sum += s1;
            }
            label1.Text = Convert.ToString(sum/0.01)+"\n------说明-----\n:此结构还可\n承受"+Convert.ToString((int)(sum/0.01))+"次冲击";
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void KuoZhanSuLv_Load(object sender, EventArgs e)
        {
            sqlConnection sc = new sqlConnection();
            string[] ReadData = sc.Read_SQL_Data("ExpandVelocity");
            if (ReadData[1] != null)
            {
                int i = 0;
                try
                {
                    textBox1_D_Kth.Text = ReadData[i++];
                    textBox2_E.Text = ReadData[i++];
                    textBox3_KC_max.Text = ReadData[i++];
                    textBox4_KC_min.Text = ReadData[i++];
                    textBox5_Kc.Text = ReadData[i++];
                    textBox1_a0.Text = ReadData[i++];
                }
                catch (Exception EE)
                {

                }
            }
        }
    }
}