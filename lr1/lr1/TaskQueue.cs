using System;
using System.Collections.Concurrent;
using System.Threading;

namespace lr1
{
    public delegate void TaskDelegate();

    class TaskQueue
    {
        static object locker = new object();
        BlockingCollection<TaskDelegate> Tasks = new BlockingCollection<TaskDelegate>(new ConcurrentQueue<TaskDelegate>());

        public TaskQueue(int queueCount)
        {
            for (int i = 0; i < queueCount; i++)
            {
                var thread = new Thread(ThreadWork); 
                thread.Start();
            }
        }

        public void ThreadWork()
        {

            while (true)
            {
              //  lock(locker){ 
                var task = Tasks.Take();
                    task();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "  id");
               // }
            }
        }

        public void EnqueueTask(TaskDelegate task)
        {
            this.Tasks.Add(task);
        }
    }
}
