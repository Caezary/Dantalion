namespace Dantalion.Library;

public class ConsoleOutputProvider : IOutputProvider
{
    public void OutputName(string name)
    {
        System.Console.Title = name;
        System.Console.WriteLine(name);
        System.Console.WriteLine();
    }

    public void OutputAbout(string about)
    {
        System.Console.WriteLine(about);
        System.Console.WriteLine();
    }

    public void OutputChapterName(string chapterName)
    {
        System.Console.WriteLine(chapterName);
        System.Console.WriteLine();
    }

    public void OutputSubChapterName(string chapterName, uint chapterLevel)
    {
        throw new NotImplementedException();
    }

    public void OutputParagraph(string paragraph)
    {
        System.Console.WriteLine(paragraph);
        System.Console.WriteLine();
    }

    public void OutputHighlightedParagraph(string paragraph)
    {
        throw new NotImplementedException();
    }

    public void OutputLink(string linkUrl, string alias = "")
    {
        throw new NotImplementedException();
    }

    public void OutputBulletPoint(string text, uint nestingLevel = 0)
    {
        throw new NotImplementedException();
    }

    public void OutputNumberedPoint(string text, uint number, uint nestingLevel = 0)
    {
        throw new NotImplementedException();
    }

    public void OutputThankYou(string thankYouText)
    {
        System.Console.WriteLine(thankYouText);
        System.Console.WriteLine();
    }
}