using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework.Application.Zones;

namespace ReSharper.WixToolset.Tests
{
    [ZoneDefinition]
    public class TestEnvironmentZone : ITestsZone, IRequire<PsiFeatureTestZone>
    {
    }
}
