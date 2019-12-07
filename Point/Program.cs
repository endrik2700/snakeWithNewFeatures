using System;
using System.Threading;
using System.Drawing;

namespace Point
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 55);
            Console.SetBufferSize(100, 55);

            Walls walls = new Walls(80, 25);
            walls.DrawWalls();

            MyPoint tail = new MyPoint(6, 5, '*');
            Snake snake = new Snake(tail, 4, Color.GreenYellow, Direction.RIGHT); //added a color
            snake.DrawFigure();
            
            Console.WriteLine("Try to find some food for the snake"); //telling to search for food

            FoodCatering foodCatered = new FoodCatering(80, 25, '$');
            MyPoint food = foodCatered.CaterFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHitByFigure(snake))
                {
                    
                    for (int i=0; i>=3;i++) { //if the worm hits the wall, 2 beeps
                        Console.Beep();
                        snake.color = Color.Red; //changing the snake's color to red
                        
                    }
                    Console.BackgroundColor = ConsoleColor.DarkMagenta; //changing the console color on impact
                    Console.WriteLine($" {snake.name} hit the wall");
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCatered.CaterFood();
                    food.Draw();
                    Console.Beep(); // if the worm eats, console makes 1 beep
                    Random fiftyPercent = new System.Random();
                    //bool like; 
                    fiftyPercent.Next(1, 2);
                    Console.WriteLine(fiftyPercent.Equals(1) ? $"{snake.name} likes the food" : $"{snake.name} hates the food");  //determining wheter the snake likes the food
                        
                   Console.WriteLine( fiftyPercent.Equals(1) ? snake.color = Color.Azure : snake.color = Color.Purple); //changig colors dependent on the reaction to food
                }else
                {
                    snake.MoveSnake();
                }
                Thread.Sleep(300);
                
                if (Console.KeyAvailable)
                { 
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.ReadUserKey(key.Key);
                }                
            }

            WriteGameOver();

            Console.ReadLine();
        }

        public static void WriteGameOver()
        {
            Console.Clear();
            int xOffset = 35;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            ShowMessage("=========", xOffset, yOffset++);
            ShowMessage("GAME OVER", xOffset, yOffset++);
            ShowMessage("=========", xOffset, yOffset++);
        }

        public static void ShowMessage(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}
