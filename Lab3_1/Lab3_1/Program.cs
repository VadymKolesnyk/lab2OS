using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_1
{
    class Analyzer
    {
        private readonly DirectoryInfo root;
        private readonly SortedDictionary<long, List<FileInfo>> barGraph;
        private readonly uint step;
        public uint Step { get => step; }
        private void HandleFile(FileInfo file)
        {
            if (file.Exists)
            {
                long size = file.Length / step;
                if (barGraph.TryGetValue(size, out List<FileInfo> files))
                {
                    files.Add(file);
                }
                else
                {
                    barGraph.Add(size, new List<FileInfo> { file });
                }  
            }
        }
        private void HandleDirectory(DirectoryInfo root)
        {
            foreach (FileInfo file in root.GetFiles())
            {
                HandleFile(file);
            }
            foreach (DirectoryInfo directory in root.GetDirectories())
            {
                HandleDirectory(directory);
            }
        }
        public SortedDictionary<long, List<FileInfo>> Scan()
        {
            HandleDirectory(root);
            foreach (var item in barGraph)
            {
                item.Value.Sort((left, right) =>
                {
                    int diff = (int)(left.Length - right.Length);
                    return diff == 0 ? string.Compare(left.Name, right.Name) : diff;
                });
            }
            return barGraph;
        }
        public Analyzer(uint step, string path)
        {
            this.root = new DirectoryInfo(path);
            this.step = step;
            this.barGraph = new SortedDictionary<long, List<FileInfo>>();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Analyzer analyzer = new Analyzer(1024, @"C:\Users\Vadik\Downloads\Telegram Desktop");
            var barGraph = analyzer.Scan();
            foreach (var item in barGraph)
            {
                Console.WriteLine($"{analyzer.Step * item.Key} - { analyzer.Step * (item.Key + 1) - 1} ({item.Value.Count}):");
                foreach (var file in item.Value)
                {
                    Console.WriteLine($"\t\t{file.Length,13}\t\t{file.Name}");
                }
            }
            Console.ReadKey();

        }
    }
}
