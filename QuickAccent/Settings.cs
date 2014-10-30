using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickAccent
{
    /// <summary>
    /// Represent the settings for Quick Accent.
    /// </summary>
    [Serializable]
    public class Settings
    {
        /// <summary>
        /// Gets or sets a value indicating whether to use the windows hotkey.
        /// </summary>
        /// <value>
        ///   <c>true</c> if use windows hotkey; otherwise, <c>false</c>.
        /// </value>
        public bool UseWindowsHotkey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to start Quick Accent on windows logon.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if start on windows logon; otherwise, <c>false</c>.
        /// </value>
        public bool StartOnWindowsLogon { get; set; }

        /// <summary>
        /// Sets a value indicating whether to show a tip balloon when the accent is selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if show a balloon when accent selected; otherwise, <c>false</c>.
        /// </value>
        public bool ShowBalloonWhenAccentSelected { get; set; }

        /// <summary>
        /// Gets or sets the accents.
        /// </summary>
        /// <value>
        /// The accents.
        /// </value>
        public List<Accent> Accents { get; set; } 
    }
}
