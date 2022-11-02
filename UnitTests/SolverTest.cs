
namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Str8tsSolver.Model;

    [TestClass]
    public class SolverTest
    {
        // Used for testing if the solver solves a null puzzle.
        // => Expected result: null
        [TestMethod]
        public void Solve_Null_Puzzle()
        {
            Puzzle expectedResult = null;

            Solver solver = new Solver();
            Puzzle actualResult = solver.StartSolving(null);

            Assert.AreEqual(expectedResult, actualResult);
        }

        // Used for testing if the solver solves an unsovable puzzle.
        // => Expected result: null
        [TestMethod]
        public void Solve_Unsovable_Puzzle()
        {
            Puzzle expectedResult = null;

            string unsovablePuzzle = "w3 w3 w3 w3 b3 w3 w3 b3 b3; w3 w3 w3 b3 w3 w3 w3 w3 w3; b3 w3 w3 b3 w3 w3 b3 w3 w3; w3 w9 b5 w0 w2 b0 w0 w3 b6; w0 w0 w0 w0 w0 w1 w0 w0 w0; b0 w0 w9 b7 w0 w2 b0 w5 w0; w6 w0 b0 w0 w4 b8 w1 w0 b0; w0 w0 w0 w0 w8 b0 w0 w1 w0; b0 b0 w6 w0 b9 w0 w0 w0 w0";
            Puzzle puzzle = new Converter().ConvertPuzzle(unsovablePuzzle);

            Solver solver = new Solver();
            Puzzle actualResult = solver.StartSolving(puzzle);

            Assert.AreEqual(expectedResult, actualResult);
        }

        // Used for testing if the solver solves a puzzle with only black fields.
        // => Expected result: same puzzle
        [TestMethod]
        public void Solve_OnlyBlackFields_Puzzle()
        {
            string blackFieldPuzzle = "b0 b0 b0 b0 b0 b0 b0 b0 b0; b0 b0 b0 b0 b0 b0 b0 b0 b0; b0 b0 b0 b0 b0 b0 b0 b0 b0; b0 b0 b0 b0 b0 b0 b0 b0 b0; b0 b0 b0 b0 b0 b0 b0 b0 b0; b0 b0 b0 b0 b0 b0 b0 b0 b0; b0 b0 b0 b0 b0 b0 b0 b0 b0; b0 b0 b0 b0 b0 b0 b0 b0 b0; b0 b0 b0 b0 b0 b0 b0 b0 b0";
            Puzzle puzzle = new Converter().ConvertPuzzle(blackFieldPuzzle);

            Puzzle expectedResult = puzzle;

            Solver solver = new Solver();
            Puzzle actualResult = solver.StartSolving(puzzle);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
