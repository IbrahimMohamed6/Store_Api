using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.CachService
{
    public interface ICachService
    {
        Task SetCaheResponseAsync(string Key, object Response, TimeSpan TimeToLive);
        Task<string> GetCaheResponseAsync(string Key);
    }
}
