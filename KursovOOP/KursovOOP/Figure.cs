using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovOOP
{
    public abstract class Figure
    {
        public Point location { get; set; }

        public int width { get; set; }

        public int height { get; set; }

        public Color color { get; set; }

        public bool isSelected { get; set; }


        public abstract int GetArea();

        public abstract void Draw(Graphics g);

        public abstract bool isWithinFigure(Point point);

    }
}
