using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace WinFormsZal
{
    public partial class Form2 : Form
    {
        private readonly Form1 mainForm = null;

        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 callingForm, string lang)
        {
            mainForm = callingForm;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            InitializeComponent();
        }
        private void OKButton_Click(object sender, EventArgs e)
        {
            mainForm.CreateNewCanvas((int)widthNumericUpDown.Value, (int)heightNumericUpDown.Value);
            Close();
        }
    }
}