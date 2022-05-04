using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFormsZal
{
    [Serializable]
    public abstract class Node
    {
        protected const int r = 5;
        public int X { get; set; }
        public int Y { get; set; }

        protected Node()
        {
            X = 0;
            Y = 0;
        }
        protected Node(int x, int y)
        {
            X = x;
            Y = y;
        }
        public virtual void Draw(Bitmap drawArea)
        {
            using Graphics g = Graphics.FromImage(drawArea);
            g.TranslateTransform(X, Y);
            g.DrawEllipse(Pens.Black, -r, -r, 2 * r, 2 * r);
        }
        public bool IsPointInNode(PointF testPoint)
        {
            return (testPoint.X - X) * (testPoint.X - X) +
                   (testPoint.Y - Y) * (testPoint.Y - Y) <= r * r;
        }
    }

    [Serializable]
    public class InNode : Node
    {
        public OutNode OutNode { get; set; }

        public InNode() : base()
        {
            OutNode = null;
        }
        public InNode(int x, int y) : base(x, y)
        {
            OutNode = null;
        }
        public override void Draw(Bitmap drawArea)
        {
            if (OutNode == null)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.TranslateTransform(X, Y);
                    g.FillEllipse(Brushes.White, -5, -5, 10, 10);
                }
                base.Draw(drawArea);
            }
            else
            {
                using Graphics g = Graphics.FromImage(drawArea);
                using Pen p = new(Brushes.Black, 2);
                using AdjustableArrowCap arrowCap = new(5, 5);
                p.CustomStartCap = arrowCap;
                g.DrawLine(p, X, Y, OutNode.X, OutNode.Y);
            }
        }
    }

    [Serializable]
    public class OutNode : Node
    {
        public InNode InNode { get; set; }

        public OutNode() : base()
        {
            InNode = null;
        }
        public OutNode(int x, int y) : base(x, y)
        {
            InNode = null;
        }
        public override void Draw(Bitmap drawArea)
        {
            if (InNode == null)
            {
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.TranslateTransform(X, Y);
                    g.FillEllipse(Brushes.Black, -5, -5, 10, 10);
                }
                base.Draw(drawArea);
            }
        }
    }
}
