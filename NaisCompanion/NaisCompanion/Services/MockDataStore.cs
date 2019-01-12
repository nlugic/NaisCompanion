using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NaisCompanion.Models;

namespace NaisCompanion.Services
{
    public class MockDataStore<T> : IDataStore<T> where T : IBaseModel
    {
        public List<T> Items { get; set; }

        public MockDataStore() { }
        
        public async Task<bool> SetItems(List<T> items)
        {
            Items = items;
            return await Task.FromResult(true);
        }

        public async Task<bool> AddItemAsync(T item)
        {
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            T oldItem = Items.Where((T arg) => arg.Id == item.Id).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            T oldItem = Items.Where((T arg) => arg.Id == id).FirstOrDefault();
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}