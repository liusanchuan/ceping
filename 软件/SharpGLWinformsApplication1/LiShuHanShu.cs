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
    public partial class LiShuHanShu : Form
    {
        public string[] name={
                                 "应力",
                                 "震动",
                                 "源头载荷",
                                 "形变",
                                 "裂纹",
                                 "材料参数",
                                 "涂层烧蚀量",
                                 "传动阻力",
                                 "电机扭矩",
                                 "制动力矩",
                                 "液压及电控"

                             };
        public LiShuHanShu()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Reset_dataGridView()
        {
            DataTable dt=new DataTable();

            for (int i = 0; i < name.Length; i++)
            {
                dt.Columns.Add(name[i]);
            }
            DataRow dt1 = dt.NewRow();
            DataRow dt2 = dt.NewRow();
            DataRow dt3 = dt.NewRow();
            DataRow dt4 = dt.NewRow();
            DataRow dt5 = dt.NewRow();
            DataRow dt6 = dt.NewRow();

            for(int i=0;i<11;i++){
            dt1[i]=100;
            dt2[i] = 80 ;
            dt3[i] = 60 ;
            dt4[i] = 40 ;
            dt5[i] = 20;
            dt6[i] = 0 ;
            }
            //add 6 rows
            dt.Rows.Add(dt1);
            dt.Rows.Add(dt2);
            dt.Rows.Add(dt3);
            dt.Rows.Add(dt4);
            dt.Rows.Add(dt5);
            dt.Rows.Add(dt6);
            
            dataGridView1.DataSource = dt.DefaultView;
            for (int i = 0; i < 11; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            
        }
        public void ReadXmlToDataGrid()
        {
            DataTable dt=new DataTable();

            for (int i = 0; i < name.Length; i++)
            {
                dt.Columns.Add(name[i]);
            }
            DataRow dt1 = dt.NewRow();
            DataRow dt2 = dt.NewRow();
            DataRow dt3 = dt.NewRow();
            DataRow dt4 = dt.NewRow();
            DataRow dt5 = dt.NewRow();
            DataRow dt6 = dt.NewRow();
            DataRow[] dtrow = {dt1,dt2,dt3,dt4,dt5,dt6};
            string str = "../Debug/LiShuduBiao.xml";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(str);
             XmlNodeList nodeList = xmldoc.SelectSingleNode("NewXML").ChildNodes;//获取bookstore节点的所有子节点
            int x = 0;
            foreach (XmlNode Xn  in nodeList){
                XmlElement xe = (XmlElement)Xn;
                for (int B = 0; B < name.Length; B++)
                {
                    dtrow[x][B] = xe.GetAttribute(name[B]);
                }
                dt.Rows.Add(dtrow[x]);
                x++;

            }

            DataSet myds = new DataSet();
            myds.ReadXml(str);
            dataGridView1.DataSource = dt.DefaultView;
            for (int i = 0; i < 11; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void SaveDataGridToXml()
        {
            string str = "../Debug/LiShuduBiao.xml";
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            // Create and insert a new element.  
            XmlNode rowsNode = doc.CreateElement("NewXML");
            doc.AppendChild(rowsNode);

      
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    XmlNode rowNode = doc.CreateElement("row");


                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {

                        XmlAttribute rowAttribute = doc.CreateAttribute(dataGridView1.Columns[j].HeaderText);
                        rowAttribute.Value = dataGridView1.Rows[i].Cells[j].Value.ToString().Trim();
                        rowNode.Attributes.Append(rowAttribute);
                        rowsNode.AppendChild(rowNode);
                    }
                }
                doc.Save(str);

            
        }

        private void LiShuHanShu_Load(object sender, EventArgs e)
        {

            ReadXmlToDataGrid();

            int[] X1 = new int[] { 100, 90, 80, 70 };
            int[] X2 = new int[] { 80, 70, 60, 50 };
            int[] X3 = new int[] { 60, 50, 40, 30 };
            int[] X4 = new int[] { 40, 30, 20, 10 };
            int[] X5 = new int[] { 20, 10, 0, 0 };

            double[] series1 = new double[] { 0, 1, 1, 0 };

            chart1.Series[0].Points.DataBindXY(X1, series1);
            chart1.Series[1].Points.DataBindXY(X2, series1);
            chart1.Series[2].Points.DataBindXY(X3, series1);
            chart1.Series[3].Points.DataBindXY(X4, series1);
            chart1.Series[4].Points.DataBindXY(X5, series1);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            SaveDataGridToXml();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset_dataGridView();
        }
    }
}
