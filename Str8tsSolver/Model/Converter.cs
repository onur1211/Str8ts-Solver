using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Str8tsSolver.Model
{
    /// <summary>
    /// The public <see cref="Converter"></see> class./>
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Used for getting the field from a string.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns>The field.</returns>
        private Field GetField(string field, int puzzleLength)
        {
            int numberValue;

            if (field == null)
            {
                throw new ArgumentException(nameof(field), "ERROR: The field is invalid or null!");
            }

            if (!field.Contains("w") && !field.Contains("b"))
            {
                throw new ArgumentException(nameof(field));
            }

            // Get the white field and extract the number value.
            if (field.Contains("w"))
            {
                var value = field.Split('w');

                if (value == null || value.Length < 1)
                {
                    throw new ArgumentException(nameof(field), "ERROR: The value is null or contains no valid number value!");
                }

                bool isValid = int.TryParse(value[1], out numberValue);

                if (!isValid)
                {
                    throw new InvalidCastException(nameof(numberValue));
                }

                if (numberValue < 0 || numberValue > puzzleLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(numberValue), "ERROR: The value can not be negative or higher then the puzzle length!");
                }

                return new Field(Color.White, numberValue);
            }

            // Get the black field and extract the number value.
            if (field.Contains("b"))
            {
                var value = field.Split('b');

                if (value == null || value.Length < 1)
                {
                    throw new ArgumentException(nameof(field), "ERROR: The value is null or contains no valid number value!");
                }

                bool isValid = int.TryParse(value[1], out numberValue);

                if (!isValid)
                {
                    throw new InvalidCastException(nameof(numberValue));
                }

                if (numberValue < 0 || numberValue > puzzleLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(numberValue), "ERROR: The value can not be negative or higher then the puzzle length!");
                }

                return new Field(Color.Black, numberValue);
            }

            return default;
        }

        /// <summary>
        /// Used for converting a string into a puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle.</param>
        /// <returns>The puzzle.</returns>
        public Puzzle ConvertPuzzle(string puzzle)
        {
            try
            {
                if (puzzle == "")
                {
                    throw new ArgumentException(nameof(puzzle), "ERROR: The string is empty!");
                }

                // Split the string.
                var puzz = puzzle.Split(';');

                // Filter empty entries.
                puzz = puzz.Where(text => text != "").ToArray();

                List<string> fieldsAsString = new List<string>();

                foreach (var values in puzz)
                {
                    if (values == null)
                    {
                        continue;
                    }

                    foreach (var val in values.Split(' '))
                    {
                        if (val == "" || val == null)
                        {
                            continue;
                        }

                        fieldsAsString.Add(val);
                    }
                }

                List<Field> totalFields = new List<Field>();

                // Get the field from every field as string.
                foreach (var field in fieldsAsString)
                {
                    totalFields.Add(this.GetField(field, puzz.Length));
                }

                Field[,] fields = new Field[puzz.Length, puzz.Length];
                int count = 0;

                // Insert the fields in a 2D field array.
                for (int i = 0; i < puzz.Length; i++)
                {
                    for (int j = 0; j < puzz.Length; j++)
                    {
                        fields[i, j] = totalFields[count];
                        count++;
                    }
                }

                // Return the puzzle with the fields.
                return new Puzzle(fields, puzz.Length, puzz.Length);
            }
            catch
            {
                // Catch if something fails and return default
                // => invalid puzzle input.
                return null;
            }
        }
    }
}
