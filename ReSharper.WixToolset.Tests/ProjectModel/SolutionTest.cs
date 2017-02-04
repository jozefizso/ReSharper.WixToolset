using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.DataFlow;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.TestFramework;
using JetBrains.Util;
using NUnit.Framework;

namespace ReSharper.WixToolset.Tests.ProjectModel
{
    [TestFixture]
    public class SolutionTest : BaseTestWithExistingSolution
    {
        [Test]
        [Ignore]
        public void TestedMethodName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            
            //this.DoTestSolution("SetupProject1.sln");
            //this.WithSingleProject()

            var path = this.BaseTestDataPath.Combine("SetupProject1.sln");
            this.DoTestSolution(path, VerifySolution);

            // Act

            // Assert
        }

        private void VerifySolution(Lifetime lifetime, ISolution solution)
        {
            Assert.Fail("");
        }
    }
}
