using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuickAccent
{
    /// <summary>
    /// A Hotkey Enabled Context Menu Strip is a Context Menu Strip
    /// that can be opened via a Windows Hotkey.
    /// </summary>
    public class HotkeyEnabledContextMenuStrip : ContextMenuStrip
    {
        /// <summary>
        /// Registers the hot key.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="id">The id.</param>
        /// <param name="fsModifiers">The fs modifiers.</param>
        /// <param name="vk">The vk.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        /// <summary>
        /// Unregisters the hot key.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Initializes a new instance of the <see cref="HotkeyEnabledContextMenuStrip"/> class.
        /// </summary>
        public HotkeyEnabledContextMenuStrip()
        {
        }

        /// <summary>
        /// Initialises the hotkey.
        /// </summary>
        public void InitialiseHotkey()
        {
            RegisterHotKey(HotkeyModifier, Hotkey);
        }
        
        /// <summary>
        /// The WindowProc.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message"/> to process.</param>
        protected override void WndProc(ref Message m)
        {
            //  Call the base.
            base.WndProc(ref m);

            //  Have we hit the hotkey?
            if (m.Msg == WM_HOTKEY && HotkeyEnabled)
            {
                //  Open the menu.
                Show();
                Focus();
                Items.OfType<ToolStripMenuItem>().First().Select();
            }
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            //  Register the hot key.
            RegisterHotKey(Handle, 6969, (uint)modifier, (uint)key);
        }

        /// <summary>
        /// Unregisters the hotkey.
        /// </summary>
        public void UnregisterHotkey()
        {
            //  Unregister the hotkey.
            UnregisterHotKey(Handle, 6969);
        }
        
        /// <summary>
        /// Windows message code.
        /// </summary>
        private static int WM_HOTKEY = 0x0312;

        /// <summary>
        /// Flag defining whether the hotkey is enabled.
        /// </summary>
        private bool isHotkeyEnabled = false;

        /// <summary>
        /// Gets or sets a value indicating whether the hotkey is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the hotkey is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool HotkeyEnabled
        {
            get { return isHotkeyEnabled; }
            set
            {
                if (isHotkeyEnabled == value)
                    return;
                if (value)
                {
                    isHotkeyEnabled = true;
                    RegisterHotKey(HotkeyModifier, Hotkey);
                }
                else
                {
                    isHotkeyEnabled = false;
                    UnregisterHotkey();
                }
            }
        }

        /// <summary>
        /// Gets or sets the hotkey modifier.
        /// </summary>
        /// <value>
        /// The hotkey modifier.
        /// </value>
        public ModifierKeys HotkeyModifier { get; set; }

        /// <summary>
        /// Gets or sets the hotkey.
        /// </summary>
        /// <value>
        /// The hotkey.
        /// </value>
        public Keys Hotkey { get; set; }

        /// <summary>
        /// Gets or sets the initial position control.
        /// </summary>
        /// <value>
        /// The initial position control.
        /// </value>
        public Control InitialPositionControl { get; set; }
    }

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}