using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabKasp
{
    class QueueLab <T>
    {
        private object lockOn1 = new object();
        private object lockOn2 = new object();

        private Queue<T> queue;

        public QueueLab()
        {
            queue = new Queue<T>();
        } 

        public T Pop()
        {
            T item = default(T);
            try
            {
                lock (lockOn1)
                {

                    while (true)
                    {
                        try
                        {
                            lock (lockOn2)
                            {

                                if (queue.Any())
                                {
                                    item = queue.Dequeue();
                                    Console.WriteLine($"Pop {item}");
                                    return item;
                                }
                                Monitor.Pulse(lockOn2);
                                Monitor.Wait(lockOn2);

                            }
                        }
                        catch (Exception ex)
                        {
                            Monitor.Pulse(lockOn2);
                            Console.WriteLine(ex.Message);
                            return item;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Monitor.Pulse(lockOn1);
                Console.WriteLine(ex.Message);
                return item;
            }
        }

        public void Push(T item)
        {
            try
            {
                lock (lockOn2)
                {
                    queue.Enqueue(item);
                    Console.WriteLine($"Push {item}");
                    Monitor.Pulse(lockOn2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class ThreadLab
    {
        public Thread thrd;
        QueueLab<int> queueLab;

        public ThreadLab(string name, QueueLab<int> queue)
        {
            thrd = new Thread(this.Run);
            queueLab = queue;
            thrd.Name = name;
            thrd.Start();
        }

        void Run()
        {
            if (thrd.Name == "Push")
            {
                for (int i = 0; i < 20; i++)
                    queueLab.Push(i);  
                
            }
            else
            {
                for (int i = 0; i < 20; i++)
                    queueLab.Pop();

            }
        }
    }
}
