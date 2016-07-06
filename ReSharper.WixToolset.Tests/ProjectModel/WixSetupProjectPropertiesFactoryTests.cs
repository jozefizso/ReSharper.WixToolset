using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Application.platforms;
using JetBrains.Metadata.Utils;
using JetBrains.ProjectModel.Properties;
using JetBrains.Util;
using JetBrains.VsIntegration.ProjectModel.ProjectProperties;
using NUnit.Framework;
using ReSharper.WixToolset.ProjectModel;
using PlatformID = JetBrains.Application.platforms.PlatformID;

namespace ReSharper.WixToolset.Tests.ProjectModel
{
    [TestFixture]
    public class WixSetupProjectPropertiesFactoryTests
    {
        [Test]
        public void FactoryGuid_DefaultFactory_ReturnsWixSetupProjectPropertiesFactoryGuid()
        {
            // Arrange
            var expectedGuid = WixSetupProjectPropertiesFactory.WixSetupPropertyFactoryGuid;
            var factory = new WixSetupProjectPropertiesFactory();

            // Act
            var actualGuid = factory.FactoryGuid;

            // Assert
            Assert.AreEqual(expectedGuid, actualGuid);
        }

        [Test]
        public void IsApplicable_ValidWixSetupProjectGuid_ReturnsTrue()
        {
            // Arrange
            var wixProjectTypeGuid = new Guid("930c7802-8a8c-48f9-8165-68863bccd9dd");
            var parameters = new ProjectPropertiesFactoryParameters(wixProjectTypeGuid, new List<Guid>(), null, null, FileSystemPath.Empty, FileSystemPath.Empty);

            var factory = new WixSetupProjectPropertiesFactory();

            // Act
            var actualIsApplicable = factory.IsApplicable(parameters);

            // Assert
            Assert.IsTrue(actualIsApplicable, $"Factory must accept WiX project type GUID {wixProjectTypeGuid}");
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("1EB0BE61-E9C0-4953-8A3E-1A1D26FF2D24")]
        public void IsApplicable_ValidWixSetupProjectGuid_ReturnsFalse(string invalidProjectTypeGuid)
        {
            // Arrange
            var guid = Guid.Parse(invalidProjectTypeGuid);
            var parameters = new ProjectPropertiesFactoryParameters(guid, new List<Guid>(), null, null, FileSystemPath.Empty, FileSystemPath.Empty);

            var factory = new WixSetupProjectPropertiesFactory();

            // Act
            var actualIsApplicable = factory.IsApplicable(parameters);

            // Assert
            Assert.IsFalse(actualIsApplicable, $"Factory must accept only WiX project type GUID");
        }

        [Test]
        public void CreateProjectProperties_ValidProjectPropertiesFactoryParameters_ReturnsWixSetupProjectProperties()
        {
            // Arrange
            var fakeFrameworkIdentifier = new FrameworkIdentifier("WixToolset");
            var fakePlatformId = new PlatformID(fakeFrameworkIdentifier, new Version(1, 0), ProfileIdentifier.Default);
            var fakeTargetPlatformData = new TargetPlatformData("WixToolset", "v1.0");
            var projectTypeGuids = new List<Guid> { WixSetupProjectPropertiesFactory.WixSetupProjectTypeGuid };

            var parameters = new ProjectPropertiesFactoryParameters(
                WixSetupProjectPropertiesFactory.WixSetupProjectTypeGuid,
                projectTypeGuids,
                fakePlatformId,
                fakeTargetPlatformData, 
                FileSystemPath.Empty,
                FileSystemPath.Empty);

            var factory = new WixSetupProjectPropertiesFactory();

            // Act
            var actualProperties = factory.CreateProjectProperties(parameters);

            // Assert
            Assert.IsNotNull(actualProperties);
            Assert.IsInstanceOf<WixSetupProjectProperties>(actualProperties);

            var wixActualProperties = actualProperties as WixSetupProjectProperties;
            Assert.AreEqual(WixSetupProjectPropertiesFactory.WixSetupPropertyFactoryGuid, wixActualProperties.OwnerFactoryGuid);
            Assert.AreEqual(fakePlatformId, wixActualProperties.PlatformId);
            CollectionAssert.AreEqual(projectTypeGuids, wixActualProperties.ProjectTypeGuids);
        }
    }
}
