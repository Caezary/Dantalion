namespace Dantalion.Library;

public static class Presentation
{
    private const string ThankYouDefaultText = "Thank You!";
    
    private static readonly LinkedList<ChapterDescriptor> Chapters = new();
    private static IOutputProvider _outputProvider = new MarkdownOutputProvider(Console.Out);
    
    private static string? Name { get; set; }
    
    private static string? AboutText { get; set; }
    
    private static string? ThankYouText { get; set; }

    public static void Title(string name) => Name = name;

    public static void About(string aboutText) => AboutText = aboutText;

    public static void Chapter(string name, Action<PresentationContext> implementation)
        => Chapters.AddLast(new ChapterDescriptor(name, implementation));

    public static void ThankYou(string thankYouText = ThankYouDefaultText)
    {
        ThankYouText = thankYouText;
        RunPresentation();
    }

    private static void RunPresentation()
    {
        PresentName();
        PresentAboutText();
        PresentChapters();
        PresentThankYou();
    }

    private static void PresentName()
    {
        if (!string.IsNullOrEmpty(Name))
        {
            _outputProvider.OutputName(Name);
        }
    }

    private static void PresentAboutText()
    {
        if (!string.IsNullOrEmpty(AboutText))
        {
            _outputProvider.OutputAbout(AboutText);
        }
    }

    private static void PresentChapters()
    {
        foreach (var (chapterName, implementation) in Chapters)
        {
            var context = new PresentationContext(_outputProvider);

            _outputProvider.OutputChapterName(chapterName);
            implementation(context);
        }
    }

    private static void PresentThankYou()
    {
        if (!string.IsNullOrEmpty(ThankYouText))
        {
            _outputProvider.OutputThankYou(ThankYouText);
        }
    }

    private record ChapterDescriptor(string Name, Action<PresentationContext> Implementation);
}