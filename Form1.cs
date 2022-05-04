using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Resources;
using System.IO;

namespace WinFormsZal
{
    public partial class Form1 : Form
    {
        private const int baseWidth = 500;
        private const int baseHeight = 500;
        private Bitmap drawArea = null;
        private int canvasWidth = baseWidth;
        private int canvasHeight = baseHeight;
        private List<Block> elements = new();
        private Block selectedElement = null;
        private Node selectedNode = null;
        private Block selectedNodeParent = null;
        private bool isStart = false;
        private bool moving = false;
        private bool drawingLink = false;
        private (int x, int y) offset = (0, 0);
        private string lang = "pl-PL";
        private readonly ResourceManager strings;
        public Form1()
        {
            InitializeComponent();
            strings = new("WinFormsZal.strings.strings", System.Reflection.Assembly.GetExecutingAssembly());
            CreateNewCanvas(canvasWidth, canvasHeight);
        }
        public void CreateNewCanvas(int width, int height)
        {
            if (drawArea != null) drawArea.Dispose();
            canvasWidth = width;
            canvasHeight = height;
            drawArea = new Bitmap(width, height);
            Canvas.Image = drawArea;
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
            }
            selectedElement = null;
            elements.Clear();
            isStart = false;
            moving = false;
            drawingLink = false;
            TextBox.Text = string.Empty;
            TextBox.Enabled = false;
        }
        private void UnselectAll()
        {
            selectedElement = null;
            TextBox.Text = string.Empty;
            TextBox.Enabled = false;
            for (int i = elements.Count - 1; i >= 0; i--)
                elements[i].IsSelected = false;
        }
        private void Redraw()
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                g.Clear(Color.White);
            }
            foreach (var elem in elements)
                elem.Draw(drawArea);
            Canvas.Refresh();
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (!moving)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        LeftButtonDown(sender, e);
                        break;
                    case MouseButtons.Right:
                        RightButtonDown(sender, e);
                        break;
                    case MouseButtons.Middle:
                        if (selectedElement != null)
                        {
                            moving = true;
                            offset = (selectedElement.X - e.X, selectedElement.Y - e.Y);
                        }
                        break;
                }
                Canvas.Refresh();
            }
        }
        private void LeftButtonDown(object sender, MouseEventArgs e)
        {
            if (deleteButton.Checked)
            {
                for (int i = elements.Count - 1; i >= 0; i--)
                {
                    if (elements[i].IsPointInPolygon(new PointF(e.X, e.Y)))
                    {
                        if (elements[i] is StartBlock)
                            isStart = false;
                        elements[i].DeleteConnections();
                        if (elements[i] == selectedElement)
                            UnselectAll();
                        elements.RemoveAt(i);
                        break;
                    }
                }
                Redraw();
            }
            else if (linkButton.Checked)
            {
                for (int i = elements.Count - 1; i >= 0; i--)
                {
                    selectedNode = elements[i].IsPointInNode(new PointF(e.X, e.Y));
                    if (selectedNode != null && selectedNode is OutNode)
                    {
                        OutNode temp = selectedNode as OutNode;
                        if (temp.InNode == null)
                        {
                            drawingLink = true;
                            selectedNodeParent = elements[i];
                        break;
                        }
                        else
                            selectedNode = null;
                    }
                    else selectedNode = null;
                }
            }
            else
            {
                if (decisiveRadioButton.Checked)
                    elements.Add(new DecisiveBlock(strings.GetString("decisiveBlockText"), e.X, e.Y));
                if (operativeRadioButton.Checked)
                    elements.Add(new OperativeBlock(strings.GetString("operativeBlockText"), e.X, e.Y));
                if (startBlockButton.Checked)
                {
                    if (!isStart)
                    {
                        elements.Add(new StartBlock("START", e.X, e.Y));
                        isStart = true;
                    }
                    else
                    {
                        MessageBox.Show(strings.GetString("secondStartText"), string.Empty, MessageBoxButtons.OK);
                        return;
                    }
                }
                if (stopBlockButton.Checked)
                    elements.Add(new StopBlock("STOP", e.X, e.Y));
                elements.Last().Draw(drawArea);
            }
        }
        private void RightButtonDown(object sender, MouseEventArgs e)
        {
            UnselectAll();
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                if (elements[i].IsPointInPolygon(new PointF(e.X, e.Y)))
                {
                    selectedElement = elements[i];
                    elements[i].IsSelected = true;
                    if (!(elements[i] is StartBlock) && !(elements[i] is StopBlock))
                        TextBox.Enabled = true;
                    TextBox.Text = elements[i].Text;
                    break;
                }
            }
            Redraw();
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                moving = false;

                if (selectedElement != null)
                {
                    if (selectedElement.X < 0) selectedElement.X = 0;
                    if (selectedElement.X > canvasWidth) selectedElement.X = canvasWidth;
                    if (selectedElement.Y < 0) selectedElement.Y = 0;
                    if (selectedElement.Y > canvasHeight) selectedElement.Y = canvasHeight;
                    Redraw();
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                drawingLink = false;
                if (selectedNode != null)
                {
                    for (int i = elements.Count - 1; i >= 0; i--)
                    {
                        Node temp = elements[i].IsPointInNode(new PointF(e.X, e.Y));
                        if (temp != null && temp is InNode && elements[i] != selectedNodeParent)
                        {
                            InNode newInNode = temp as InNode;
                            OutNode newOutNode = selectedNode as OutNode;
                            if (newInNode.OutNode == null)
                            {
                                newInNode.OutNode = newOutNode;
                                newOutNode.InNode = newInNode;
                            }
                            break;
                        }
                    }
                    selectedNode = null;
                    selectedNodeParent = null;
                    Redraw();
                }
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && selectedElement != null)
            {
                selectedElement.X = e.X + offset.x;
                selectedElement.Y = e.Y + offset.y;
                Redraw();
            }
            if (drawingLink && selectedNode != null)
            {
                Redraw();
                using (Graphics g = Graphics.FromImage(drawArea))
                {
                    g.DrawLine(Pens.Black, selectedNode.X, selectedNode.Y, e.X, e.Y);
                }
                Canvas.Refresh();
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (selectedElement != null)
            {
                selectedElement.Text = TextBox.Text;
                Redraw();
            }
        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            Form childForm = new Form2(this, lang);
            childForm.Location = new Point(Location.X + Width / 2 - childForm.Width / 2,
                                           Location.Y + Height / 2 - childForm.Height / 2);
            childForm.ShowDialog();
            childForm.Dispose();
        }
        private void PLButton_Click(object sender, EventArgs e)
        {
            lang = "pl-PL";
            ChangeLanguage();
        }
        private void ENButton_Click(object sender, EventArgs e)
        {
            lang = "en";
            ChangeLanguage();
        }
        private void ChangeLanguage()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            ChangeLanguageRec(this);
            if (selectedElement != null && !(selectedElement is StartBlock) && !(selectedElement is StopBlock))
                TextBox.Enabled = true;
        }
        //https://www.dotnetcurry.com/ShowArticle.aspx?ID=174
        private void ChangeLanguageRec(Control c)
        {
            foreach (Control c1 in c.Controls)
            {
                if (!(c1 is SplitContainer || c1 is PictureBox))
                {
                    ComponentResourceManager resources = new(typeof(Form1));
                    resources.ApplyResources(c1, c1.Name, new CultureInfo(lang));
                }
                ChangeLanguageRec(c1);
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                UnselectAll();
                Data data = new(drawArea.Width, drawArea.Height, elements);
                using (var fs = (FileStream)saveFileDialog.OpenFile())
                {
                    FileOperator.Save(fs, data);
                }
                Redraw();
            }
            saveFileDialog.Dispose();
        }
        private void LoadButton_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var fs = (FileStream)openFileDialog.OpenFile())
                {
                    var data = FileOperator.Load(fs);

                    if (data == null)
                    {
                        MessageBox.Show(strings.GetString("badLoadText"), string.Empty, MessageBoxButtons.OK);
                        return;
                    }
                    CreateNewCanvas(data.Width, data.Height);
                    elements = data.Elements;
                }
                Redraw();
                foreach (var el in elements)
                    if (el is StartBlock)
                        isStart = true;
            }
            openFileDialog.Dispose();
        }
    }
}