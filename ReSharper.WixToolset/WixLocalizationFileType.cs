using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.ProjectModel;

namespace ReSharper.WixToolset
{
    [ProjectFileTypeDefinition(Constants.WixLocalizationFileTypeName)]
    public class WixLocalizationFileType : XmlProjectFileType
    {
        public static readonly string[] WixProjectExtensions = { Constants.WixLocalizationFileTypeExt };

        public new static WixLocalizationFileType Instance;

        public WixLocalizationFileType()
            : base(Constants.WixLocalizationFileTypeName, Constants.WixLocalizationFileTypeDisplayName, WixProjectExtensions)
        {
        }
    }
}
