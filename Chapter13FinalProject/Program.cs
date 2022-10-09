using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Chapter13FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
        string path= @"c:\2\Text1.txt";
        string text="";
        if (File.Exists(path))
        {
           using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
         }
         char[] split = new char[] { ' ', '\r', '\n' };
         var array = text.Split(split, StringSplitOptions.RemoveEmptyEntries);

            var stopWatch1 = new Stopwatch();
            var stopWatch2 = new Stopwatch();

            stopWatch1.Start();
            AddToList(array);
            stopWatch1.Stop();
            Console.WriteLine("Время выполнения AddToList:");
            Console.WriteLine(stopWatch1.Elapsed);

            stopWatch2.Start();
            AddToLinkedList(array);
            stopWatch2  .Stop();
            Console.WriteLine("Время выполнения AddToLinkedList:");
            Console.WriteLine(stopWatch2.Elapsed);
        }
        static void AddToList(string[] words)
        {
            List<string> list = new List<string>();
            foreach(var w in words)
                list.Add(w.ToString()); 
        }
        static void AddToLinkedList(string[] Words)
        {
            LinkedList<string> list = new LinkedList<string>(); 
            foreach (var W in Words)    
                list.AddLast(W.ToString()); 
        }
    }
}