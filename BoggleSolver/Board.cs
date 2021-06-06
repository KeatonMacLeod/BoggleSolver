/// <summary>
/// Holds current board game.
/// </summary>

namespace BoggleSolver
{
    public class Board
    {
        /// <summary>
        /// Single integer dimension of the board; represents length and width (must be a square).
        /// </summary>
        public int dimensions { get; private set; }

        /// <summary>
        /// Cells on the board.
        /// </summary>
        public Cell[,] board { get; private set; }

        /// <summary>
        /// Initializes an instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="dimensions">The dimensions of the board; board must be a square.</param>
        /// <param name="boardString">String representation of the board game.</param>
        /// <remarks>
        /// If <paramref name="board"/> is "ABCDEFGHIJKLMNOP", then the board is assumed to be:
        /// 
        /// ABCD
        /// EFGH
        /// IJKL
        /// MNOP
        /// </remarks>
        public Board (int dimensions, string boardString)
        {
            this.dimensions = dimensions;
            this.board = new Cell[dimensions,dimensions];

            int rowIterator = 0;
            int colIterator = 0;

            foreach (var character in boardString)
            {
                board[rowIterator,colIterator] = new Cell(character, rowIterator, colIterator);

                colIterator++;

                if (colIterator == this.dimensions)
                {
                    colIterator = 0;
                    rowIterator++;
                }
            }
        }

        /// <summary>
        /// Validate that the current (x,y) coordinate pair exists on the board.
        /// </summary>
        /// <param name="x">The x value of the (x,y) coordinate pair to validate.</param>
        /// <param name="y">The y value of the (x,y) coordinate pair to validate.</param>
        /// <returns><see langword="true"/> if the (x,y) coordinate is valid, otherwise <see langword="false"/>.</returns>
        public bool IsValidPosition(int x, int y)
        {
            if (x >= 0 && x < this.dimensions &&
                y >= 0 && y < this.dimensions)
            {
                return true;
            }

            return false;
        }
    }
}
