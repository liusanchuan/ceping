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
    public partial class CanshuTU : Form
    {
        public CanshuTU()
        {
            InitializeComponent();
        }

        private void CanshuTU_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.DataBindXY(CanShuBianhuaZhi.x,CanShuBianhuaZhi.Cal);
        }
    }
}
