
namespace WinFormsZal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fileGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.NewButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.editGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.operativeRadioButton = new System.Windows.Forms.RadioButton();
            this.decisiveRadioButton = new System.Windows.Forms.RadioButton();
            this.textBoxLabel = new System.Windows.Forms.Label();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.linkButton = new System.Windows.Forms.RadioButton();
            this.deleteButton = new System.Windows.Forms.RadioButton();
            this.startBlockButton = new System.Windows.Forms.RadioButton();
            this.stopBlockButton = new System.Windows.Forms.RadioButton();
            this.langGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.PLButton = new System.Windows.Forms.Button();
            this.ENButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.fileGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.editGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.langGroupBox.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.Canvas);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            // 
            // Canvas
            // 
            resources.ApplyResources(this.Canvas, "Canvas");
            this.Canvas.Name = "Canvas";
            this.Canvas.TabStop = false;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.fileGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.editGroupBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.langGroupBox, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // fileGroupBox
            // 
            this.fileGroupBox.Controls.Add(this.tableLayoutPanel3);
            resources.ApplyResources(this.fileGroupBox, "fileGroupBox");
            this.fileGroupBox.Name = "fileGroupBox";
            this.fileGroupBox.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.NewButton, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.LoadButton, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.SaveButton, 0, 1);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // NewButton
            // 
            resources.ApplyResources(this.NewButton, "NewButton");
            this.NewButton.Name = "NewButton";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // LoadButton
            // 
            resources.ApplyResources(this.LoadButton, "LoadButton");
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // editGroupBox
            // 
            this.editGroupBox.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.editGroupBox, "editGroupBox");
            this.editGroupBox.Name = "editGroupBox";
            this.editGroupBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.operativeRadioButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.decisiveRadioButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBoxLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.TextBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.linkButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.deleteButton, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.startBlockButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.stopBlockButton, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // operativeRadioButton
            // 
            resources.ApplyResources(this.operativeRadioButton, "operativeRadioButton");
            this.operativeRadioButton.Image = global::WinFormsZal.Properties.Resources._003_rectangular_shape_outline;
            this.operativeRadioButton.Name = "operativeRadioButton";
            this.operativeRadioButton.UseVisualStyleBackColor = true;
            // 
            // decisiveRadioButton
            // 
            resources.ApplyResources(this.decisiveRadioButton, "decisiveRadioButton");
            this.decisiveRadioButton.Image = global::WinFormsZal.Properties.Resources.rhomb;
            this.decisiveRadioButton.Name = "decisiveRadioButton";
            this.decisiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // textBoxLabel
            // 
            resources.ApplyResources(this.textBoxLabel, "textBoxLabel");
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxLabel, 3);
            this.textBoxLabel.Name = "textBoxLabel";
            // 
            // TextBox
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.TextBox, 3);
            resources.ApplyResources(this.TextBox, "TextBox");
            this.TextBox.Name = "TextBox";
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // linkButton
            // 
            resources.ApplyResources(this.linkButton, "linkButton");
            this.linkButton.Image = global::WinFormsZal.Properties.Resources.link;
            this.linkButton.Name = "linkButton";
            this.linkButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Image = global::WinFormsZal.Properties.Resources.bin;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // startBlockButton
            // 
            resources.ApplyResources(this.startBlockButton, "startBlockButton");
            this.startBlockButton.Checked = true;
            this.startBlockButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startBlockButton.Image = global::WinFormsZal.Properties.Resources.green_ellipse;
            this.startBlockButton.Name = "startBlockButton";
            this.startBlockButton.TabStop = true;
            this.startBlockButton.UseVisualStyleBackColor = true;
            // 
            // stopBlockButton
            // 
            resources.ApplyResources(this.stopBlockButton, "stopBlockButton");
            this.stopBlockButton.Image = global::WinFormsZal.Properties.Resources.red_ellipse;
            this.stopBlockButton.Name = "stopBlockButton";
            this.stopBlockButton.UseVisualStyleBackColor = true;
            // 
            // langGroupBox
            // 
            this.langGroupBox.Controls.Add(this.tableLayoutPanel4);
            resources.ApplyResources(this.langGroupBox, "langGroupBox");
            this.langGroupBox.Name = "langGroupBox";
            this.langGroupBox.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.PLButton, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ENButton, 0, 1);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // PLButton
            // 
            resources.ApplyResources(this.PLButton, "PLButton");
            this.PLButton.Name = "PLButton";
            this.PLButton.UseVisualStyleBackColor = true;
            this.PLButton.Click += new System.EventHandler(this.PLButton_Click);
            // 
            // ENButton
            // 
            resources.ApplyResources(this.ENButton, "ENButton");
            this.ENButton.Name = "ENButton";
            this.ENButton.UseVisualStyleBackColor = true;
            this.ENButton.Click += new System.EventHandler(this.ENButton_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "diag";
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "diag";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.fileGroupBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.editGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.langGroupBox.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox fileGroupBox;
        private System.Windows.Forms.GroupBox editGroupBox;
        private System.Windows.Forms.RadioButton decisiveRadioButton;
        private System.Windows.Forms.RadioButton operativeRadioButton;
        private System.Windows.Forms.GroupBox langGroupBox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label textBoxLabel;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.RadioButton linkButton;
        private System.Windows.Forms.RadioButton deleteButton;
        private System.Windows.Forms.RadioButton startBlockButton;
        private System.Windows.Forms.RadioButton stopBlockButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button PLButton;
        private System.Windows.Forms.Button ENButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

