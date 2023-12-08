namespace Dantalion.Library;

public record PointContext(IOutputProvider Output)
{
    public void BulletPoint(string text, Action<PointContext>? innerPoints = null) => throw new NotImplementedException();
    
    public void NumberedPoint(string text, Action<PointContext>? innerPoints = null) => throw new NotImplementedException();
}