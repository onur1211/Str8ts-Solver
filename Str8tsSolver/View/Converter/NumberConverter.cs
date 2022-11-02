using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Str8tsSolver.Model;

namespace Str8tsSolver.View.Converter
{
    /// <summary>
    /// The public <see cref="NumberConverter"></see> class./>
    /// </summary>
    public class NumberConverter : IValueConverter
    {
        /// <summary>
        /// Used for converting the numbers of a puzzle.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A object which represents the numbers of a puzzle.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Puzzle puzzle = (Puzzle)value;

            List<string> numbers = new List<string>();

            if (puzzle == null)
            {
                return default;
            }

            foreach (var field in puzzle.Fields)
            {
                if (field == null)
                {
                    continue;
                }

                if (field.Value == 0)
                {
                    numbers.Add(" ");
                    continue;
                }

                numbers.Add(field.Value.ToString());
            }

            return numbers;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
