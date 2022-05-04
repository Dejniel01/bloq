using System;
using System.Drawing;

namespace WinFormsZal
{
    [Serializable]
    public abstract class Block
    {
        protected int width = 150;
        protected int height = 100;
        protected int x;
        protected int y;
        protected int textRectangleWidth = 150;
        protected int textRectangleHeight = 100;
        public string Text { get; set; }
        abstract public int X { get; set; }
        abstract public int Y { get; set; }
        public bool IsSelected { get; set; }

        protected Block()
        {
            Text = string.Empty;
            X = 0;
            Y = 0;
            IsSelected = false;
        }
        protected Block(string text, int x, int y)
        {
            Text = text;
            X = x;
            Y = y;
            IsSelected = false;
        }
        public virtual void Draw(Bitmap drawArea)
        {
            using Graphics g = Graphics.FromImage(drawArea);
            using Font font = new("Arial", 8, FontStyle.Regular);
            StringFormat stringFormat = new();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.TranslateTransform(X, Y);
            g.DrawString(Text, font, Brushes.Black,
                new Rectangle(-textRectangleWidth / 2, -textRectangleHeight / 2, textRectangleWidth, textRectangleHeight),
                stringFormat);
        }
        public abstract bool IsPointInPolygon(PointF testPoint);
        public abstract Node IsPointInNode(PointF testPoint);
        public abstract void DeleteConnections();
    }

    [Serializable]
    public class DecisiveBlock : Block
    {
        private readonly PointF[] points;
        public InNode InNode { get; set; }
        public OutNode OutNodeT { get; set; }
        public OutNode OutNodeF { get; set; }
        public override int X
        {
            get => x;
            set
            {
                x = value;
                if (InNode != null)
                    InNode.X = value;
                if (OutNodeT != null)
                    OutNodeT.X = value - width / 2;
                if (OutNodeF != null)
                    OutNodeF.X = value + width / 2;
            }
        }
        public override int Y
        {
            get => y;
            set
            {
                y = value;
                if (InNode != null)
                    InNode.Y = value - height / 2;
                if (OutNodeT != null)
                    OutNodeT.Y = value;
                if (OutNodeF != null)
                    OutNodeF.Y = value;
            }
        }

        public DecisiveBlock() : base()
        {
            points = null;
            InNode = null;
            OutNodeT = null;
            OutNodeF = null;
            textRectangleWidth = width / 2;
            textRectangleHeight = height / 2;
        }
        public DecisiveBlock(string text,  int x, int y) : base(text,  x, y)
        {
            points = new PointF[4] {
                        new(-width / 2, 0),
                        new(0, height / 2),
                        new(width/2, 0),
                        new(0, -height / 2)};
            InNode = new InNode( X, Y - height / 2);
            OutNodeT = new OutNode( X - width / 2, Y);
            OutNodeF = new OutNode( X + width / 2, Y);
            textRectangleWidth = width / 2;
            textRectangleHeight = height / 2;
        }
        public override void Draw(Bitmap drawArea)
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.TranslateTransform(X, Y);
                using (Pen p = new(Color.Black, 2))
                {
                    if (IsSelected) p.DashPattern = new float[] { 2, 1 };
                    g.DrawPolygon(p, points);
                }
                g.FillPolygon(Brushes.White, points);

                using Font font = new("Arial", 8, FontStyle.Regular);
                StringFormat stringFormat = new();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                g.DrawString("T", font, Brushes.Black, -width / 2, -17, stringFormat);
                g.DrawString("F", font, Brushes.Black, width / 2, -17, stringFormat);
            }
            InNode.Draw(drawArea);
            OutNodeT.Draw(drawArea);
            OutNodeF.Draw(drawArea);
            base.Draw(drawArea);
        }
        public override bool IsPointInPolygon(PointF testPoint)
        {
            return 2 * Math.Abs(testPoint.X - X) / width + 2 * Math.Abs(testPoint.Y - Y) / height <= 1;
        }
        public override Node IsPointInNode(PointF testPoint)
        {
            if (InNode.IsPointInNode(testPoint)) return InNode;
            if (OutNodeT.IsPointInNode(testPoint)) return OutNodeT;
            if (OutNodeF.IsPointInNode(testPoint)) return OutNodeF;
            return null;
        }
        public override void DeleteConnections()
        {
            if (InNode.OutNode != null)
                InNode.OutNode.InNode = null;
            if (OutNodeT.InNode != null)
                OutNodeT.InNode.OutNode = null;
            if (OutNodeF.InNode != null)
                OutNodeF.InNode.OutNode = null;
            InNode.OutNode = null;
            OutNodeT.InNode = null;
            OutNodeF.InNode = null;
        }
    }

    [Serializable]
    public class OperativeBlock : Block
    {
        public InNode InNode { get; set; }
        public OutNode OutNode { get; set; }
        public override int X
        {
            get => x;
            set
            {
                x = value;
                if (InNode != null)
                    InNode.X = value;
                if (OutNode != null)
                    OutNode.X = value;
            }
        }
        public override int Y
        {
            get => y;
            set
            {
                y = value;
                if (InNode != null)
                    InNode.Y = value - height / 2;
                if (OutNode != null)
                    OutNode.Y = value + height / 2;
            }
        }

        public OperativeBlock() : base()
        {
            InNode = null;
            OutNode = null;
        }
        public OperativeBlock(string text,  int x, int y) : base(text,  x, y)
        {
            InNode = new InNode( X, Y - height / 2);
            OutNode = new OutNode( X, Y + height / 2);
        }
        public override void Draw(Bitmap drawArea)
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.TranslateTransform(X, Y);
                g.FillRectangle(Brushes.White, -width / 2, -height / 2, width, height);
                using Pen p = new(Color.Black, 2);
                if (IsSelected) p.DashPattern = new float[] { 2, 1 };
                g.DrawRectangle(p, -width / 2, -height / 2, width, height);
            }
            InNode.Draw(drawArea);
            OutNode.Draw(drawArea);
            base.Draw(drawArea);
        }
        public override bool IsPointInPolygon(PointF testPoint)
        {
            return testPoint.X >= X - width / 2 &&
                    testPoint.X <= X + width / 2 &&
                    testPoint.Y >= Y - height / 2 &&
                    testPoint.Y <= Y + height / 2;
        }
        public override Node IsPointInNode(PointF testPoint)
        {
            if (InNode.IsPointInNode(testPoint)) return InNode;
            if (OutNode.IsPointInNode(testPoint)) return OutNode;
            return null;
        }
        public override void DeleteConnections()
        {
            if (InNode.OutNode != null)
                InNode.OutNode.InNode = null;
            if (OutNode.InNode != null)
                OutNode.InNode.OutNode = null;
            InNode.OutNode = null;
            OutNode.InNode = null;
        }
    }

    [Serializable]
    public class StartBlock : Block
    {
        public OutNode OutNode { get; set; }
        public override int X
        {
            get => x;
            set
            {
                x = value;
                if (OutNode != null)
                    OutNode.X = value;
            }
        }
        public override int Y
        {
            get => y;
            set
            {
                y = value;
                if (OutNode != null)
                    OutNode.Y = value + height / 2;
            }
        }

        public StartBlock() : base()
        {
            OutNode = null;
            textRectangleWidth = width / 2;
            textRectangleHeight = height / 2;
        }
        public StartBlock(string text,  int x, int y) : base(text,  x, y)
        {
            OutNode = new( X, Y + height / 2);
            textRectangleWidth = width / 2;
            textRectangleHeight = height / 2;
        }
        public override void Draw(Bitmap drawArea)
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.TranslateTransform(X, Y);
                g.FillEllipse(Brushes.White, -width / 2, -height / 2, width, height);

                using Pen p = new(Color.Green, 2);
                if (IsSelected) p.DashPattern = new float[] { 2, 1 };
                g.DrawEllipse(p, -width / 2, -height / 2, width, height);
            }
            OutNode.Draw(drawArea);
            base.Draw(drawArea);
        }
        public override bool IsPointInPolygon(PointF testPoint)
        {
            return (testPoint.X - X) * (testPoint.X - X) / ((width / 2) * (width / 2)) +
                   (testPoint.Y - Y) * (testPoint.Y - Y) / ((height / 2) * (height / 2)) <= 1;
        }
        public override Node IsPointInNode(PointF testPoint)
        {
            if (OutNode.IsPointInNode(testPoint)) return OutNode;
            return null;
        }
        public override void DeleteConnections()
        {
            if (OutNode.InNode != null)
                OutNode.InNode.OutNode = null;
            OutNode.InNode = null;
        }
    }

    [Serializable]
    public class StopBlock : Block
    {
        public InNode InNode { get; set; }
        public override int X
        {
            get => x;
            set
            {
                x = value;
                if (InNode != null)
                    InNode.X = value;
            }
        }
        public override int Y
        {
            get => y;
            set
            {
                y = value;
                if (InNode != null)
                    InNode.Y = value - height / 2;
            }
        }

        public StopBlock() : base()
        {
            InNode = null;
            textRectangleWidth = width / 2;
            textRectangleHeight = height / 2;
        }
        public StopBlock(string text,  int x, int y) : base(text,  x, y)
        {
            InNode = new( X, Y - height / 2);
            textRectangleWidth = width / 2;
            textRectangleHeight = height / 2;
        }     
        public override void Draw(Bitmap drawArea)
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.TranslateTransform(X, Y);
                g.FillEllipse(Brushes.White, -width / 2, -height / 2, width, height);
                using Pen p = new(Color.Red, 2);
                if (IsSelected) p.DashPattern = new float[] { 2, 1 };
                g.DrawEllipse(p, -width / 2, -height / 2, width, height);
            }
            InNode.Draw(drawArea);
            base.Draw(drawArea);
        }
        public override bool IsPointInPolygon(PointF testPoint)
        {
            return (testPoint.X - X) * (testPoint.X - X) / ((width / 2) * (width / 2)) +
                   (testPoint.Y - Y) * (testPoint.Y - Y) / ((height / 2) * (height / 2)) <= 1;
        }
        public override Node IsPointInNode(PointF testPoint)
        {
            if (InNode.IsPointInNode(testPoint)) return InNode;
            return null;
        }
        public override void DeleteConnections()
        {
            if (InNode.OutNode != null)
                InNode.OutNode.InNode = null;
            InNode.OutNode = null;
        }
    }
}
