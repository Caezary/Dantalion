namespace Dantalion.Library;

public interface IOutputProvider
{
    void OutputName(string name);
    void OutputAbout(string about);
    void OutputChapterName(string chapterName);
    void OutputSubChapterName(string chapterName, uint chapterLevel);
    void OutputParagraph(string paragraph);
    void OutputHighlightedParagraph(string paragraph);
    void OutputLink(string linkUrl, string alias = "");
    void OutputBulletPoint(string text, uint nestingLevel = 0);
    void OutputNumberedPoint(string text, uint number, uint nestingLevel = 0);
    void OutputThankYou(string thankYouText);
}