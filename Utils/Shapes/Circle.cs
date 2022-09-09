namespace Utils.Shapes;

public sealed record Circle(int Radius) : Shape
{
    public override double CalculateArea()
    {
        CheckRadius();
        
        return Math.PI * Radius * Radius;
    }

    private void CheckRadius()
    {
        if (Radius <= 0)
        {
            throw new ArgumentException("Invalid radius");
        }
    }
}