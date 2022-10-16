using System.Drawing;
using System.Windows.Forms;

namespace StockMaster
{
    class DraggableObject
    {
        public bool Dragging;
        public bool Rollover;
        public int OffsetX;
        public int OffsetY;
        public Color Color;

        public DraggableObject() { }

        public virtual bool Check(int mouseX, int mouseY)
        {
            return false;
        }

        public virtual void Over(int mouseX, int mouseY)
        {
            Rollover = !Check(mouseX, mouseY);
        }

        public virtual void Update(int mouseX, int mouseY) { }

        public virtual void Pressed(int mouseX, int mouseY) { }

        public virtual void Released() { }

        public virtual void Draw(PaintEventArgs e) { }
    }
}
