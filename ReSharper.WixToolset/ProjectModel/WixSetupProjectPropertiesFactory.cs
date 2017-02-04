using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using JetBrains.Metadata.Reader.API;
using JetBrains.Metadata.Utils;
using JetBrains.ProjectModel.Impl;
using JetBrains.ProjectModel.Properties;
using JetBrains.ProjectModel.Properties.Common;
using JetBrains.ProjectModel.Properties.CSharp;
using JetBrains.Util;
using JetBrains.Util.Logging;

namespace ReSharper.WixToolset.ProjectModel
{
    [ProjectModelExtension]
    public class WixSetupProjectPropertiesFactory : UnknownProjectPropertiesFactory
    {
        public static readonly Guid WixSetupPropertyFactoryGuid = new Guid("{1EB0BE61-E9C0-4953-8A3E-1A1D26FF2D24}");
        public static readonly Guid WixSetupProjectTypeGuid = new Guid("{930c7802-8a8c-48f9-8165-68863bccd9dd}");

        public override Guid FactoryGuid
        {
            get { return WixSetupPropertyFactoryGuid; }
        }

        public override bool IsApplicable(ProjectPropertiesFactoryParameters parameters)
        {
            return parameters.ProjectTypeGuid == WixSetupProjectTypeGuid;
        }

        public override IProjectProperties CreateProjectProperties(ProjectPropertiesFactoryParameters parameters)
        {
            return this.ImportProject(parameters);
        }

        public override IProjectProperties Read(BinaryReader reader, ProjectSerializationIndex index)
        {
            var projectProperties = new WixSetupProjectProperties(this.FactoryGuid);
            projectProperties.ReadProjectProperties(reader, index);
            return projectProperties;
        }

        public IProjectProperties ImportProject(ProjectPropertiesFactoryParameters parameters)
        {
            var projectProperties = new WixSetupProjectProperties(parameters.ProjectTypeGuids, parameters.PlatformId, this.FactoryGuid);

            var projectLocation = parameters.ProjectFilePath;
            if (!projectLocation.ExistsFile)
            {
                return projectProperties;
            }

            Stream projectFileStream = null;
            Logger.Catch(() => projectFileStream = projectLocation.OpenFileForReading());
            if (projectFileStream == null)
            {
                return projectProperties;
            }

            using (projectFileStream)
            {
                var xmlDocument = new XmlDocument();
                try
                {
                    xmlDocument.Load(projectFileStream);
                }
                catch (Exception ex)
                {
                    Logger.LogExceptionSilently(ex);
                    return projectProperties;
                }

                var namespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);

                var newConfig = projectProperties.GetOrCreateActiveConfiguration(TargetFrameworkId.Default) as IWixSetupProjectConfiguration;
                if (newConfig != null)
                {
                    var importer = new WixSetupProjectConfigurationImporter(namespaceManager);
                    importer.Import(newConfig, xmlDocument.DocumentElement);
                }
            }

            return projectProperties;
        }
    }
}
