using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KursovOOP
{
    internal class Triangle : Figure
    {

        public Point point1 { get; set; }
        public Point point2 { get; set; }


        public override bool isWithinFigure(Point point)
        {
            CalculateDimensions();
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

            Point[] trianglePoints = { point1, point2, new Point(point1.X, point2.Y) };
            var brush = new SolidBrush(color);
            g.FillPolygon(brush, trianglePoints);
            var pen = new Pen(borderColor, 2);
            g.DrawPolygon(pen, trianglePoints);

        }

        public override int GetArea()
        {

            var point3 = new Point(point1.X, point2.Y);
            var a = (Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow(point2.Y - point1.Y, 2)));
            var b = (Math.Sqrt(Math.Pow((point3.X - point2.X), 2) + Math.Pow(point3.Y - point2.Y, 2)));
            var c = (Math.Sqrt(Math.Pow((point1.X - point3.X), 2) + Math.Pow(point1.Y - point3.Y, 2)));
            var p = (a + b + c) / 2;
            return (int)Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        }

        private void CalculateDimensions()
        {
            width = Math.Abs(point1.X - point2.X);
            height = Math.Abs(point1.Y - point2.Y);
        }
    }
}
