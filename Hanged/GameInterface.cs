using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanged
{
    /// <summary>
    /// A game interface represents a game console interface.
    /// </summary>
    public class GameInterface
    {
        /// <summary>
        /// Shows start banner.
        /// </summary>
        public void Start()
        {
            var middleSpace = (Console.WindowWidth - 29) / 2;
            Console.SetCursorPosition(middleSpace, 2);
            Console.WriteLine(" ____________________________");
            Console.SetCursorPosition(middleSpace, Console.CursorTop);
            Console.WriteLine("|                            |");
            Console.SetCursorPosition(middleSpace, Console.CursorTop);
            Console.WriteLine("|        HANGED GAME         |");
            Console.SetCursorPosition(middleSpace, Console.CursorTop);
            Console.WriteLine("|       Press any key        |");
            Console.SetCursorPosition(middleSpace, Console.CursorTop);
            Console.WriteLine("|____________________________|");
            Console.ReadKey();
        }

        /// <summary>
        /// Reads user input. 
        /// </summary>
        /// <returns></returns>
        public char ReadChar()
        {
            var input = Constants.NULL;
            do
            {
                input = Console.ReadKey().KeyChar;
                this.ResetCursor();
            } while (!char.IsLetter(input));
            return input;
        }

        /// <summary>
        /// Paints the initial game state.
        /// </summary>
        /// <param name="wordLength">The hidden word length</param>
        public void Paint(int wordLength)
        {
            var middleSpace = (Console.WindowWidth - 21) / 2;
            Console.Clear();
            Console.SetCursorPosition(middleSpace, 0);
            Console.WriteLine("     ______________");
            Console.SetCursorPosition(middleSpace, 1);
            Console.WriteLine("    |              |");
            Console.SetCursorPosition(middleSpace, 2);
            Console.WriteLine("    |               ");
            Console.SetCursorPosition(middleSpace, 3);
            Console.WriteLine("    |                ");
            Console.SetCursorPosition(middleSpace, 4);
            Console.WriteLine("    |               ");
            Console.SetCursorPosition(middleSpace, 5);
            Console.WriteLine("    |                ");
            Console.SetCursorPosition(middleSpace, 6);
            Console.WriteLine("    |");
            Console.SetCursorPosition(middleSpace, 7);
            Console.WriteLine("    |");
            Console.SetCursorPosition(middleSpace, 8);
            Console.WriteLine("____|_____");
            Console.WriteLine();
            var initialWord = string.Join(" ", Enumerable.Repeat(Constants.WILDCARD, wordLength).ToList());
            Console.SetCursorPosition((Console.WindowWidth - initialWord.Length) / 2, 10);
            Console.WriteLine(initialWord);
            Console.WriteLine();
            Console.WriteLine("Ingresadas: ");
            Console.WriteLine("Repetidas: ");
            Console.WriteLine();
            Console.Write("Presione siguiente letra: ");
        }

        /// <summary>
        /// Repaints the matched letters on console.
        /// </summary>
        /// <param name="matchedLetters">A list of the matched letters using \0 as not matched</param>
        /// <param name="errorsCount">The game errors count</param>
        /// <param name="enteredLetters">A list of user entered letters</param>
        /// <param name="repeatedLetters">A list of the repeated letter</param>
        public void Repaint(List<char> matchedLetters, int errorsCount, List<char> enteredLetters, List<char> repeatedLetters)
        {
            this.RepaintWord(matchedLetters);
            this.RepaintGallow(errorsCount);
            this.RepaintEnteredLetters(enteredLetters);
            this.RepaintRepeatedLetters(repeatedLetters);
            this.ResetCursor();
        }

        /// <summary>
        /// Paints game over banner.
        /// </summary>
        /// <param name="won">The game over status</param>
        /// <param name="word">The mystery word</param>
        public void PaintGameOverMessage(bool won, string word)
        {
            var middleSpace = (Console.WindowWidth - 29) / 2;
            Console.Clear();
            Console.SetCursorPosition(middleSpace, 2);
            Console.WriteLine(" ____________________________");
            Console.SetCursorPosition(middleSpace, Console.CursorTop);
            Console.WriteLine("|                            |");
            Console.SetCursorPosition(middleSpace, Console.CursorTop);
            if (won)
            {
                Console.WriteLine("|          YOU WIN!          |");
            }
            else
            {
                Console.WriteLine("|          YOU LOSE!         |");
            }
            Console.SetCursorPosition(middleSpace, Console.CursorTop);
            Console.WriteLine("|       Press any key        |");
            Console.SetCursorPosition(middleSpace, Console.CursorTop);
            Console.WriteLine("|____________________________|");
            if (!won)
            {
                Console.WriteLine();
                var message = string.Format("The word was: {0}", word);
                Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, Console.CursorTop);
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// Repaints the mistery word.
        /// </summary>
        /// <param name="matchedLetters">The paited letters, using \0 as not found character</param>
        private void RepaintWord(List<char> matchedLetters)
        {
            var updatedLetters = new List<char>();
            matchedLetters.ForEach(letter => updatedLetters.Add(letter == Constants.NULL ? Constants.WILDCARD : letter));
            var word = string.Join(" ", updatedLetters);
            Console.SetCursorPosition((Console.WindowWidth - word.Length) / 2, 10);
            Console.Write(word);
        }

        /// <summary>
        /// Repaints the game gallow based on the user errors.
        /// </summary>
        /// <param name="errorsCount">The errors count</param>
        private void RepaintGallow(int errorsCount)
        {
            var middleSpace = (Console.WindowWidth - 21) / 2;
            if (errorsCount > 0)
            {
                Console.SetCursorPosition(middleSpace + 19, 2);
                Console.Write("O");
            }
            if (errorsCount > 1)
            {
                Console.SetCursorPosition(middleSpace + 19, 3);
                Console.Write("|");
                Console.SetCursorPosition(middleSpace + 19, 4);
                Console.Write("|");
            }
            if (errorsCount > 2)
            {
                Console.SetCursorPosition(middleSpace + 18, 3);
                Console.Write("_");
            }
            if (errorsCount > 3)
            {
                Console.SetCursorPosition(middleSpace + 20, 3);
                Console.Write("_");
            }
            if (errorsCount > 4)
            {
                Console.SetCursorPosition(middleSpace + 20, 5);
                Console.Write("\\");
            }
            if (errorsCount > 5)
            {
                Console.SetCursorPosition(middleSpace + 18, 5);
                Console.Write("/");
            }
        }

        /// <summary>
        /// Repaints the user entered letters list.
        /// </summary>
        /// <param name="enteredLetters">A list of the entered characters</param>
        private void RepaintEnteredLetters(List<char> enteredLetters)
        {
            Console.SetCursorPosition(12, 12);
            Console.Write(string.Join(", ", enteredLetters));
        }

        /// <summary>
        /// Repaints the user reppeated letters list.
        /// </summary>
        /// <param name="repeatedLetters">A list of the entered characters</param>
        private void RepaintRepeatedLetters(List<char> repeatedLetters)
        {
            Console.SetCursorPosition(11, 13);
            Console.Write(string.Join(", ", repeatedLetters));
        }

        /// <summary>
        /// Resets the cursor position to the input line.
        /// </summary>
        private void ResetCursor()
        {
            Console.SetCursorPosition(26, 15);
        }
    }
}
