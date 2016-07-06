using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.ProjectModel.Properties;
using JetBrains.Util;
using NUnit.Framework;
using ReSharper.WixToolset.ProjectModel;

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
    }
}
