using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.ProjectModel;
using JetBrains.ProjectModel.Properties;
using JetBrains.ProjectModel.Properties.Common;
using PlatformID = JetBrains.Application.platforms.PlatformID;

namespace ReSharper.WixToolset.ProjectModel
{
    public class WixSetupProjectProperties : ProjectPropertiesBase<WixSetupProjectConfiguration>, IProjectProperties
    {
        public WixSetupProjectProperties(Guid factoryGuid)
            : base(factoryGuid)
        {
        }

        public WixSetupProjectProperties(ICollection<Guid> projectTypeGuids, PlatformID platformId, Guid factoryGuid)
            : base(projectTypeGuids, platformId, factoryGuid)
        {
        }

        public override IBuildSettings BuildSettings
        {
            get { return null; }
        }

        public ProjectLanguage DefaultLanguage
        {
            get { return ProjectLanguage.UNKNOWN; }
        }

        public ProjectKind ProjectKind
        {
            get { return ProjectKind.REGULAR_PROJECT; }
        }

        public override void Dump(TextWriter to, int indent = 0)
        {
            to.Write(new string(' ', indent * 2));
            to.WriteLine("WiX Setup Project Properties:");
            this.DumpActiveConfigurations(to, indent);
            base.Dump(to, indent + 1);
        }
    }
}
