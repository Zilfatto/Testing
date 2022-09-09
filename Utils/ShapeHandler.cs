using Utils.Shapes;

namespace Utils;

public static class ShapeHandler
{
    public static void PrintOutShapeAreas(IEnumerable<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name} has an area of {shape.CalculateArea()} units square");
        }
    }
}