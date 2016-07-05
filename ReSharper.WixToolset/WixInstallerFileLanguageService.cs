using System;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Xml;
using JetBrains.ReSharper.Psi.Xml.Resources;
using JetBrains.UI.Icons;

namespace ReSharper.WixToolset
{
    [ProjectFileType(typeof(WixInstallerFileType))]
    public class WixInstallerFileLanguageService : XmlProjectFileLanguageService
    {
        private readonly WixInstallerFileType fileType;

        public WixInstallerFileLanguageService(WixInstallerFileType fileType)
            : base(fileType)
        {
            this.fileType = fileType;
        }

        public override IconId Icon { get { return PsiXmlThemedIcons.XmlFile.Id; } }

        public override PsiLanguageType GetPsiLanguageType(ProjectFileType languageType)
        {
            return WixLanguage.Instance;
        }
    }
}
