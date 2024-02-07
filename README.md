# Str8ts-Solver


![solver_screenshot](https://github.com/onur1211/Str8ts-Solver/assets/107207990/ae321c92-8213-4cd8-8cf1-729851ddb8aa)


Str8ts puzzle solver with unit tests (C# WPF .NET Framework) 

This is a solver application for str8ts puzzles.

The application takes a string representation of a Str8ts puzzle as input.

Clicking on the Create Button creates the puzzle and visualizes it.
If the input is invalid then an error message is displayed.

Clicking on the Solve Button solves the given puzzle.
If the puzzle is not solvable or is already solved then an error message is displayed.

All puzzle sizes (6x6, 9x9...) are supported in this application.
Additionally there are some unit tests included in this application.

The application already starts with a default puzzle:
"w3 w0 w0 w0 b0 w0 w0 b0 b0; w0 w0 w0 b0 w6 w0 w9 w0 w0; b1 w2 w0 b0 w0 w0 b0 w0 w8; w0 w9 b5 w0 w2 b0 w0 w3 b6; w0 w0 w0 w0 w0 w1 w0 w0 w0; b0 w0 w9 b7 w0 w2 b0 w5 w0; w6 w0 b0 w0 w4 b8 w1 w0 b0; w0 w0 w0 w0 w8 b0 w0 w1 w0; b0 b0 w6 w0 b9 w0 w0 w0 w0"

IMPORTANT: The string represantion of the puzzle must be in this format otherwise the input is detected as invalid.

Str8ts rules and explanation: https://de.wikipedia.org/wiki/Str8ts
