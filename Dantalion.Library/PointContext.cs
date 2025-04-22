namespace Dantalion.Library;

public record PointContext(IOutputProvider Output, uint NestingLevel)
{
    private uint _numberedPointCount = 0;

    public void BulletPoint(string text, Action<PointContext>? innerPoints = null)
    {
        ResetNumberedPointCount();
        Output.OutputBulletPoint(text, NestingLevel);
        if (innerPoints == null)
        {
            return;
        }

        var nextNestingLevel = NestingLevel + 1;
        var pointContext = new PointContext(Output, nextNestingLevel);
        innerPoints(pointContext);
    }

    public void NumberedPoint(string text, Action<PointContext>? innerPoints = null)
    {
        ++_numberedPointCount;
        Output.OutputNumberedPoint(text, _numberedPointCount, NestingLevel);
        if (innerPoints == null)
        {
            return;
        }

        var nextNestingLevel = NestingLevel + 1;
        var pointContext = new PointContext(Output, nextNestingLevel);
        innerPoints(pointContext);
    }

    private void ResetNumberedPointCount() => _numberedPointCount = 0;
}