using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Abstracts
{
    public class Maze
    {
        private bool[] _visited;
        private readonly Grid _grid;
        private static Vector2[] MOVE =
        [
            new Vector2(0, -1),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(-1, 0)
        ];

        public Maze(Grid grid)
        {
            _grid = grid;
            _visited = new bool[grid.Width * _grid.Height];
        }

        public void Prim()
        {
            //
        }
        
        private List<Direction> UnvisitedAdjacents(int iterator)
        {
            Cell cell = At(iterator);
            List<Direction> list = new List<Direction>();
            bool[] array =
            [
                cell.Can(Direction.Up) ? true : false,
                cell.Can(Direction.Right) ? true : false,
                cell.Can(Direction.Down) ? true : false,
                cell.Can(Direction.Left) ? true : false
            ];
            if (array[0] && !_visited[iterator - _grid.Width]) list.Add(Direction.Up);
            if (array[1] && !_visited[iterator + 1]) list.Add(Direction.Right);
            if (array[2] && !_visited[iterator + _grid.Width]) list.Add(Direction.Down);
            if (array[3] && !_visited[iterator - 1]) list.Add(Direction.Left);
            return list;
        }
        
        private Cell At(int numeric)
        {
            int x = numeric % _grid.Height;
            int y = numeric / _grid.Height;
            return _grid.Get(x, y);
        }

        private int Iterator(int x, int y)
        {
            return (x * _grid.Width) + y;
        }

        public void check()
        {
            int w = 0;
            int h = 0;
            for(int i = 0; i < _grid.Height; i++)
            {
                w = i;
                Console.WriteLine($"i:{i}");
                for(int j = 0; j < _grid.Width; j++)
                {
                    h = j;
                    int ij = Iterator(i, j);
                    int checkHor = ij / _grid.Width;
                    int checkVer = ij % _grid.Width;
                    int wh = Iterator(w, h);
                    int checkWid = wh / _grid.Width;
                    int checkHei = wh % _grid.Width;
                    Console.WriteLine($"N:{ij}");
                }
            }
        }
    }
}