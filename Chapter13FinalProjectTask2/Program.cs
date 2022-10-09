using System.Linq;

namespace Chapter13FinalProjectTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\2\Text1.txt";
            string text = "";
            char[] split = new char[] { ' ', '\r', '\n' };
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            }
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            var array = noPunctuationText.Split(split,StringSplitOptions.RemoveEmptyEntries);
            TopTenWords(array);

            
        }
        static void TopTenWords(string[] words)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach(var word in words)
            {
                if(!wordCount.ContainsKey(word))
                {
                    wordCount[word]=1;
                }
                else
                {
                    wordCount[word]++;
                }

            }

            //wordCount.OrderBy(x => x.Value);
            wordCount = wordCount.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);
            var ten = wordCount.Take(10).Select(c=>c.Key).ToList();   
            foreach(var t in ten)
                Console.WriteLine(t);
        }
    }
}