using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // Distinct Collection
        List<int> numbers = new List<int> { 1, 2, 2, 3, 4, 4, 5 };
        var distinctSorted = numbers.Distinct().OrderBy(x => x).ToList();
        Console.WriteLine("Distinct & Sorted: " + string.Join(", ", distinctSorted));
        // -------------------


        // Avg word length
        string sentence = "The quick brown fox jumps over the lazy dog.";
        double averageLength = sentence.Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(word => word.Length)
                                       .Average();
        Console.WriteLine("Avg. word length: " + averageLength);
        // -------------------


        // Strings 
        List<string> words = new List<string> { "absorb", "anaconda", "abs", "adlib", "grab" };
        char startChar = 'a';
        char endChar = 'b';

        var filteredWords = words.Where(word => word.StartsWith(startChar) && word.EndsWith(endChar)).ToList();
        Console.WriteLine("Words starting with 'a' and ending with 'b': " + string.Join(", ", filteredWords));
        // -------------------



        // Students & Grades
        List<Student> students = new List<Student>
        {
            new Student { FirstName = "John", ID = 1 },
            new Student { FirstName = "Foe", ID = 2 },
            new Student { FirstName = "Doe", ID = 3 }
        };

        List<Grade> grades = new List<Grade>
        {
            new Grade { ID = 1, Score = 95 },
            new Grade { ID = 2, Score = 88 },
            new Grade { ID = 3, Score = 91 }
        };

        var studentGrades = students.Join(grades, student => student.ID, grade => grade.ID,
            (student, grade) => new { student.FirstName, grade.Score }).ToList();

        foreach (var item in studentGrades)
        {
            Console.WriteLine($"{item.FirstName} scored {item.Score}");
        }
        // -------------------



        // Extending query ops
        List<int> numbers2 = new List<int> { 1, 2, 3, 4, 5 };
        numbers2.PrintAll();

        List<Student> students2 = new List<Student>
        {
            new Student { FirstName = "John", ID = 1 },
            new Student { FirstName = "Foe", ID = 2 },
            new Student { FirstName = "Doe", ID = 3 }
        };

        Student studentWithMaxID = students.FindMaxBy(s => s.ID);
        if (studentWithMaxID != null)
        {
            Console.WriteLine("Student with the highest ID: " + studentWithMaxID.FirstName);
        }
        // -------------------
    }
}

public class Student
{
    public string FirstName { get; set; }
    public int ID { get; set; }
}

public class Grade
{
    public int ID { get; set; }
    public int Score { get; set; }
}


public static class EnumerableExtensions
{
    public static void PrintAll<T>(this IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }

    public static T FindMaxBy<T, TKey>(this IEnumerable<T> collection, Func<T, TKey> selector) where TKey : IComparable<TKey>
    {
        return collection.OrderByDescending(selector).FirstOrDefault();
    }
}
