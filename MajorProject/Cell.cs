using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
