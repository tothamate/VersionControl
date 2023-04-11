using gyak06.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak06.Entities
{
    class Car : Toy
    {
        protected override void DrawToy(Graphics g)
        {
            Image imageFile = Image.FromFile(@"Images\car.png");
            g.DrawImage(imageFile, 0, 0, Width, Height);
        }
    }
}
