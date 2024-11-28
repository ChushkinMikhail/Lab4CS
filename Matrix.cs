// See https://aka.ms/new-console-template for more information
using System;

public class MyMatrix
    {
    private int[,] matrix;
    private int rows;
    private int cols;

    public MyMatrix(int rows, int cols, int minValue, int maxValue)
        {
        this.rows = rows;
        this.cols = cols;

        matrix = new int[rows, cols];

        Random rand = new Random();

        for (int i = 0; i < rows; i++)
            {
            for (int j = 0; j < cols; j++)
                {
                matrix[i, j] = rand.Next(minValue, maxValue);
                }
            }
        }

    public int this[int row, int col]
        {
        get { return matrix[row, col]; }
        set { matrix[row, col] = value; }
        }

    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
        if (a.rows != b.rows || a.cols != b.cols)
            {
            throw new InvalidOperationException ("Матриицы не одинакового размера");
            }

        MyMatrix result = new MyMatrix(a.rows, a.cols, 0, 1);
        for (int i = 0; i < a.rows; i++)
            {
            for (int j = 0; j < a.cols; j++)
                {
                result[i, j] = a[i, j] + b[i, j];
                }
            }
        return result;
        }

    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
        {
        if (a.rows != b.rows || a.cols != b.cols)
            {
            throw new InvalidOperationException("Матриицы не одинакового размера");
            }

        MyMatrix result = new MyMatrix(a.rows, a.cols, 0, 1);
        for (int i = 0; i < a.rows; i++)
            {
            for (int j = 0; j < a.cols; j++)
                {
                result[i, j] = a[i, j] - b[i, j];
                }
            }
        return result;
        }

    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
        if (a.cols != b.rows)
            {
            throw new InvalidOperationException("Матриицы не одинаковой размерности");
            }

        MyMatrix result = new MyMatrix(a.rows, b.cols, 0, 1);

        for (int i = 0; i < a.rows; i++)
            {
            for (int j = 0; j < b.cols; j++)
                {
                for (int k = 0; k < a.cols; k++)
                    {
                    result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
        return result;
        }
    
    public static MyMatrix operator *(MyMatrix a, int scalar)
        {
        MyMatrix result = new MyMatrix(a.rows, a.cols, 0, 1);
        for (int i = 0; i < a.rows; i++)
            {
            for (int j = 0; j < a.cols; j++)
                {
                result[i, j] = a[i, j] * scalar;
                }
            }
        return result;
        }

    public static MyMatrix operator /(MyMatrix a, int scalar)
        {
        if (scalar == 0)
            {
            throw new DivideByZeroException("На ноль днлить нельзя");
            }

        MyMatrix result = new MyMatrix(a.rows, a.cols, 0, 1);
        for (int i = 0; i < a.rows; i++)
            {
            for (int j = 0; j < a.cols; j++)
                {
                result[i, j] = a[i, j] / scalar;
                }
            }
        return result;
        }

    public void Print()
        {
        for (int i = 0; i < rows; i++)
            {
            for (int j = 0; j < cols; j++)
                {
                Console.Write(matrix[i, j] + "\t");
                }
            Console.WriteLine();
            }
        }
    }

class Program
    {
    void Main()
        {
        Console.WriteLine("Введите количество строк:");
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов:");
        int cols = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите минимальное значение:");
        int minValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите максимальное значение:");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix matrixA = new MyMatrix(rows, cols, minValue, maxValue);
        MyMatrix matrixB = new MyMatrix(rows, cols, minValue, maxValue);

        Console.WriteLine("Матрица A:");
        matrixA.Print();
        Console.WriteLine("Матрица B:");
        matrixB.Print();

        var sum = matrixA + matrixB;
        Console.WriteLine("Сумма матриц A и B:");
        sum.Print();

        var sub = matrixA - matrixB;
        Console.WriteLine("Разность матриц A и B:");
        sub.Print();

        MyMatrix matrixC = new MyMatrix(cols, rows, minValue, maxValue);

        Console.WriteLine("Матрица C:");
        matrixC.Print();

        var nult = matrixA * matrixC;
        Console.WriteLine("Произведение матриц A и C:");
        nult.Print();

        Console.WriteLine("Умножение матрицы A на число:");
        var scal1 = matrixA * 2;
        scal1.Print();

        Console.WriteLine("Деление матрицы A на число:");
        var scal2 = matrixA / 2;
        scal2.Print();
        }
    }
