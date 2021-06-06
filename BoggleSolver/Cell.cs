using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoggleSolver
{
    public class Cell
    {
        /// <summary>
        /// Value indicating whether the current node has been marked in the current search.
        /// </summary>
        public bool marked { get; set; }

        /// <summary>
        /// Character contained within this instance of the cell.
        /// </summary>
        public char character { get; private set; }

        /// <summary>
        /// The x position of the <see cref="Cell"/> on the game board.
        /// </summary>
        public int x { get; private set; }

        /// <summary>
        /// The y position of the <see cref="Cell"/> on the game board.
        /// </summary>
        public int y { get; private set; }

        /// <summary>
        /// Initializes an instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="x">The x position of the cell on the game board.</param>
        /// <param name="y">The y position of the cell on the game board.</param>
        public Cell(char character, int x, int y)
        {
            this.character = character;
            this.x = x;
            this.y = y;
            this.marked = false;
        }
    }
}
