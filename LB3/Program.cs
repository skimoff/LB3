namespace LB3;

class Program
{
    static Random random = new Random();

    static void printArray(int[] array, int size)
    {
        for (int i = 0; i < size; i++)
            Console.Write(array[i] + " ");
    }

    static void fillArray(int[] array, int size)
    {
        for (int i = 0; i < size; i++)
            array[i] = Convert.ToInt32(Console.ReadLine());
    }

    static void fillArrayRandom(int[] array, int size)
    {
        for (int i = 0; i < size; i++)
            array[i] = random.Next(51);
    }

    static void fillArrayFile(int[] array, int size)
    {
        using (StreamReader input = new StreamReader("in1.txt"))
        {
            for (int i = 0; i < size; i++)
                array[i] = Convert.ToInt32(input.ReadLine());
        }
    }

    static int createSize()
    {
        int size;
        int count = 0;
        do
        {
            Console.WriteLine("Enter size(1-100)");
            size = Convert.ToInt32(Console.ReadLine());
            if (size < 1 || size > 100)
            {
                count++;
            }

            if (count >= 3)
            {
                size = 20;
            }
        } while (count != 3);

        return size;
    }

    static void task1()
    {
        int size = createSize();
        int[] arr = new int[size];

        Console.WriteLine("enter values yourself(1), randomly(2) or from a file(3): ");
        int pr;
        pr = Convert.ToInt32(Console.ReadLine());
        switch (pr)
        {
            case 1:
                fillArray(arr, size);
                break;
            case 2:
                fillArrayRandom(arr, size);
                break;
            case 3:
                fillArrayFile(arr, size);
                break;
            default:
                fillArrayRandom(arr, size);
                break;
        }

        Array.Reverse(arr);
        printArray(arr, size);
        Array.Sort(arr, 0, size / 2);
        Array.Reverse(arr, 0, size / 2);

        for (int i = size / 2; i < size; i++)
            arr[i] -= arr[(size / 2) - 1];

        Console.WriteLine();
        printArray(arr, size);
    }

    static void fillTwoArrayRandom(int[,] array, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array[i, j] = random.Next(51);
            }
        }
    }

    static void fillTwoArrayFile(int[,] array, int rows, int cols, string fileName)
    {
        using (StreamReader input = new StreamReader(fileName))
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = Convert.ToInt32(input.ReadLine());
                }
            }
        }
        
    }

    static void printTwoArray(int[,] array, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void sortCols(int[,] array, int x)
    {
        x -= 1;
        int g = array.GetLength(1);
        for (int i = 0; i < g - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < g; j++)
            {
                if (array[x, j] < array[x, minIndex])
                {
                    minIndex = j;
                }
            }

            (array[x, i], array[x, minIndex]) = (array[x, minIndex], array[x, i]);
        }
    }

    static void task2()
    {
        int m = 3;
        int g = 4;
        int[,] a = new int[m, g];
        int[,] b = new int[m, g];
        int[,] c = new int[m, g];

        int pr;
        Console.WriteLine("Enter values manually(1) or randomly(2): ");
        pr = Convert.ToInt32(Console.ReadLine());
        if (pr == 1)
        {
            fillTwoArrayFile(b, m, g, "in2.txt");
            fillTwoArrayFile(c, m, g, "in3.txt");
        }
        else
        {
            fillTwoArrayRandom(b, m, g);
            fillTwoArrayRandom(c, m, g);
        }

        Console.WriteLine("b: ");
        printTwoArray(b, m, g);
        Console.WriteLine();
        Console.WriteLine("c: ");
        printTwoArray(c, m, g);
        Console.WriteLine();

        Console.WriteLine("Enter cows:");
        int x = Convert.ToInt32(Console.ReadLine());
        if (x > 0 & x <= m)
            sortCols(b, x);
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < g; j++)
            {
                a[i, j] = b[i, j] - c[i, j];
            }
        }

        printTwoArray(a, m, g);
    }

    static void Main(string[] args)
    {
        //task1();
        task2();
        Console.ReadKey();
    }
}