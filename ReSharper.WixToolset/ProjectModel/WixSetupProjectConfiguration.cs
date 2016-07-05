using System;
using System.IO;
using JetBrains.ProjectModel.Impl.Build;
using JetBrains.ProjectModel.Properties;

namespace ReSharper.WixToolset.ProjectModel
{
    public class WixSetupProjectConfiguration : ProjectConfigurationBase, IWixSetupProjectConfiguration
    {
        private string defineConstants = "";

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
            writer.Write(this.defineConstants);
        }

        public override void ReadConfiguration(BinaryReader reader)
        {
            base.ReadConfiguration(reader);
            this.defineConstants = reader.ReadString();
        }

        public override bool UpdateFrom(IProjectConfiguration configuration)
        {
            var configurationBase = configuration as WixSetupProjectConfiguration;
            if (configurationBase == null)
            {
                return false;
            }

            this.DefineConstants = configurationBase.DefineConstants;
            return base.UpdateFrom(configuration);
        }

        public override void Dump(TextWriter to, int indent)
        {
            to.Write(new string(' ', 2 + indent * 2));
            to.WriteLine("DefineConstants:{0}", this.DefineConstants);
            base.Dump(to, indent);
        }
    }
}