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
    public partial class Main_Form : Form
    {
        public realiable realiable = new realiable();
        public Main_Form()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void groupBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }


        private void 可靠性评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            realiable.Show();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(realiable);
        }

        private void 裂纹快速评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liewenpinggu Liewenpinggu = new Liewenpinggu();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(Liewenpinggu);
        }

        private void 历史数据查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyData hd = new historyData();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(hd);
        }

        private void 扩展速率评估ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KuoZhanSuLv kuzhan = new KuoZhanSuLv();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(kuzhan);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void 添加数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(GuanLiYuan.ma==true){
                adddata add = new adddata();
            groupBox1.Controls.Clear();
            groupBox1.Controls.Add(add);
            }else{
                MessageBox.Show("非管理员账户不可进入后台管理界面");
            }
            
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


    }
}
