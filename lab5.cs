
using System;

public class MultiArray
{
    private int[,] array;
    private int rows;
    private int columns;

    public MultiArray(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        array = new int[rows, columns];
    }

    public int GetElement(int row, int column)
    {
        return array[row, column];
    }

    public void SetElement(int row, int column, int value)
    {
        array[row, column] = value;
    }

    public int[] GetRow(int row)
    {
        int[] rowArray = new int[columns];
        for (int i = 0; i < columns; i++)
        {
            rowArray[i] = array[row, i];
        }
        return rowArray;
    }

    public int[] GetColumn(int column)
    {
        int[] columnArray = new int[rows];
        for (int i = 0; i < rows; i++)
        {
            columnArray[i] = array[i, column];
        }
        return columnArray;
    }

    public static void Main(string[] args)
    {
        int rows = 1000;
        int columns = 1000;
        MultiArray multiArray = new MultiArray(rows, columns);

        // Измеряем время доступа к элементу массива
        DateTime start = DateTime.Now;
        int element = multiArray.GetElement(500, 500);
        DateTime end = DateTime.Now;
        TimeSpan directAccessTime = end - start;

        // Измеряем время доступа к строке массива через вектор Айлиффа
        start = DateTime.Now;
        int[] row = multiArray.GetRow(500);
        end = DateTime.Now;
        TimeSpan iliffeVectorAccessTime = end - start;

        Console.WriteLine("Время прямого доступа: " + directAccessTime.TotalMilliseconds + " мс");
        Console.WriteLine("Время доступа через вектор Айлиффа: " + iliffeVectorAccessTime.TotalMilliseconds + " мс");
    }
}
