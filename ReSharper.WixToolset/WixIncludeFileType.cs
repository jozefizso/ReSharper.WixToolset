using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.ProjectModel;

namespace ReSharper.WixToolset
{
    [ProjectFileTypeDefinition(Constants.WixIncludeFileTypeName)]
    public class WixIncludeFileType : XmlProjectFileType
    {
        public static readonly string[] WixProjectExtensions = { Constants.WixIncludeFileTypeExt };

        public new static WixIncludeFileType Instance;

        public WixIncludeFileType()
            : base(Constants.WixIncludeFileTypeName, Constants.WixIncludeFileTypeDisplayName, WixProjectExtensions)
        {
        }
    }
}
