using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorProject
{
    internal class Maze
    {
        private int _width;
        private int _height;
        private int _cellSize;
        private Cell[,] _cellList; //Array of all cells
        //private Cell[] _cellArr;
        private int _cellsVisited;
        private int _cellCount;
        

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int Cellsize { get => _cellSize; set => _cellSize = value; }
        //public Cell[] CellArr { get => _cellArr; set => _cellArr = value; }

        public Cell[,] CellList { get => _cellList; set => _cellList = value; }
        public int CellsVisited { get => _cellsVisited; set => _cellsVisited = value; }
        public int CellCount { get => _cellCount; set => _cellCount = value; }

        enum direction
        {
            N,
            E,
            S,
            W
        }
        public Maze(int h, int w)
        {
            Height = h;
            Width = w;
            Cellsize = 4;
            CellsVisited = 0;
            CellCount = 0;
            //CellArr = new Cell[h * w];
            CellList = new Cell[w, h];
            /*for (int y = 0; y < h*w; y++)
            {
                CellArr[y] = new Cell(y%w, y/h);
                //Console.WriteLine(CellArr[y].Coord[0]);
                //Console.WriteLine(CellArr[y].Coord[1]);

            }
            Console.WriteLine(CellArr[3].Coord[0]); */
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    CellList[x, y] = new Cell(x, y);
                }
            }
        }

        public void Pathfind(int[] start)
        {
            while (CellsVisited < CellCount)
            {
                if (start[0] == 0 && start[1] == 0)
                {

                }
            }
        }

    }
}
