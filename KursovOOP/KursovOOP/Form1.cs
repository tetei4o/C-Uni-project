using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovOOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Figure> shapes = new List<Figure>();
        private Point initialClick;
        private bool isButtonHeld;
        private Figure drawnShape;


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isButtonHeld = true;
            initialClick = e.Location;

            shapes.ForEach(x => x.isSelected = false);

            if (e.Button == MouseButtons.Left)
            {
                var selected = shapes
                    .FirstOrDefault(x => x.isWithinFigure(initialClick));

                if (selected != null)
                {
                    selected.isSelected = true;
                }
                isButtonHeld = false;
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isButtonHeld)
            {
                return;
            }

            if (radioButton1.Checked)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.location = new Point(Math.Min(initialClick.X, e.Location.X), Math.Min(initialClick.Y, e.Location.Y));
                rectangle.width = Math.Abs(initialClick.X - e.Location.X);
                rectangle.height = Math.Abs(initialClick.Y - e.Location.Y);
                drawnShape = rectangle;
            }


            if (radioButton2.Checked)
            {
                Circle circle = new Circle();
                circle.location = new Point(Math.Min(initialClick.X, e.Location.X), Math.Min(initialClick.Y, e.Location.Y));
                circle.width = Math.Abs(initialClick.X - e.Location.X);
                circle.height = Math.Abs(initialClick.Y - e.Location.Y);
                drawnShape = circle;
            }

            if (radioButton3.Checked)
            {
                Triangle triangle = new Triangle();
                triangle.point1 = initialClick;
                triangle.point2 = e.Location;
                triangle.location = triangle.point1;
                drawnShape = triangle;

            }

            drawnShape.color = Color.Ivory;

            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isButtonHeld)
            {
                return;
            }

            if (e.Button == MouseButtons.Right && drawnShape != null)
            {
                ColorDialog colorDialog = new ColorDialog();

                DialogResult result = colorDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    drawnShape.isSelected = true;
                    drawnShape.color = colorDialog.Color;

                    shapes.Add(drawnShape);
                }
            }

            drawnShape = null;
            isButtonHeld = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < shapes.Count; i++)
                shapes[i].Draw(e.Graphics);

            if (isButtonHeld && drawnShape != null)
                drawnShape.Draw(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selected = shapes
                .FirstOrDefault(x => x.isSelected);

            if (selected != null)
            {

                Details details = new Details(selected);
                details._width();
                details._height();
                details._area();
                details.ShowDialog();
                selected.width = details.GetWidth;
                selected.height = details.GetHeight;
                selected.color = details.GetColor;
            }

            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (shapes.Count > 0)
            {
                shapes.RemoveAt(shapes.Count - 1);
                Invalidate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            var selected = shapes
                    .FirstOrDefault(x => x.isWithinFigure(initialClick));

            if (selected != null)
            {
                shapes.RemoveAt(shapes.FindIndex(x => x.isSelected = true));
                Invalidate();
            }

        }
    }
}
