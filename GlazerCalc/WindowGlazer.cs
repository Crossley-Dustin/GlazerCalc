using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlazerCalc
{
    public class WindowGlazer
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Quantity { get; set; }
        public string Color { get; set; }

        public double WoodLength { get { return ( Quantity * (2 * (Height + Width) * 3.25)); } }
        public double GlassArea { get { return ( Quantity * (2 * (Height * Width))); } }
        public DateTime DateOrdered { get; set; }       
    }
}
