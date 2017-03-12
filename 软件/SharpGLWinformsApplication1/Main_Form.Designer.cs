namespace SharpGLWinformsApplication1
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.skinMenuStrip1 = new CCWin.SkinControl.SkinMenuStrip();
            this.可靠性评估ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.裂纹快速评估ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.扩展速率评估ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史数据查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.skinMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(850, 665);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(214, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 56);
            this.label1.TabIndex = 2;
            this.label1.Text = "欢迎使用此软件";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -141);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(852, 835);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // skinMenuStrip1
            // 
            this.skinMenuStrip1.AllowDrop = true;
            this.skinMenuStrip1.Arrow = System.Drawing.Color.Transparent;
            this.skinMenuStrip1.Back = System.Drawing.Color.White;
            this.skinMenuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.skinMenuStrip1.BackgroundImage = global::SharpGLWinformsApplication1.Properties.Resources._1261;
            this.skinMenuStrip1.BackRadius = 4;
            this.skinMenuStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinMenuStrip1.Base = System.Drawing.Color.SteelBlue;
            this.skinMenuStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinMenuStrip1.BaseForeAnamorphosis = false;
            this.skinMenuStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinMenuStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinMenuStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.skinMenuStrip1.BaseItemAnamorphosis = true;
            this.skinMenuStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.BaseItemBorderShow = true;
            this.skinMenuStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinMenuStrip1.BaseItemDown")));
            this.skinMenuStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinMenuStrip1.BaseItemMouse")));
            this.skinMenuStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.BaseItemRadius = 4;
            this.skinMenuStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinMenuStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinMenuStrip1.Fore = System.Drawing.Color.Black;
            this.skinMenuStrip1.HoverFore = System.Drawing.Color.White;
            this.skinMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinMenuStrip1.ItemAnamorphosis = true;
            this.skinMenuStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.ItemBorderShow = true;
            this.skinMenuStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinMenuStrip1.ItemRadius = 4;
            this.skinMenuStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.可靠性评估ToolStripMenuItem,
            this.裂纹快速评估ToolStripMenuItem,
            this.扩展速率评估ToolStripMenuItem,
            this.历史数据查询ToolStripMenuItem,
            this.添加数据ToolStripMenuItem});
            this.skinMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.skinMenuStrip1.Name = "skinMenuStrip1";
            this.skinMenuStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinMenuStrip1.Size = new System.Drawing.Size(850, 28);
            this.skinMenuStrip1.SkinAllColor = true;
            this.skinMenuStrip1.TabIndex = 4;
            this.skinMenuStrip1.Text = "skinMenuStrip1";
            this.skinMenuStrip1.TitleAnamorphosis = true;
            this.skinMenuStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinMenuStrip1.TitleRadius = 4;
            this.skinMenuStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 可靠性评估ToolStripMenuItem
            // 
            this.可靠性评估ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.可靠性评估ToolStripMenuItem.Image = global::SharpGLWinformsApplication1.Properties.Resources.org_zwanoo_android_speedtest_24px_1068411_easyicon_net;
            this.可靠性评估ToolStripMenuItem.Name = "可靠性评估ToolStripMenuItem";
            this.可靠性评估ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.可靠性评估ToolStripMenuItem.Text = "可靠性评估";
            this.可靠性评估ToolStripMenuItem.Click += new System.EventHandler(this.可靠性评估ToolStripMenuItem_Click);
            // 
            // 裂纹快速评估ToolStripMenuItem
            // 
            this.裂纹快速评估ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.裂纹快速评估ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.裂纹快速评估ToolStripMenuItem.Image = global::SharpGLWinformsApplication1.Properties.Resources.miui_control_panel_24px_1068376_easyicon_net;
            this.裂纹快速评估ToolStripMenuItem.Name = "裂纹快速评估ToolStripMenuItem";
            this.裂纹快速评估ToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.裂纹快速评估ToolStripMenuItem.Text = "裂纹快速查找";
            this.裂纹快速评估ToolStripMenuItem.Click += new System.EventHandler(this.裂纹快速评估ToolStripMenuItem_Click);
            // 
            // 扩展速率评估ToolStripMenuItem
            // 
            this.扩展速率评估ToolStripMenuItem.Image = global::SharpGLWinformsApplication1.Properties.Resources.android_browser_24px_1068289_easyicon_net;
            this.扩展速率评估ToolStripMenuItem.Name = "扩展速率评估ToolStripMenuItem";
            this.扩展速率评估ToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.扩展速率评估ToolStripMenuItem.Text = "扩展速率评估";
            this.扩展速率评估ToolStripMenuItem.Click += new System.EventHandler(this.扩展速率评估ToolStripMenuItem_Click);
            // 
            // 历史数据查询ToolStripMenuItem
            // 
            this.历史数据查询ToolStripMenuItem.Image = global::SharpGLWinformsApplication1.Properties.Resources.android_monitor_24px_1068300_easyicon_net;
            this.历史数据查询ToolStripMenuItem.Name = "历史数据查询ToolStripMenuItem";
            this.历史数据查询ToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.历史数据查询ToolStripMenuItem.Text = "历史数据查询";
            this.历史数据查询ToolStripMenuItem.Click += new System.EventHandler(this.历史数据查询ToolStripMenuItem_Click);
            // 
            // 添加数据ToolStripMenuItem
            // 
            this.添加数据ToolStripMenuItem.Image = global::SharpGLWinformsApplication1.Properties.Resources.aurorasoftworks_quadrant_ui_standard_24px_1068318_easyicon_net;
            this.添加数据ToolStripMenuItem.Name = "添加数据ToolStripMenuItem";
            this.添加数据ToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.添加数据ToolStripMenuItem.Text = "管理员界面";
            this.添加数据ToolStripMenuItem.Click += new System.EventHandler(this.添加数据ToolStripMenuItem_Click);
            // 
            // Main_Form
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(850, 693);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.skinMenuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.skinMenuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "评估软件";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.skinMenuStrip1.ResumeLayout(false);
            this.skinMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 可靠性评估ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 裂纹快速评估ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 扩展速率评估ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史数据查询ToolStripMenuItem;
        private CCWin.SkinControl.SkinMenuStrip skinMenuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem 添加数据ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}