using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpGLWinformsApplication1
{
    public partial class history_data_MDI_child : Form
    {
        public history_data_MDI_child()
        {
            InitializeComponent();
        }
        public void fill( List<List<Double>> Ser,
         int Pub_cedian,List<List<String>> X_all,bool[]check_box)
        {
            chart1.Series[0].Name = "测点" + Pub_cedian + "-应力";
            chart1.Series[1].Name = "测点" + Pub_cedian + "-温度";
            chart1.Series[2].Name = "测点" + Pub_cedian + "-震动";
            chart1.Series[3].Name = "测点" + Pub_cedian + "-变形";
            for (int i = 0; i < check_box.Length; i++)
            {
                if (!check_box[i])
                {
                    chart1.Series[i].IsVisibleInLegend = false;
                }
            }
            int temp=0,index=0;
            for (int i = 0; i < X_all.Count; i++)
            {
                if (temp<X_all[i].Count)
                {
                    temp = X_all[i].Count;
                    index = i;
                }
            }
            this.Text = "查看区间：从" + Convert.ToString(Convert.ToDateTime(X_all[index][0]).ToString("yyyy/MM/dd hh:mm")) + "到" + Convert.ToString(Convert.ToDateTime(X_all[index][X_all[index].Count - 1]).ToString("yyyy/MM/dd hh:mm"));
            for (int seriesNum=0; seriesNum< Ser.Count; seriesNum++)
            {
                for (int i = 0; i < Ser[seriesNum].Count; i++)
                {
                    chart1.Series[seriesNum].Points.AddXY(Convert.ToString(Convert.ToDateTime(X_all[seriesNum][i]).ToString("hh:mm:ss")), Ser[seriesNum][i]);
                }
            }
                    
        }



        private void history_data_MDI_child_Paint(object sender, PaintEventArgs e)
        {
            chart1.Width = this.Width;
            chart1.Height = this.Height-40;
        }

        private void history_data_MDI_child_Load(object sender, EventArgs e)
        {

        }

        private void history_data_MDI_child_Resize(object sender, EventArgs e)
        {
            chart1.Width = this.Width-20;
            chart1.Height = this.Height - 40;
            
        }
    }
}
