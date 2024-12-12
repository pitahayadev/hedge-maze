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

        public void Backtrack()
        {
            if(!Array.Exists(_visited, i => i == false))
            {
                return;
            }
            else
            {
                Stack<Cell> stack = new Stack<Cell>();
                int x = Random.Shared.Next(_grid.Width);
                int y = Random.Shared.Next(_grid.Height);
                Cell first = _grid.Get(x, y);
                stack.Push(first);
                
                while(stack.Count > 0)
                {
                    Cell curr_cell = stack.Peek();
                    int curr_index = Iterator(curr_cell);
                    List<Direction> availables = UnvisitedAdjacents(curr_cell, curr_index);
                    Direction direction;
                    if (availables.Count == 0)
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (availables.Count == 1)
                    {
                        direction = availables.ElementAt(0);
                    }
                    else
                    {
                        int selected = Random.Shared.Next(availables.Count);
                        direction = availables.ElementAt(selected);
                    }

                    Vector2 next_pos = curr_cell.Position + MOVE[(int)direction];
                    Cell next_cell = _grid.Get((int)next_pos.X, (int)next_pos.Y);

                    curr_cell.Open(direction);
                    Direction opposite = (Direction)(((int)direction + 2) % 4);
                    next_cell.Open(opposite);

                    stack.Push(next_cell);
                }
            }
        }
        
        private List<Direction> UnvisitedAdjacents(Cell cell, int iterator)
        {
            List<Direction> unvisited = new List<Direction>();
            bool[] adjacents =
            [
                cell.Can(Direction.Up),
                cell.Can(Direction.Right),
                cell.Can(Direction.Down),
                cell.Can(Direction.Left)
            ];
            if (adjacents[0] && !_visited[iterator - _grid.Width]) unvisited.Add(Direction.Up);
            if (adjacents[1] && !_visited[iterator + 1]) unvisited.Add(Direction.Right);
            if (adjacents[2] && !_visited[iterator + _grid.Width]) unvisited.Add(Direction.Down);
            if (adjacents[3] && !_visited[iterator - 1]) unvisited.Add(Direction.Left);
            return unvisited;
        }

        private int Iterator(Cell cell)
        {
            return (int)cell.Position.X / Cell.WIDTH + (int)cell.Position.Y / Cell.HEIGHT * _grid.Width;
        }
    }
}