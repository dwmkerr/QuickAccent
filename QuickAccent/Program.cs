using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuickAccent
{
    /// <summary>
    /// The main program class.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //  Load the settings.
            ApplicationContext.Instance.LoadSettings();

            //  Create the context menu.
            CreateContextMenu();

            //  Create the tray icon.
            CreateTrayIcon();

            //  Create the menu items.
            CreateAccentMenuItems();

            //  Set the hotkey.
            UpdateHotkeyState(ApplicationContext.Instance.Settings.UseWindowsHotkey);

            //  Run the main window.
            Application.Run();
        }

        /// <summary>
        /// Creates the context menu.
        /// </summary>
        private static void CreateContextMenu()
        {
            contextMenu = new HotkeyEnabledContextMenuStrip();
            contextMenu.Name = "Context Menu";
            contextMenu.HotkeyModifier = ModifierKeys.Win;
            contextMenu.Hotkey = Keys.Q;

            //  Add the separator.
            contextMenu.Items.Add(new ToolStripSeparator());

            //  Add 'Settings'.
            var settingsItem = new ToolStripMenuItem("&Settings");
            settingsItem.Click += settingsItem_Click;
            contextMenu.Items.Add(settingsItem);

            //  Add 'Exit'.
            var exitItem = new ToolStripMenuItem("E&xit");
            exitItem.Click += exitItem_Click;
            contextMenu.Items.Add(exitItem);

            //  The context menu will also have to wait for keyup/keydown to handle shift functionality.
            contextMenu.KeyDown += contextMenu_KeyDown;
            contextMenu.KeyUp += contextMenu_KeyUp;
            contextMenu.Closed += contextMenu_Closed;
        }

        /// <summary>
        /// Shows the settings window.
        /// </summary>
        private static void ShowSettingsWindow()
        {
            //  Is the settings form open? If so, activate it.
            if (settingsForm != null && settingsForm.IsHandleCreated)
            {
                settingsForm.Activate();
                return;
            }

            //  Create the settings form.
            settingsForm = new FormQuickAccent();

            //  Show the settings form.
            settingsForm.Show();
        }

        /// <summary>
        /// Handles the Closed event of the contextMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ToolStripDropDownClosedEventArgs"/> instance containing the event data.</param>
        static void contextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            SetShiftMode(false);
        }

        /// <summary>
        /// Handles the KeyUp event of the contextMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        static void contextMenu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                SetShiftMode(false);
        }

        /// <summary>
        /// Handles the KeyDown event of the contextMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        static void contextMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey)
                SetShiftMode(true);
        }

        /// <summary>
        /// The shifted menu items.
        /// </summary>
        private static readonly List<ToolStripMenuItem> shiftedMenuItems = new List<ToolStripMenuItem>();

        /// <summary>
        /// Sets the shift mode.
        /// </summary>
        /// <param name="shift">if set to <c>true</c> [shift].</param>
        private static void SetShiftMode(bool shift)
        {
            //  Go through every accent menu item.
            foreach (var menuItem in GetAccentMenuItems())
            {
                var accent = (Accent)menuItem.Tag;

                //  If the accent is empty, skip it.
                if (string.IsNullOrEmpty(accent.DisplayName))
                    continue;
                

                if (shift == false)
                {
                    menuItem.Text = accent.DisplayName;
                    shiftedMenuItems.Remove(menuItem);
                }
                else if (!string.IsNullOrEmpty(accent.ShiftDisplayName) && !string.IsNullOrEmpty(accent.ShiftAccentValue))
                {
                    //  Change the mode.
                    menuItem.Text = accent.ShiftDisplayName;
                    shiftedMenuItems.Add(menuItem);
                }
            }
        }

        /// <summary>
        /// Gets the accent menu items.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<ToolStripMenuItem> GetAccentMenuItems()
        {
            return contextMenu.Items.OfType<ToolStripMenuItem>().Where(tsmi => tsmi.Tag is Accent);
        }

        /// <summary>
        /// Handles the Click event of the exitItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        static void exitItem_Click(object sender, EventArgs e)
        {
            trayIcon.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the settingsItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        static void settingsItem_Click(object sender, EventArgs e)
        {
            ShowSettingsWindow();
        }

        /// <summary>
        /// Creates the tray icon.
        /// </summary>
        private static void CreateTrayIcon()
        {
            trayIcon = new NotifyIcon();
            trayIcon.ContextMenuStrip = contextMenu;
            trayIcon.Icon = Properties.Resources.QuickAccentIconSmall;
            trayIcon.Visible = true;
            trayIcon.Text = "QuickAccent - Quickly copy accents to your clipboard";
            trayIcon.MouseDoubleClick += trayIcon_MouseDoubleClick;
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the trayIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        static void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowSettingsWindow();
        }

        /// <summary>
        /// Creates the accent menu items.
        /// </summary>
        public static void CreateAccentMenuItems()
        {
            //  Delete any previously dynamically generated items.
            foreach (var menuItemToDelete in dynamicallyGeneratedItems)
                contextMenu.Items.Remove(menuItemToDelete);

            //  Clear the dynamic list.
            dynamicallyGeneratedItems.Clear();

            int index = 0;
            //  Add each item.
            foreach (var item in ApplicationContext.Instance.DisplayAccents)
            {
                var menuItem = new ToolStripMenuItem
                {
                    Text = item.DisplayName,
                    Tag = item,

                };
                menuItem.Click += menuItem_Click;
                contextMenu.Items.Insert(index++, menuItem);
                dynamicallyGeneratedItems.Add(menuItem);
            }

            //  At this new index we can add a separator.
            var separator = new ToolStripSeparator();
            contextMenu.Items.Insert(index++, separator);
            dynamicallyGeneratedItems.Add(separator);

            //  Now select all distinct tag names.
            var tags = ApplicationContext.Instance.DisplayAccents.SelectMany(da => da.ParseTags()).Distinct().OrderBy(tag => tag);

            //  Go through each group.
            foreach (var tag in tags)
            {
                //  Create a context menu item for the tag.
                var tagMenuItem = new ToolStripMenuItem(tag);
                dynamicallyGeneratedItems.Add(tagMenuItem);
                tagMenuItem.Tag = new Accent();

                //  Find all accents tagged.
                var taggedAccents = ApplicationContext.Instance.DisplayAccents.Where(da => da.ParseTags().Contains(tag)).ToList();

                //  Add each accent.
                foreach (var accent in taggedAccents)
                {
                    var tagItem = new ToolStripMenuItem(accent.DisplayName);
                    tagItem.Tag = accent;
                    tagItem.Click += menuItem_Click;
                    tagMenuItem.DropDownItems.Add(tagItem);
                }

                //  Add to the menu.
                contextMenu.Items.Insert(index++, tagMenuItem);
            }
        }

        /// <summary>
        /// Handles the Click event of the menuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        static void menuItem_Click(object sender, EventArgs e)
        {
            var accent = sender is ToolStripMenuItem ? ((ToolStripMenuItem)sender).Tag as Accent : null;
            if (accent != null)
                SelectAccent(accent, shiftedMenuItems.Contains((ToolStripMenuItem)sender));
        }

        /// <summary>
        /// Updates the state of the hotkey.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c> [enabled].</param>
        public static void UpdateHotkeyState(bool enabled)
        {
            contextMenu.HotkeyEnabled = enabled;
        }

        /// <summary>
        /// Call this function to select a quick accent - copying it to the clipboard and notifying the user.
        /// </summary>
        /// <param name="accent">The accent.</param>
        /// <param name="shifted">if set to <c>true</c> set the shifted accent.</param>
        static void SelectAccent(Accent accent, bool shifted)
        {
            //  Get the accent to copy.
            var accentToCopy = shifted ? accent.ShiftAccentValue : accent.AccentValue;

            //  Copy the accent.
            Clipboard.SetText(accentToCopy);

            //  Are we showing a tip-balloon?
            if (ApplicationContext.Instance.Settings.ShowBalloonWhenAccentSelected)
            {
                trayIcon.ShowBalloonTip(300, accentToCopy + " Copied", "The text " + accentToCopy + " has been copied to your clipboard", ToolTipIcon.Info);
            }
        }

        /// <summary>
        /// The notify icon.
        /// </summary>
        private static NotifyIcon trayIcon;

        /// <summary>
        /// The context menu strip.
        /// </summary>
        private static HotkeyEnabledContextMenuStrip contextMenu;

        /// <summary>
        /// The settings form.
        /// </summary>
        private static FormQuickAccent settingsForm;

        /// <summary>
        /// The dynamically generated menu items.
        /// </summary>
        private static readonly List<ToolStripItem> dynamicallyGeneratedItems = new List<ToolStripItem>();
    }
}
