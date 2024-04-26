using System;
using System.Text.Json;
using System.Text.Json.Serialization;

abstract class Task
{
    protected string text = "Example";
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
    }
}
class Task1 : Task
{
    public Task1(string text) : base(text)
    {
        List<char> lettersList = new List<char>();
        int spaceBuf = 1;
        for (int i = 0; i < text.Length-1; i++)
        {
            if (text[i] ==' ') {
                spaceBuf = i;
            }
        }
        for (int i = 0; i<= spaceBuf; i++)
        {
            for (int j=text.Length-1; j>= spaceBuf; j--) {
                if (text[i] == text[j])
                {
                    lettersList.Add(text[i]);

                }
            }
        }
        for (int x=0; x<lettersList.Count; x++)
        {
            Console.WriteLine(lettersList[x]);
        }
    }
}
class Task2 : Task
{
    public Task2(string text) : base(text)
    {
        string cryptoText = "";
        char charBuf = ' ';
        for (int i=0; i<=text.Length-1; i++) {
            charBuf = text[i];
        }
        Console.WriteLine(cryptoText);
    }
}
class JsonTasks
{
    public static void Write<T>(T obj, string path)
    {
        using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fileStream, obj);
        }
    }
 
}

public class Program
{
    public static void Main()
    {
        Task a = new Task1("Привет, мир!");
        string root_path = @"C:\Users\m2311567\Documents";
        string folderName = "Answer";
        string task1_filename = "task_1.json";
        string task2_filename = "task_2.json";
        root_path = Path.Combine(root_path, folderName);
        if (!Directory.Exists(root_path))
        {
            Directory.CreateDirectory(root_path);
        }
        task1_filename = Path.Combine(root_path, task1_filename);
        task2_filename = Path.Combine(root_path, task2_filename);
    }
}
