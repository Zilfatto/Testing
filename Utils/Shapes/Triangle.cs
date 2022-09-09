namespace Utils.Shapes;

public sealed record Triangle(int A, int B, int C) : Shape
{
    public override double CalculateArea()
    {
        CheckIfTriangleIsValid();

        if (IsRightAngled())
        {
            var (firstLeg, secondLeg) = GetRightAngledTriangleLegs();

            return (double)firstLeg * secondLeg / 2;
        }

        var semiPerimeter = (double)(A + B + C) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - A) * (semiPerimeter - B) * (semiPerimeter - C));
    }

    private void CheckIfTriangleIsValid()
    {
        // Validation using Triangle Inequality Theorem
        if (A + B <= C || A + C <= B || C + B <= A)
        {
            throw new ArgumentException("Impossible triangle");
        }
    }

    private bool IsRightAngled()
    {
        // A is the longest side (or one of two)
        if (A >= B && A >= C)
        {
            return CheckPythagorasTheorem(A, B, C);
        }

        // B is the longest side (or one of two)
        if (B >= A && B >= C)
        {
            return CheckPythagorasTheorem(B, A, C);
        }

        // C is the longest side then
        return CheckPythagorasTheorem(C, A, B);
    }

    private bool CheckPythagorasTheorem(int longestSide, int secondSide, int thirdSide)
    {
        return longestSide * longestSide == secondSide * secondSide + thirdSide * thirdSide;
    }

    private (int firstLeg, int secondLeg) GetRightAngledTriangleLegs()
    {
        if (A < C && B < C)
        {
            return (A, B);
        }

        if (B < A && C < A)
        {
            return (B, C);
        }

        return (C, A);
    }
}