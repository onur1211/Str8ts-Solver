using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Str8tsSolver.Model;

namespace Str8tsSolver.View.Converter
{
    /// <summary>
    /// The public <see cref="PuzzleConverter"></see> class./>
    /// </summary>
    public class PuzzleConverter : IValueConverter
    {
        /// <summary>
        /// Used for converting a puzzle.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>A object which represents a puzzle.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Puzzle puzzle = (Puzzle)value;

            List<SolidColorBrush> colors = new List<SolidColorBrush>();

            if (puzzle == null)
            {
                return default;
            }

            foreach (var field in puzzle.Fields)
            {
                if (field != null)
                {
                    if (field.Color == Model.Color.White)
                    {
                        // Color: White
                        colors.Add(new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255)));
                    }

                    if (field.Color == Model.Color.Black)
                    {
                        // Color: Black
                        colors.Add(new SolidColorBrush(System.Windows.Media.Color.FromRgb(60, 60, 60)));
                    }
                }
            }

            return colors;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
