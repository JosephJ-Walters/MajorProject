using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorProject
{
    internal class Stack
    {
        private int[][] _stackList;
        private int _head = -1;

        public int[][] StackList { get => _stackList; set => _stackList = value; }
        public int Head { get => _head; set => _head = value; }

        public Stack(int h, int w)
        {
            StackList = new int[2][];
        }

        public void Push(Cell cell)
        {
            StackList[++Head] = cell.Coord;
        }
        public void Pop()
        {
            Head--;
        }

        public int[] Read()
        {
            return StackList[Head];
        }

    }

}
