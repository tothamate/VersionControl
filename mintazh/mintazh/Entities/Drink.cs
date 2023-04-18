using mintazh.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mintazh.Entities
{
    public class Drink : Product
    {
        public override void Display()
        {
            BackColor = Color.LightBlue;
        }
    }
}
