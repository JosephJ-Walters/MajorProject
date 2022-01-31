using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct neighboursVisited
{
    public neighboursVisited (int Top, int Bottom, int Left, int Right)
    {
        top = Top;
        bottom = Bottom;
        left = Left;
        right = Right;
    }

    public int count()
    {
        int total = 0;

        if (top != -1)
            total+= top;

        if (bottom != -1)
            total += bottom;

        if (right != -1)
            total += right;

        if (left != -1)
            total += left;

        return total;
    }

    public int top = 0;
    public int bottom = 0; 
    public int left = 0;   
    public int right = 0;





};



namespace MajorProject
{
    internal class Cell
    {
        private bool _visited = false;
        private int[] coord = new int[2];
        private bool[] _walls = { true, true }; //East Wall, South Wall
        private bool[] _available = new bool[4];


        public bool Visited { get => _visited; set => _visited = value; }
        public int[] Coord { get => coord; set => coord = value; }
        public bool[] Walls { get => _walls; set => _walls = value; }
        public bool[] Available { get => _available; set => _available = value; }

        public Cell(int x, int y)
        {
            Coord[0] = x;
            Coord[1] = y;
            for (int i = 0; i < 3; i++)
            {
                Available[i] = false; //Available { N, E, S, W)
            }
        }

        public neighboursVisited returnNeighbours(Cell[,] celllist)
        {
            int topVisited;
            int bottomVisited;
            int leftVisited;
            int rightVisited;
            try
            {
                topVisited = (celllist[Coord[0], Coord[1] - 1].Visited == false) ? 1 : 0;
            }
            catch
            {
                topVisited = -1;
            }

            try
            {
                bottomVisited = (celllist[Coord[0], Coord[1] + 1].Visited == false) ? 1 : 0;
            }
            catch
            {
                bottomVisited = -1;
            }

            try
            {
                leftVisited = (celllist[Coord[0] - 1, Coord[1]].Visited == false) ? 1 : 0;
            }
            catch
            {
                leftVisited = -1;
            }

            try
            {
                rightVisited = (celllist[Coord[0] + 1, Coord[1]].Visited == false) ? 1 : 0;
            }
            catch
            {
                rightVisited = -1;
            }
            return new neighboursVisited(topVisited, bottomVisited, leftVisited, rightVisited);


        }

        public void neighbours(Cell[,] celllist)
        {
            try //North cell check
            {
                if (celllist[Coord[0], Coord[1] - 1].Visited == false) //Checks if North cell is available
                {
                    Available[0] = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No cell north");
            }

            try //South cell check
            {
                if (celllist[Coord[0], Coord[1] + 1].Visited == false) //Checks if South Cell is available
                {
                    Available[2] = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No cell south");
            }

            try //West cell check
            {
                if (celllist[Coord[0] - 1, Coord[1]].Visited == false) //Checks if West cell is available
                {
                    Available[3] = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No cell west");
            }

            try //east cell check
            {
                if (celllist[Coord[0] + 1, Coord[1]].Visited == false) //checks if East cell is available
                {
                    Available[1] = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No cell east");
            }
        }
    }
}
