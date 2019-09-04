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
            this.label13 = new System.Windows.Forms.Label();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.btnGenerateGuid = new System.Windows.Forms.Button();
            this.chkBoxValue = new System.Windows.Forms.CheckBox();
            this.dtpValue = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lException = new System.Windows.Forms.Label();
            this.lNoResults = new System.Windows.Forms.Label();
            this.lDateTimeRun = new System.Windows.Forms.Label();
            this.btnRunAgain = new System.Windows.Forms.Button();
            this.l4th = new System.Windows.Forms.Label();
            this.l3rd = new System.Windows.Forms.Label();
            this.l2nd = new System.Windows.Forms.Label();
            this.l1st = new System.Windows.Forms.Label();
            this.lDifferencePercent = new System.Windows.Forms.Label();
            this.lDifference = new System.Windows.Forms.Label();
            this.lOptimisedTotalTime = new System.Windows.Forms.Label();
            this.lUnoptimisedTotalTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lOverall = new System.Windows.Forms.Label();
            this.lFourth = new System.Windows.Forms.Label();
            this.lThird = new System.Windows.Forms.Label();
            this.lSecond = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lFirst = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbStatus = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(26, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unoptimised SP Name";
            // 
            // tbUnoptimisedSPName
            // 
            this.tbUnoptimisedSPName.Location = new System.Drawing.Point(25, 56);
            this.tbUnoptimisedSPName.Name = "tbUnoptimisedSPName";
            this.tbUnoptimisedSPName.Size = new System.Drawing.Size(186, 20);
            this.tbUnoptimisedSPName.TabIndex = 1;
            this.tbUnoptimisedSPName.Text = "dbo.Test";
            // 
            // tbOptimisedSPName
            // 
            this.tbOptimisedSPName.Location = new System.Drawing.Point(240, 56);
            this.tbOptimisedSPName.Name = "tbOptimisedSPName";
            this.tbOptimisedSPName.Size = new System.Drawing.Size(186, 20);
            this.tbOptimisedSPName.TabIndex = 3;
            this.tbOptimisedSPName.Text = "dbo.TestOptimised";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 40);
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
            this.lbUnoptimisedParameters.Size = new System.Drawing.Size(186, 186);
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
            this.lbOptimisedParameters.Size = new System.Drawing.Size(186, 186);
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
            this.btnGenerate.Size = new System.Drawing.Size(111, 46);
            this.btnGenerate.TabIndex = 18;
            this.btnGenerate.Text = "Run";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(708, 353);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.tbDBName);
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
            this.tabPage1.Size = new System.Drawing.Size(700, 327);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(71, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "DB Name";
            // 
            // tbDBName
            // 
            this.tbDBName.Location = new System.Drawing.Point(137, 8);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(186, 20);
            this.tbDBName.TabIndex = 24;
            this.tbDBName.Text = "VCBedrock";
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
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(3, 283);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(694, 41);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status:";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.LightCoral;
            this.tabPage5.Controls.Add(this.lException);
            this.tabPage5.Controls.Add(this.lNoResults);
            this.tabPage5.Controls.Add(this.lDateTimeRun);
            this.tabPage5.Controls.Add(this.btnRunAgain);
            this.tabPage5.Controls.Add(this.l4th);
            this.tabPage5.Controls.Add(this.l3rd);
            this.tabPage5.Controls.Add(this.l2nd);
            this.tabPage5.Controls.Add(this.l1st);
            this.tabPage5.Controls.Add(this.lDifferencePercent);
            this.tabPage5.Controls.Add(this.lDifference);
            this.tabPage5.Controls.Add(this.lOptimisedTotalTime);
            this.tabPage5.Controls.Add(this.lUnoptimisedTotalTime);
            this.tabPage5.Controls.Add(this.label11);
            this.tabPage5.Controls.Add(this.lOverall);
            this.tabPage5.Controls.Add(this.lFourth);
            this.tabPage5.Controls.Add(this.lThird);
            this.tabPage5.Controls.Add(this.lSecond);
            this.tabPage5.Controls.Add(this.label12);
            this.tabPage5.Controls.Add(this.lFirst);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(700, 327);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Results";
            // 
            // lException
            // 
            this.lException.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lException.Location = new System.Drawing.Point(3, 206);
            this.lException.Name = "lException";
            this.lException.Size = new System.Drawing.Size(694, 118);
            this.lException.TabIndex = 20;
            this.lException.Text = "Exception:";
            this.lException.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lException.Visible = false;
            // 
            // lNoResults
            // 
            this.lNoResults.AutoSize = true;
            this.lNoResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNoResults.Location = new System.Drawing.Point(252, 146);
            this.lNoResults.Name = "lNoResults";
            this.lNoResults.Size = new System.Drawing.Size(197, 39);
            this.lNoResults.TabIndex = 19;
            this.lNoResults.Text = "No Results";
            // 
            // lDateTimeRun
            // 
            this.lDateTimeRun.AutoSize = true;
            this.lDateTimeRun.Location = new System.Drawing.Point(381, 187);
            this.lDateTimeRun.Name = "lDateTimeRun";
            this.lDateTimeRun.Size = new System.Drawing.Size(176, 13);
            this.lDateTimeRun.TabIndex = 18;
            this.lDateTimeRun.Text = "Date Time Run: 03/09/19 03:15:21";
            // 
            // btnRunAgain
            // 
            this.btnRunAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunAgain.Location = new System.Drawing.Point(388, 253);
            this.btnRunAgain.Name = "btnRunAgain";
            this.btnRunAgain.Size = new System.Drawing.Size(163, 46);
            this.btnRunAgain.TabIndex = 17;
            this.btnRunAgain.Text = "Try Again";
            this.btnRunAgain.UseVisualStyleBackColor = true;
            this.btnRunAgain.Click += new System.EventHandler(this.BtnRunAgain_Click);
            // 
            // l4th
            // 
            this.l4th.AutoSize = true;
            this.l4th.Location = new System.Drawing.Point(323, 95);
            this.l4th.Name = "l4th";
            this.l4th.Size = new System.Drawing.Size(46, 13);
            this.l4th.TabIndex = 16;
            this.l4th.Text = "4th Test";
            // 
            // l3rd
            // 
            this.l3rd.AutoSize = true;
            this.l3rd.Location = new System.Drawing.Point(323, 73);
            this.l3rd.Name = "l3rd";
            this.l3rd.Size = new System.Drawing.Size(46, 13);
            this.l3rd.TabIndex = 15;
            this.l3rd.Text = "3rd Test";
            // 
            // l2nd
            // 
            this.l2nd.AutoSize = true;
            this.l2nd.Location = new System.Drawing.Point(323, 51);
            this.l2nd.Name = "l2nd";
            this.l2nd.Size = new System.Drawing.Size(49, 13);
            this.l2nd.TabIndex = 14;
            this.l2nd.Text = "2nd Test";
            // 
            // l1st
            // 
            this.l1st.AutoSize = true;
            this.l1st.Location = new System.Drawing.Point(323, 29);
            this.l1st.Name = "l1st";
            this.l1st.Size = new System.Drawing.Size(45, 13);
            this.l1st.TabIndex = 13;
            this.l1st.Text = "1st Test";
            // 
            // lDifferencePercent
            // 
            this.lDifferencePercent.AutoSize = true;
            this.lDifferencePercent.Location = new System.Drawing.Point(6, 253);
            this.lDifferencePercent.Name = "lDifferencePercent";
            this.lDifferencePercent.Size = new System.Drawing.Size(76, 13);
            this.lDifferencePercent.TabIndex = 12;
            this.lDifferencePercent.Text = "Difference (%):";
            // 
            // lDifference
            // 
            this.lDifference.AutoSize = true;
            this.lDifference.Location = new System.Drawing.Point(6, 231);
            this.lDifference.Name = "lDifference";
            this.lDifference.Size = new System.Drawing.Size(81, 13);
            this.lDifference.TabIndex = 11;
            this.lDifference.Text = "Difference (ms):";
            // 
            // lOptimisedTotalTime
            // 
            this.lOptimisedTotalTime.AutoSize = true;
            this.lOptimisedTotalTime.Location = new System.Drawing.Point(6, 209);
            this.lOptimisedTotalTime.Name = "lOptimisedTotalTime";
            this.lOptimisedTotalTime.Size = new System.Drawing.Size(131, 13);
            this.lOptimisedTotalTime.TabIndex = 10;
            this.lOptimisedTotalTime.Text = "Optimised Total Time (ms):";
            // 
            // lUnoptimisedTotalTime
            // 
            this.lUnoptimisedTotalTime.AutoSize = true;
            this.lUnoptimisedTotalTime.Location = new System.Drawing.Point(6, 187);
            this.lUnoptimisedTotalTime.Name = "lUnoptimisedTotalTime";
            this.lUnoptimisedTotalTime.Size = new System.Drawing.Size(143, 13);
            this.lUnoptimisedTotalTime.TabIndex = 9;
            this.lUnoptimisedTotalTime.Text = "Unoptimised Total Time (ms):";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Performance";
            // 
            // lOverall
            // 
            this.lOverall.AutoSize = true;
            this.lOverall.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOverall.Location = new System.Drawing.Point(286, 205);
            this.lOverall.Name = "lOverall";
            this.lOverall.Size = new System.Drawing.Size(367, 39);
            this.lOverall.TabIndex = 7;
            this.lOverall.Text = "Overall Result: PASS";
            // 
            // lFourth
            // 
            this.lFourth.AutoSize = true;
            this.lFourth.Location = new System.Drawing.Point(6, 95);
            this.lFourth.Name = "lFourth";
            this.lFourth.Size = new System.Drawing.Size(182, 13);
            this.lFourth.TabIndex = 6;
            this.lFourth.Text = "4th Test (Same data returned): PASS";
            // 
            // lThird
            // 
            this.lThird.AutoSize = true;
            this.lThird.Location = new System.Drawing.Point(6, 73);
            this.lThird.Name = "lThird";
            this.lThird.Size = new System.Drawing.Size(200, 13);
            this.lThird.TabIndex = 5;
            this.lThird.Text = "3rd Test (Same columns returned): PASS";
            // 
            // lSecond
            // 
            this.lSecond.AutoSize = true;
            this.lSecond.Location = new System.Drawing.Point(6, 51);
            this.lSecond.Name = "lSecond";
            this.lSecond.Size = new System.Drawing.Size(253, 13);
            this.lSecond.TabIndex = 4;
            this.lSecond.Text = "2nd Test (Same number of columns returned): PASS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(323, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Messages";
            // 
            // lFirst
            // 
            this.lFirst.AutoSize = true;
            this.lFirst.Location = new System.Drawing.Point(6, 29);
            this.lFirst.Name = "lFirst";
            this.lFirst.Size = new System.Drawing.Size(232, 13);
            this.lFirst.TabIndex = 1;
            this.lFirst.Text = "1st Test (Same number of rows returned): PASS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Results";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCopyToClipboard);
            this.tabPage2.Controls.Add(this.tbOutput);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(700, 327);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Generated SQL";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(6, 302);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(689, 23);
            this.btnCopyToClipboard.TabIndex = 1;
            this.btnCopyToClipboard.Text = "Copy to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.BtnCopyToClipboard_Click);
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(6, 6);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbOutput.Size = new System.Drawing.Size(688, 294);
            this.tbOutput.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbStatus);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(700, 327);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.FormattingEnabled = true;
            this.lbStatus.HorizontalScrollbar = true;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::StoredProcedureTester.Properties.Resources.Readme2;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(694, 325);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 354);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Stored Procedure Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label lDifferencePercent;
        private System.Windows.Forms.Label lDifference;
        private System.Windows.Forms.Label lOptimisedTotalTime;
        private System.Windows.Forms.Label lUnoptimisedTotalTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lOverall;
        private System.Windows.Forms.Label lFourth;
        private System.Windows.Forms.Label lThird;
        private System.Windows.Forms.Label lSecond;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lFirst;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label l4th;
        private System.Windows.Forms.Label l3rd;
        private System.Windows.Forms.Label l2nd;
        private System.Windows.Forms.Label l1st;
        private System.Windows.Forms.Button btnRunAgain;
        private System.Windows.Forms.Label lDateTimeRun;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.Label lNoResults;
        private System.Windows.Forms.Label lException;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbDBName;
    }
}

