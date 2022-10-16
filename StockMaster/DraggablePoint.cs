using System;
using System.Drawing;
using System.Windows.Forms;

namespace StockMaster
{
    class DraggablePoint : DraggableObject
    {
        public int X;
        public int Y;
        private int R;

        public DraggablePoint(int x, int y)
        {
            X = x;
            Y = y;
            R = 10;

            Dragging = false;
            Rollover = false;
            OffsetX = 0;
            OffsetY = 0;
            Color = Color.FromArgb(100, 0, 255);
        }

        public override bool Check(int mouseX, int mouseY)
        {
            return Math.Sqrt(Math.Pow(X - mouseX, 2) + Math.Pow(Y - mouseY, 2)) <= R;
        }

        public override void Over(int mouseX, int mouseY)
        {
            Rollover = !Check(mouseX, mouseY);
        }

        public override void Update(int mouseX, int mouseY)
        {
            if (Dragging)
            {
                X = mouseX + OffsetX;
                Y = mouseY + OffsetY;
            }
        }

        public override void Pressed(int mouseX, int mouseY)
        {
            if (Check(mouseX, mouseY))
            {
                Dragging = true;

                OffsetX = X - mouseX;
                OffsetY = Y - mouseY;
            }
        }

        public override void Released()
        {
            Dragging = false;
        }

        public override void Draw(PaintEventArgs e)
        {
            Color color;
            if (Dragging)
            {
                color = Color.Green;
            }
            else if (Rollover)
            {
                color = Color.Red;
            }
            else
            {
                color = Color;
            }

            e.Graphics.FillEllipse(new SolidBrush(color), X - R, Y - R, 2 * R, 2 * R);
        }
    }
}
