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
    public partial class Details : Form
    {

        public Details(Figure fig)
        {
            InitializeComponent();
            this.fig = fig;
        }

        public int width;
        public int height;
        public int area;
        public Color color;
        public Figure fig;


        public int GetWidth
        {
            get { return int.Parse(textBox1.Text); }
        }
        public int GetHeight
        {
            get { return int.Parse(textBox2.Text); }
        }

        public Color GetColor
        {
            get { return color; }
        }
        public void _width()
        {
            width = fig.width;
            textBox1.Text = width.ToString();
        }

        public void _height()
        {
            height = fig.height;
            textBox2.Text = height.ToString();
        }
        public void _area()
        {
            area = fig.GetArea();
            textBox3.Text = area.ToString();
        }

        public void _color()
        {
            color = fig.color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                color = colorDialog.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
            {
                this.Close();
            }
        }
    }
}
