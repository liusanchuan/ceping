using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.OleDb;
using System.Xml;

namespace SharpGLWinformsApplication1
{
    public partial class adddata : UserControl
    {

        public adddata()
        {
            InitializeComponent();
        }

        private void adddata_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();//建立个数据表

            dt.Columns.Add(new DataColumn("id", typeof(int)));//在表中添加int类型的列

            dt.Columns.Add(new DataColumn("Name", typeof(string)));//在表中添加string类型的Name列
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlConnection.str);
            XmlNodeList all_user = doc.SelectSingleNode("userInfo").ChildNodes;
            int id = 0;
            foreach (XmlNode Seted_user in all_user)
            {

                id++;
                XmlNode user_name = Seted_user.SelectSingleNode("user_name");
                DataRow dr;//行

                dr = dt.NewRow();
                dr["id"] = id;
                string name_ = user_name.InnerText;
                dr["Name"] = name_;
                dt.Rows.Add(dr);//在表的对象的行里添加此行
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "编号";
            dataGridView1.Columns[1].HeaderText = "用户名";



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result= MessageBox.Show("是否删除此用户，删除后不可恢复！","",MessageBoxButtons.OKCancel);
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                int row = dataGridView1.CurrentRow.Index;
                string name= dataGridView1.Rows[row].Cells[1].Value.ToString().Trim();
                dataGridView1.Rows.RemoveAt(row);
                
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlConnection.str);
                XmlNodeList xnl = doc.SelectSingleNode("userInfo").ChildNodes;
                foreach (XmlNode xn in xnl)
                {
                    XmlElement xe = (XmlElement)xn;
                    XmlNode node_name = xe.SelectSingleNode("user_name");
                    if (node_name.InnerText == name)
                    {
                        xn.ParentNode.RemoveChild(xn);
                        //xe.RemoveAll();
                    }
                }
                doc.Save(xmlConnection.str);
            }

        }
       
 
    }
}

