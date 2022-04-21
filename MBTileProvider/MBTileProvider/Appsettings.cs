using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MBTileProvider
{
    public interface IAppsettings
    {
        string SourceFile { get; }
    }
    public class Appsettings : IAppsettings
    {
        private readonly IConfiguration configuration;

        public Appsettings(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string SourceFile
        {
            get
            {
                return this.configuration["SourceFile"];
            }
        }
    }
}
