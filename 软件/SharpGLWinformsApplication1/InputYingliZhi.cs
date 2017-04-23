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
    //定义应力回传委托
    public delegate void TransfDelegate(String stress_value);
    public partial class InputYingliZhi : Form
    {
        public InputYingliZhi()
        {
            InitializeComponent();
        }
        //声明委托
        public event TransfDelegate TransfEvent;
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
            //超过可靠性系数大于0.999999的情况
            if (GaiLv < 4)
            {
                return (GaiLv - 4) * (0.000001 / 3.27) + 1;
            }
            else
            {
                return 1;
            }
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
                Double R52 = Cal_R(textBox52.Text);
                Double R51 = Cal_R(textBox51.Text);
                Double R4 =  Cal_R( textBox4.Text);
                Double R32 = Cal_R(textBox32.Text);
                Double R31 = Cal_R(textBox31.Text);
                Double R24 = Cal_R(textBox24.Text);
                Double R23 = Cal_R(textBox23.Text);
                Double R22 = Cal_R(textBox22.Text);
                Double R21 = Cal_R(textBox21.Text);
                Double R14 = Cal_R(textBox14.Text);
                Double R13 = Cal_R(textBox13.Text);
                Double R12 = Cal_R(textBox12.Text);
                Double R11 = Cal_R(textBox11.Text); 
               R = new Double[5]{
                    R11*R12*Math.Pow(R13,8)*Math.Pow(R14,20),
                    R21*R22*Math.Pow(R23,8)*Math.Pow(R24,20),
                    1-(1-R31)*(1-R32),
                    R4,
                    1-(1-R51)*(1-R52)
                };
               textBoxR1.Text = R[0].ToString();
               textBoxR2.Text = R[1].ToString();
               textBoxR3.Text = R[2].ToString();
               textBoxR4.Text = R[3].ToString();
               textBoxR5.Text = R[4].ToString();

               Double RS = R[0] * R[1] * Math.Pow(R[2], 2) * R[3] * Math.Pow(R[4], 8);
               textBox_KKX.Text = RS.ToString();
                SaveDatabase();

            }
            catch (Exception E)
            {
                MessageBox.Show("输入值有误");
            }
        }
        private void SaveDatabase()
        {
            DataClasses1DataContext dc = Dataclass1Singlon.getSinglon();
            StressInput stress_input = dc.StressInput.FirstOrDefault();
            try {
                dc.StressInput.DeleteOnSubmit(stress_input);
                dc.SubmitChanges();
            }catch(Exception E)
            {
                ;
            }
            try {
                stress_input = new StressInput()
                {
                    kc11 = Convert.ToDouble(textBox11.Text),
                    kc12 = Convert.ToDouble(textBox12.Text),
                    kc13 = Convert.ToDouble(textBox13.Text),
                    kc14 = Convert.ToDouble(textBox14.Text),
                    kc21 = Convert.ToDouble(textBox21.Text),
                    kc22 = Convert.ToDouble(textBox22.Text),
                    kc23 = Convert.ToDouble(textBox23.Text),
                    kc24 = Convert.ToDouble(textBox24.Text),
                    kc31 = Convert.ToDouble(textBox31.Text),
                    kc32 = Convert.ToDouble(textBox32.Text),
                    kc4 = Convert.ToDouble(textBox4.Text),
                    kc51 = Convert.ToDouble(textBox51.Text),
                    kc52 = Convert.ToDouble(textBox52.Text)
                };
                dc.StressInput.InsertOnSubmit(stress_input);
                dc.SubmitChanges();
            }catch(Exception E)
            {
                ;
            }
        }
        private void ReadDatabase()
        {
            try
            {
                DataClasses1DataContext dc = Dataclass1Singlon.getSinglon();
                var stress_input = from i in dc.StressInput
                                   where i.Id == 0
                                   select i;

                textBox11.Text = stress_input.First().kc11.ToString();
                textBox12.Text = stress_input.First().kc12.ToString();
                textBox13.Text = stress_input.First().kc13.ToString();
                textBox14.Text = stress_input.First().kc14.ToString();
                textBox21.Text = stress_input.First().kc21.ToString();
                textBox22.Text = stress_input.First().kc22.ToString();
                textBox23.Text = stress_input.First().kc23.ToString();
                textBox24.Text = stress_input.First().kc24.ToString();
                textBox31.Text = stress_input.First().kc31.ToString();
                textBox32.Text = stress_input.First().kc32.ToString();
                textBox4.Text = stress_input.First().kc4.ToString();
                textBox51.Text = stress_input.First().kc51.ToString();
                textBox52.Text = stress_input.First().kc52.ToString();

            }
            catch (Exception E)
            {
                ;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Cal_QiangDu();
            //触发委托事件
            TransfEvent(textBox_KKX.Text);
        }

        private void InputYingliZhi_Load(object sender, EventArgs e)
        {
            ReadDatabase();
        }
    }
}
