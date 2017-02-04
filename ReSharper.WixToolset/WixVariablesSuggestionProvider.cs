using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.CodeCompletion;
using JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure;
using JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure.LookupItems;
using JetBrains.ReSharper.Features.Intellisense.CodeCompletion.Xml;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Impl.CodeStyle;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.ReSharper.Psi.Xml.Tree;
using JetBrains.UI.Avalon.TreeListView;
using JetBrains.Util;

namespace ReSharper.WixToolset
{
    [Language(typeof(WixLanguage))]
    public class WixVariablesSuggestionProvider : ItemsProviderOfSpecificContext<XmlCodeCompletionContext>
    {
        protected override bool IsAvailable(XmlCodeCompletionContext context)
        {
            var xml = context.UnterminatedContext.TreeNode as IXmlToken;
            if (xml == null)
            {
                return false;
            }
            var tokenType = xml.GetTokenType();

            return true;
        }

        protected override bool AddLookupItems(XmlCodeCompletionContext context, GroupedItemsCollector collector)
        {
            IRangeMarker rangeMarker = new TextRange(context.BasicContext.CaretDocumentRange.TextRange.StartOffset).CreateRangeMarker(context.BasicContext.Document);

            var lookupItem1 = new SimpleTextLookupItem("$(var", rangeMarker);
            lookupItem1.InitializeRanges(context.EvaluateRanges(), context.BasicContext);
            collector.Add(lookupItem1);

            var lookupItem2 = new SimpleTextLookupItem("!(bind.", rangeMarker);
            lookupItem2.InitializeRanges(context.EvaluateRanges(), context.BasicContext);
            collector.Add(lookupItem2);

            return true;
        }
    }
}
