namespace Dantalion.Library.Specs;

public class MarkdownOutputProviderSpecs
{
    private readonly TextWriter _writer = Substitute.For<TextWriter>();
    private readonly MarkdownOutputProvider _sut;

    public MarkdownOutputProviderSpecs()
    {
        _sut = new MarkdownOutputProvider(_writer);
    }

    [Fact]
    public void OutputName_EmptyNameGiven_Throws()
    {
        var act = () => _sut.OutputName("");

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Fact]
    public void OutputName_NameGiven_OutputsName()
    {
        _sut.OutputName("Test name");

        _writer.Received().WriteLine("# Test name");
    }

    [Fact]
    public void OutputAbout_EmptyTextGiven_Throws()
    {
        var act = () => _sut.OutputAbout("");

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Fact]
    public void OutputAbout_AboutTextGiven_OutputsFormattedText()
    {
        _sut.OutputAbout("Test about");

        _writer.Received().WriteLine("_Test about_");
    }

    [Fact]
    public void OutputThankYou_EmptyTextGiven_Throws()
    {
        var act = () => _sut.OutputThankYou("");

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Fact]
    public void OutputThankYou_AboutTextGiven_OutputsFormattedText()
    {
        _sut.OutputThankYou("Test thank you");

        _writer.Received().WriteLine("## Test thank you");
    }

    [Fact]
    public void OutputChapterName_EmptyNameGiven_Throws()
    {
        var act = () => _sut.OutputChapterName("");

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Fact]
    public void OutputChapterName_NameGiven_OutputsFormattedText()
    {
        _sut.OutputChapterName("Test chapter name");

        _writer.Received().WriteLine("## Test chapter name");
    }

    [Fact]
    public void OutputSubChapterName_EmptyNameGiven_Throws()
    {
        var act = () => _sut.OutputSubChapterName("", 1);

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(5)]
    [InlineData(10)]
    public void OutputSubChapterName_LevelOutOfBounds_Throws(uint chapterLevel)
    {
        var act = () => _sut.OutputSubChapterName("Test sub chapter name", chapterLevel);

        act.Should().Throw<MarkdownGenerationException>();
    }

    [Fact]
    public void OutputSubChapterName_LevelOneNameGiven_OutputsFormattedText()
    {
        _sut.OutputSubChapterName("Test sub chapter name", 1);

        _writer.Received().WriteLine("### Test sub chapter name");
    }
    
    [Fact]
    public void OutputSubChapterName_LevelTwoNameGiven_OutputsFormattedText()
    {
        _sut.OutputSubChapterName("Test sub chapter name", 2);

        _writer.Received().WriteLine("#### Test sub chapter name");
    }

    [Fact]
    public void OutputSubChapterName_LevelThreeNameGiven_OutputsFormattedText()
    {
        _sut.OutputSubChapterName("Test sub chapter name", 3);

        _writer.Received().WriteLine("##### Test sub chapter name");
    }

    [Fact]
    public void OutputSubChapterName_LevelFourNameGiven_OutputsFormattedText()
    {
        _sut.OutputSubChapterName("Test sub chapter name", 4);

        _writer.Received().WriteLine("###### Test sub chapter name");
    }

    [Fact]
    public void OutputParagraph_EmptyTextGiven_Throws()
    {
        var act = () => _sut.OutputParagraph("");

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Fact]
    public void OutputParagraph_TextGiven_OutputsFormattedText()
    {
        _sut.OutputParagraph("Test paragraph");

        _writer.Received().WriteLine("Test paragraph");
    }

    [Fact]
    public void OutputHighlightedParagraph_EmptyTextGiven_Throws()
    {
        var act = () => _sut.OutputHighlightedParagraph("");

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Fact]
    public void OutputHighlightedParagraph_TextGiven_OutputsFormattedText()
    {
        _sut.OutputHighlightedParagraph("Test highlighted paragraph");

        _writer.Received().WriteLine("**Test highlighted paragraph**");
    }

    [Fact]
    public void OutputLink_EmptyUrlGiven_Throws()
    {
        var act = () => _sut.OutputLink("");

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Fact]
    public void OutputLink_UrlGivenWithoutAlias_OutputsUrlLink()
    {
        _sut.OutputLink("https://test.link");

        _writer.Received().WriteLine("<https://test.link>");
    }

    [Fact]
    public void OutputLink_UrlGivenWithAlias_OutputsAliasedLink()
    {
        _sut.OutputLink("https://test.link", "Test link");

        _writer.Received().WriteLine("[Test link](https://test.link)");
    }

    [Fact]
    public void OutputBulletPoint_EmptyTextGiven_Throws()
    {
        var act = () => _sut.OutputBulletPoint("");

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Fact]
    public void OutputBulletPoint_TextGiven_OutputsFormattedText()
    {
        _sut.OutputBulletPoint("Test bullet point");

        _writer.Received().WriteLine("* Test bullet point");
    }

    [Fact]
    public void OutputBulletPoint_IndentedOnce_OutputsFormattedText()
    {
        _sut.OutputBulletPoint("Test bullet point", 1);

        _writer.Received().WriteLine("    * Test bullet point");
    }

    [Fact]
    public void OutputBulletPoint_IndentedTwice_OutputsFormattedText()
    {
        _sut.OutputBulletPoint("Test bullet point", 2);

        _writer.Received().WriteLine("        * Test bullet point");
    }

    [Fact]
    public void OutputNumberedPoint_EmptyTextGiven_Throws()
    {
        var act = () => _sut.OutputNumberedPoint("", 1);

        act.Should().Throw<MarkdownGenerationException>();
    }
    
    [Fact]
    public void OutputNumberedPoint_ZeroAsNumberGiven_Throws()
    {
        var act = () => _sut.OutputNumberedPoint("Test numbered point", 0);

        act.Should().Throw<MarkdownGenerationException>();
    }

    [Fact]
    public void OutputNumberedPoint_TextGiven_OutputsFormattedText()
    {
        _sut.OutputNumberedPoint("Test numbered point", 1);

        _writer.Received().WriteLine("1. Test numbered point");
    }

    [Fact]
    public void OutputNumberedPoint_IndentedOnce_OutputsFormattedText()
    {
        _sut.OutputNumberedPoint("Test numbered point", 2, 1);

        _writer.Received().WriteLine("    2. Test numbered point");
    }

    [Fact]
    public void OutputNumberedPoint_IndentedTwice_OutputsFormattedText()
    {
        _sut.OutputNumberedPoint("Test numbered point", 6, 2);

        _writer.Received().WriteLine("        6. Test numbered point");
    }
}