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

            //Testing stack works
            stack1.Push(maze1.CellArr[3]);
            //Console.WriteLine(maze1.CellArr[8].Coord[0]);
            Console.WriteLine(stack1.Read()[0] + " , " + stack1.Read()[1]);
            stack1.Push(maze1.CellArr[67]);
            Console.WriteLine(stack1.Read()[0] + " , " + stack1.Read()[1]);
            stack1.Pop();
            Console.WriteLine(stack1.Read()[0] + " , " + stack1.Read()[1]);

        }
    }

}