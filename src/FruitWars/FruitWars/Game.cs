﻿namespace FruitWars
{
    /// <summary>
    /// Used to initialize the game and perform the game loop.
    /// </summary>
    internal class Game
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        private static void Main()
        {
            GridManager gridManager = new GridManager();
            IIOManager ioManager = new ConsoleManager();
            GameEngine.Run(gridManager, ioManager);
        }
    }
}
