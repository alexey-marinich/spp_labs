using System;

namespace mpp_lab_2
{
    public delegate void TaskDelegate(string file1, string file2);

    public delegate void LoggerDelegate(string logMessage);
    static class Program
    {
        public static void Logger(string logMessage)
        {

        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("введите только 2 аргумента");
                return;
            }

            string dir1 = @"C:\3\1";
            string dir2 = @"C:\3\2";

            ThreadQueue threadQueue = new ThreadQueue(3);
            DirectoryWork directoryWork = new DirectoryWork(dir1, dir2, threadQueue, null);
            directoryWork.CopyDir(dir1, dir2);
            Console.WriteLine("файлов скопировано: " + DirectoryWork.filesCopyNum);
            Console.ReadLine();
        }
    }
}