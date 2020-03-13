using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanged
{
    /// <summary>
    /// A game model represents all the bussiness logic for a hanged game.
    /// </summary>
    public class GameModel
    {
        /// <summary>
        /// The mystery word.
        /// </summary>
        public string Word { get; private set; }

        /// <summary>
        /// A list of the user entered letters.
        /// </summary>
        public List<char> EnteredLetters { get; private set; }

        /// <summary>
        /// User errors count.
        /// </summary>
        public int Errors { get; private set; }

        /// <summary>
        /// A list of the user repeated letters.
        /// </summary>
        public List<char> RepeatedLetters {
            get {
                return (from letter in this.EnteredLetters
                       group letter by letter into grouped
                       where grouped.Count() > 1
                       select grouped.Key).ToList();
            }
        }

        /// <summary>
        /// A list of the user matched letters.
        /// </summary>
        public List<char> MatchedLetters
        {
            get
            {
                var matched = new List<char>();
                this.Word.ToList().ForEach(letter => matched.Add(this.EnteredLetters.Contains(letter) ? letter : Constants.NULL));
                return matched;
            }
        }

        /// <summary>
        /// The game istate if is able to introduce letters.
        /// </summary>
        public bool IsOver
        {
            get
            {
                return this.Errors >= 6 || this.Won;
            }
        }

        /// <summary>
        /// The game over status.
        /// </summary>
        public bool Won
        {
            get
            {
                foreach (char letter in this.Word)
                {
                    if (!this.EnteredLetters.Contains(letter))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Constructs a game model.
        /// </summary>
        /// <param name="word">The expected mystery word</param>
        public GameModel(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new Exception();
            }
            this.Word = word.ToLower();
            this.EnteredLetters = new List<char>();
        }

        /// <summary>
        /// Receives a letter that should exist on the mystery word.
        /// </summary>
        /// <param name="letter">The letter that should be contained on the mystery word</param>
        public void ReceiveLetter(char letter)
        {
            letter = char.ToLower(letter);
            if (this.IsOver)
            {
                throw new Exception();
            }
            if (!this.Word.Contains(letter) || this.EnteredLetters.Contains(letter))
            {
                this.Errors++;
            }
            this.EnteredLetters.Add(letter);
        }
    }
}
