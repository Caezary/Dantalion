# Dantalion

A handy library for creating Code as Presentation.
It was born from weariness of seeing code-specific presentations being done in ppt or similar formats, which are not the best tools for this task.
It can output the presentation into Console or a Markdown file (LaTeX is also planned).

The library itself is implemented in `Dantalion.Library`, while a sample usage (and some of the author's thoughts on CRs) can be found in `Dantalion.Console`.

## Example

The following example shows a top-level implementation of a presentation. It can be placed in a `Program.cs` file.

```csharp
using static Dantalion.Library.Presentation;

Title("Example presentation");
About("A brief description");

Chapter("Topic 1", Topic1.Chapter);
Chapter("Topic 2", Topic2.Chapter);
Chapter("Topic 3", Topic3.Chapter);

ThankYou();
```

For clarity, a chapter can be put into a separate static class. The next example shows how a chapter might be implemented.

```csharp
public static class Topic1
{
    public static void Chapter(PresentationContext context)
    {
        context.Paragraph("This is a paragraph.");
        
        context.Link("https://test.com/link", "test link");
        
        context.HighlightedParagraph("This is a highlighted paragraph");
        
        context.NumberedPoint("Numbered point 1");
        context.NumberedPoint("Numbered point 2");
        context.NumberedPoint("Numbered point 3");
    }
}
```

A more comprehensive example can be seen in `Dantalion.Console` project.

## Usage

As such, this library is meant to structure and simplify how the code is presented in your favourite IDE, thus no execution is needed.
Nonetheless, the resulting code can be run - currently this will output a Markdown text to the console containing the presentation contents.
For this to work, the final `ThankYou()` method call is needed to be placed once, at the end as it will run the implemented presentation.
It can be run using the following commands:

```shell
cd [PathToProjectWithPresentation]
dotnet build
dotnet run
```
