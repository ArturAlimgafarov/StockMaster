using System;
using System.Drawing;
using System.Windows.Forms;

namespace StockMaster
{
    class DraggableLine : DraggableObject
    {
        public DraggablePoint Point1;
        public DraggablePoint Point2;

        public DraggableLine(int x1, int y1, int x2, int y2)
        {
            Point1 = new DraggablePoint(x1, y1);
            Point2 = new DraggablePoint(x2, y2);

            Dragging = false;
            Rollover = false;
            OffsetX = 0;
            OffsetY = 0;
            Color = Color.FromArgb(0, 255, 0);
        }

        public override bool Check(int mouseX, int mouseY)
        {
            int A = Point2.Y - Point1.Y;
            int B = Point1.X - Point2.X;
            int C = Point1.X * (Point1.Y - Point2.Y) + Point1.Y * (Point2.X - Point1.X);

            float eps = 0.05f;

            return Math.Abs(A * mouseX + B * mouseY + C) / Math.Sqrt(A * A + B * B + C * C) < eps &&
                (mouseX > Math.Min(Point1.X, Point2.X) && mouseX < Math.Max(Point1.X, Point2.X)) &&
                (mouseY > Math.Min(Point2.Y, Point2.Y) && mouseY < Math.Max(Point1.Y, Point2.Y));
        }

        public override void Over(int mouseX, int mouseY)
        {
            Rollover = !Check(mouseX, mouseY);
            Point1.Rollover = !Check(mouseX, mouseY);
            Point2.Rollover = !Check(mouseX, mouseY);
        }

        public override void Update(int mouseX, int mouseY)
        {
            if (Dragging)
            {
                //Point1.Update(mouseX, mouseY);
                //Point1.Update(mouseX, mouseY);
                Point1.X = mouseX + Point1.OffsetX;
                Point1.Y = mouseY + Point1.OffsetY;

                Point2.X = mouseX + Point2.OffsetX;
                Point2.Y = mouseY + Point2.OffsetY;
            }
        }

        public override void Pressed(int mouseX, int mouseY)
        {
            if (Check(mouseX, mouseY))
            {
                Dragging = true;

                Point1.Dragging = true;
                Point2.Dragging = true;

                Point1.OffsetX = Point1.X - mouseX;
                Point1.OffsetY = Point1.Y - mouseY;
                Point2.OffsetX = Point2.X - mouseX;
                Point2.OffsetY = Point2.Y - mouseY;
            }
        }

        public override void Released()
        {
            Dragging = false;

            Point1.Released();
            Point2.Released();
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

            e.Graphics.DrawLine(new Pen(color, 2), Point1.X, Point1.Y, Point2.X, Point2.Y);
            Point1.Draw(e);
            Point2.Draw(e);
        }
    }
}
