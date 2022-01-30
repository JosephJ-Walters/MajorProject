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
        private int[] _currentLocation = new int[2];
        private Random rnd = new Random();
        private int _choice;


        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int Cellsize { get => _cellSize; set => _cellSize = value; }
        //public Cell[] CellArr { get => _cellArr; set => _cellArr = value; }

        public Cell[,] CellList { get => _cellList; set => _cellList = value; }
        public int CellsVisited { get => _cellsVisited; set => _cellsVisited = value; }
        public int CellCount { get => _cellCount; set => _cellCount = value; }
        public int[] CurrentLocation { get => _currentLocation; set => _currentLocation = value; }
        public int Choice { get => _choice; set => _choice = value; }
        public Random Rnd { get => rnd; set => rnd = value; }

        public enum Direction : int
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
            CellCount = h * w;
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

        public void Pathfind(int[] start, Stack stack1, ref Stack stackDisplay)
        {
            while (CellsVisited < CellCount)
            {
                CurrentLocation[0] = start[0]; CurrentLocation[1] = start[1];
                stack1.Push(CellList[CurrentLocation[0], CurrentLocation[1]]);
                Nextcell(stack1, ref stackDisplay);
            }
        }

        public void Nextcell(Stack stack1, ref Stack stackDisplay)
        {
            CellList[CurrentLocation[0], CurrentLocation[1]].neighbours(CellList); //Finds unvisited cells around itself
            Console.WriteLine(CurrentLocation[0] + " , " + CurrentLocation[1]);
            CellsVisited++;
            int num = 0;
            foreach (bool item in CellList[CurrentLocation[0], CurrentLocation[1]].Available) //Finds number of unvisited cells around current cell
            {
                if (item == true)
                {
                    num++;
                }
            }

            Choice = Rnd.Next(num); //The (N-1) available cell will be the next visible,
            int index = 0; //The current index of the array
            int numpos = 0; //The (N-1) 'true' index visited

            if (num == 0) //If no cells are available then pop the stack and read the new top value until cell is available
            {
                stack1.Pop(); //Removes top cell location from stack
                CurrentLocation = stack1.Read();
                Nextcell(stack1, ref stackDisplay);
            }
            else
            {
                while (CellList[CurrentLocation[0], CurrentLocation[1]].Visited == false) //Run until current cell is set to visited, visited = true when next cell found
                {

                    if (CellList[CurrentLocation[0], CurrentLocation[1]].Available[index] == true) 
                    {
                        if (numpos == Choice)
                        {
                            switch (index) //Index of array tells us the direction
                            {
                                case (int)Direction.N: //North
                                    CellList[CurrentLocation[0], CurrentLocation[1] - 1].Walls[1] = false; //Breaks south wall of cell above
                                    CellList[CurrentLocation[0], CurrentLocation[1]].Visited = true;
                                    //CurrentLocation = { CurrentLocation[0], CurrentLocation[1] - 1 }; //Updates location
                                    CurrentLocation[1] = CurrentLocation[1] - 1;
                                    stack1.Push(CellList[CurrentLocation[0], CurrentLocation[1]]); //Pushes new location to stack
                                    stackDisplay.Push(CellList[CurrentLocation[0], CurrentLocation[1]]); //Stores next cell visitied in order
                                    Nextcell(stack1, ref stackDisplay);
                                    break;

                                case (int)Direction.E: //East
                                    CellList[CurrentLocation[0], CurrentLocation[1]].Walls[0] = false; //Breaks east wall of current cell
                                    CellList[CurrentLocation[0], CurrentLocation[1]].Visited = true;
                                    //CurrentLocation = { CurrentLocation[0] + 1, CurrentLocation[1] }; //Updates location
                                    CurrentLocation[0] = CurrentLocation[0] + 1;
                                    stack1.Push(CellList[CurrentLocation[0], CurrentLocation[1]]); //Pushes new location to stack
                                    stackDisplay.Push(CellList[CurrentLocation[0], CurrentLocation[1]]); //Stores next cell visitied in order
                                    Nextcell(stack1, ref stackDisplay);
                                    break;

                                case (int)Direction.S: //South
                                    CellList[CurrentLocation[0], CurrentLocation[1]].Walls[1] = false; //Breaks south wall of current cell
                                    CellList[CurrentLocation[0], CurrentLocation[1]].Visited = true;
                                    //CurrentLocation = { CurrentLocation[0], CurrentLocation[1] + 1 }; //Updates location
                                    CurrentLocation[1] = CurrentLocation[1] + 1;
                                    stack1.Push(CellList[CurrentLocation[0], CurrentLocation[1]]); //Pushes new location to stack
                                    stackDisplay.Push(CellList[CurrentLocation[0], CurrentLocation[1]]); //Stores next cell visitied in order
                                    Nextcell(stack1, ref stackDisplay);
                                    break;

                                case (int)Direction.W: //West
                                    CellList[CurrentLocation[0] - 1, CurrentLocation[1]].Walls[0] = false; //Breaks west wall of cell to the right
                                    CellList[CurrentLocation[0], CurrentLocation[1]].Visited = true;
                                    //CurrentLocation = { CurrentLocation[0] - 1, CurrentLocation[1] }; //Updates location
                                    CurrentLocation[0] = CurrentLocation[0] - 1;
                                    stack1.Push(CellList[CurrentLocation[0], CurrentLocation[1]]); //Pushes new location to stack
                                    stackDisplay.Push(CellList[CurrentLocation[0], CurrentLocation[1]]); //Stores next cell visitied in order
                                    Nextcell(stack1, ref stackDisplay);
                                    break;

                                default:
                                    break;
                            }
                        }
                        else
                        {
                            numpos++;
                            index++;
                        }
                    }
                    else
                    {
                        index++;
                    }
                }
            }
            //CellList[CurrentLocation[0], CurrentLocation[1]].Available[choice]
        }
    }
}
