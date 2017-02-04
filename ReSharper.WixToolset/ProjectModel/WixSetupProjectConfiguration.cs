using System;
using System.IO;
using JetBrains.ProjectModel.Impl.Build;
using JetBrains.ProjectModel.Properties;

namespace ReSharper.WixToolset.ProjectModel
{
    public class WixSetupProjectConfiguration : ProjectConfigurationBase, IWixSetupProjectConfiguration
    {
        private string productVersion = "";
        private string outputName = "";
        private string outputType = "";
        private string defineConstants = "";

        public string ProductVersion
        {
            get { return this.productVersion; }
            set
            {
                string str = value ?? string.Empty;
                if (this.productVersion == str)
                {
                    return;
                }

                this.productVersion = str;
                this.OnPropertyChange();
            }
        }

        public string OutputName
        {
            get { return this.outputName; }
            set
            {
                string str = value ?? string.Empty;
                if (this.outputName == str)
                {
                    return;
                }

                this.outputName = str;
                this.OnPropertyChange();
            }
        }

        public string OutputType
        {
            get { return this.outputType; }
            set
            {
                string str = value ?? string.Empty;
                if (this.outputType == str)
                {
                    return;
                }

                this.outputType = str;
                this.OnPropertyChange();
            }
        }

        public string DefineConstants
        {
            get { return this.defineConstants; }
            set
            {
                string str = value ?? string.Empty;
                if (this.defineConstants == str)
                {
                    return;
                }

                this.defineConstants = str;
                this.OnPropertyChange();
            }
        }

        public override void WriteConfiguration(BinaryWriter writer)
        {
            base.WriteConfiguration(writer);
            writer.Write(this.productVersion);
            writer.Write(this.outputName);
            writer.Write(this.outputType);
            writer.Write(this.defineConstants);
        }

        public override void ReadConfiguration(BinaryReader reader)
        {
            base.ReadConfiguration(reader);
            this.productVersion = reader.ReadString();
            this.outputName = reader.ReadString();
            this.outputType = reader.ReadString();
            this.defineConstants = reader.ReadString();
        }

        public override bool UpdateFrom(IProjectConfiguration configuration)
        {
            var configurationBase = configuration as WixSetupProjectConfiguration;
            if (configurationBase == null)
            {
                return false;
            }

            this.ProductVersion = configurationBase.ProductVersion;
            this.OutputName = configurationBase.OutputName;
            this.OutputType = configurationBase.OutputType;
            this.DefineConstants = configurationBase.DefineConstants;
            return base.UpdateFrom(configuration);
        }

        public override void Dump(TextWriter to, int indent)
        {
            string margin = new string(' ', 2 + indent * 2);
            to.Write(margin);
            to.WriteLine("ProductVersion:{0}", this.ProductVersion);
            to.Write(margin);
            to.WriteLine("OutputName:{0}", this.OutputName);
            to.Write(margin);
            to.WriteLine("OutputType:{0}", this.OutputType);
            to.Write(margin);
            to.WriteLine("DefineConstants:{0}", this.DefineConstants);
            base.Dump(to, indent);
        }
    }
}