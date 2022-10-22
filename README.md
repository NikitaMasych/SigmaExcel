# Welcome!

This is MVP electronic table similar to the Microsoft Excel via C# and .NET.

## Use cases:

* Enter formula in cell or textbox and evaluate the result
* Save table to a .csv file
* Open table from a .csv file
* Modify rows and columns amount
* Reset table to the default state
* Configure warnings for deletion of the unsaved content

## Supported operations and syntax:
```
0. Numeric decimal values (integer or floating point) 
1. Binary arifmethic operations: +, -, *, / 
2. Unary arifmethic operations: +, -
3. Max, min from multiple values: max(2,92.1,-8,6), min(66,89,5,-23.2) e.g.
4. Trigonometrical operations: sin, cos, tan, cot
5. Exponential equation: 2 ^ 5 or 2 ** 5 equals 32
6. Integer-like division and modulo: div(7,2), mod(48,5) equal 3 
7. References to values of specific cells, e.g.: E8, B4
8. Absolute value function, e.g.: abs(-2), abs(2) equals 2
```
### Invalid expression behavior:
If entered expression can not be evaluated (contains unspecified syntax, refers to unexisting/unevaluated cells, calculation error, e.g. division by zero), it remains in the cells and is visible for futher modification.

# Parser implementation:

Parsing realized with ANTLR4 context grammar.

## Saving of the table:

Project uses model of .csv file in order to store table. First line contains dimensional sizes and after table-like separated by specific character expressions of the corresponding cells.

## Saving current warnings:
Each time application shutdowns, environmental file with current warnings configuration is saved in ${AppData}/SigmaExcel/
