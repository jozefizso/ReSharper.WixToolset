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
        string DefineConstants { get; set; }
    }
}
