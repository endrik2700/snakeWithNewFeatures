using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Point
{
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    class Snake : Figure
    {
        public Direction Direction;
        public Color color;
        public string name;

        public Snake(MyPoint tail, int length, Color _color,  Direction _direction) //added a new propery named class
        {
            Direction = _direction;
            color = _color;
            
            for (int i = 0; i < length; i++)
            {
                MyPoint newPoint = new MyPoint(tail);
                newPoint.MovePoint(i, Direction);
                pointList.Add(newPoint);
            }
            
        }
        // naming the snake by user
        public String nameSnake () {

            Console.WriteLine("What's the snake's name?");
            string snakeName = Console.ReadLine();
            name = snakeName;
            return name;
        }

        public void MoveSnake()
        {
            MyPoint tail = pointList.First();
            pointList.Remove(tail);
            MyPoint head = GetNextPoint();
            pointList.Add(head);
            tail.Clear();
            head.Draw();
        }

        public MyPoint GetNextPoint()
        {
            MyPoint head = pointList.Last();
            MyPoint nextPoint = new MyPoint(head);
            nextPoint.MovePoint(1, Direction);
            return nextPoint;
        }

        public void ReadUserKey(ConsoleKey key)
        {
            if(key == ConsoleKey.LeftArrow)
            {
                Direction = Direction.LEFT;
            }
            else if(key == ConsoleKey.RightArrow)
            {
                Direction = Direction.RIGHT;
            } 
            else if(key == ConsoleKey.UpArrow)
            {
                Direction = Direction.UP;
            } 
            else if(key == ConsoleKey.DownArrow)
            {
                Direction = Direction.DOWN;
            }
        }

        internal bool Eat(MyPoint food)
        {
            MyPoint head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.symbol = head.symbol;
                pointList.Add(food);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
