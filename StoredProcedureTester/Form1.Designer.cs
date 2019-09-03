namespace StoredProcedureTester
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tbUnoptimisedSPName = new System.Windows.Forms.TextBox();
            this.tbOptimisedSPName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUnoptimisedParameters = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbOptimisedParameters = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnAddToUnoptimised = new System.Windows.Forms.Button();
            this.btnAddToOptimised = new System.Windows.Forms.Button();
            this.btnAddToBoth = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGenerateGuid = new System.Windows.Forms.Button();
            this.chkBoxValue = new System.Windows.Forms.CheckBox();
            this.dtpValue = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbStatus = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unoptimised SP Name";
            // 
            // tbUnoptimisedSPName
            // 
            this.tbUnoptimisedSPName.Location = new System.Drawing.Point(25, 32);
            this.tbUnoptimisedSPName.Name = "tbUnoptimisedSPName";
            this.tbUnoptimisedSPName.Size = new System.Drawing.Size(186, 20);
            this.tbUnoptimisedSPName.TabIndex = 1;
            this.tbUnoptimisedSPName.Text = "VCBedrock.dbo.Test";
            // 
            // tbOptimisedSPName
            // 
            this.tbOptimisedSPName.Location = new System.Drawing.Point(240, 32);
            this.tbOptimisedSPName.Name = "tbOptimisedSPName";
            this.tbOptimisedSPName.Size = new System.Drawing.Size(186, 20);
            this.tbOptimisedSPName.TabIndex = 3;
            this.tbOptimisedSPName.Text = "VCBedrock.dbo.TestOptimised";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Optimised SP Name";
            // 
            // lbUnoptimisedParameters
            // 
            this.lbUnoptimisedParameters.FormattingEnabled = true;
            this.lbUnoptimisedParameters.Location = new System.Drawing.Point(25, 97);
            this.lbUnoptimisedParameters.Name = "lbUnoptimisedParameters";
            this.lbUnoptimisedParameters.Size = new System.Drawing.Size(186, 212);
            this.lbUnoptimisedParameters.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Unoptimised SP Parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Optimised SP Parameters";
            // 
            // lbOptimisedParameters
            // 
            this.lbOptimisedParameters.FormattingEnabled = true;
            this.lbOptimisedParameters.Location = new System.Drawing.Point(240, 97);
            this.lbOptimisedParameters.Name = "lbOptimisedParameters";
            this.lbOptimisedParameters.Size = new System.Drawing.Size(186, 212);
            this.lbOptimisedParameters.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(438, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Add Parameter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(438, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(438, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(438, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Type";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(438, 41);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(100, 20);
            this.tbName.TabIndex = 12;
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(438, 79);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(214, 20);
            this.tbValue.TabIndex = 13;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Int",
            "String",
            "Guid",
            "DateTime",
            "Bool"});
            this.cbType.Location = new System.Drawing.Point(438, 121);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(99, 21);
            this.cbType.TabIndex = 14;
            // 
            // btnAddToUnoptimised
            // 
            this.btnAddToUnoptimised.Location = new System.Drawing.Point(583, 150);
            this.btnAddToUnoptimised.Name = "btnAddToUnoptimised";
            this.btnAddToUnoptimised.Size = new System.Drawing.Size(111, 23);
            this.btnAddToUnoptimised.TabIndex = 15;
            this.btnAddToUnoptimised.Text = "Add To Unoptimsied";
            this.btnAddToUnoptimised.UseVisualStyleBackColor = true;
            this.btnAddToUnoptimised.Click += new System.EventHandler(this.BtnAddToUnoptimised_Click);
            // 
            // btnAddToOptimised
            // 
            this.btnAddToOptimised.Location = new System.Drawing.Point(583, 179);
            this.btnAddToOptimised.Name = "btnAddToOptimised";
            this.btnAddToOptimised.Size = new System.Drawing.Size(111, 23);
            this.btnAddToOptimised.TabIndex = 16;
            this.btnAddToOptimised.Text = "Add To Optimsied";
            this.btnAddToOptimised.UseVisualStyleBackColor = true;
            this.btnAddToOptimised.Click += new System.EventHandler(this.BtnAddToOptimised_Click);
            // 
            // btnAddToBoth
            // 
            this.btnAddToBoth.Location = new System.Drawing.Point(583, 208);
            this.btnAddToBoth.Name = "btnAddToBoth";
            this.btnAddToBoth.Size = new System.Drawing.Size(111, 23);
            this.btnAddToBoth.TabIndex = 17;
            this.btnAddToBoth.Text = "Add To Both";
            this.btnAddToBoth.UseVisualStyleBackColor = true;
            this.btnAddToBoth.Click += new System.EventHandler(this.BtnAddToBoth_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(583, 237);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(111, 69);
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(708, 356);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnGenerateGuid);
            this.tabPage1.Controls.Add(this.chkBoxValue);
            this.tabPage1.Controls.Add(this.dtpValue);
            this.tabPage1.Controls.Add(this.lblStatus);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnGenerate);
            this.tabPage1.Controls.Add(this.tbUnoptimisedSPName);
            this.tabPage1.Controls.Add(this.btnAddToBoth);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnAddToOptimised);
            this.tabPage1.Controls.Add(this.tbOptimisedSPName);
            this.tabPage1.Controls.Add(this.btnAddToUnoptimised);
            this.tabPage1.Controls.Add(this.lbUnoptimisedParameters);
            this.tabPage1.Controls.Add(this.cbType);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbValue);
            this.tabPage1.Controls.Add(this.lbOptimisedParameters);
            this.tabPage1.Controls.Add(this.tbName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(700, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.TabPage1_Click);
            // 
            // btnGenerateGuid
            // 
            this.btnGenerateGuid.Location = new System.Drawing.Point(654, 77);
            this.btnGenerateGuid.Name = "btnGenerateGuid";
            this.btnGenerateGuid.Size = new System.Drawing.Size(39, 23);
            this.btnGenerateGuid.TabIndex = 22;
            this.btnGenerateGuid.Text = "Guid";
            this.btnGenerateGuid.UseVisualStyleBackColor = true;
            this.btnGenerateGuid.Click += new System.EventHandler(this.BtnGenerateGuid_Click);
            // 
            // chkBoxValue
            // 
            this.chkBoxValue.AutoSize = true;
            this.chkBoxValue.Location = new System.Drawing.Point(438, 81);
            this.chkBoxValue.Name = "chkBoxValue";
            this.chkBoxValue.Size = new System.Drawing.Size(65, 17);
            this.chkBoxValue.TabIndex = 21;
            this.chkBoxValue.Text = "Is True?";
            this.chkBoxValue.UseVisualStyleBackColor = true;
            // 
            // dtpValue
            // 
            this.dtpValue.CustomFormat = "dd/MM/yy hh:mm";
            this.dtpValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpValue.Location = new System.Drawing.Point(438, 79);
            this.dtpValue.Name = "dtpValue";
            this.dtpValue.Size = new System.Drawing.Size(214, 20);
            this.dtpValue.TabIndex = 20;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(26, 314);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbOutput);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(700, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Generated SQL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(6, 6);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(691, 318);
            this.tbOutput.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbStatus);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(700, 330);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.Location = new System.Drawing.Point(9, 6);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(688, 316);
            this.lbStatus.TabIndex = 21;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox1);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(700, 330);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Read me";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StoredProcedureTester.Properties.Resources.Readme;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(694, 325);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 354);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Stored Procedure Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUnoptimisedSPName;
        private System.Windows.Forms.TextBox tbOptimisedSPName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbUnoptimisedParameters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbOptimisedParameters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnAddToUnoptimised;
        private System.Windows.Forms.Button btnAddToOptimised;
        private System.Windows.Forms.Button btnAddToBoth;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DateTimePicker dtpValue;
        private System.Windows.Forms.CheckBox chkBoxValue;
        private System.Windows.Forms.Button btnGenerateGuid;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

