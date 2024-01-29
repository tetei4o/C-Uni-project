using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovOOP
{
    internal class Rectangle : Figure
    {
        public override bool isWithinFigure(Point point)
        {
            if (location.X < point.X && point.X < location.X + width && location.Y < point.Y && point.Y < location.Y + height)
            {
                return true;
            }
            return false;
        }

        public override void Draw(Graphics g)
        {
            var borderColor = color;
            if (isSelected)
            {
                borderColor = Color.Black;
            }

            var brush = new SolidBrush(color);
            g.FillRectangle(brush, location.X, location.Y, width, height);
            var pen = new Pen(borderColor, 2);
            g.DrawRectangle(pen, location.X, location.Y, width, height);

        }

        public override int GetArea()
        {
            return width * height;
        }
    }
}
