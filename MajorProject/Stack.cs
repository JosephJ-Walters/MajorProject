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
            StackList = new int[h*w][];
        }

        public void Push(Cell cell)
        {
            Head++;
            StackList[Head] = cell.Coord;
        }
        public void Pop()
        {
            Head--;
            Console.WriteLine("POPPED!");
        }

        public int[] Peek()
        {
            return StackList[Head];
        }

    }

}
