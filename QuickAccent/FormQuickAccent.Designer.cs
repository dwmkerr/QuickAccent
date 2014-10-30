namespace QuickAccent
{
    partial class FormQuickAccent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuickAccent));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxStartOnWindowsStart = new System.Windows.Forms.CheckBox();
            this.checkBoxEnableHotkey = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.listViewAccents = new System.Windows.Forms.ListView();
            this.columnHeaderDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAccent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAltCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderShiftDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderShiftAccent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAltCodeShift = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderShow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTags = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            this.toolStripMenuItemSettings.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(32, 19);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxStartOnWindowsStart);
            this.groupBox1.Controls.Add(this.checkBoxEnableHotkey);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 89);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Settings";
            // 
            // checkBoxStartOnWindowsStart
            // 
            this.checkBoxStartOnWindowsStart.AutoSize = true;
            this.checkBoxStartOnWindowsStart.Location = new System.Drawing.Point(18, 47);
            this.checkBoxStartOnWindowsStart.Name = "checkBoxStartOnWindowsStart";
            this.checkBoxStartOnWindowsStart.Size = new System.Drawing.Size(220, 17);
            this.checkBoxStartOnWindowsStart.TabIndex = 1;
            this.checkBoxStartOnWindowsStart.Text = "Start Quick Accent when Windows starts";
            this.checkBoxStartOnWindowsStart.UseVisualStyleBackColor = true;
            this.checkBoxStartOnWindowsStart.CheckedChanged += new System.EventHandler(this.checkBoxStartOnWindowsStart_CheckedChanged);
            // 
            // checkBoxEnableHotkey
            // 
            this.checkBoxEnableHotkey.AutoSize = true;
            this.checkBoxEnableHotkey.Location = new System.Drawing.Point(18, 24);
            this.checkBoxEnableHotkey.Name = "checkBoxEnableHotkey";
            this.checkBoxEnableHotkey.Size = new System.Drawing.Size(333, 17);
            this.checkBoxEnableHotkey.TabIndex = 0;
            this.checkBoxEnableHotkey.Text = "Allow the menu to be opened with the Windows Key + Q shortcut";
            this.checkBoxEnableHotkey.UseVisualStyleBackColor = true;
            this.checkBoxEnableHotkey.CheckedChanged += new System.EventHandler(this.checkBoxEnableHotkey_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonEdit);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.buttonNew);
            this.groupBox2.Controls.Add(this.listViewAccents);
            this.groupBox2.Location = new System.Drawing.Point(12, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 360);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accents";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEdit.Location = new System.Drawing.Point(417, 331);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit...";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(498, 331);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNew.Location = new System.Drawing.Point(579, 331);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 1;
            this.buttonNew.Text = "New...";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // listViewAccents
            // 
            this.listViewAccents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAccents.CheckBoxes = true;
            this.listViewAccents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderDisplayName,
            this.columnHeaderAccent,
            this.columnHeaderAltCode,
            this.columnHeaderShiftDisplayName,
            this.columnHeaderShiftAccent,
            this.columnHeaderAltCodeShift,
            this.columnHeaderShow,
            this.columnHeaderTags});
            this.listViewAccents.FullRowSelect = true;
            this.listViewAccents.GridLines = true;
            this.listViewAccents.Location = new System.Drawing.Point(6, 19);
            this.listViewAccents.Name = "listViewAccents";
            this.listViewAccents.Size = new System.Drawing.Size(648, 306);
            this.listViewAccents.TabIndex = 0;
            this.listViewAccents.UseCompatibleStateImageBehavior = false;
            this.listViewAccents.View = System.Windows.Forms.View.Details;
            this.listViewAccents.VirtualMode = true;
            this.listViewAccents.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listViewAccents_RetrieveVirtualItem);
            // 
            // columnHeaderDisplayName
            // 
            this.columnHeaderDisplayName.Text = "Display Name";
            this.columnHeaderDisplayName.Width = 120;
            // 
            // columnHeaderAccent
            // 
            this.columnHeaderAccent.Text = "Accent";
            this.columnHeaderAccent.Width = 80;
            // 
            // columnHeaderAltCode
            // 
            this.columnHeaderAltCode.Text = "Alt Code";
            this.columnHeaderAltCode.Width = 80;
            // 
            // columnHeaderShiftDisplayName
            // 
            this.columnHeaderShiftDisplayName.Text = "Display Name (Shift)";
            this.columnHeaderShiftDisplayName.Width = 120;
            // 
            // columnHeaderShiftAccent
            // 
            this.columnHeaderShiftAccent.Text = "Accent (Shift)";
            this.columnHeaderShiftAccent.Width = 80;
            // 
            // columnHeaderAltCodeShift
            // 
            this.columnHeaderAltCodeShift.Text = "Alt Code (Shift)";
            this.columnHeaderAltCodeShift.Width = 80;
            // 
            // columnHeaderShow
            // 
            this.columnHeaderShow.Text = "Show in Menu";
            this.columnHeaderShow.Width = 100;
            // 
            // columnHeaderTags
            // 
            this.columnHeaderTags.Text = "Tags";
            this.columnHeaderTags.Width = 200;
            // 
            // FormQuickAccent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 479);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormQuickAccent";
            this.Text = "Quick Accent";
            this.Load += new System.EventHandler(this.FormQuickAccent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.ListView listViewAccents;
        private System.Windows.Forms.ColumnHeader columnHeaderAccent;
        private System.Windows.Forms.ColumnHeader columnHeaderAltCode;
        private System.Windows.Forms.ColumnHeader columnHeaderDisplayName;
        private System.Windows.Forms.ColumnHeader columnHeaderShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ColumnHeader columnHeaderShiftDisplayName;
        private System.Windows.Forms.ColumnHeader columnHeaderShiftAccent;
        private System.Windows.Forms.ColumnHeader columnHeaderAltCodeShift;
        private System.Windows.Forms.ColumnHeader columnHeaderTags;
        private System.Windows.Forms.CheckBox checkBoxEnableHotkey;
        private System.Windows.Forms.CheckBox checkBoxStartOnWindowsStart;
    }
}

