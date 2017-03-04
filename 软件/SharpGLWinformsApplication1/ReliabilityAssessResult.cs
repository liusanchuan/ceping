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
    public partial class ReliabilityAssessResult : Form
    {
        
        public ReliabilityAssessResult()
        {
            InitializeComponent();
            label.Text = realiable.eventual;
         }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ReliabilityAssessResult_Load(object sender, EventArgs e)
        {

        }


    }
}
