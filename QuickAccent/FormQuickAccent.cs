using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickAccent
{
    /// <summary>
    /// The QuickAccent form.
    /// </summary>
    public partial class FormQuickAccent : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormQuickAccent"/> class.
        /// </summary>
        public FormQuickAccent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the buttonNew control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonNew_Click(object sender, EventArgs e)
        {
            //  Create the edit accent dialog, with the 'New Accent' option.
            var newAccentForm = new FormEditAccent(FormEditAccent.EditMode.NewAccent);
            
            //  Show the dialog.
            if (newAccentForm.ShowDialog(this) == DialogResult.OK)
            {
                //  We have a new accent, add it to the settings and repopulate.
                ApplicationContext.Instance.Settings.Accents.Add(newAccentForm.Accent);
                ApplicationContext.Instance.SaveSettings();
                OnAccentsChanged();
            }
        }

        /// <summary>
        /// Called when accents changed.
        /// </summary>
        private void OnAccentsChanged()
        {
            //  Set the sorted accents.
            listViewAccents.VirtualListSize = ApplicationContext.Instance.DisplayAccents.Count();
            Program.CreateAccentMenuItems();
        }

        /// <summary>
        /// Handles the Load event of the FormQuickAccent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FormQuickAccent_Load(object sender, EventArgs e)
        {
           OnAccentsChanged();

           checkBoxEnableHotkey.Checked = ApplicationContext.Instance.Settings.UseWindowsHotkey;
           checkBoxStartOnWindowsStart.Checked = ApplicationContext.Instance.Settings.StartOnWindowsLogon;
        }

        /// <summary>
        /// Handles the RetrieveVirtualItem event of the listViewAccents control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.RetrieveVirtualItemEventArgs"/> instance containing the event data.</param>
        private void listViewAccents_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            //  Get the accent.
            var accent = ApplicationContext.Instance.DisplayAccents.ElementAt(e.ItemIndex);
            e.Item = new ListViewItem(
                new []
                    {
                        accent.DisplayName,
                        accent.AccentValue,
                        accent.AltCode,
                        accent.ShiftDisplayName,
                        accent.ShiftAccentValue,
                        accent.ShiftAltCode,
                        accent.ShowInMenu ? "Yes" : "No",
                        string.Join(", ", accent.ParseTags())
                    }
                );
        }

        /// <summary>
        /// Handles the Click event of the buttonEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //  Get the selected accent.
            if (SelectedAccent != null)
            {

                //  Create the edit accent dialog, with the 'New Accent' option.
                var newAccentForm = new FormEditAccent(FormEditAccent.EditMode.EditAccent);
                newAccentForm.Accent = SelectedAccent;

                //  Show the dialog.
                if (newAccentForm.ShowDialog(this) == DialogResult.OK)
                {
                    //  We have changed an accent.
                    ApplicationContext.Instance.SaveSettings();
                    OnAccentsChanged();
                }
            }

        }

        /// <summary>
        /// Handles the Click event of the buttonDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //  Get the selected accent.
            if (SelectedAccent != null)
            {
                listViewAccents.VirtualListSize = 0;
                ApplicationContext.Instance.Settings.Accents.Remove(SelectedAccent);
                ApplicationContext.Instance.SaveSettings();
                OnAccentsChanged();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBoxEnableHotkey control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void checkBoxEnableHotkey_CheckedChanged(object sender, EventArgs e)
        {
            //  Set the setting.
            ApplicationContext.Instance.Settings.UseWindowsHotkey = checkBoxEnableHotkey.Checked;
            ApplicationContext.Instance.SaveSettings();
            Program.UpdateHotkeyState(ApplicationContext.Instance.Settings.UseWindowsHotkey);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBoxStartOnWindowsStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void checkBoxStartOnWindowsStart_CheckedChanged(object sender, EventArgs e)
        {
            //  Set the setting.
            ApplicationContext.Instance.Settings.StartOnWindowsLogon = checkBoxStartOnWindowsStart.Checked;
            ApplicationContext.Instance.SaveSettings();
            ApplicationContext.Instance.ApplyWindowsSettings();
        }

        /// <summary>
        /// Gets the selected accent.
        /// </summary>
        public Accent SelectedAccent
        {
            get { return listViewAccents.SelectedIndices.Count > 0 ? ApplicationContext.Instance.DisplayAccents.ElementAt(listViewAccents.SelectedIndices[0]) : null; }
        }
    }
}
