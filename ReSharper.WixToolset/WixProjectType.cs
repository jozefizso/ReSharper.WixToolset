using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.ProjectModel;

namespace ReSharper.WixToolset
{
    [ProjectFileTypeDefinition(WixProjectTypeName)]
    public class WixProjectType : XmlProjectFileType
    {
        public const string WixProjectTypeName = "WIXPROJECT";
        public static readonly string[] WixProjectExtensions = new string[] { ".wxs" };

        public new static WixProjectType Instance;

        public WixProjectType()
            : base(WixProjectTypeName, "WiX Toolset Project", WixProjectExtensions)
        {
        }
    }
}
