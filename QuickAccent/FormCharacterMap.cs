using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace QuickAccent
{
    /// <summary>
    /// The Character Map form.
    /// </summary>
    public partial class FormCharacterMap : Form
    {
        public struct FontRange
        {
            public UInt16 Low;
            public UInt16 High;
        }

        [DllImport("gdi32.dll")]
        public static extern uint GetFontUnicodeRanges(IntPtr hdc, IntPtr lpgs);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        /// <summary>
        /// Initializes a new instance of the <see cref="FormCharacterMap"/> class.
        /// </summary>
        public FormCharacterMap()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FormCharacterMap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FormCharacterMap_Load(object sender, EventArgs e)
        {
            BuildCharacters(this.Font);
        }

        /// <summary>
        /// Gets the unicode ranges for font.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public List<FontRange> GetUnicodeRangesForFont(Font font)
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr hdc = g.GetHdc();
            IntPtr hFont = font.ToHfont();
            IntPtr old = SelectObject(hdc, hFont);
            uint size = GetFontUnicodeRanges(hdc, IntPtr.Zero);
            IntPtr glyphSet = Marshal.AllocHGlobal((int) size);
            GetFontUnicodeRanges(hdc, glyphSet);
            List<FontRange> fontRanges = new List<FontRange>();
            int count = Marshal.ReadInt32(glyphSet, 12);
            for (int i = 0; i < count; i++)
            {
                FontRange range = new FontRange();
                range.Low = (UInt16) Marshal.ReadInt16(glyphSet, 16 + i*4);
                range.High = (UInt16) (range.Low + Marshal.ReadInt16(glyphSet, 18 + i*4) - 1);
                fontRanges.Add(range);
            }
            SelectObject(hdc, old);
            Marshal.FreeHGlobal(glyphSet);
            g.ReleaseHdc(hdc);
            g.Dispose();
            return fontRanges;
        }

        /// <summary>
        /// Checks if char in font.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public bool CheckIfCharInFont(char character, Font font)
        {
            UInt16 intval = Convert.ToUInt16(character);
            List<FontRange> ranges = GetUnicodeRangesForFont(font);
            bool isCharacterPresent = false;
            foreach (FontRange range in ranges)
            {
                if (intval >= range.Low && intval <= range.High)
                {
                    isCharacterPresent = true;
                    break;
                }
            }
            return isCharacterPresent;
        }

        private BackgroundWorker worker = new BackgroundWorker();

        /// <summary>
        /// Gets the characters for font.
        /// </summary>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public char[] GetCharactersForFont(Font font)
        {
            List<char> chars = new List<char>();
            List<FontRange> ranges = GetUnicodeRangesForFont(font);
            foreach (FontRange range in ranges)
            {
                for (char c = (char) range.Low; c <= (char) range.High; c++)
                    chars.Add(c);
            }
            return chars.Distinct().ToArray();
        }

        internal class WorkDefinition
        {
            public Font Font { get; set; }
            public List<char> Chars { get; set; }
        }

        internal class WorkProgress
        {
            public Image Image { get; set; }
            public string Text { get; set; }
        }


        /// <summary>
        /// Builds the characters.
        /// </summary>
        /// <param name="font">The font.</param>
        private void BuildCharacters(Font font)
        {
            var chars = GetCharactersForFont(font).ToList();
            
            //  Clear the characters.
            characterMapItems.Clear();

            //  Add each character.
            characterMapItems.AddRange(chars.Select(c => new CharacterMapItem() {Char = c}));

            //  Set the list size.
            listViewCharacters.VirtualListSize = characterMapItems.Count;
        }

        /// <summary>
        /// Handles the ProgressChanged event of the worker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //  Add the image.
            imageListCharacters.Images.Add( ((WorkProgress)e.UserState).Image);

            //  Add the item.
            listViewCharacters.Items.Add(((WorkProgress)e.UserState).Text, imageListCharacters.Images.Count - 1);
        }

        /// <summary>
        /// Handles the DoWork event of the worker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var font = ((WorkDefinition) e.Argument).Font;
            var chars = ((WorkDefinition)e.Argument).Chars;

            int width = imageListCharacters.ImageSize.Width;
            int height = imageListCharacters.ImageSize.Height;

            Font fontBig = new Font(font.FontFamily, 24, font.Style, GraphicsUnit.Pixel);

            //  Go through the characters.
            //for (char c = min; c <= max; c++)
            foreach (char c in chars)
            {
                var text = c.ToString(CultureInfo.InvariantCulture);
                var fullString = text + " Alt + " + ((int)c).ToString(CultureInfo.InvariantCulture);

                var image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                var graphics = Graphics.FromImage(image);
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                //  Render the character.
                var size = graphics.MeasureString(text, fontBig);
                graphics.DrawString(text, fontBig, Brushes.Black, (width - size.Width) / 2, (height - size.Height) / 2);

                worker.ReportProgress(0, new WorkProgress {Image = image, Text = fullString});

            }
        }

        /// <summary>
        /// Builds the list view item.
        /// </summary>
        /// <param name="characterMapItem">The character map item.</param>
        /// <returns></returns>
        private ListViewItem BuildListViewItem(CharacterMapItem characterMapItem)
        {
            //  Create the list item.
            var listItem = new ListViewItem();
            listItem.Text = characterMapItem.Char.ToString(CultureInfo.InvariantCulture) 
                + " Alt + " + ((int)characterMapItem.Char).ToString(CultureInfo.InvariantCulture);
            return listItem;
        }

        /// <summary>
        /// Handles the RetrieveVirtualItem event of the listViewCharacters control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.RetrieveVirtualItemEventArgs"/> instance containing the event data.</param>
        private void listViewCharacters_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            //  Get the character.
            var character = characterMapItems[e.ItemIndex];

            //  Build the character.
            e.Item = BuildListViewItem(character);
        }

        private List<CharacterMapItem> characterMapItems = new List<CharacterMapItem>(); 
    }

    /// <summary>
    /// A Character Map item.
    /// </summary>
    internal class CharacterMapItem
    {
        public char Char { get; set; }
    }
}
