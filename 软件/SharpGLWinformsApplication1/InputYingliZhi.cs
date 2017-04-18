using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SharpGLWinformsApplication1
{
    public partial class InputYingliZhi : Form
    {
        public InputYingliZhi()
        {
            InitializeComponent();
        }
        private bool CheckFormat(String tb_text)
        {
            if (tb_text.Trim().Length == 0)
            {
                MessageBox.Show("请输入应力值");
                return false;
            }
            else
            {
                string pattern = @"^-?\d+\.?\d*$";
                Match m = Regex.Match(tb_text, pattern);   // 匹配正则表达式
                if (!m.Success)   // 输入的不是数字
                {
                    MessageBox.Show(tb_text+"不是合法值，请正确输入应力值");
                    return false;
                }
            }
            return true;
        }
        private Double Cal_R(String tb_text)
        {
            Double[] R ={
                            0.9,
                            0.95,
                            0.99,
                            0.999,
                            0.9999,
                            0.99999,
                            0.999999
                       };
            Double[] GaiLv_table ={
                               0.425509,
                               0.452799,
                               0.506856,
                               0.571316,
                               0.627559,
                               0.679278,
                               0.729897
                           };
            Double GaiLv = 345.0 / Convert.ToDouble(tb_text);
            for (int i = 0; i < GaiLv_table.Length; i++)
            {
                if (GaiLv < GaiLv_table[i])
                {
                    float a, b;
                    if (i == 0)
                    {
                        i = i + 1;
                    }
                    //直线两点式
                    return (R[i + 1] - R[i]) / (GaiLv_table[i + 1] - GaiLv_table[i]) * (GaiLv - GaiLv_table[i]) + R[i];
                    
                }
            }
            int J=GaiLv_table.Length-1;
            return (R[J + 1] - R[J]) / (GaiLv_table[J + 1] - GaiLv_table[J]) * (GaiLv - GaiLv_table[J]) + R[J];
        }

        private void Cal_QiangDu()
        {
            Double[] R;
            if(!(
                CheckFormat(textBox52.Text)&&
                CheckFormat(textBox51.Text)&&
                CheckFormat(textBox4.Text )&&
                CheckFormat(textBox32.Text)&&
                CheckFormat(textBox31.Text)&&
                CheckFormat(textBox24.Text)&&
                CheckFormat(textBox23.Text)&&
                CheckFormat(textBox22.Text)&&
                CheckFormat(textBox21.Text)&&
                CheckFormat(textBox14.Text)&&
                CheckFormat(textBox13.Text)&&
                CheckFormat(textBox12.Text)&&
                CheckFormat(textBox11.Text)
                ))
            {
                return;
            }
            
            try
            {
                Double R52 = 345.0 / Convert.ToDouble(textBox52.Text);
                Double R51 = 345.0 / Convert.ToDouble(textBox51.Text);
                Double R4 = 345.0 / Convert.ToDouble( textBox4.Text);
                Double R32 = 345.0 / Convert.ToDouble(textBox32.Text);
                Double R31 = 345.0 / Convert.ToDouble(textBox31.Text);
                Double R24 = 345.0 / Convert.ToDouble(textBox24.Text);
                Double R23 = 345.0 / Convert.ToDouble(textBox23.Text);
                Double R22 = 345.0 / Convert.ToDouble(textBox22.Text);
                Double R21 = 345.0 / Convert.ToDouble(textBox21.Text);
                Double R14 = 345.0 / Convert.ToDouble(textBox14.Text);
                Double R13 = 345.0 / Convert.ToDouble(textBox13.Text);
                Double R12 = 345.0 / Convert.ToDouble(textBox12.Text);
                Double R11 = 345.0 / Convert.ToDouble(textBox11.Text); 


               R = new Double[5]{
                    R11*R12*Math.Pow(R13,8)*Math.Pow(R14,20),
                    R21*R22*Math.Pow(R23,8)*Math.Pow(R24,20),
                    1-(1-R31)*(1-R32),
                    R4,
                    1-(1-R51)*(1-R52)
                };
               textBoxR1.Text = R[0].ToString("0.000");
               textBoxR2.Text = R[1].ToString("0.000");
               textBoxR3.Text = R[2].ToString("0.000");
               textBoxR4.Text = R[3].ToString("0.000");
               textBoxR5.Text = R[4].ToString("0.000");

               Double RS = R[0] * R[1] * Math.Pow(R[2], 2) * R[3] * Math.Pow(R[4], 8);
               textBox_KKX.Text = RS.ToString("0.000");
            }
            catch (Exception E)
            {
                MessageBox.Show("输入值有误");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Cal_QiangDu();
        }
    }
}
