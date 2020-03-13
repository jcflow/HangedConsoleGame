using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hanged
{
    /// <summary>
    /// A word pack represents a container for a collection of words.
    /// </summary>
    [XmlRoot("WordPack")]
    public class WordPack
    {
        /// <summary>
        /// A collection of words.
        /// </summary>
        [XmlArray("Words")]
        [XmlArrayItem("Word")]
        public List<string> Words;

        /// <summary>
        /// Constructs a basic wordpack.
        /// </summary>
        public WordPack()
        {
            this.Words = new List<string>();
        }
    }
}
