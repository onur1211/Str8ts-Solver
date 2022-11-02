
namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using Str8tsSolver.Model;


    [TestClass]
    public class ConverterTest
    {
        // Used for testing if the converter converts an empty string into a puzzle.
        // => Expected result: null
        [TestMethod]
        public void Convert_EmptyString_ToPuzzle()
        {
            Puzzle expectedResult = null;
            string emptyString = "";

            Converter converter = new Converter();
            Puzzle actualResult = converter.ConvertPuzzle(emptyString);

            Assert.AreEqual(expectedResult, actualResult);
        }

        // Used for testing if the converter converts an invalid string into a puzzle.
        // => Expected result: null
        [TestMethod]
        public void Convert_InvalidString_ToPuzzle()
        {
            Puzzle expectedResult = null;
            string invalidPuzzle = "w3 z0 k0 j0 b0 r0 g0 h0 t0; r0 t0 w0 b0 w6 w0 w9 w0 w0; b1 w2 w0 b0 w0 w0 b0 w0 w8; w0 w9 b5 w0 w2 b0 w0 w3 b6; w0 w0 w0 w0 w0 w1 w0 w0 w0; b0 w0 w9 b7 w0 w2 b0 w5 w0; w6 w0 b0 w0 w4 b8 w1 w0 b0; w0 w0 w0 w0 w8 b0 w0 w1 w0; b0 b0 w6 w0 b9 w0 w0 w0 w0";

            Converter converter = new Converter();
            Puzzle actualResult = converter.ConvertPuzzle(invalidPuzzle);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
