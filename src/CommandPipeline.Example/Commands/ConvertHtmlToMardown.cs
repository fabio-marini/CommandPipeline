namespace CommandPipeline.Example.Commands
{
    using CommandPipeline.Example.Entities;
    using CommandPipeline.Example.Services;
    using CommandPipeline.Infrastructure.Arguments;
    using CommandPipeline.Infrastructure.Extensions;
    using CommandPipeline.Infrastructure.Pipeline.Implementation;

    using EnsureThat;

    public class ConvertHtmlToMardown : NonParameterizedCommand
    {
        public InArgument<HtmlDocument> HtmlPage { get; set; }

        public OutArgument<MarkdownDocument> MarkdownDocument { get; set; }

        public IMarkdownConveter Conveter { get; private set; }

        public ConvertHtmlToMardown(IMarkdownConveter conveter)
        {
            this.Conveter = conveter;
        }

        public override void Execute()
        {
            Ensure.That(this.HtmlPage?.Value, "HtmlDocument").IsNotNull();

            var markdownDocument = this.Conveter.ConvertFromHtml(this.HtmlPage.Value.Content);

            var document = new MarkdownDocument { Content = markdownDocument };

            this.MarkdownDocument.Set(document);
        }
    }
}