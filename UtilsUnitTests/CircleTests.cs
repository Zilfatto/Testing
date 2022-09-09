using Utils.Shapes;

namespace UtilsUnitTests;

[TestFixture]
public class CircleTests
{
    [Test]
    public void CalculateArea_CircleHasValidRadius_ShouldCalculateArea()
    {
        const int radius = 3;
        
        const double correctArea = Math.PI * radius * radius;
        
        var circle = new Circle(radius);

        var calculatedArea = circle.CalculateArea();

        Assert.That(calculatedArea, Is.EqualTo(correctArea));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void CalculateArea_CircleHasInvalidRadius_ShouldThrowAnException(int radius)
    {
        var circle = new Circle(radius);

        Assert.Throws<ArgumentException>(() => circle.CalculateArea());
    }
}