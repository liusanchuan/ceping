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
    public partial class AssessSoftware : Form
    {
        
        public AssessSoftware()
        {
            InitializeComponent();
           
        }

        public int check()
        {

            //首先验证是不是最高管理员
            if (textBox1.Text == "Admin" && textBox2.Text == "root") {
                GuanLiYuan.ma = true;
                return 3;
            }

            int response_num = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlConnection.str);
            XmlNodeList all_user = doc.SelectSingleNode("userInfo").ChildNodes;
            foreach (XmlNode Seted_user in all_user)
            {
                XmlNode user_name = Seted_user.SelectSingleNode("user_name");
                if (textBox1.Text == user_name.InnerText)
                {
                    XmlNode user_password = Seted_user.SelectSingleNode("password");
                    if (user_password.InnerText == textBox2.Text)
                    {
                        response_num = 3;   //登录成功
                        break;
                    }
                    else
                    {
                        response_num = 2;   //密码错误
                        break;
                    }
                }
                else
                {
                    response_num = 1;       //无此用户
                }
            }
            return response_num;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int response_num = check();
            if (response_num == 3)
            {
                this.Visible = false;
                Main_Form Zhujiemian = new Main_Form();
                Zhujiemian.ShowDialog();
                this.Close();
                Zhujiemian.Dispose();
                

            }
            else if (response_num == 2)
            {
                MessageBox.Show("密码错误");
            }
            else if (response_num == 1)
            {
                MessageBox.Show("此用户名未注册");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void AssessSoftware_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
