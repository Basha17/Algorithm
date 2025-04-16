using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Dijkstra
    {
        private readonly int temp = 1;
        private readonly int permenant = 2;
        private readonly int nil = -1;
        private readonly int infinity = 999;

        int[,] adj;
        Vertex[] vertex;
        int n,e;

        public Dijkstra() {
            adj = new int[30, 30];
            vertex = new Vertex[30];
        }

        public void TryDijkstra(int source)
        {
            this.InsertVertex(0);
            this.InsertVertex(1);
            this.InsertVertex(2);
            this.InsertVertex(3);
            this.InsertVertex(4);
            this.InsertVertex(5);
            this.InsertVertex(6);
            this.InsertVertex(7);
            this.InsertVertex(8);

            InsertEdge(0, 3, 2);
            InsertEdge(0, 1, 5);
            InsertEdge(0, 4, 8);
            InsertEdge(1, 4, 2);
            InsertEdge(2, 1, 3);
            InsertEdge(2, 5, 4);
            InsertEdge(3, 4, 7);
            InsertEdge(3, 6, 8);
            InsertEdge(4, 5, 9);
            InsertEdge(4, 7, 4);
            InsertEdge(5, 1, 6);
            InsertEdge(6, 7, 9);
            InsertEdge(7, 3, 5);
            InsertEdge(7, 5, 3);
            InsertEdge(7, 8, 5);
            InsertEdge(8, 5, 3);

            FindPaths(source);
        }

        private void FindPaths(int source)
        {
            int s = GetIndex(source);

            Process(s);

            Console.WriteLine("Source Vertex : " + source + "\n");

            for (int v = 0; v < n; v++)
            {
                Console.WriteLine("Destination Vertex : " + vertex[v].Id);
                if (vertex[v].PathLength == infinity)
                    Console.WriteLine("There is no path from " + source + " to vertex " + vertex[v].Id + "\n");
                else
                    FindPath(s, v);
            }
        }

        private void Process(int s)
        {
            int v, c;
            for (v = 0; v < n; v++)
            {
                vertex[v].Status = temp;
                vertex[v].Predecessor = nil;
                vertex[v].PathLength = infinity;
            }
            vertex[s].PathLength = 0;

            while (true)
            {
                c = MinPathVertex();

                if(c == nil)
                    return;
                vertex[c].Status = permenant;
                for (v = 0; v < n; v++)
                {
                    if (IsAdjacent(c, v) && vertex[v].Status == temp)
                        if (vertex[c].PathLength + adj[c, v] < vertex[v].PathLength)
                        {
                            vertex[v].Predecessor = c;
                            vertex[v].PathLength = vertex[c].PathLength + adj[c, v];
                        }
                }
            }
        }

        private int MinPathVertex()
        {
            int min = infinity;
            int x = nil;
            for (int v = 0; v < n; v++)
            {
                if (vertex[v].Status == temp && vertex[v].PathLength < min)
                {
                    min = vertex[v].PathLength;
                    x = v;
                }
            }
            return x;
        }

        private bool IsAdjacent(int u, int v)
        {
            return (adj[u, v] != 0);
        }

        private int GetIndex(int s)
        {
            for (int i = 0; i < n; i++)
                if (s.Equals(vertex[i].Id))
                    return i;
            throw new System.InvalidOperationException("Invalid Vertex");
        }

        private void InsertVertex(int name)
        {
            vertex[n++] = new Vertex(name);
        }

        public void InsertEdge(int s1, int s2, int wt)
        {
            int u = GetIndex(s1);
            int v = GetIndex(s2);
            if (u == v)
                throw new System.InvalidOperationException("Not a valid edge");

            if (adj[u, v] != 0)
                Console.Write("Edge already present");
            else
            {
                adj[u, v] = wt;
                e++;
            }
        }

        private void FindPath(int s, int v)
        {
            int i, u;
            int[] path = new int[n];
            int sd = 0;
            int count = 0;

            while (v != s)
            {
                count++;
                path[count] = v;
                u = vertex[v].Predecessor;
                sd += adj[u, v];
                v = u;
            }
            count++;
            path[count] = s;

            Console.Write("Shortest Path is : ");
            for (i = count; i >= 1; i--)
                Console.Write(path[i] + " ");
            Console.WriteLine("\n Shortest distance is : " + sd + "\n");
        }

    }

    public class Vertex
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int Predecessor { get; set; }
        public int PathLength { get; set; }

        public Vertex(int Id)
        {
            this.Id = Id;
        }
    }

 }
