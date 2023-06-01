using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Generates puzzle matrix 
/// </summary>
public class PuzzleGenerator : MonoBehaviour
{
    public static event Action OnPuzzleGenerated;
    private const int boardSize = 9;
    private int[,] board;
    public static int[,] puzzle;
    private int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    void Start()
    {
        puzzle = GeneratePuzzle();
        OnPuzzleGenerated?.Invoke();
    }
    public int[,] GeneratePuzzle()
    {
        board = new int[boardSize, boardSize];
        GenerateSudoku(0, 0);
        return board;
    }
    /// <summary>
    /// Recursive method that generates sudoku puzzle
    /// </summary>
    private bool GenerateSudoku(int row, int column)
    {
        if (row == boardSize)
        {
            return true;
        }
        if (column == boardSize)
        {
            return GenerateSudoku(row + 1, 0);
        }
        ShuffleArray(numbers);
        foreach (int numbersInArray in numbers)
        {
            if (IsValidPlacement(row, column, numbersInArray))
            {
                board[row, column] = numbersInArray;

                if (GenerateSudoku(row, column + 1))
                {
                    return true;
                }
                board[row, column] = 0;
            }
        }
        return false;
    }
    private void ShuffleArray(int[] numberArray)
    {
        int randomNumber;
        for (int numberArrayIndex = numberArray.Length - 1; numberArrayIndex > 0; numberArrayIndex--)
        {
            randomNumber = UnityEngine.Random.Range(0, 9);
            int tempNumber = numberArray[numberArrayIndex];
            numberArray[numberArrayIndex] = numberArray[randomNumber];
            numberArray[randomNumber] = tempNumber;
        }
    }
    /// <summary>
    /// Checks if the number exist in the current position of board matrix 
    /// </summary>
    private bool IsValidPlacement(int row, int column, int numbersInArray)
    {
        for (int boardIndex = 0; boardIndex < boardSize; boardIndex++)
        {
            if (board[row, boardIndex] == numbersInArray || board[boardIndex, column] == numbersInArray)
                return false;
        }
        int squareRow = (row / 3) * 3;
        int squareColumn = (column / 3) * 3;
        for (int squareRowIndex = squareRow; squareRowIndex < squareRow + 3; squareRowIndex++)
        {
            for (int squareColumnIndex = squareColumn; squareColumnIndex < squareColumn + 3; squareColumnIndex++)
            {
                if (board[squareRowIndex, squareColumnIndex] == numbersInArray)
                    return false;
            }
        }
        return true;
    }
}
