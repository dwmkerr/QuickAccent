namespace QuickAccent
{
    partial class FormEditAccent
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxDisplayName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAccentValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAltKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCharacterMap = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxShiftedDisplayName = new System.Windows.Forms.TextBox();
            this.buttonCharacterMapShifted = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxShiftedAccent = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxShiftedAltKey = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(208, 453);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 21;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(289, 453);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 22;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxDisplayName
            // 
            this.textBoxDisplayName.Location = new System.Drawing.Point(130, 81);
            this.textBoxDisplayName.Name = "textBoxDisplayName";
            this.textBoxDisplayName.Size = new System.Drawing.Size(211, 20);
            this.textBoxDisplayName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Display Name";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(127, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "This is the text that will be shown in the pop-up menu.";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(127, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 44);
            this.label3.TabIndex = 12;
            this.label3.Text = "This is the text that will be copied to the clipboard when you click on the item " +
    "in the pop-up menu.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Accent";
            // 
            // textBoxAccentValue
            // 
            this.textBoxAccentValue.Location = new System.Drawing.Point(130, 174);
            this.textBoxAccentValue.Name = "textBoxAccentValue";
            this.textBoxAccentValue.Size = new System.Drawing.Size(179, 20);
            this.textBoxAccentValue.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(127, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 44);
            this.label5.TabIndex = 17;
            this.label5.Text = "The Alt Key code for the accent, if there is one.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Alt-Key";
            // 
            // textBoxAltKey
            // 
            this.textBoxAltKey.Location = new System.Drawing.Point(129, 280);
            this.textBoxAltKey.Name = "textBoxAltKey";
            this.textBoxAltKey.Size = new System.Drawing.Size(211, 20);
            this.textBoxAltKey.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 42);
            this.label7.TabIndex = 0;
            this.label7.Text = "Enter the details of the accent below. If you provide \'Shifted\' values, then the " +
    "shifted values will be shown and used when you press the Shift key with the pop-" +
    "up open.";
            // 
            // buttonCharacterMap
            // 
            this.buttonCharacterMap.Enabled = false;
            this.buttonCharacterMap.Location = new System.Drawing.Point(315, 174);
            this.buttonCharacterMap.Name = "buttonCharacterMap";
            this.buttonCharacterMap.Size = new System.Drawing.Size(26, 20);
            this.buttonCharacterMap.TabIndex = 8;
            this.buttonCharacterMap.Text = "...";
            this.buttonCharacterMap.UseVisualStyleBackColor = true;
            this.buttonCharacterMap.Click += new System.EventHandler(this.buttonCharacterMap_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Shifted Display Name";
            // 
            // textBoxShiftedDisplayName
            // 
            this.textBoxShiftedDisplayName.Location = new System.Drawing.Point(130, 107);
            this.textBoxShiftedDisplayName.Name = "textBoxShiftedDisplayName";
            this.textBoxShiftedDisplayName.Size = new System.Drawing.Size(211, 20);
            this.textBoxShiftedDisplayName.TabIndex = 4;
            // 
            // buttonCharacterMapShifted
            // 
            this.buttonCharacterMapShifted.Enabled = false;
            this.buttonCharacterMapShifted.Location = new System.Drawing.Point(315, 200);
            this.buttonCharacterMapShifted.Name = "buttonCharacterMapShifted";
            this.buttonCharacterMapShifted.Size = new System.Drawing.Size(26, 20);
            this.buttonCharacterMapShifted.TabIndex = 11;
            this.buttonCharacterMapShifted.Text = "...";
            this.buttonCharacterMapShifted.UseVisualStyleBackColor = true;
            this.buttonCharacterMapShifted.Click += new System.EventHandler(this.buttonCharacterMapShifted_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Shifted Accent";
            // 
            // textBoxShiftedAccent
            // 
            this.textBoxShiftedAccent.Location = new System.Drawing.Point(130, 200);
            this.textBoxShiftedAccent.Name = "textBoxShiftedAccent";
            this.textBoxShiftedAccent.Size = new System.Drawing.Size(179, 20);
            this.textBoxShiftedAccent.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 309);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Shifted Alt-Key";
            // 
            // textBoxShiftedAltKey
            // 
            this.textBoxShiftedAltKey.Location = new System.Drawing.Point(129, 306);
            this.textBoxShiftedAltKey.Name = "textBoxShiftedAltKey";
            this.textBoxShiftedAltKey.Size = new System.Drawing.Size(211, 20);
            this.textBoxShiftedAltKey.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(90, 372);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Tags";
            // 
            // textBoxTags
            // 
            this.textBoxTags.Location = new System.Drawing.Point(127, 369);
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(211, 20);
            this.textBoxTags.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(127, 392);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(214, 44);
            this.label12.TabIndex = 20;
            this.label12.Text = "Tags let you categorise accents. Tags should be comma separated.";
            // 
            // FormEditAccent
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(376, 488);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxTags);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxShiftedAltKey);
            this.Controls.Add(this.buttonCharacterMapShifted);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxShiftedAccent);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxShiftedDisplayName);
            this.Controls.Add(this.buttonCharacterMap);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxAltKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAccentValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDisplayName);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormEditAccent";
            this.ShowInTaskbar = false;
            this.Text = "Edit Accent";
            this.Load += new System.EventHandler(this.FormEditAccent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxDisplayName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAccentValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAltKey;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonCharacterMap;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxShiftedDisplayName;
        private System.Windows.Forms.Button buttonCharacterMapShifted;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxShiftedAccent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxShiftedAltKey;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.Label label12;
    }
}