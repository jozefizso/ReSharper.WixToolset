using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.ProjectModel;

namespace ReSharper.WixToolset
{
    [ProjectFileTypeDefinition(Constants.WixInstallerFileTypeName)]
    public class WixInstallerFileType : XmlProjectFileType
    {
        public static readonly string[] WixProjectExtensions = { Constants.WixInstallerFileTypeExt };

        public new static WixInstallerFileType Instance;

        public WixInstallerFileType()
            : base(Constants.WixInstallerFileTypeName, Constants.WixInstallerFileTypeDisplayName, WixProjectExtensions)
        {
        }
    }
}
