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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void PicBox_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public int check()
        {
            int response_num = 1;
            XmlDocument doc = new XmlDocument();
            doc.Load("userInfo.xml");
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
                    }
                    else
                    {
                        response_num = 2;   //密码错误
                    }
                }
                else
                {
                    response_num = 1;       //无此用户
                }
            }
            return response_num;
        }
        private void PicBox_Regester_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            int Num = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlConnection.str);

            int response_num = check();
            if (response_num == 1)  //无此用户
            {
                //判断密码和确认密码是否相同
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("两次输入的密码不同，请重新输入");
                    textBox3.Text = textBox2.Text = "";
                    return;
                }
                XmlNode bookstore = doc.SelectSingleNode("userInfo");
                XmlElement user = doc.CreateElement("user");
                user.SetAttribute("ID", Convert.ToString(Num++));
                XmlElement user_name = doc.CreateElement("user_name");
                user_name.InnerText = textBox1.Text;
                XmlElement user_password = doc.CreateElement("password");
                user_password.InnerText = textBox2.Text;
                user.AppendChild(user_name);
                user.AppendChild(user_password);
                bookstore.AppendChild(user);
                doc.Save(xmlConnection.str);
                 MessageBox.Show("注册成功","",MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("此用户名已被占用");
                textBox1.Text=textBox3.Text = textBox2.Text = "";
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
