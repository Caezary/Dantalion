using Dantalion.Library;

namespace Dantalion.Console;

public static class Introduction
{
    public static void Chapter(PresentationContext context)
    {
        context.Paragraph("This presentation is available on github:");
        context.Link("https://github.com/Caezary/Dantalion", "Dantalion");
        
        context.Paragraph("Created in code for ease of presentation.");
        
        context.HighlightedParagraph(
            "This is a highly opinionated presentation with made-up philosophy and some amount of controversy ;)");
    }
}