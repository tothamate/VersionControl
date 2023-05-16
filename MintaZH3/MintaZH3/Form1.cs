using MintaZH3.Entities;
using MintaZH3.Enum;
using PackMaker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MintaZH3
{
    public partial class Form1 : Form
    {
        BindingList<Child> children = new BindingList<Child>();
        SantaClausPack pack = new SantaClausPack();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = children;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var c = new Child();
            var behaviour = (Behaviour)int.Parse(txtBehaviour.Text);
            if(!c.CheckBehaviour(behaviour)
            {
                MessageBox.Show("Helytelen érték, csak 1-5 közötti szám adható meg!");
                return;
            }

            pack.GetGifts(behaviour);

            c.Name = txt.Text;
            c.YearlyBehaviour = (Behaviour)behaviour;
            c.Gifts = pack.GetGifts(behaviour);

            children.Add(c);

            var badCount = (from x in children
                            where x.YearlyBehaviour == Behaviour.Bad || x.YearlyBehaviour == Behaviour.Worst
                            select x).Count();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();

            if(sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }


        }
    }
}
