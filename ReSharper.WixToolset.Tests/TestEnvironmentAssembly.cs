using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Application;
using JetBrains.ReSharper.Resources.Shell;
using JetBrains.TestFramework;
using JetBrains.Threading;
using NUnit.Framework;
using ReSharper.WixToolset;
using ReSharper.WixToolset.Tests;

[SetUpFixture]
// ReSharper disable once CheckNamespace
public class TestEnvironmentAssembly : ExtensionTestEnvironmentAssembly<TestEnvironmentZone>
{
}
