using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using JetBrains.ProjectModel.MSBuild;
using JetBrains.ProjectModel.Properties.Managed;

namespace ReSharper.WixToolset.ProjectModel
{
    public class WixSetupProjectConfigurationImporter
    {
        private readonly XmlNamespaceManager namespaceManager;

        public WixSetupProjectConfigurationImporter(XmlNamespaceManager namespaceManager)
        {
            this.namespaceManager = namespaceManager;
            namespaceManager.AddNamespace("pr", "http://schemas.microsoft.com/developer/msbuild/2003");
        }

        public void Import(IWixSetupProjectConfiguration newConfig, XmlElement xmlDocument)
        {
            var propertyGroupElements = xmlDocument.SelectNodes(MSBuildProjectUtil.Qualify("PropertyGroup"), this.namespaceManager);
            if (propertyGroupElements != null)
            {
                foreach (XmlElement propertyGroupElement in propertyGroupElements)
                {
                    this.ImportInternal(newConfig, propertyGroupElement);
                }
            }
        }

        protected virtual void ImportInternal(IWixSetupProjectConfiguration config, XmlElement propertyGroupElement)
        {
            this.GetChildValue(propertyGroupElement, "ProductVersion", (value) => config.ProductVersion = value);
            this.GetChildValue(propertyGroupElement, "OutputName", (value) => config.OutputName = value);
            this.GetChildValue(propertyGroupElement, "OutputType", (value) => config.OutputType = value);
            this.GetChildValue(propertyGroupElement, "DefineConstants", (value) => config.DefineConstants = value);
        }

        protected string GetChildValue(XmlElement parent, string childTag, Action<string> propertySetter)
        {
            XmlNode xmlNode = parent.SelectSingleNode(QualifyXmlName(childTag), this.namespaceManager);
            var value = xmlNode?.InnerText;

            if (value != null)
            {
                propertySetter(value);
            }

            return value;
        }

        public static string QualifyXmlName(string elementName)
        {
            return "pr:" + elementName;
        }
    }
}
