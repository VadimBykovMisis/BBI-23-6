//1.1
using System;

struct Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double[] coordinates)
    {
        if (coordinates.Length != 2)
        {
            throw new ArgumentException("Coordinates array must contain exactly 2 elements (X and Y).");
        }
        X = coordinates[0];
        Y = coordinates[1];
    }

    public static double Distance(Point point1, Point point2)
    {
        double deltaX = point2.X - point1.X;
        double deltaY = point2.Y - point1.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    public static void PrintDistance(Point point1, Point point2)
    {
        Console.WriteLine($"Coordinates of Point 1: ({point1.X}, {point1.Y})");
        Console.WriteLine($"Coordinates of Point 2: ({point2.X}, {point2.Y})");
        Console.WriteLine($"Distance between Point 1 and Point 2: {Distance(point1, point2):F2}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Point[] points = new Point[3];
        points[0] = new Point(new double[] { 0, 0 });
        points[1] = new Point(new double[] { 3, 4 });
        points[2] = new Point(new double[] { -2, 6 });

        for (int i = 0; i < points.Length - 1; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                Point.PrintDistance(points[i], points[j]);
            }
        }
    }
}
//1.2 
using System;
abstract class Profession
{
    private string name;
    protected string professionName;
    public string Name { get { return name; } }
    private int nadbavka;
    public int Nadbavka { get { return nadbavka; } }
    public Profession(string name, int nadbavka)
    {
        this.name = name;
        this.nadbavka = nadbavka;
    }
    public void PrintInfo()
    {
        Console.WriteLine("{0} {1}, slalry: {2}", professionName, name, Calculate());
    }
    public abstract int Calculate();
}
class Fireman : Profession
{
    private int dangerous;
    public int Dangerous { get { return dangerous; } }
    public Fireman(string name, int nadbavka, int dangerous) : base(name, nadbavka)
    {
        professionName = "fireman";
        this.dangerous = dangerous;
    }
    public override int Calculate()
    {
        return (dangerous + Nadbavka) * 100;
    }
}
class Engineer : Profession
{
    private int category;
    public int Category { get { return category; } }
    public Engineer(string name, int category, int nadbavka) : base(name, nadbavka)
    {
        professionName = "engineer";
        this.category = category;
    }
    public override int Calculate()
    {
        return (Nadbavka + category) * 100;
    }
}
class Scientist : Profession
{
    private int degree;
    public int Degree { get { return degree; } }
    public Scientist(string name, int degree, int nadbavka) : base(name, nadbavka)
    {
        professionName = "scientist";
        this.degree = degree;
    }
    public override int Calculate()
    {
        return (Nadbavka + degree) * 100;
    }
}
class Programm
{
    static void Main(string[] args)
    {
        Profession[] firemen = new Profession[5]
        {
            new Fireman("Alex", 4, 2),
            new Fireman("Boris", 8, 1),
            new Fireman("Egor", 5, 2),
            new Fireman("Igor", 6, 3),
            new Fireman("Yuriy", 3, 1)
        };
        SortBySalary(firemen);
        Print(firemen);
        Profession[] engineers = new Profession[]
        {
            new Engineer("Nina", 3, 5),
            new Engineer("Valya", 3, 1),
            new Engineer("Maria", 4, 3),
            new Engineer("Vasiliy", 2, 1),
            new Engineer("Adil", 5, 4)
        };
        SortBySalary(engineers);
        Print(engineers);
        Profession[] scientists = new Profession[]
        {
            new Scientist("Nadya", 1, 8),
            new Scientist("Arseniy", 3, 5),
            new Scientist("Tema", 3, 7),
            new Scientist("Jason", 2, 5),
            new Scientist("Makar", 4, 5)
        };
        SortBySalary(scientists);
Print(scientists);
        Profession[] professions = new Profession[15];
        for(int i = 0; i < 5; i++)
        {
            professions[i] = firemen[i];
        }
        for (int i = 0; i < 5; i++)
        {
            professions[i+5] = engineers[i];
        }
        for (int i = 0; i < 5; i++)
        {
            professions[i+10] = scientists[i];
        }
        SortBySalary(professions);
        Print(professions);
        Console.ReadKey();
    }
    static void SortBySalary(Profession[] professions)
    {
        Profession t;
        for (int i = 0; i < professions.Length; i++)
        {
            for (int j = 0; j < professions.Length-1; j++)
            {
                if(professions[j].Calculate() < professions[j+1].Calculate())
                {
                    t = professions[j];
                    professions[j] = professions[j + 1];
                    professions[j + 1] = t;
                }
            }
        }
    }
    static void Print(Profession[] professions)
    {
        for ( int i = 0; i < professions.Length; i++)
        {
            professions[i].PrintInfo();
        }
        Console.WriteLine();
    }
}
//6.2
using System;

abstract class Animal
{
    protected string name;
    protected string dietType;
    public string DietType { get { return dietType; } }

    public Animal(string name, string dietType)
    {
        this.name = name;
        this.dietType = dietType;
    }

    public abstract void MakeSound();

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Diet type: {dietType}");
        Console.Write("Sound: ");
        MakeSound();
        Console.WriteLine();
    }
}

class Giraffe : Animal
{
    public Giraffe(string name) : base(name, "Herbivore")
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Giraffe: *silence*");
    }
}

class Pig : Animal
{
    public Pig(string name) : base(name, "Omnivore")
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Pig: Oink oink!");
    }
}

class Elephant : Animal
{
    public Elephant(string name) : base(name, "Herbivore")
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Elephant: Trumpet!");
    }
}

class Lion : Animal
{
    public Lion(string name) : base(name, "Carnivore")
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Lion: Roar!");
    }
}

class Tiger : Animal
{
    public Tiger(string name) : base(name, "Carnivore")
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Tiger: Growl!");
    }
}

class Monkey : Animal
{
    public Monkey(string name) : base(name, "Omnivore")
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Monkey: Ooh ooh aah aah!");
    }
}

class Program
{
    static void Main()
    {
        Animal[] animals = new Animal[]
        {
            new Giraffe("Giraffe1"), new Giraffe("Giraffe2"), new Giraffe("Giraffe3"),
            new Pig("Pig1"), new Pig("Pig2"), new Pig("Pig3"),
            new Elephant("Elephant1"), new Elephant("Elephant2"), new Elephant("Elephant3"),
            new Lion("Lion1"), new Lion("Lion2"), new Lion("Lion3"),
            new Tiger("Tiger1"), new Tiger("Tiger2"), new Tiger("Tiger3"),
            new Monkey("Monkey1"), new Monkey("Monkey2"), new Monkey("Monkey3")
        };

        Console.WriteLine("Herbivores:");
        PrintAnimalsByDietType(animals, "Herbivore");

        Console.WriteLine("Carnivores:");
        PrintAnimalsByDietType(animals, "Carnivore");

        Console.WriteLine("Omnivores:");
        PrintAnimalsByDietType(animals, "Omnivore");

        Console.ReadKey();
    }

    static void PrintAnimalsByDietType(Animal[] animals, string dietType)
    {
        foreach (Animal animal in animals)
        {
            if (animal.DietType == dietType)
            {
                animal.PrintInfo();
            }
        }
    }
}
//15.1
using System;
using System.Collections.Generic;
struct Series
{
    public string Title;
    public double AverageDuration;
    public string Description;
    public bool IsWatched;

    public Series(string title, double averageDuration)
    {
        Title = title;
        AverageDuration = averageDuration;
        Description = $"Для сериала {title} описание не задано";
        IsWatched = false;
    }

    public void UpdateDescription(string newDescription)
    {
        if (newDescription.Length >= 20 && newDescription.Length <= 200)
        {
            Description = newDescription;
        }
        else
        {
            Console.WriteLine("Описание должно содержать от 20 до 200 символов.");
        }
    }

    public void MarkAsWatched()
    {
        IsWatched = true;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Название: {Title}");
        Console.WriteLine($"Средняя длительность серии: {AverageDuration}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Просмотрено: {(IsWatched ? "Да" : "Нет")}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Series> seriesList = new List<Series>()
        {
            new Series("Friends", 22.5),
            new Series("Breaking Bad", 50.0),
            new Series("Game of Thrones", 55.0),
            new Series("Stranger Things", 45.0),
            new Series("The Office", 25.0)
        };

        seriesList.Sort((x, y) => x.Title.CompareTo(y.Title));

        Console.WriteLine("Список сериалов:");
        foreach (Series series in seriesList)
        {
            series.PrintInfo();
        }

        Console.ReadKey();
    }
}
//5.1
using System;

struct Book
{
    private string title;
    private int ISBN;
    private string author;
    private int year;
    public string Author { get { return author; } }
    public int Year { get { return year; } }

    private static int _nextISBN = 1;
    public Book(string title, string author, int year)
    {
        this.title = title;
        ISBN = _nextISBN + 1;
        _nextISBN++;
        this.author = author;
        this.year = year;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Название: {title}");
        Console.WriteLine($"ISBN: {ISBN}");
        Console.WriteLine($"Автор: {author}");
        Console.WriteLine($"Год издания: {year}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book[] books = new Book[10]
        {
            new Book("Война и мир", "Лев Толстой", 1869),
            new Book("Преступление и наказание", "Фёдор Достоевский", 1866),
            new Book("1984", "Джордж Оруэлл", 1949),
            new Book("Мастер и Маргарита", "Михаил Булгаков", 1966),
            new Book("Улисс", "Джеймс Джойс", 1922),
            new Book("Маленький принц", "Антуан де Сент-Экзюпери", 1943),
            new Book("Гарри Поттер и философский камень", "Дж. К. Роулинг", 1997),
            new Book("Гарри Поттер и Тайная комната", "Дж. К. Роулинг", 1998),
            new Book("Гарри Поттер и узник Азкабана", "Дж. К. Роулинг", 1999),
            new Book("Гарри Поттер и Кубок огня", "Дж. К. Роулинг", 2000)
        };

        Console.WriteLine("Информация о всех книгах:");
        foreach (Book book in books)
        {
            book.PrintInfo();
        }

        Console.WriteLine("Введите имя автора для поиска книг:");
        string authorToSearch = Console.ReadLine();

        Console.WriteLine($"Книги автора {authorToSearch}:");
        foreach (Book book in books)
        {
            if (book.Author == authorToSearch)
            {
                book.PrintInfo();
            }
        }

        Console.WriteLine("Введите век для поиска книг:");
        int centuryToSearch = int.Parse(Console.ReadLine());
        Console.WriteLine($"Книги, написанные в {centuryToSearch} веке:");
        foreach (var book in books)
        {
            int century = (book.Year - 1) / 100 + 1;
            if (century == centuryToSearch)
            {
                book.PrintInfo();
            }
        }
        Console.ReadKey();
    }
}