/// <summary>
/// 
/// </summary>

namespace BoggleSolver
{
    using System;
    using System.Collections.Generic;

    public class Solver
    {
        /// <summary>
        /// Maximum word length to search for.
        /// </summary>
        public static int maximumWordLength;

        /// <summary>
        /// A list containing all valid scrabble words.
        /// </summary>
        public static List<string> scrabbleWords;

        /// <summary>
        /// Takes in an instance of the <see cref="Board"/> class and outputs all the possible words onto the screen.
        /// </summary>
        /// <param name="board"></param>
        public static void Solve(Board board)
        {
            Stack<Cell> characterStack = new Stack<Cell>();
            List<string> printedWords = new List<string>();
            for (int r = 0; r < board.dimensions; r++)
                for (int c = 0; c < board.dimensions; c++)
                {
                    characterStack.Push(board.board[r,c]);
                    Solve(characterStack, board, printedWords);
                }

            int sum = 0;

            foreach (var s in printedWords)
            {
                if (s.Length <= 4)
                    sum += 1;
                else if (s.Length == 5)
                    sum += 2;
                else if (s.Length == 6)
                    sum += 3;
                else if (s.Length == 7)
                    sum += 5;
                else
                    sum += 11;
            }

            Console.WriteLine("Total points found: " + sum);
        }

        /// <summary>
        /// Performs checks to validate if the current words in character list make up a word, and iterates through
        /// the board to gather all other words.
        /// </summary>
        /// <param name="characterStack">Current stack of characters being evaluated.</param>
        /// <param name="board">The current instance of the board.</param>
        /// <param name="printedWords">List of words that have been printed out.</param>
        public static void Solve(Stack<Cell> characterStack, Board board, List<string> printedWords)
        {
            // Check if current characters in the stack make up a word (dictionary check)
            string word = "";
            foreach (var c in characterStack)
            {
                word += c.character;
            }

            word = Reverse(word);

            if (word.Length >= 3 && Solver.scrabbleWords.Contains(word) && !printedWords.Contains(word))
            {
                System.Console.WriteLine(word);
                printedWords.Add(word);
            }

            if (characterStack.Count >= Solver.maximumWordLength)
            {
                characterStack.Pop();
                return;
            }

            Cell currentCell = characterStack.Pop();
            currentCell.marked = true;
            characterStack.Push(currentCell);

            for (int r = currentCell.x - 1; r <= currentCell.x + 1; r++)
            {
                for (int c = currentCell.y - 1; c <= currentCell.y + 1; c++)
                {
                    if (board.IsValidPosition(r, c) && board.board[r, c].marked == false)
                    {
                        characterStack.Push(board.board[r, c]);
                        Solve(characterStack, board, printedWords);
                    }
                }
            }

            currentCell = characterStack.Pop();
            currentCell.marked = false;
        }

        /// <summary>
        /// Reverses the given string
        /// </summary>
        /// <param name="s">The string to reverse.</param>
        /// <returns></returns>
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
