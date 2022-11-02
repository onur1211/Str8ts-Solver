using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Str8tsSolver.Model
{
    /// <summary>
    /// The public <see cref="Solver"></see> class./>
    /// </summary>
    public class Solver
    {
        public bool Solved
        {
            get;
            set;
        }

        /// <summary>
        /// Used for starting the solving process for a puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle.</param>
        /// <returns>The solved puzzle.</returns>
        public Puzzle StartSolving(Puzzle puzzle)
        {
            this.Solved = false;

            if (puzzle == null)
            {
                return null;
            }

            try
            {
                // Check if the puzzle is already solved.
                // => if true then show message and return the puzzle.
                if (this.IsPuzzleDone(puzzle))
                {
                    MessageBox.Show("Puzzle is already solved!", "Puzzle Solution", MessageBoxButton.OK, MessageBoxImage.Information);
                    return puzzle;
                }

                // Start solving the puzzle until its solved or no valid solution was found.
                while (!this.Solved)
                {
                    // Start solving by the first field in the puzzle.
                    // => if true then show message solution found and return the solved puzzle. 
                    if (this.Solve(puzzle, 0, 0))
                    {
                        MessageBox.Show("Solution found!", "Puzzle Solution", MessageBoxButton.OK, MessageBoxImage.Information);
                        return puzzle;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                // If the solving process failed.
                // => Show no solution found message and return default.
                MessageBox.Show("No solution found for this puzzle!", "Puzzle Solution", MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }

            return null;
        }

        /// <summary>
        /// Used for solving a field of the puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle.</param>
        /// <param name="columnPosition">The column position of the field.</param>
        /// <param name="rowPosition">The row position of the field.</param>
        /// <returns>The bool if solving was done.</returns>
        private bool Solve(Puzzle puzzle, int columnPosition, int rowPosition)
        {
            // Check if the puzzle is done/solved.
            if (this.IsPuzzleDone(puzzle))
            {
                this.Solved = true;
                return true;
            }

            // Check if end of row is reached
            // => if true then go to next column.
            if (rowPosition == puzzle.Width)
            {
                return Solve(puzzle, columnPosition + 1, 0);
            }

            // Check if field is not white (=black) or if the field is white and already has a value.
            // => if true then skip the field.
            if (puzzle.Fields[columnPosition, rowPosition].Color == Color.Black ||
                puzzle.Fields[columnPosition, rowPosition].Color == Color.White &&
                puzzle.Fields[columnPosition, rowPosition].Value != 0)
            {
                return Solve(puzzle, columnPosition, rowPosition + 1);
            }

            // Try the results until a valid one is found.
            for (int result = 1; result <= puzzle.Fields.GetLength(0); result++)
            {
                // Check if the result value is not valid
                // => if true then continue and try the next number.
                if (!IsResultValid(puzzle, result, columnPosition, rowPosition))
                {
                    continue;
                }

                // Set the result value in to the field.
                puzzle.Fields[columnPosition, rowPosition].Value = result;

                // Solve the next field.
                if (Solve(puzzle, columnPosition, rowPosition + 1))
                {
                    return true;
                }

                // Reset the field value if the result does not fit.
                puzzle.Fields[columnPosition, rowPosition].Value = 0;
            }

            return false;
        }

        /// <summary>
        /// Used for checking if the puzzle is done.
        /// </summary>
        /// <param name="puzzle">The puzzle</param>
        /// <returns>The puzzle.</returns>
        private bool IsPuzzleDone(Puzzle puzzle)
        {
            // Check every field
            foreach (var field in puzzle.Fields)
            {
                // If the field is white and has the value 0 (=empty) then the puzzle is not done.
                if (field.Color == Color.White && field.Value == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Used for checking if the result is valid.
        /// </summary>
        /// <param name="puzzle">The puzzle.</param>
        /// <param name="result">The result value.</param>
        /// <param name="columnPosition">The column position of the field.</param>
        /// <param name="rowPosition">The row position of the field.</param>
        /// <returns>The bool for validation.</returns>
        private bool IsResultValid(Puzzle puzzle, int result, int columnPosition, int rowPosition)
        {
            // Check the rows and the columns.
            if (this.CheckRows(puzzle, result, columnPosition) &&
                this.CheckColumns(puzzle, result, rowPosition))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Used for checking the rows of a field.
        /// </summary>
        /// <param name="puzzle">The puzzle.</param>
        /// <param name="result">The result.</param>
        /// <param name="columnPosition">The column position of the field.</param>
        /// <returns></returns>
        private bool CheckRows(Puzzle puzzle, int result, int columnPosition)
        {
            int rowCount = 0;

            while (rowCount < puzzle.Fields.GetLength(0))
            {
                // If field is black and the value is 0 (= empty field) => skip the field.
                if (puzzle.Fields[columnPosition, rowCount].Color == Color.Black &&
                    puzzle.Fields[columnPosition, rowCount].Value == 0)
                {
                    rowCount++;
                    continue;
                }

                // If field is not 0 (=empty) and the field value is the same as the result => return false.
                if (puzzle.Fields[columnPosition, rowCount].Value != 0 &&
                    puzzle.Fields[columnPosition, rowCount].Value == result)
                {
                    return false;
                }

                rowCount++;
            }

            return true;
        }

        /// <summary>
        /// Used for checking the columns of a field.
        /// </summary>
        /// <param name="puzzle">The puzzle.</param>
        /// <param name="result">The result.</param>
        /// <param name="rowPosition">The row position of the field.</param>
        /// <returns></returns>
        private bool CheckColumns(Puzzle puzzle, int result, int rowPosition)
        {
            int columnCount = 0;

            while (columnCount < puzzle.Fields.GetLength(0))
            {
                // If field is black and the value is 0 (= empty field) => skip the field.
                if (puzzle.Fields[columnCount, rowPosition].Color == Color.Black &&
                    puzzle.Fields[columnCount, rowPosition].Value == 0)
                {
                    columnCount++;
                    continue;
                }

                // If field is not 0 (=empty) and the field value is the same as the result => return false.
                if (puzzle.Fields[columnCount, rowPosition].Value != 0 &&
                    puzzle.Fields[columnCount, rowPosition].Value == result)
                {
                    return false;
                }

                columnCount++;
            }

            return true;
        }
    }
}
