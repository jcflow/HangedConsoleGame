using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Hanged
{
    /// <summary>
    /// A serializer is used to read and write XML files based on model classes.
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// Serializes the model to a file.
        /// </summary>
        /// <typeparam name="T">The type of the model</typeparam>
        /// <param name="model">The instance that will be serialized</param>
        /// <param name="path">The path of the file to write</param>
        public static void Serialize<T>(T model, string path) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            File.Create(path).Close();
            using (var writer = XmlWriter.Create(path))
            {
                serializer.Serialize(writer, model);
            }
        }

        /// <summary>
        /// Deserializes the model from a file.
        /// </summary>
        /// <typeparam name="T">The type of the model</typeparam>
        /// <param name="path">The path of the file to read</param>
        /// <returns>A model instance with the respective data</returns>
        public static T Deserialize<T>(string path) where T : new()
        {
            T response;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var reader = XmlReader.Create(path))
            {
                response = (T)serializer.Deserialize(reader);
            }
            return response;
        }
    }
}
