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
    public partial class history_data_series : Form
    {
        MdiLayout current_layout = new MdiLayout();

        public history_data_series()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            current_layout = MdiLayout.TileHorizontal;
        }
        private void history_data_series_Load(object sender, EventArgs e)
        {
            
        }
        public void add_aChild( Double[][] series,
         int Pub_cedian,String[]X)
        {
            history_data_MDI_child h1 = new history_data_MDI_child();
            h1.MdiParent = this;
            h1.Show();
            h1.fill(series, Pub_cedian,X);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
            current_layout = MdiLayout.TileHorizontal;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
            current_layout = MdiLayout.TileVertical;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void history_data_series_FormClosing(object sender, FormClosingEventArgs e)
        {
            history_series_from.history_series_fo = 2;
            e.Cancel = true;
            this.Visible = false;
        }

        private void history_data_series_Resize(object sender, EventArgs e)
        {
            this.LayoutMdi(current_layout);
        }

        private void history_data_series_Paint(object sender, PaintEventArgs e)
        {
            this.LayoutMdi(current_layout);
        }

        private void history_data_series_ControlAdded(object sender, ControlEventArgs e)
        {
            this.LayoutMdi(current_layout);

        }
    }
}
