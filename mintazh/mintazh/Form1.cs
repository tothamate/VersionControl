using mintazh.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mintazh
{
    public partial class Form1 : Form
    {
        private List<Product> _products = new List<Product>();

        public Form1()
        {
            InitializeComponent();
            var valami = LoadXml("Menu.xml");
        }

        public string LoadXml(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                //var output = sr.ReadLine();
                //while (!sr.EndOfStream)
                //{
                //    output += "\n" + sr.ReadLine();
                //}
                //return output;

                return sr.ReadToEnd();
            }

            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
