using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gyak005
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetRates();
        }

        private void GetRates()
        {
            var mnbService = new MnbServiceReferenceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
