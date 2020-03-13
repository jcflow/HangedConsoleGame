using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hanged
{
    /// <summary>
    /// A game controller represents an intermediary between console interface and model.
    /// </summary>
    public class GameController
    {
        /// <summary>
        /// The game model.
        /// </summary>
        private GameModel model;
        /// <summary>
        /// The game console interface.
        /// </summary>
        private GameInterface gameInterface;

        /// <summary>
        /// Constructs a game controller.
        /// </summary>
        /// <param name="model">A game model instance</param>
        /// <param name="gameInterface">A game interface</param>
        public GameController(GameModel model, GameInterface gameInterface)
        {
            this.model = model;
            this.gameInterface = gameInterface;
        }

        /// <summary>
        /// Starts the game using model and interface.
        /// </summary>
        public void Start()
        {
            gameInterface.Start();
            gameInterface.Paint(model.Word.Length);
            while (!model.IsOver)
            {
                model.ReceiveLetter(gameInterface.ReadChar());
                gameInterface.Repaint(model.MatchedLetters, model.Errors,
                    model.EnteredLetters, model.RepeatedLetters);
            }
            Thread.Sleep(Constants.GAME_OVER_WAIT);
            gameInterface.PaintGameOverMessage(model.Won, model.Word);
        }
    }
}
