using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Str8tsSolver.Model
{
    /// <summary>
    /// The public <see cref="Field"></see> class./>
    /// </summary>
    public class Field
    {
        public Field(Color color, int value)
        {
            this.Color = color;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public int Value
        {
            get;
            set;
        }
    }
}
