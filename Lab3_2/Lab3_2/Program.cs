using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("+-------------------------------------------------------------------------+");
                Console.Write("|");
                Console.SetCursorPosition(37 + drive.Name.Length / 2, Console.CursorTop);
                Console.Write(drive.Name);
                Console.SetCursorPosition(74, Console.CursorTop);
                Console.WriteLine("|");
                if (drive.IsReady)
                {
                    Console.WriteLine("+--------------------------+----------------------------------------------+");
                    Console.WriteLine($@"| Тип:                     | {drive.DriveType,-44} |");
                    Console.WriteLine($@"| Метка:                   | {drive.VolumeLabel,-44} |");
                    Console.WriteLine($@"| Файловая система         | {drive.DriveFormat,-44} |");
                    Console.WriteLine($@"| Корневая папка:          | {drive.RootDirectory.FullName,-44} |");
                    Console.WriteLine("+--------------------------+----------------------------------------------+");
                    Console.WriteLine($@"| Объем диска:             | {drive.TotalSize,14} байт = {(double)drive.TotalSize / 1073741824,7:0.00} ГБ = {drive.TotalSize * 100.0 / drive.TotalSize,6:0.00} %  |");
                    Console.WriteLine($@"| Свободное пространство:  | {drive.TotalFreeSpace,14} байт = {(double)drive.TotalFreeSpace / 1073741824,7:0.00} ГБ = {drive.TotalFreeSpace * 100.0 / drive.TotalSize,6:0.00} %  |");
                    Console.WriteLine($@"| Занятое пространство:    | {drive.TotalSize - drive.TotalFreeSpace,14} байт = {(double)(drive.TotalSize - drive.TotalFreeSpace) / 1073741824,7:0.00} ГБ = {(drive.TotalSize - drive.TotalFreeSpace) * 100.0 / drive.TotalSize,6:0.00} %  |");
                    Console.WriteLine("+--------------------------+----------------------------------------------+");
                    int count = Convert.ToInt32((drive.TotalSize - drive.TotalFreeSpace) * 73.0 / drive.TotalSize);
                    string percent = new string(' ', count);
                    string percentNext = new string(' ', 73 - count);
                    Console.Write("|");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(percent);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{percentNext}|");
                }

                    Console.WriteLine("+-------------------------------------------------------------------------+");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
