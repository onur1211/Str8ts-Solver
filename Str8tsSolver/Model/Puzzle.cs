using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Str8tsSolver.Model
{
    /// <summary>
    /// The public <see cref="Puzzle"></see> class./>
    /// </summary>
    public class Puzzle
    {
        public Puzzle(Field[,] fields, int height, int width)
        {
            this.Fields = fields;
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public int Height
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        public Field[,] Fields
        {
            get;
            set;
        }
    }
}
