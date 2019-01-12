using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NaisCompanion.Models;

namespace NaisCompanion.Services
{
    public class TouristMockDataStore : MockDataStore<Tourist>
    {
        public TouristMockDataStore(List<Tourist> items)
            :base(items) { }

        public async Task<Tourist> GetTouristAsync(string userName)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Username == userName));
        }
    }
}