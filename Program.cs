﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dijkstra dijkstra = new Dijkstra();
            dijkstra.TryDijkstra(0);
        }
    }
}
