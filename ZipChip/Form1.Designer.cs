namespace ZipChip
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.comSt = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCit = new System.Windows.Forms.TextBox();
            this.lstviewMain = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zipchipTimeout = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cntrySrch = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Co:";
            // 
            // comSt
            // 
            this.comSt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comSt.FormattingEnabled = true;
            this.comSt.Location = new System.Drawing.Point(12, 87);
            this.comSt.MaxLength = 2;
            this.comSt.Name = "comSt";
            this.comSt.Size = new System.Drawing.Size(61, 32);
            this.comSt.Sorted = true;
            this.comSt.TabIndex = 2;
            this.comSt.DropDownClosed += new System.EventHandler(this.comSt_DropDownClosed);
            this.comSt.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            this.comSt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comSt_KeyDown);
            this.comSt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "City:";
            // 
            // txtCit
            // 
            this.txtCit.Enabled = false;
            this.txtCit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCit.Location = new System.Drawing.Point(154, 87);
            this.txtCit.MaxLength = 32;
            this.txtCit.Name = "txtCit";
            this.txtCit.Size = new System.Drawing.Size(279, 29);
            this.txtCit.TabIndex = 3;
            this.txtCit.TextChanged += new System.EventHandler(this.txtCit_TextChanged);
            this.txtCit.Enter += new System.EventHandler(this.txtCit_Enter);
            this.txtCit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCit_KeyDown);
            this.txtCit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtCit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtCit_MouseUp);
            // 
            // lstviewMain
            // 
            this.lstviewMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstviewMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstviewMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstviewMain.Location = new System.Drawing.Point(12, 125);
            this.lstviewMain.Name = "lstviewMain";
            this.lstviewMain.Size = new System.Drawing.Size(482, 599);
            this.lstviewMain.TabIndex = 4;
            this.lstviewMain.TabStop = false;
            this.lstviewMain.UseCompatibleStateImageBehavior = false;
            this.lstviewMain.View = System.Windows.Forms.View.Details;
            this.lstviewMain.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.lstviewMain.Leave += new System.EventHandler(this.lstviewMain_Leave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Zip Code";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "City";
            this.columnHeader2.Width = 350;
            // 
            // zipchipTimeout
            // 
            this.zipchipTimeout.Enabled = true;
            this.zipchipTimeout.Interval = 3250;
            this.zipchipTimeout.Tick += new System.EventHandler(this.zipchipTimeout_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search countries:";
            // 
            // cntrySrch
            // 
            this.cntrySrch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cntrySrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cntrySrch.Location = new System.Drawing.Point(12, 32);
            this.cntrySrch.MaxLength = 32;
            this.cntrySrch.Name = "cntrySrch";
            this.cntrySrch.Size = new System.Drawing.Size(177, 29);
            this.cntrySrch.TabIndex = 1;
            this.cntrySrch.TextChanged += new System.EventHandler(this.cntrySrch_TextChanged);
            this.cntrySrch.Enter += new System.EventHandler(this.cntrySrch_Enter);
            this.cntrySrch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cntrySrch_KeyDown);
            this.cntrySrch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cntrySrch_KeyPress);
            this.cntrySrch.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cntrySrch_MouseUp);
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(196, 32);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(80, 29);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.TabStop = false;
            this.btnLoad.Text = "Load Cities";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 736);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.cntrySrch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstviewMain);
            this.Controls.Add(this.txtCit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comSt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZipChip v1.50";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comSt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCit;
        private System.Windows.Forms.ListView lstviewMain;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Timer zipchipTimeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cntrySrch;
        private System.Windows.Forms.Button btnLoad;
    }
}

