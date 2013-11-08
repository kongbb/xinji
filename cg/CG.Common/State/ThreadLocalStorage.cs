using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CG.Common.Interface;

namespace CG.Common.State
{
    public class ThreadLocalStorage : ILocalStorage
    {
        private const string KeyPrefix = "ThreadLocalStorage_";

        /// <summary>
        /// Stores the given object into local storage.
        /// </summary>
        /// <param name="key">The key to access the stored item</param>
        /// <param name="item">The item to store.</param>
        public void Store(string key, object item)
        {
            key = KeyPrefix + key;
            LocalDataStoreSlot threadSlot = Thread.GetNamedDataSlot(key);
            Thread.SetData(threadSlot, item);
        }

        /// <summary>
        /// Retrieves a stored item from local storage
        /// </summary>
        /// <param name="key">The key to access the stored item</param>
        /// <param name="removeFromStore">Whether to remove the item from storage after 
        /// retrieval</param>
        /// <returns>The required item from local storage</returns>
        public object Get(string key, bool removeFromStore)
        {
            key = KeyPrefix + key;
            LocalDataStoreSlot threadSlot = Thread.GetNamedDataSlot(key);
            return Thread.GetData(threadSlot);
        }

        /// <summary>
        /// Checks whether the Local storage contains this key
        /// </summary>
        /// <param name="key">key to check if exists</param>
        /// <returns>true if exists</returns>
        public bool HasKeyAndNotNullValue(string key)
        {
            key = KeyPrefix + key;

            LocalDataStoreSlot threadSlot = Thread.GetNamedDataSlot(key);

            return Thread.GetData(threadSlot) != null;
        }

        /// <summary>
        /// Determines if the local storage is available, in the case of HTTP Context if it is a spawned
        /// thread then the context may not be available for access.
        /// </summary>
        /// <returns>True if available</returns>
        public bool IsStorageAvailable()
        {
            return true;
        }
    }
}
