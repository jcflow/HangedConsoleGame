using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hanged
{
    /// <summary>
    /// The program runner.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Runs the program.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var pack = Serializer.Deserialize<WordPack>("DefaultWords.xml");
            var word = pack.Words[new Random().Next(0, pack.Words.Count)];
            var gameInterface = new GameInterface();
            var model = new GameModel(word);
            var controller = new GameController(model, gameInterface);
            controller.Start();
            Console.ReadKey();
        }
    }
}
