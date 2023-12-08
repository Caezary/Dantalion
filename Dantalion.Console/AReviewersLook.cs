using Dantalion.Library;

namespace Dantalion.Console;

public static class AReviewersLook
{
    public static void Chapter(PresentationContext context)
    {
        context.SubChapter("Some assumptions", Assumptions);
        context.SubChapter("The three readings of code", ReviewerReads);
        context.SubChapter("The Beautiful Controversy PT1", Controversy1);
        context.SubChapter("The Beautiful Controversy PT2", Controversy2);
        context.SubChapter("To test or not to test?", AboutUnitTests);
        context.SubChapter("Mechanisms that will raise the reviewer's suspicion ;)", MechanismRedFlags);
        context.SubChapter("Exceptions that will raise the reviewer's suspicion ;)", ExceptionRedFlags);
    }

    private static void Assumptions(PresentationContext context)
    {
        context.Paragraph(
            "Shared code ownership - everybody is responsible for the state of the code and no one developer owns it.");
        
        context.Paragraph(
            """
            Every developer should know the lingua franca - i.e.
            language syntax, SOLID, design patterns, most common libraries etc.
            """);
        
        context.Paragraph("A coding standard is present ;)");
    }

    private static void ReviewerReads(PresentationContext context)
    {
        context.NumberedPoint("Is the code understandable?");
        context.NumberedPoint("Is the code correct?");
        context.NumberedPoint("Is the code well designed?");
    }

    private static void Controversy1(PresentationContext context)
    {
        context.BulletPoint("the reviewer reads the code under review a lot");
        
        context.BulletPoint("the more complicated to code is, the harder it is to review it");
        
        context.BulletPoint(
            "if convoluted code also has comments, is it really better? Think about:",
            inner =>
            {
                inner.BulletPoint("Correctness");
                inner.BulletPoint("Maintainability");
                inner.BulletPoint("Readability");
            });
        
        context.BulletPoint(
            "because of this, the reviewer (and all other developers) will probably skip the comments");
    }

    private static void Controversy2(PresentationContext context)
    {
        context.Paragraph("How are we supposed to write code like that?");
        
        context.BulletPoint("simplify the hard-to-understand parts");
        context.BulletPoint("do not do preemptive optimisation");
        context.BulletPoint("make the code SCREAM what it does :)");
        context.BulletPoint("what about documentation? - there is a mechanism for that...");
    }

    private static void AboutUnitTests(PresentationContext context)
    {
        context.SubChapter("What are not Unit Tests?", WhatAreNotUnitTests);
        context.SubChapter("What are Unit Tests?", WhatAreUnitTests);
    }

    private static void WhatAreNotUnitTests(PresentationContext context)
    {
        context.BulletPoint("Integration Tests");
        context.BulletPoint("Automated Acceptance Tests");
        context.BulletPoint("Test Scenarios");
        context.BulletPoint("Tests - not a mistake");
    }

    private static void WhatAreUnitTests(PresentationContext context)
    {
        context.BulletPoint("Proofs");
        context.BulletPoint("Specs");
        context.BulletPoint("Documentation");
    }

    private static void MechanismRedFlags(PresentationContext context)
    {
        context.NumberedPoint("Reflection");
        context.NumberedPoint("dynamic");
        context.NumberedPoint("System.Linq.Expressions");
        context.NumberedPoint("Roslyn code generators");
        context.NumberedPoint("runtime compile");
        context.NumberedPoint("emit");
        context.NumberedPoint("other exotic parts of .NET");
    }

    private static void ExceptionRedFlags(PresentationContext context)
    {
        context.NumberedPoint("Exception");
        context.NumberedPoint("InvalidOperationException");
        context.NumberedPoint("NotImplementedException");
    }
}