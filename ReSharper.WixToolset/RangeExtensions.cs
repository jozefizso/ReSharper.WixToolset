using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure;
using JetBrains.ReSharper.Feature.Services.CSharp.CodeCompletion.Infrastructure;
using JetBrains.ReSharper.Features.Intellisense.CodeCompletion.Xml;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Util.Literals;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Util;

namespace ReSharper.WixToolset
{
    public static class RangeExtensions
    {
        public static TextLookupRanges EvaluateRanges(this XmlCodeCompletionContext context)
        {
            CodeCompletionContext basicContext = context.BasicContext;
            TextRange selectedRange = basicContext.SelectedRange.TextRange;
            TextRange documentRange = basicContext.CaretDocumentRange.TextRange;
            TreeOffset caretTreeOffset = basicContext.CaretTreeOffset;
            var tokenNode = basicContext.File.FindTokenAt(caretTreeOffset) as ITokenNode;

            if (tokenNode != null && tokenNode.IsAnyStringLiteral())
                documentRange = tokenNode.GetDocumentRange().TextRange;

            var replaceRange = new TextRange(documentRange.StartOffset, Math.Max(documentRange.EndOffset, selectedRange.EndOffset));

            return new TextLookupRanges(replaceRange, replaceRange);
        }
    }
}
