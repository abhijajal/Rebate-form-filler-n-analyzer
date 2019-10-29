namespace Asg2_apj180001
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.colFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhoneNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelFirstName = new System.Windows.Forms.Label();
            this.labelMiddileInit = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.labelAddrLine1 = new System.Windows.Forms.Label();
            this.labelAddrLine2 = new System.Windows.Forms.Label();
            this.labelCtiy = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.labelZipCode = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelProofOfPurchase = new System.Windows.Forms.Label();
            this.labelDateReceived = new System.Windows.Forms.Label();
            this.comboPofa = new System.Windows.Forms.ComboBox();
            this.dateRecieved = new System.Windows.Forms.DateTimePicker();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textPhoneNo = new System.Windows.Forms.TextBox();
            this.comboGender = new System.Windows.Forms.ComboBox();
            this.maskedZipCode = new System.Windows.Forms.MaskedTextBox();
            this.textCity = new System.Windows.Forms.TextBox();
            this.textAddr2 = new System.Windows.Forms.TextBox();
            this.textAddr1 = new System.Windows.Forms.TextBox();
            this.textLastName = new System.Windows.Forms.TextBox();
            this.textMiddleName = new System.Windows.Forms.TextBox();
            this.textFirstName = new System.Windows.Forms.TextBox();
            this.comboState = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.stripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFullName,
            this.colPhoneNo});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(204, 413);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView1_ItemSelectionChanged);
            // 
            // colFullName
            // 
            this.colFullName.Text = "Full name";
            this.colFullName.Width = 90;
            // 
            // colPhoneNo
            // 
            this.colPhoneNo.Text = "Phone number";
            this.colPhoneNo.Width = 90;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFirstName.Location = new System.Drawing.Point(12, 3);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(74, 17);
            this.labelFirstName.TabIndex = 1;
            this.labelFirstName.Text = "First name";
            // 
            // labelMiddileInit
            // 
            this.labelMiddileInit.AutoSize = true;
            this.labelMiddileInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMiddileInit.Location = new System.Drawing.Point(12, 35);
            this.labelMiddileInit.Name = "labelMiddileInit";
            this.labelMiddileInit.Size = new System.Drawing.Size(85, 17);
            this.labelMiddileInit.TabIndex = 2;
            this.labelMiddileInit.Text = "Middle initial";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastName.Location = new System.Drawing.Point(12, 69);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(74, 17);
            this.labelLastName.TabIndex = 3;
            this.labelLastName.Text = "Last name";
            // 
            // labelAddrLine1
            // 
            this.labelAddrLine1.AutoSize = true;
            this.labelAddrLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddrLine1.Location = new System.Drawing.Point(12, 103);
            this.labelAddrLine1.Name = "labelAddrLine1";
            this.labelAddrLine1.Size = new System.Drawing.Size(98, 17);
            this.labelAddrLine1.TabIndex = 4;
            this.labelAddrLine1.Text = "Address line 1";
            // 
            // labelAddrLine2
            // 
            this.labelAddrLine2.AutoSize = true;
            this.labelAddrLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddrLine2.Location = new System.Drawing.Point(12, 132);
            this.labelAddrLine2.Name = "labelAddrLine2";
            this.labelAddrLine2.Size = new System.Drawing.Size(98, 17);
            this.labelAddrLine2.TabIndex = 5;
            this.labelAddrLine2.Text = "Address line 2";
            // 
            // labelCtiy
            // 
            this.labelCtiy.AutoSize = true;
            this.labelCtiy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCtiy.Location = new System.Drawing.Point(12, 161);
            this.labelCtiy.Name = "labelCtiy";
            this.labelCtiy.Size = new System.Drawing.Size(31, 17);
            this.labelCtiy.TabIndex = 6;
            this.labelCtiy.Text = "City";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelState.Location = new System.Drawing.Point(12, 193);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(41, 17);
            this.labelState.TabIndex = 7;
            this.labelState.Text = "State";
            // 
            // labelZipCode
            // 
            this.labelZipCode.AutoSize = true;
            this.labelZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelZipCode.Location = new System.Drawing.Point(12, 222);
            this.labelZipCode.Name = "labelZipCode";
            this.labelZipCode.Size = new System.Drawing.Size(63, 17);
            this.labelZipCode.TabIndex = 8;
            this.labelZipCode.Text = "Zip code";
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGender.Location = new System.Drawing.Point(12, 253);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(56, 17);
            this.labelGender.TabIndex = 9;
            this.labelGender.Text = "Gender";
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhoneNumber.Location = new System.Drawing.Point(12, 281);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(101, 17);
            this.labelPhoneNumber.TabIndex = 10;
            this.labelPhoneNumber.Text = "Phone number";
            this.labelPhoneNumber.Click += new System.EventHandler(this.LabelPhoneNo_Click);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(12, 309);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(102, 17);
            this.labelEmail.TabIndex = 11;
            this.labelEmail.Text = "E-mail address";
            // 
            // labelProofOfPurchase
            // 
            this.labelProofOfPurchase.AutoSize = true;
            this.labelProofOfPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProofOfPurchase.Location = new System.Drawing.Point(12, 338);
            this.labelProofOfPurchase.Name = "labelProofOfPurchase";
            this.labelProofOfPurchase.Size = new System.Drawing.Size(180, 17);
            this.labelProofOfPurchase.TabIndex = 12;
            this.labelProofOfPurchase.Text = "Proof of purchase attached";
            this.labelProofOfPurchase.Click += new System.EventHandler(this.LabelPofa_Click);
            // 
            // labelDateReceived
            // 
            this.labelDateReceived.AutoSize = true;
            this.labelDateReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateReceived.Location = new System.Drawing.Point(12, 368);
            this.labelDateReceived.Name = "labelDateReceived";
            this.labelDateReceived.Size = new System.Drawing.Size(96, 17);
            this.labelDateReceived.TabIndex = 13;
            this.labelDateReceived.Text = "Data received";
            // 
            // comboPofa
            // 
            this.comboPofa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboPofa.FormattingEnabled = true;
            this.comboPofa.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.comboPofa.Location = new System.Drawing.Point(212, 338);
            this.comboPofa.Name = "comboPofa";
            this.comboPofa.Size = new System.Drawing.Size(50, 24);
            this.comboPofa.TabIndex = 11;
            this.comboPofa.SelectedIndexChanged += new System.EventHandler(this.ComboPofa_SelectedIndexChanged);
            // 
            // dateRecieved
            // 
            this.dateRecieved.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateRecieved.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateRecieved.Location = new System.Drawing.Point(212, 368);
            this.dateRecieved.Name = "dateRecieved";
            this.dateRecieved.Size = new System.Drawing.Size(170, 23);
            this.dateRecieved.TabIndex = 12;
            this.dateRecieved.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // textEmail
            // 
            this.textEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textEmail.Location = new System.Drawing.Point(212, 309);
            this.textEmail.MaximumSize = new System.Drawing.Size(600, 23);
            this.textEmail.MaxLength = 60;
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(350, 23);
            this.textEmail.TabIndex = 10;
            this.textEmail.TextChanged += new System.EventHandler(this.TextEmail_TextChanged);
            // 
            // textPhoneNo
            // 
            this.textPhoneNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textPhoneNo.Location = new System.Drawing.Point(212, 281);
            this.textPhoneNo.MaxLength = 21;
            this.textPhoneNo.Name = "textPhoneNo";
            this.textPhoneNo.Size = new System.Drawing.Size(210, 23);
            this.textPhoneNo.TabIndex = 9;
            this.textPhoneNo.TextChanged += new System.EventHandler(this.TextPhoneNo_TextChanged);
            // 
            // comboGender
            // 
            this.comboGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboGender.FormattingEnabled = true;
            this.comboGender.Items.AddRange(new object[] {
            "M",
            "F"});
            this.comboGender.Location = new System.Drawing.Point(212, 253);
            this.comboGender.Name = "comboGender";
            this.comboGender.Size = new System.Drawing.Size(35, 24);
            this.comboGender.TabIndex = 8;
            this.comboGender.SelectedIndexChanged += new System.EventHandler(this.ComboGender_SelectedIndexChanged);
            // 
            // maskedZipCode
            // 
            this.maskedZipCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.maskedZipCode.Location = new System.Drawing.Point(212, 225);
            this.maskedZipCode.Mask = "00000-9999";
            this.maskedZipCode.Name = "maskedZipCode";
            this.maskedZipCode.Size = new System.Drawing.Size(100, 23);
            this.maskedZipCode.TabIndex = 7;
            this.maskedZipCode.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MaskedZipCode_MaskInputRejected);
            this.maskedZipCode.TextChanged += new System.EventHandler(this.MaskedZipCode_TextChanged);
            // 
            // textCity
            // 
            this.textCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textCity.Location = new System.Drawing.Point(212, 164);
            this.textCity.MaxLength = 25;
            this.textCity.Name = "textCity";
            this.textCity.Size = new System.Drawing.Size(250, 23);
            this.textCity.TabIndex = 5;
            this.textCity.TextChanged += new System.EventHandler(this.TextCity_TextChanged);
            // 
            // textAddr2
            // 
            this.textAddr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textAddr2.Location = new System.Drawing.Point(212, 132);
            this.textAddr2.MaxLength = 35;
            this.textAddr2.Name = "textAddr2";
            this.textAddr2.Size = new System.Drawing.Size(350, 23);
            this.textAddr2.TabIndex = 4;
            // 
            // textAddr1
            // 
            this.textAddr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textAddr1.Location = new System.Drawing.Point(212, 103);
            this.textAddr1.MaxLength = 35;
            this.textAddr1.Name = "textAddr1";
            this.textAddr1.Size = new System.Drawing.Size(350, 23);
            this.textAddr1.TabIndex = 3;
            this.textAddr1.TextChanged += new System.EventHandler(this.TextAddr1_TextChanged);
            // 
            // textLastName
            // 
            this.textLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textLastName.Location = new System.Drawing.Point(212, 69);
            this.textLastName.MaxLength = 20;
            this.textLastName.Name = "textLastName";
            this.textLastName.Size = new System.Drawing.Size(200, 23);
            this.textLastName.TabIndex = 2;
            this.textLastName.TextChanged += new System.EventHandler(this.TextLastName_TextChanged);
            // 
            // textMiddleName
            // 
            this.textMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textMiddleName.Location = new System.Drawing.Point(212, 37);
            this.textMiddleName.MaxLength = 1;
            this.textMiddleName.Name = "textMiddleName";
            this.textMiddleName.Size = new System.Drawing.Size(20, 23);
            this.textMiddleName.TabIndex = 1;
            // 
            // textFirstName
            // 
            this.textFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textFirstName.Location = new System.Drawing.Point(212, 4);
            this.textFirstName.MaxLength = 20;
            this.textFirstName.Name = "textFirstName";
            this.textFirstName.Size = new System.Drawing.Size(200, 23);
            this.textFirstName.TabIndex = 0;
            this.textFirstName.TextChanged += new System.EventHandler(this.TextFirstName_TextChanged);
            // 
            // comboState
            // 
            this.comboState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboState.FormattingEnabled = true;
            this.comboState.Location = new System.Drawing.Point(212, 193);
            this.comboState.Name = "comboState";
            this.comboState.Size = new System.Drawing.Size(45, 24);
            this.comboState.TabIndex = 6;
            this.comboState.SelectedIndexChanged += new System.EventHandler(this.ComboState_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonSave.Location = new System.Drawing.Point(212, 397);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Enabled = false;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonClear.Location = new System.Drawing.Point(359, 397);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 14;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDelete.Location = new System.Drawing.Point(487, 396);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 15;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripLabel,
            this.stripValue});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 21;
            this.statusStrip.Text = "statusStrip";
            // 
            // stripLabel
            // 
            this.stripLabel.Name = "stripLabel";
            this.stripLabel.Size = new System.Drawing.Size(58, 17);
            this.stripLabel.Text = "stripLabel";
            // 
            // stripValue
            // 
            this.stripValue.Name = "stripValue";
            this.stripValue.Size = new System.Drawing.Size(58, 17);
            this.stripValue.Text = "stripValue";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textFirstName);
            this.panel1.Controls.Add(this.comboPofa);
            this.panel1.Controls.Add(this.labelDateReceived);
            this.panel1.Controls.Add(this.buttonDelete);
            this.panel1.Controls.Add(this.labelProofOfPurchase);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.dateRecieved);
            this.panel1.Controls.Add(this.labelPhoneNumber);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Controls.Add(this.labelGender);
            this.panel1.Controls.Add(this.textEmail);
            this.panel1.Controls.Add(this.labelZipCode);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.labelState);
            this.panel1.Controls.Add(this.textPhoneNo);
            this.panel1.Controls.Add(this.labelCtiy);
            this.panel1.Controls.Add(this.comboState);
            this.panel1.Controls.Add(this.labelAddrLine2);
            this.panel1.Controls.Add(this.comboGender);
            this.panel1.Controls.Add(this.labelAddrLine1);
            this.panel1.Controls.Add(this.maskedZipCode);
            this.panel1.Controls.Add(this.labelLastName);
            this.panel1.Controls.Add(this.textMiddleName);
            this.panel1.Controls.Add(this.labelMiddileInit);
            this.panel1.Controls.Add(this.textCity);
            this.panel1.Controls.Add(this.labelFirstName);
            this.panel1.Controls.Add(this.textLastName);
            this.panel1.Controls.Add(this.textAddr2);
            this.panel1.Controls.Add(this.textAddr1);
            this.panel1.Location = new System.Drawing.Point(222, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 418);
            this.panel1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelMiddileInit;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelAddrLine1;
        private System.Windows.Forms.Label labelAddrLine2;
        private System.Windows.Forms.Label labelCtiy;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label labelZipCode;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelProofOfPurchase;
        private System.Windows.Forms.Label labelDateReceived;
        private System.Windows.Forms.ComboBox comboPofa;
        private System.Windows.Forms.DateTimePicker dateRecieved;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textPhoneNo;
        private System.Windows.Forms.ComboBox comboGender;
        private System.Windows.Forms.MaskedTextBox maskedZipCode;
        private System.Windows.Forms.TextBox textCity;
        private System.Windows.Forms.TextBox textAddr2;
        private System.Windows.Forms.TextBox textAddr1;
        private System.Windows.Forms.TextBox textLastName;
        private System.Windows.Forms.TextBox textMiddleName;
        private System.Windows.Forms.TextBox textFirstName;
        private System.Windows.Forms.ComboBox comboState;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ColumnHeader colFullName;
        private System.Windows.Forms.ColumnHeader colPhoneNo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel stripLabel;
        private System.Windows.Forms.ToolStripStatusLabel stripValue;
        private System.Windows.Forms.Panel panel1;
    }
}

