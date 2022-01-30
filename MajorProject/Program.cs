using System;

namespace MajorProject // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the maze");
            Console.Write("Please enter the height of the maze desired: ");
            int des_height = int.Parse(Console.ReadLine());
            Console.Write("Please enter the width of the maze desired: ");
            int des_width = int.Parse(Console.ReadLine());

            Maze maze1 = new Maze(des_height, des_width);
            Stack stack1 = new Stack(des_height, des_width);
            Stack stackDisplay = new Stack(des_height, des_width);

            /*Testing stack works
                //stack1.Push(maze1.CellArr[3]);
                stack1.Push(maze1.CellList[3,7]);

                //Console.WriteLine(maze1.CellArr[8].Coord[0]);
                Console.WriteLine(stack1.Read()[0] + " , " + stack1.Read()[1]);
                stack1.Push(maze1.CellList[6,7]);
                Console.WriteLine(stack1.Read()[0] + " , " + stack1.Read()[1]);
                stack1.Pop();
                Console.WriteLine(stack1.Read()[0] + " , " + stack1.Read()[1]);
            */

            int[] start = { 0, 0 };
            stack1.Push(maze1.CellList[maze1.CurrentLocation[0], maze1.CurrentLocation[1]]);
            stackDisplay.Push(maze1.CellList[maze1.CurrentLocation[0], maze1.CurrentLocation[1]]);
            maze1.Pathfind(start, stack1, ref stackDisplay);
            Console.WriteLine("Are you ready to see the list of visited cells?");
            Console.ReadKey();
            int test1 = 0;
            while (test1 < des_height*des_width)
            {
                Console.WriteLine(stackDisplay.Read()[0] + " , " + stackDisplay.Read()[1]);
                stackDisplay.Pop();
                test1++;
            } 
        }
    }

}
