using System;
using System.Collections.Generic;


//Задание 1
//public class MyMatrix
//{
//    private int[,] _matrix;
//    private int _rows;
//    private int _cols;

//    public MyMatrix(int rows, int cols, int minValue, int maxValue)
//    {
//        _rows = rows;
//        _cols = cols;
//        _matrix = new int[rows, cols];
//        Random rand = new Random();

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                _matrix[i, j] = rand.Next(minValue, maxValue);
//            }
//        }
//    }

//    public int this[int row, int col]
//    {
//        get => _matrix[row, col];
//        set => _matrix[row, col] = value;
//    }

//    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
//    {
//        if (a._rows != b._rows || a._cols != b._cols)
//            throw new InvalidOperationException("Матрицы должны иметь одинаковые размеры для сложения.");

//        MyMatrix result = new MyMatrix(a._rows, a._cols, 0, 1);
//        for (int i = 0; i < a._rows; i++)
//        {
//            for (int j = 0; j < a._cols; j++)
//            {
//                result[i, j] = a[i, j] + b[i, j];
//            }
//        }
//        return result;
//    }

//    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
//    {
//        if (a._rows != b._rows || a._cols != b._cols)
//            throw new InvalidOperationException("Матрицы должны иметь одинаковые размеры для вычитания.");

//        MyMatrix result = new MyMatrix(a._rows, a._cols, 0, 1);
//        for (int i = 0; i < a._rows; i++)
//        {
//            for (int j = 0; j < a._cols; j++)
//            {
//                result[i, j] = a[i, j] - b[i, j];
//            }
//        }
//        return result;
//    }

//    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
//    {
//        if (a._cols != b._rows)
//            throw new InvalidOperationException("Количество столбцов первой матрицы должно равно количеству строк второй матрицы.");

//        MyMatrix result = new MyMatrix(a._rows, b._cols, 0, 1);
//        for (int i = 0; i < a._rows; i++)
//        {
//            for (int j = 0; j < b._cols; j++)
//            {
//                for (int k = 0; k < a._cols; k++)
//                {
//                    result[i, j] += a[i, k] * b[k, j];
//                }
//            }
//        }
//        return result;
//    }

//    public static MyMatrix operator *(MyMatrix matrix, int scalar)
//    {
//        MyMatrix result = new MyMatrix(matrix._rows, matrix._cols, 0, 1);
//        for (int i = 0; i < matrix._rows; i++)
//        {
//            for (int j = 0; j < matrix._cols; j++)
//            {
//                result[i, j] = matrix[i, j] * scalar;
//            }
//        }
//        return result;
//    }

//    public static MyMatrix operator /(MyMatrix matrix, int scalar)
//    {
//        if (scalar == 0)
//            throw new DivideByZeroException("Деление на ноль невозможно.");

//        MyMatrix result = new MyMatrix(matrix._rows, matrix._cols, 0, 1);
//        for (int i = 0; i < matrix._rows; i++)
//        {
//            for (int j = 0; j < matrix._cols; j++)
//            {
//                result[i, j] = matrix[i, j] / scalar;
//            }
//        }
//        return result;
//    }

//    public void Print()
//    {
//        for (int i = 0; i < _rows; i++)
//        {
//            for (int j = 0; j < _cols; j++)
//            {
//                Console.Write($"{_matrix[i, j]} ");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {

//        Console.Write("Введите количество строк: ");
//        int rows = int.Parse(Console.ReadLine());
//        Console.Write("Введите количество столбцов: ");
//        int cols = int.Parse(Console.ReadLine());
//        Console.Write("Введите минимальное значение: ");
//        int minValue = int.Parse(Console.ReadLine());
//        Console.Write("Введите максимальное значение: ");
//        int maxValue = int.Parse(Console.ReadLine());

//        MyMatrix matrix1 = new MyMatrix(rows, cols, minValue, maxValue);
//        MyMatrix matrix2 = new MyMatrix(rows, cols, minValue, maxValue);

//        Console.WriteLine("Первая матрица:");
//        matrix1.Print();
//        Console.WriteLine("Вторая матрица:");
//        matrix2.Print();

//        MyMatrix sum = matrix1 + matrix2;
//        Console.WriteLine("Сумма матриц:");
//        sum.Print();

//        MyMatrix difference = matrix1 - matrix2;
//        Console.WriteLine("Разность матриц:");
//        difference.Print();

//        Console.Write("Введите число для умножения матриц: ");
//        int scalar = int.Parse(Console.ReadLine());
//        MyMatrix scaledMatrix = matrix1 * scalar;
//        Console.WriteLine($"Первая матрица, умноженная на {scalar}:");
//        scaledMatrix.Print();

//        MyMatrix dividedMatrix = matrix1 / scalar;
//        Console.WriteLine($"Первая матрица, деленная на {scalar}:");
//        dividedMatrix.Print();
//    }
//}


//Задание 2

public class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, int productionYear, int maxSpeed)
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
    }

    // Переопределяем метод ToString для удобного вывода информации о машине
    public override string ToString()
    {
        return $"Name: {Name}, Year: {ProductionYear}, Max Speed: {MaxSpeed}";
    }
}

public class CarComparer : IComparer<Car>
{
    private readonly string _propertyToSortBy;

    public CarComparer(string propertyToSortBy)
    {
        _propertyToSortBy = propertyToSortBy.ToLower();
    }

    public int Compare(Car x, Car y)
    {
        if (_propertyToSortBy == "name")
        {
            return string.Compare(x.Name, y.Name);
        }
        else if (_propertyToSortBy == "year")
        {
            return x.ProductionYear.CompareTo(y.ProductionYear);
        }
        else if (_propertyToSortBy == "maxspeed")
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed);
        }
        else
        {
            throw new ArgumentException("Property to sort by is not recognized.");
        }
    }
}

//class Program
//{
//    static void Main()
//    {
//        Car[] cars = new Car[]
//        {
//            new Car("Toyota", 2015, 180),
//            new Car("Ford", 2020, 200),
//            new Car("BMW", 2018, 250),
//            new Car("Audi", 2019, 240)
//        };

//        Array.Sort(cars, new CarComparer("name"));
//        Console.WriteLine("Сортировка по названию:");
//        foreach (var car in cars)
//        {
//            Console.WriteLine(car);
//        }

//        Array.Sort(cars, new CarComparer("year"));
//        Console.WriteLine("\nСортировка по году выпуска:");
//        foreach (var car in cars)
//        {
//            Console.WriteLine(car);
//        }

//        Array.Sort(cars, new CarComparer("maxspeed"));
//        Console.WriteLine("\nСортировка по максимальной скорости:");
//        foreach (var car in cars)
//        {
//            Console.WriteLine(car);
//        }
//    }
//}


//Задание 3

public class CarCatalog
{
    private Car[] cars;

    public CarCatalog(Car[] cars)
    {
        this.cars = cars;
    }

    // Итератор для прямого прохода
    public IEnumerable<Car> GetCars()
    {
        foreach (var car in cars)
        {
            yield return car;
        }
    }

    // Итератор для обратного прохода
    public IEnumerable<Car> GetCarsReverse()
    {
        for (int i = cars.Length - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }

    // Итератор с фильтром по году выпуска
    public IEnumerable<Car> GetCarsByYear(int year)
    {
        foreach (var car in cars)
        {
            if (car.ProductionYear == year)
            {
                yield return car;
            }
        }
    }

    // Итератор с фильтром по максимальной скорости
    public IEnumerable<Car> GetCarsByMaxSpeed(int maxSpeed)
    {
        foreach (var car in cars)
        {
            if (car.MaxSpeed >= maxSpeed)
            {
                yield return car;
            }
        }
    }
}
class Program
{
    static void Main()
    {
        Car[] cars = new Car[]
        {
            new Car("Toyota", 2015, 180),
            new Car("Ford", 2020, 200),
            new Car("BMW", 2018, 250),
            new Car("Audi", 2019, 240)
        };

        CarCatalog catalog = new CarCatalog(cars);

        Console.WriteLine("Прямой проход:");
        foreach (var car in catalog.GetCars())
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\nОбратный проход:");
        foreach (var car in catalog.GetCarsReverse())
        {
            Console.WriteLine(car);
        }


        Console.WriteLine("\nПроход с фильтром по году выпуска (2018):");
        foreach (var car in catalog.GetCarsByYear(2018))
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\nПроход с фильтром по максимальной скорости (200):");
        foreach (var car in catalog.GetCarsByMaxSpeed(200))
        {
            Console.WriteLine(car);
        }
    }
}

