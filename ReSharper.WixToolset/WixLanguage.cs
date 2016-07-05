using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Xml;

namespace ReSharper.WixToolset
{
    [LanguageDefinition(WixLanguageName)]
    public class WixLanguage : XmlLanguage
    {
        public const string WixLanguageName = "WXSLANG";

        [CanBeNull]
        public new static readonly WixLanguage Instance;

        public WixLanguage()
            : base(WixLanguageName, "WiX Installer")
        {
        }
    }
}
