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
        //private Cell[,] _cellList;
        private Cell[] _cellArr;
        

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int Cellsize { get => _cellSize; set => _cellSize = value; }
        public Cell[] CellArr { get => _cellArr; set => _cellArr = value; }

        //internal Cell[,] CellList { get => _cellList; set => _cellList = value; }

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
            CellArr = new Cell[h * w];
            for (int y = 0; y < h*w; y++)
            {
                CellArr[y] = new Cell(y%w, y/h);
                //Console.WriteLine(CellArr[y].Coord[0]);
                //Console.WriteLine(CellArr[y].Coord[1]);

            }
            Console.WriteLine(CellArr[3].Coord[0]);

        }

    }
}
