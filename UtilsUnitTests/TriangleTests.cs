using Utils.Shapes;

namespace UtilsUnitTests;

[TestFixture]
public class TriangleTests
{
    [Test]
    public void CalculateArea_TriangleHasValidLegs_ShouldCalculateArea()
    {
        const int a = 2, b = 3, c = 4;

        const double semiPerimeter = (double)(a + b + c) / 2;

        var correctArea = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

        var triangle = new Triangle(a, b, c);

        var calculatedArea = triangle.CalculateArea();
        
        Assert.That(calculatedArea, Is.EqualTo(correctArea));
    }
    
    [Test]
    public void CalculateArea_TriangleHasValidLegsAndIsRightAngled_ShouldCalculateArea()
    {
        const int a = 3, b = 4, c = 5;

        const double semiPerimeter = (double)(a + b + c) / 2;

        var correctArea = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

        var triangle = new Triangle(a, b, c);

        var calculatedArea = triangle.CalculateArea();
        
        Assert.That(calculatedArea, Is.EqualTo(correctArea));
    }

    [TestCase(-1, -2, -3)]
    [TestCase(-1, 0 , 1)]
    [TestCase(0, 1, 2)]
    [TestCase(1, 2, 100)]
    public void CalculateArea_TriangleHasInvalidLegs_ShouldThrowAnException(int a , int b , int c)
    {
        var triangle = new Triangle(a, b, c);

        Assert.Throws<ArgumentException>(() => triangle.CalculateArea());
    }
}