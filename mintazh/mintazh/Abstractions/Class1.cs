using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mintazh.Abstractions
{
    public abstract class Product : Button
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value;
                Text = _title;
            }
        }

        private int _calories;

        public int Calories
        {
            get { return _calories; }
            set 
            {
                _calories = value;
                Display();
            }
        }

        public Product()
        {
            Width = 150;
            Height = 50;
        }

        public abstract void Display();
    }
}
