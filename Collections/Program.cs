using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle objectForSearch = new Circle(2.4, 3.7, 6.9);
            Circle result = new Circle();

            Stopwatch stopWatch = new Stopwatch();
            Random rand = new Random();
            ArrayList array = new ArrayList();
            LinkedList<Circle> linkedList = new LinkedList<Circle>();
            Stack<Circle> stack = new Stack<Circle>();
            Queue<Circle> queue = new Queue<Circle>();
            Hashtable hashTable = new Hashtable();
            Dictionary<int,Circle> dictionary = new Dictionary<int,Circle>();

            /*-----------------------------------------------------------------------------------------
                               ADD ELEMENT  -- ArrayList vs LinkedList            
            ------------------------------------------------------------------------------------------*/

            stopWatch.Start();
            for (int i = 0; i < 500000; i++)
            {
                array.Add(new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            array.Add(objectForSearch);
            for (int i = 0; i < 500000; i++)
            {
                array.Add(new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }            
            stopWatch.Stop();
            Console.WriteLine("Add Elements - RunTime for ArrayList - " + stopWatch.Elapsed);
            stopWatch.Reset();  

          
            stopWatch.Start();                      
            for (int i = 0; i < 500000; i++)
            {
                linkedList.AddLast(new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }            
            linkedList.AddLast(objectForSearch);
            for (int i = 0; i < 500000; i++)
            {
                linkedList.AddLast(new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("Add Elements RunTime for LinkedList - " + stopWatch.Elapsed);
            stopWatch.Reset();

            /*-----------------------------------------------------------------------------------------
                                     SEARCH ELEMENT --  ArrayList vs LinkedList         
            ------------------------------------------------------------------------------------------*/
           
            stopWatch.Start();
            array.Sort(new CircleComparer());
            int index = array.BinarySearch((object)objectForSearch,new CircleComparer());
            result = (Circle)array[index];            
            stopWatch.Stop();
            Console.WriteLine("\nSearch Elements RunTime for ArrayList - " + stopWatch.Elapsed);
            stopWatch.Reset();
                                  
            stopWatch.Start();
            result = (Circle)linkedList.Find(objectForSearch).Value;            
            stopWatch.Stop();
            Console.WriteLine("Search Elements RunTime for LinkedList - " + stopWatch.Elapsed);
            stopWatch.Reset();

            /*-----------------------------------------------------------------------------------------
                         REMOVE ELEMENT --  ArrayList vs LinkedList         
            ------------------------------------------------------------------------------------------*/

            stopWatch.Start();
            array.Remove(objectForSearch);
            stopWatch.Stop();
            Console.WriteLine("\nRemove Elements RunTime for ArrayList - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            linkedList.Remove(objectForSearch);
            stopWatch.Stop();
            Console.WriteLine("Remove Elements RunTime for LinkedList - " + stopWatch.Elapsed);
            stopWatch.Reset();

            /*-----------------------------------------------------------------------------------------
                             ADD ELEMENT  -- Stack vs Queue            
             ------------------------------------------------------------------------------------------*/
            stopWatch.Start();
            for (int i = 0; i < 5000; i++)
            {
                stack.Push(new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stack.Push(objectForSearch);
            for (int i = 0; i < 5000; i++)
            {
                stack.Push(new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("\nAdd Elements - RunTime for Stack - " + stopWatch.Elapsed);
            stopWatch.Reset();


            stopWatch.Start();
            for (int i = 0; i < 5000; i++)
            {
                queue.Enqueue(new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            queue.Enqueue(objectForSearch);
            for (int i = 0; i < 5000; i++)
            {
                queue.Enqueue(new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("Add Elements - RunTime for Queue - " + stopWatch.Elapsed);
            stopWatch.Reset();

            /*-----------------------------------------------------------------------------------------
                         SEARCH ELEMENT --  Stack vs Queue         
            ------------------------------------------------------------------------------------------*/
            CircleComparer circleComparer = new CircleComparer(); 

            stopWatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                if (circleComparer.Compare(objectForSearch, stack.ElementAt(i)) == 0)
                    result = stack.ElementAt(i);
            }            
            stopWatch.Stop();
            Console.WriteLine("\nSearch Elements - RunTime for Stack - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                if (circleComparer.Compare(objectForSearch, queue.ElementAt(i)) == 0)
                    result = queue.ElementAt(i);
            }
            stopWatch.Stop();
            Console.WriteLine("Search Elements - RunTime for Queue - " + stopWatch.Elapsed);
            stopWatch.Reset();

            /*-----------------------------------------------------------------------------------------
                                 REMOVE ELEMENT --  Stack vs Queue         
            ------------------------------------------------------------------------------------------*/

            stopWatch.Start();
            stack.Pop();
            stopWatch.Stop();
            Console.WriteLine("\nRemove Elements - RunTime for Stack - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            queue.Dequeue();
            stopWatch.Stop();
            Console.WriteLine("Remove Elements - RunTime for Queue - " + stopWatch.Elapsed);
            stopWatch.Reset();

            /*-----------------------------------------------------------------------------------------
                                     ADD ELEMENT  -- HashTable vs Dictionary            
            ------------------------------------------------------------------------------------------*/

            stopWatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                hashTable.Add(i, new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("\nAdd Elements - RunTime for HashTable - " + stopWatch.Elapsed);
            stopWatch.Reset();


            stopWatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                dictionary.Add(i, new Circle((rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1), (rand.Next(20) + rand.Next(20) * 0.1)));
            }
            stopWatch.Stop();
            Console.WriteLine("Add Elements - RunTime for Dictionary - " + stopWatch.Elapsed);
            stopWatch.Reset();

            /*-----------------------------------------------------------------------------------------
                                  SEARCH ELEMENT --  HashTable vs Dictionary         
            ------------------------------------------------------------------------------------------*/

            stopWatch.Start();
            result = (Circle)hashTable[500000];
            stopWatch.Stop();
            Console.WriteLine("\nSearch Elements - RunTime for Hashtable - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            result = (Circle)dictionary[500000];
            stopWatch.Stop();
            Console.WriteLine("Search Elements - RunTime for Dictionary - " + stopWatch.Elapsed);
            stopWatch.Reset();

            /*-----------------------------------------------------------------------------------------
                                      REMOVE ELEMENT  -- HashTable vs Dictionary            
            ------------------------------------------------------------------------------------------*/
            stopWatch.Start();
            hashTable.Remove(500000);
            stopWatch.Stop();
            Console.WriteLine("\nRemove Elements - RunTime for HashTable - " + stopWatch.Elapsed);
            stopWatch.Reset();

            stopWatch.Start();
            dictionary.Remove(500000);
            stopWatch.Stop();
            Console.WriteLine("Remove Elements - RunTime for Dictionary - " + stopWatch.Elapsed);
            stopWatch.Reset();

            Console.ReadLine();
        }
    }
}
