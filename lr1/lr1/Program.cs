using System;
using System.Threading;

namespace lr1
{
	class Program
	{
		static void Main(string[] args)
		{
			TaskQueue taskQueue = new TaskQueue(5);
			for (int i = 0; i < 5; i++)
			{
				taskQueue.EnqueueTask(count);
			}
		}
		static void count()
		{
			int j = 1;
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine("Поток id{0} >> #{1}", Thread.CurrentThread.ManagedThreadId, j);
				j++;
				Thread.Sleep(50);
			}
		}
	}
}
