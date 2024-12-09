using System;
using System.Collections.Generic;
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

        public void Backtrack()
        {
            if(!Array.Exists(_visited, i => i == false))
            {
                return;
            }
            else
            {
                Stack<Cell> stack = new Stack<Cell>();
                Vector2 vposition = InitialPosition();
                Cell first = _grid.Get((int)vposition.X, (int)vposition.Y);
                stack.Push(first);

                while(stack.Count > 0)
                {
                    Cell curr_cell = stack.Peek();
                    int curr_index = (int)curr_cell.Position.X + (int)curr_cell.Position.Y * _grid.Width;

                }
            }
        }

        // private List<Direction> Go(Cell cell)
        // {
        //     int position = (int)cell.Position.X + (int)cell.Position.Y * _grid.Width;
        // }

        private List<Direction> Can(Cell cell)
        {
            List<Direction> adjacents = new List<Direction>();
            bool[] array =
            [
                cell.Can(Direction.Up),
                cell.Can(Direction.Right),
                cell.Can(Direction.Down),
                cell.Can(Direction.Left)
            ];
            if (array[0]) adjacents.Add(Direction.Up);
            if (array[1]) adjacents.Add(Direction.Right);
            if (array[2]) adjacents.Add(Direction.Down);
            if (array[3]) adjacents.Add(Direction.Left);
            return adjacents;
        }

        private Vector2 InitialPosition()
        {
            Random random = new Random();
            int x = random.Next(_grid.Width);
            int y = random.Next(_grid.Height);
            return new Vector2(x, y);
        }
    }
}