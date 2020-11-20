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
        private DirectoryInfo root;
        private uint[] barGraph;
        private uint step;
        public Analyzer(uint step, string path)
        {
            this.root = new DirectoryInfo(path);
            this.step = step;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            string dirName = "C:\\Program Files";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            dirInfo.
            Console.WriteLine($"Название каталога: {dirInfo.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}");

        }
    }
}
