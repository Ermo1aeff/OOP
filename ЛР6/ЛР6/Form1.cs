using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР6
{
    public partial class Form1 : Form
    {
        // Список для хранения всех нарисованных фигур
        private List<Shape> _shapes;

        public Form1()
        {
            InitializeComponent();
            _shapes = new List<Shape>();

            // Привязываем обработчик события отрисовки к PictureBox
            pictureBox1.Paint += PictureBox1_Paint;

            btnDraw.Click += BtnDraw_Click;
            btnClear.Click += BtnClear_Click;
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                // Парсим текст из TextBox и создаем объект фигуры
                Shape newShape = CommandParser.Parse(txtCommand.Text);

                // Добавляем фигуру в список
                _shapes.Add(newShape);
                pictureBox1.Refresh();
                txtCommand.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _shapes.Clear();
            pictureBox1.Refresh();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Включаем сглаживание для более красивой отрисовки
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Каждая фигура знает, как нарисовать себя, используя предоставленный Graphics
            foreach (Shape shape in _shapes)
            {
                shape.Draw(e.Graphics);
            }
        }
    }
}
