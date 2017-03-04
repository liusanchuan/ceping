﻿using System;
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
        public void fill( Double[][] series,
         int Pub_cedian,String[] X)
        {
            

            chart1.Series[0].Name = "测点" + Pub_cedian + "-应力";
            chart1.Series[1].Name = "测点" + Pub_cedian + "-温度";
            chart1.Series[2].Name = "测点" + Pub_cedian + "-震动";
            chart1.Series[3].Name = "测点" + Pub_cedian + "-变形";
            this.Text="查看区间：从"+ Convert.ToString(Convert.ToDateTime(X[X.Length-1]).ToString("yyyy/MM/dd hh:mm"))+"到"+Convert.ToString(Convert.ToDateTime(X[0]).ToString("yyyy/MM/dd hh:mm")) ;
            for(int i=0;i<X.Length;i++){
                X[i]=Convert.ToString(Convert.ToDateTime(X[i]).ToString("hh:mm:ss"));
            }
            for (int seriesNum=0; seriesNum< 4; seriesNum++)
            {
                    chart1.Series[seriesNum].Points.DataBindXY(X, series[seriesNum]);
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

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    doCheckBox();
        //}
        //void doCheckBox()
        //{

        //    if (checkBox1.Checked == false)
        //    {
        //        chart1.Series[0].IsVisibleInLegend = false;
        //    }else
        //    {
        //        chart1.Series[0].IsVisibleInLegend = true;
        //    }
        //    if (checkBox2.Checked == false)
        //    {
        //        chart1.Series[1].IsVisibleInLegend = false;
        //    }
        //    else
        //    {
        //        chart1.Series[1].IsVisibleInLegend = true;

        //    }
        //    if (checkBox2.Checked == false)
        //    {
        //        chart1.Series[2].IsVisibleInLegend = false;
        //    }
        //    else
        //    {
        //        chart1.Series[2].IsVisibleInLegend = true;

        //    }
        //    if (checkBox3.Checked == false)
        //    {
        //        chart1.Series[3].IsVisibleInLegend = false;
        //    }
        //    else
        //    {
        //        chart1.Series[3].IsVisibleInLegend = true;

        //    }
        //}

        //private void checkBox3_CheckedChanged(object sender, EventArgs e)
        //{
        //    doCheckBox();
        //}

        //private void checkBox4_CheckedChanged(object sender, EventArgs e)
        //{
        //    doCheckBox();

        //}

        //private void checkBox2_CheckedChanged(object sender, EventArgs e)
        //{
        //    doCheckBox();
        //}
 
    }
}
