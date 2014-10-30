using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace QuickAccent
{
    /// <summary>
    /// The <see cref="ApplicationContext"/> Singleton class.
    /// </summary>
    public sealed class ApplicationContext
    {
        /// <summary>
        /// The Singleton instace. Declared 'static readonly' to enforce
        /// a single instance only and lazy initialisation.
        /// </summary>
        private static readonly ApplicationContext instance = new ApplicationContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// Declared private to enforce a single instance only.
        /// </summary>
        private ApplicationContext()
        {
        }

        /// <summary>
        /// Loads the settings.
        /// </summary>
        public void LoadSettings()
        {
            //  Do we have a settings file?
            if (File.Exists(GetSettingsPath()))
            {
                //  Try and load it.
                try
                {
                    using (var stream = new FileStream(GetSettingsPath(), FileMode.Open))
                    {
                        //  Create a serializer.
                        var serializer = new XmlSerializer(typeof(Settings));

                        //  Read the settings.
                        Settings = (Settings)serializer.Deserialize(stream);
                        
                    }
                }
                catch (Exception exception)
                {
                    //  Trace the exception.
                    System.Diagnostics.Trace.WriteLine("Exception loading settings file: " + exception);

                    //  Warn the user.
                    MessageBox.Show("Failed to load the settings file.", "Error");
                }
            }
            else
            {
                //  We have no settings file - create the default settings.
                CreateDefaultSettings();
                SaveSettings();
            }
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        public void SaveSettings()
        {
            //  Try and open the strem.
            try
            {
                using (var stream = new FileStream(GetSettingsPath(), FileMode.Create))
                {
                    //  Create a serializer.
                    var serializer = new XmlSerializer(typeof(Settings));

                    //  Write the settings.
                    serializer.Serialize(stream, Settings);
                }
            }
            catch (Exception exception)
            {
                //  Trace the exception.
                System.Diagnostics.Trace.WriteLine("Exception saving settings file: " + exception);

                //  Warn the user.
                MessageBox.Show("Failed to save the settings file.", "Error");
            }
        }

        /// <summary>
        /// Applies the windows settings, such as the 'start on logon'.
        /// </summary>
        public void ApplyWindowsSettings()
        {
            //  Create a startup manager.
            var startupManager = new ApplicationAutoStartupManager();
            startupManager.ApplicationPath = Application.ExecutablePath;

            //  Are we set to start on windows startup?
            if (Settings.StartOnWindowsLogon)
                startupManager.AddToStartupFolder();
            else
                startupManager.RemoveFromStartupFolder();
        }

        /// <summary>
        /// Creates the default settings.
        /// </summary>
        private void CreateDefaultSettings()
        {
            Settings = new Settings
                           {
                               Accents = new List<Accent>()
                                             {
                                                 new Accent
                                                     {
                                                         DisplayName = "à",
                                                         AccentValue = "à",
                                                         AltCode = "Alt + 133", 
                                                         ShowInMenu = true, 
                                                         SortCode = 0
                                                     }
                                             },
                                             UseWindowsHotkey = true,
                                             StartOnWindowsLogon = true
                           };
        }

        /// <summary>
        /// Gets the ApplicationContext Singleton Instance.
        /// </summary>
        public static ApplicationContext Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Gets the settings path.
        /// </summary>
        /// <returns></returns>
        private string GetSettingsPath()
        {
            var executableDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (executableDirectory == null)
                throw new InvalidOperationException("Cannot get the executable directory.");
            return Path.Combine(executableDirectory, @"Settings.xml");
        }
        
        /// <summary>
        /// Gets the settings.
        /// </summary>
        public Settings Settings { get; private set; }

        /// <summary>
        /// Gets the display accents.
        /// </summary>
        public IEnumerable<Accent> DisplayAccents
        {
            get { return from accent in Settings.Accents where accent.ShowInMenu orderby accent.SortCode select accent; }
        }
    }
}
