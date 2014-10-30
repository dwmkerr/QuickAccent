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
    /// The Edit Accent form.
    /// </summary>
    public partial class FormEditAccent : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormEditAccent"/> class.
        /// </summary>
        /// <param name="editMode">The edit mode.</param>
        public FormEditAccent(EditMode editMode)
        {
            //  Set the edit mode.
            this.editMode = editMode;

            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FormEditAccent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FormEditAccent_Load(object sender, EventArgs e)
        {
            switch (editMode)
            {
                case EditMode.NewAccent:
                    Text = "New Accent";
                    break;
                case EditMode.EditAccent:
                    Text = "Edit Accent";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //  Do we have an accent?
            if (Accent != null)
            {
                textBoxDisplayName.Text = Accent.DisplayName;
                textBoxShiftedDisplayName.Text = Accent.ShiftDisplayName;
                textBoxAccentValue.Text = Accent.AccentValue;
                textBoxShiftedAccent.Text = Accent.ShiftAccentValue;
                textBoxAltKey.Text = Accent.AltCode;
                textBoxShiftedAltKey.Text = Accent.ShiftAltCode;
                textBoxTags.Text = Accent.Tags;
            }
            else
            {
                Accent = new Accent();
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonCharacterMap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonCharacterMap_Click(object sender, EventArgs e)
        {

            //  Show the character map dialog.
            var characterMapDialog = new FormCharacterMap();
            if (characterMapDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        /// <summary>
        /// Handles the Click event of the buttonOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            //  Save settings.
            Accent.DisplayName = textBoxDisplayName.Text;
            Accent.AccentValue = textBoxAccentValue.Text;
            Accent.AltCode = textBoxAltKey.Text;
            Accent.ShiftDisplayName = textBoxShiftedDisplayName.Text;
            Accent.ShiftAccentValue = textBoxShiftedAccent.Text;
            Accent.ShiftAltCode = textBoxShiftedAltKey.Text;
            Accent.Tags = textBoxTags.Text;
        }

        /// <summary>
        /// Handles the Click event of the buttonCharacterMapShifted control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonCharacterMapShifted_Click(object sender, EventArgs e)
        {
            //  Show the character map dialog.
            var characterMapDialog = new FormCharacterMap();
            if (characterMapDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }

        /// <summary>
        /// The edit mode.
        /// </summary>
        private EditMode editMode = EditMode.EditAccent;

        /// <summary>
        /// Defines the edit mode.
        /// </summary>
        public enum EditMode
        {
            NewAccent,
            EditAccent
        }

        /// <summary>
        /// Gets or sets the accent.
        /// </summary>
        /// <value>
        /// The accent.
        /// </value>
        public Accent Accent { get; set; }
    }
}
