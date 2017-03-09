using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabKasp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestQueue();
            TestSearcher();
            Console.ReadLine();
        }

        public static void TestQueue()
        {
            QueueLab<Int32> Queue = new QueueLab<int>();

            ThreadLab t1 = new ThreadLab("Pop", Queue);
            ThreadLab t2 = new ThreadLab("Push", Queue);
            ThreadLab t3 = new ThreadLab("Pop", Queue);
            ThreadLab t4 = new ThreadLab("Pop", Queue);
            ThreadLab t5 = new ThreadLab("Push", Queue);
            ThreadLab t6 = new ThreadLab("Push", Queue);
            t1.thrd.Join();
            t2.thrd.Join();
            t3.thrd.Join();
            t4.thrd.Join();
            t5.thrd.Join();
            t6.thrd.Join();
        }

        public static void TestSearcher()
        {
            Searcher searcher = new Searcher(10000, 45);
            searcher.ShowResult();
        }
    }
}
