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
            //Stack stackDisplay = new Stack(des_height, des_width);

            int[] start = { 5, 5 };

            //stack1.Push(maze1.CellList[maze1.CurrentLocation[0], maze1.CurrentLocation[1]]);
            //stackDisplay.Push(maze1.CellList[maze1.CurrentLocation[0], maze1.CurrentLocation[1]]);
            maze1.Pathfind(start);
            maze1.Render(des_height, des_width);
            Console.ReadKey();
        }
    }

}
