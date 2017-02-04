using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.ProjectModel.Properties;
using JetBrains.Util;

namespace ReSharper.WixToolset.ProjectModel
{
    public interface IWixSetupProjectConfiguration : IProjectConfiguration, IUserDataHolder
    {
        string ProductVersion { get; set; }

        string OutputName { get; set; }

        string OutputType { get; set; }

        string DefineConstants { get; set; }
    }
}
