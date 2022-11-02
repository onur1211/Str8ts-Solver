using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Str8tsSolver.Model;

namespace Str8tsSolver.ViewModel
{
    /// <summary>
    /// The public <see cref="PuzzleVM"></see> class./>
    /// </summary>
    public class PuzzleVM : INotifyPropertyChanged
    {
        /// <summary>
        /// The private field for the puzzle.
        /// </summary>
        private Puzzle puzzle;

        public PuzzleVM()
        {
            // Default starting puzzle.
            this.PuzzleAsString = "w3 w0 w0 w0 b0 w0 w0 b0 b0; w0 w0 w0 b0 w6 w0 w9 w0 w0; b1 w2 w0 b0 w0 w0 b0 w0 w8; w0 w9 b5 w0 w2 b0 w0 w3 b6; w0 w0 w0 w0 w0 w1 w0 w0 w0; b0 w0 w9 b7 w0 w2 b0 w5 w0; w6 w0 b0 w0 w4 b8 w1 w0 b0; w0 w0 w0 w0 w8 b0 w0 w1 w0; b0 b0 w6 w0 b9 w0 w0 w0 w0";
            this.Solver = new Solver();
            this.Converter = new Converter();
        }

        /// <summary>
        /// Gets or sets the puzzle.
        /// </summary>
        public Puzzle Puzzle
        {
            get
            {
                return this.puzzle;
            }

            set
            {
                this.puzzle = value;
                this.FirePropertyChanged(nameof(this.Puzzle));
            }
        }

        /// <summary>
        /// Gets or sets the solver.
        /// </summary>
        public Solver Solver
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the converter.
        /// </summary>
        public Converter Converter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the puzzle as string.
        /// </summary>
        public string PuzzleAsString
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
