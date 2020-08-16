using System;
using System.Collections.Generic;

namespace AlgorythmPrima
{
    class Edge             //класс ребра
    {
        public int v1;
        public int v2;
      public int weight;
        public Edge(int v1, int v2, int weight)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.weight = weight;
        }

    }
    class PriorityComparer : Comparer<Edge>
    {
        public override int Compare(Edge x, Edge y)
        {
            if (object.Equals(x, y)) return 0;
            else if (x.weight == y.weight) { if (x.v1 == y.v1) return x.v2.CompareTo(y.v2); else return x.v1.CompareTo(y.v1); }
            else return y.weight.CompareTo(x.weight);
        }
    }

    class Program
    {
        static bool checkIfItIsUsed(List<int> usedV, Edge notUsedE)
        {
            foreach (int i in usedV) if (i == notUsedE.v1) foreach (int j in usedV) if( j == notUsedE.v2) return false;
            return true;
        }
        static void Main(string[] args)
        {
            
            List<Edge> E = new List<Edge>();   //Все рёбра графа
            List<Edge> MST = new List<Edge>();  //Максимальное покрывающее дерево
            int v = 20;

            var v1v2 = new Edge(1,2,8); E.Add(v1v2); //добавляем рёбра в список
            var v2v3 = new Edge(2,3,2); E.Add(v2v3);
            var v3v4 = new Edge(3,4,13); E.Add(v3v4);
            var v4v5 = new Edge(4,5,13); E.Add(v4v5);
            var v1v5 = new Edge(1,5,10); E.Add(v1v5);
            var v1v15 = new Edge(1,15,11); E.Add(v1v15);
            var v2v11 = new Edge(2,11,9); E.Add(v2v11);
            var v3v12 = new Edge(3,12,1); E.Add(v3v12);
            var v4v13 = new Edge(4,13,16); E.Add(v4v13);
            var v5v14 = new Edge(5,14,5); E.Add(v5v14);
            var v11v16 = new Edge(11,16,8); E.Add(v11v16);
            var v12v16 = new Edge(12,16,10); E.Add(v12v16);
            var v13v16 = new Edge(13,16,5); E.Add(v13v16);
            var v14v16 = new Edge(14,16,2); E.Add(v14v16);
            var v15v16 = new Edge(15,16,4); E.Add(v15v16);
            var v11v15 = new Edge(11,15,1); E.Add(v11v15);
            var v11v12 = new Edge(11,12,3); E.Add(v11v12);
            var v12v13 = new Edge(12,13,6); E.Add(v12v13);
            var v13v14 = new Edge(13,14,1); E.Add(v13v14);
            var v14v15 = new Edge(14,15,12); E.Add(v14v15);
            var v6v16 = new Edge(6,16,10); E.Add(v6v16);
            var v7v16 = new Edge(7,16,13); E.Add(v7v16);
            var v8v16 = new Edge(8,16,7); E.Add(v8v16);
            var v9v16 = new Edge(9,16,14); E.Add(v9v16);
            var v10v16 = new Edge(10,16,15); E.Add(v10v16);
            var v3v6 = new Edge(3,6,4); E.Add(v3v6);
            var v6v18 = new Edge(6,18,6); E.Add(v6v18);
            var v9v18 = new Edge(9,18,5); E.Add(v9v18);
            var v6v11 = new Edge(6,11,7); E.Add(v6v11);
            var v6v12 = new Edge(6,12,12); E.Add(v6v12);
            var v9v11 = new Edge(9,11,6); E.Add(v9v11);
            var v9v15 = new Edge(9,15,11); E.Add(v9v15);
            var v9v17 = new Edge(9,17,4); E.Add(v9v17);
            var v7v17 = new Edge(7,17,7); E.Add(v7v17);
            var v7v15 = new Edge(7,15,3); E.Add(v7v15);
            var v7v14 = new Edge(7,14,13); E.Add(v7v14);
            var v5v7 = new Edge(5,7,1); E.Add(v5v7);
            var v5v20 = new Edge(5,20,13); E.Add(v5v20);
            var v10v14 = new Edge(10,14,4); E.Add(v10v14);
            var v10v13 = new Edge(10,13,11); E.Add(v10v13);
            var v8v13 = new Edge(8,13, 8); E.Add(v8v13);
            var v8v12 = new Edge(8,12,9); E.Add(v8v12);
            var v3v19 = new Edge(3,19,4); E.Add(v3v19);
            var v4v19 = new Edge(4,19,2); E.Add(v4v19);
            var v4v20 = new Edge(4,20,6); E.Add(v4v20);

            
            E.Sort(new PriorityComparer());             //Сортируем по возрастанию
            int i;
            

            List<Edge> notUsedE = new List<Edge>(E);  //Не использованные рёбра

            List<int> usedV = new List<int>();        //букет
            List<int> notUsedV = new List<int>();     // неиспользованные вершины
            
            for (i = 1; i <= v; i++)
            {
                notUsedV.Add(i);
            }
            i = 0;
            while(notUsedV.Count > 0)            //пока не покроем все вершины
            {
                if ((usedV.IndexOf(notUsedE[i].v1) != -1 && usedV.IndexOf(notUsedE[i].v2) == -1) || (usedV.IndexOf(notUsedE[i].v2) != -1 && usedV.IndexOf(notUsedE[i].v1) == -1) || usedV.Count==0) //ищем вершины смежные с вершинами в букете
                {
                    if (checkIfItIsUsed(usedV, notUsedE[i]))
                    {

                        if (usedV.Count == 0)                         //В случае начала добавляем обе вершины
                        {
                            usedV.Add(notUsedE[i].v1);
                            notUsedV.Remove(notUsedE[i].v1);
                            usedV.Add(notUsedE[i].v2);
                            notUsedV.Remove(notUsedE[i].v2);
                            MST.Add(notUsedE[i]);
                            notUsedE.RemoveAt(i);
                            i = 0;
                            continue;
                        }
                        else
                        if (usedV.IndexOf(notUsedE[i].v1) != -1)      // Если первая вершина есть в букете, добавляем вторую
                        {
                            usedV.Add(notUsedE[i].v2);                       //Добавляем вершину в наш букет
                            notUsedV.Remove(notUsedE[i].v2);                    //Удаляем вершину из неиспользованных
                            MST.Add(notUsedE[i]);                       //Добавляем ребро в наше дерево
                            notUsedE.RemoveAt(i);                      //Удаляем ребро из списка неиспользованных
                            i = 0;                                    //Проходим список с неиспользованными рёбрами сначала
                            continue;
                        }
                        else if (usedV.IndexOf(notUsedE[i].v2) != -1)      //Если вторая вершина есть в букете, добавляем первую
                        {
                            usedV.Add(notUsedE[i].v1);
                            notUsedV.Remove(notUsedE[i].v1);

                            MST.Add(notUsedE[i]);
                            notUsedE.RemoveAt(i);
                            i = 0;
                            continue;
                        }
                    }
                }

               
                
                i++;
               
            }

            Console.WriteLine("Максимальное покрывающее дерево");

            int W = 0;
            foreach (Edge element in MST)                               
            {
                W += element.weight;
                Console.WriteLine($"v{element.v1} - v{element.v2}, pow{element.weight}");
            }
            Console.WriteLine($"Power  = {W}");
            Console.ReadKey();
        }
        
    }
}
