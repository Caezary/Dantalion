namespace Dantalion.Library;

public record PresentationContext(IOutputProvider Output, uint ChapterLevel)
{
    private uint _numberedPointCount = 0;
    
    public void Paragraph(string paragraph)
    {
        ResetNumberedPointCount();
        Output.OutputParagraph(paragraph);
    }

    public void HighlightedParagraph(string paragraph)
    {
        ResetNumberedPointCount();
        Output.OutputHighlightedParagraph(paragraph);
    }

    public void Link(string linkUrl, string alias = "")
    {
        ResetNumberedPointCount();
        Output.OutputLink(linkUrl, alias);
    }

    public void BulletPoint(string text, Action<PointContext>? innerPoints = null)
    {
        ResetNumberedPointCount();
        Output.OutputBulletPoint(text);
        if (innerPoints == null)
        {
            return;
        }

        var pointContext = new PointContext(Output, NestingLevel: 1);
        innerPoints(pointContext);
    }

    public void NumberedPoint(string text, Action<PointContext>? innerPoints = null)
    {
        ++_numberedPointCount;
        Output.OutputNumberedPoint(text, _numberedPointCount);
        if (innerPoints == null)
        {
            return;
        }

        var pointContext = new PointContext(Output, NestingLevel: 1);
        innerPoints(pointContext);
    }

    public void SubChapter(string name, Action<PresentationContext> implementation)
    {
        ResetNumberedPointCount();
        var subChapterLevel = ChapterLevel + 1;
        Output.OutputSubChapterName(name, subChapterLevel);
        var subChapterContext = new PresentationContext(Output, subChapterLevel);
        implementation(subChapterContext);
    }
    
    private void ResetNumberedPointCount() => _numberedPointCount = 0;
}