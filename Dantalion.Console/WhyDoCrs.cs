using Dantalion.Library;

namespace Dantalion.Console;

public static class WhyDoCrs
{
    public static void Chapter(PresentationContext context)
    {
        context.SubChapter("Do computers dream of quality code?", ComputerDreams);
        context.SubChapter("Who benefits from good code?", WhoBenefits);
        context.SubChapter("What constitutes a good code?", WhatIsGoodCode);
        context.SubChapter("But is it worth the trouble?", Doubts);
        context.SubChapter("CR Trends", Trends);
    }

    private static void ComputerDreams(PresentationContext context)
    {
        context.Paragraph(
            "The machine only needs IL or ASM, it doesn't need OO or functional code, readable or maintainable code.");
    }

    private static void WhoBenefits(PresentationContext context)
    {
        context.Paragraph("Expectations of the business, clients, developers, architects - all is defined by code.");
    }

    private static void WhatIsGoodCode(PresentationContext context)
    {
        context.BulletPoint("Readability");
        context.BulletPoint("Maintainability");
        context.BulletPoint("Correctness");
        context.BulletPoint("Meeting the business needs");
        context.BulletPoint("Extensibility");
        context.BulletPoint("Security");
        context.BulletPoint("Reusability");
        context.BulletPoint("Runtime efficiency");
    }

    private static void Doubts(PresentationContext context)
    {
        context.BulletPoint("Does every developer read every line of code in the system at least three times?");
        context.BulletPoint("the emotional approach");
        context.BulletPoint("how many comments are too much?");
    }

    private static void Trends(PresentationContext context)
    {
        context.BulletPoint("F2F reviews");
        context.BulletPoint("PRs");
        context.BulletPoint("non-blocking CRs");
    }
}