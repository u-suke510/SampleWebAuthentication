using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs
{
    public interface IRepositoryBase
    {
    }

    public class RepositoryBase : IRepositoryBase
    {
        protected readonly IConfigManager conf;
        protected ILogger logger;

        public RepositoryBase(IOptions<ConfigManager> options)
        {
            conf = options.Value;
        }
    }
}
