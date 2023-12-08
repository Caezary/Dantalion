namespace Dantalion.Library;

public record PresentationContext(IOutputProvider Output)
{
    public void Paragraph(string paragraph) => Output.OutputParagraph(paragraph);
    
    public void HighlightedParagraph(string paragraph) => Output.OutputHighlightedParagraph(paragraph);

    public void Link(string linkUrl, string alias = "") => Output.OutputLink(linkUrl, alias);
    
    public void BulletPoint(string text, Action<PointContext>? innerPoints = null) => throw new NotImplementedException();
    
    public void NumberedPoint(string text, Action<PointContext>? innerPoints = null) => throw new NotImplementedException();

    public void SubChapter(string name, Action<PresentationContext> implementation) =>
        throw new NotImplementedException();
}