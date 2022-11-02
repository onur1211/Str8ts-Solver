using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Str8tsSolver.ViewModel;

namespace Str8tsSolver
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PuzzleVM puzzleVM;

        public MainWindow()
        {
            InitializeComponent();
            this.puzzleVM = new PuzzleVM();
            this.DataContext = this.puzzleVM;
        }

        /// <summary>
        /// Used for solving a puzzle after clicking the solve button.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event args.</param>
        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            this.puzzleVM.Puzzle = this.puzzleVM.Solver.StartSolving(this.puzzleVM.Puzzle);
        }

        /// <summary>
        /// Used for creating a puzzle after clicking the create button.
        /// </summary>
        /// <param name="sender">Object sender.</param>
        /// <param name="e">Event args.</param>
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            this.puzzleVM.Puzzle = this.puzzleVM.Converter.ConvertPuzzle(this.puzzleVM.PuzzleAsString);

            if (this.puzzleVM.Puzzle == null)
            {
                MessageBox.Show("No valid puzzle input detected!", "Puzzle Input", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
