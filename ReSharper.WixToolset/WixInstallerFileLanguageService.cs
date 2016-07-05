using System;
using JetBrains.Metadata.Reader.API;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Properties;
using JetBrains.ProjectModel.Properties.CSharp;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Impl;
using JetBrains.ReSharper.Psi.Xml;
using JetBrains.ReSharper.Psi.Xml.Resources;
using JetBrains.UI.Icons;
using JetBrains.Util;
using ReSharper.WixToolset.ProjectModel;

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
            if (languageType.Is<WixInstallerFileType>())
            {
                return WixLanguage.Instance;
            }

            return UnknownLanguage.Instance;
        }

        public override PreProcessingDirective[] GetPreprocessorDefines(IProject project, TargetFrameworkId targetFrameworkId)
        {
            var processingDirectiveArray = EmptyArray<PreProcessingDirective>.Instance;
            var configuration = project.ProjectProperties.TryGetConfiguration<IWixSetupProjectConfiguration>(targetFrameworkId);

            string defineConstants = configuration?.DefineConstants;
            if (!string.IsNullOrEmpty(defineConstants))
            {
                string[] strArray = defineConstants.Split(';', ',', ' ');
                processingDirectiveArray = new PreProcessingDirective[strArray.Length];
                for (int index = 0; index < strArray.Length; ++index)
                {
                    processingDirectiveArray[index] = new PreProcessingDirective(strArray[index].Trim(), string.Empty);
                }
            }

            return processingDirectiveArray;
        }
    }

    public class WixInstallerFileLanguageService1 : CSharpProjectFileLanguageService
    {
        public WixInstallerFileLanguageService1(CSharpProjectFileType csharpProjectFileType) : base(csharpProjectFileType)
        {
        }
    }

}
