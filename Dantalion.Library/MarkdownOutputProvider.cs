namespace Dantalion.Library;

public class MarkdownOutputProvider : IOutputProvider
{
    private readonly TextWriter _writer;

    public MarkdownOutputProvider(TextWriter writer)
    {
        _writer = writer;
    }
    
    public void OutputName(string name)
    {
        MarkdownGenerationException.ThrowIfEmpty(name, "Name");
        
        WriteWithSurroundingEmptyLines($"# {name}");
    }

    public void OutputAbout(string about)
    {
        MarkdownGenerationException.ThrowIfEmpty(about, "About text");
        
        WriteWithSurroundingEmptyLines($"_{about}_");
    }

    public void OutputChapterName(string chapterName)
    {
        MarkdownGenerationException.ThrowIfEmpty(chapterName, "Chapter name");
        
        _writer.WriteLine();
        WriteWithSurroundingEmptyLines($"## {chapterName}");
    }

    public void OutputSubChapterName(string chapterName, uint chapterLevel)
    {
        const string fieldName = "Subchapter name";
        MarkdownGenerationException.ThrowIfEmpty(chapterName, fieldName);
        MarkdownGenerationException.ThrowIfLowerBoundExceeded(chapterLevel, 1, fieldName);
        MarkdownGenerationException.ThrowIfHigherBoundExceeded(chapterLevel, 4, fieldName);

        var additionalLevelSigns = Repeat("#", chapterLevel);
        
        _writer.WriteLine();
        WriteWithSurroundingEmptyLines($"##{additionalLevelSigns} {chapterName}");
    }

    public void OutputParagraph(string paragraph)
    {
        MarkdownGenerationException.ThrowIfEmpty(paragraph, "Paragraph");
        
        WriteWithSurroundingEmptyLines(paragraph);
    }

    public void OutputHighlightedParagraph(string paragraph)
    {
        MarkdownGenerationException.ThrowIfEmpty(paragraph, "Highlighted paragraph");
        
        WriteWithSurroundingEmptyLines($"**{paragraph}**");
    }

    public void OutputLink(string linkUrl, string alias = "")
    {
        MarkdownGenerationException.ThrowIfEmpty(linkUrl, "Link URL");

        WriteWithSurroundingEmptyLines(
            string.IsNullOrEmpty(alias)
                ? $"<{linkUrl}>"
                : $"[{alias}]({linkUrl})");
    }

    public void OutputBulletPoint(string text, uint nestingLevel = 0)
    {
        MarkdownGenerationException.ThrowIfEmpty(text, "Bullet point text");

        var indentation = Indentation(nestingLevel);
        WriteWithSurroundingEmptyLines($"{indentation}* {text}");
    }

    public void OutputNumberedPoint(string text, uint number, uint nestingLevel = 0)
    {
        const string fieldName = "Numbered point text";
        MarkdownGenerationException.ThrowIfEmpty(text, fieldName);
        MarkdownGenerationException.ThrowIfLowerBoundExceeded(number, 1, fieldName);
        
        var indentation = Indentation(nestingLevel);
        WriteWithSurroundingEmptyLines($"{indentation}{number}. {text}");
    }

    public void OutputThankYou(string thankYouText)
    {
        MarkdownGenerationException.ThrowIfEmpty(thankYouText, "Thank you text");
        
        WriteWithSurroundingEmptyLines($"## {thankYouText}");
    }

    private void WriteWithSurroundingEmptyLines(string text)
    {
        _writer.WriteLine();
        _writer.WriteLine(text);
        _writer.WriteLine();
    }

    private static string Indentation(uint level) => Repeat("    ", level);

    private static string Repeat(string value, uint times)
        => string.Join("", Enumerable.Repeat(value, (int)times));
}