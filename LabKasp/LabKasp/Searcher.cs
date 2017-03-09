using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LabKasp
{
    class Searcher
    {
        private List<int> collection;
        private int x;

        public Searcher(int count, int number)
        {
            x = number;
            Random rnd = new Random();
            collection = new List<int>();
            for (int i = 0; i < count; i++)
            {
                collection.Add(rnd.Next(100));
            }

        }

        public void ShowResult()
        {
            List<int> usedCollection = new List<int>();
            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i] >= x)
                    continue;
                if (usedCollection.Contains(collection[i]))
                    continue;
                int tempResult = x - collection[i];
                for (int j = 0; j < collection.Count; j++)
                {
                    if (i == j)
                        continue;
                    if (collection[j] == tempResult)
                    {
                        usedCollection.Add(collection[j]);
                        Console.WriteLine($"{collection[i]} + {collection[j]} = {x}");
                        break;
                    }

                }
                usedCollection.Add(collection[i]);
            }
        }


    }
}
