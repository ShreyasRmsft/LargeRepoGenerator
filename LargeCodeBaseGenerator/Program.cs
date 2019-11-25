using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LargeCodeBaseGenerator
{
    class Program
    {
        static int _maxDepth = 9;
        static int _filesPerFolder = 5;
        static int _foldersPerFolder = 3;

        static int _totalFiles = 0;

        static string _unitTestFileContents = Resource1.UnitTestFileContents;

        static void Main(string[] args)
        {
            var tasks = new List<Task>();

            for (int folder = 0; folder < _foldersPerFolder; folder++)
            {
                int localVarFolder = folder;
                var task = new Task(() =>
                {
                    var newDir = $"{localVarFolder}";
                    Directory.CreateDirectory(newDir);
                    RecursivelyCreateFiles(newDir, 1);
                });

                tasks.Add(task);
                task.Start();
            }

            Task.WaitAll(tasks.ToArray());

            System.Console.WriteLine(_totalFiles);
            System.Console.ReadKey();
        }

        static void RecursivelyCreateFiles(string curfolderPath, int curDepth)
        {
            for (int file = 0; file < _filesPerFolder; file++)
            {
                _totalFiles++;
                File.WriteAllText($"{curfolderPath}\\{file}.cs", string.Format(_unitTestFileContents, $"{curfolderPath.Replace("\\", "")}{file}"));
            }

            for (int folder = 0; folder < _foldersPerFolder; folder++)
            {
                var newDir = $"{curfolderPath}\\{folder}";
                Directory.CreateDirectory(newDir);
                if (curDepth < _maxDepth)
                {
                    RecursivelyCreateFiles(newDir, curDepth + 1);
                }
            }
        }
    }
}
