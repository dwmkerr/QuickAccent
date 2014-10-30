using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuickAccent
{
    /// <summary>
    /// Represents an accent selected to be used in the QuickAccent application.
    /// </summary>
    [Serializable]
    public class Accent
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        [XmlAttribute]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the accent value.
        /// </summary>
        /// <value>
        /// The accent value.
        /// </value>
        [XmlAttribute]
        public string AccentValue { get; set; }

        /// <summary>
        /// Gets or sets the alt code.
        /// </summary>
        /// <value>
        /// The alt code.
        /// </value>
        [XmlAttribute]
        public string AltCode { get; set; }

        /// <summary>
        /// Gets or sets the display name of the shift.
        /// </summary>
        /// <value>
        /// The display name of the shift.
        /// </value>
        [XmlAttribute]
        public string ShiftDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the shift accent value.
        /// </summary>
        /// <value>
        /// The shift accent value.
        /// </value>
        [XmlAttribute]
        public string ShiftAccentValue { get; set; }

        /// <summary>
        /// Gets or sets the shift alt code.
        /// </summary>
        /// <value>
        /// The shift alt code.
        /// </value>
        [XmlAttribute]
        public string ShiftAltCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show in menu].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show in menu]; otherwise, <c>false</c>.
        /// </value>
        [XmlAttribute]
        public bool ShowInMenu { get; set; }

        /// <summary>
        /// Gets or sets the sort code.
        /// </summary>
        /// <value>
        /// The sort code.
        /// </value>
        [XmlAttribute]
        public uint SortCode { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        [XmlAttribute]
        public string Tags { get; set; }

        /// <summary>
        /// Parses the tags.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ParseTags()
        {
            if(string.IsNullOrEmpty(Tags))
                yield break;

            foreach(var tag in Tags.Split(','))
                yield return tag.Trim();
        }
    }
}
