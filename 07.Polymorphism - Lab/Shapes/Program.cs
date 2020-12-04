using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(4, 5);
            Shape circle = new Circle(4);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(circle.Draw());
        }
    }
}
