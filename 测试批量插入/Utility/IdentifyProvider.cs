using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sino.Hf.EtcService
{
    public class IdentifyProvider : IIdentifyProvider
    {
        public Task<string> CreateIdAsync(Type type)
        {
            return Task<string>.Factory.StartNew(() =>
            {
                return CreateId(type);
            });
        }

        public string CreateId(Type type)
        {
            return Guid.NewGuid().ToString();
        }

        public string CreateId<T>()
        {
            return CreateId(typeof(T));
        }
    }
}
