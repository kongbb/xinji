using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.Common.Interface
{
    public interface ILocalStorage
    {
        /// <summary>
        /// Stores the given object into local storage.
        /// </summary>
        /// <param name="key">The key to access the stored item</param>
        /// <param name="item">The item to store.</param>
        void Store(string key, object item);

        /// <summary>
        /// Retrieves a stored item from local storage
        /// </summary>
        /// <param name="key">The key to access the stored item</param>
        /// <param name="removeFromStore">Whether to remove the item from storage after 
        /// retrieval</param>
        /// <returns>The required item from local storage</returns>
        object Get(string key, bool removeFromStore = false);

        /// <summary>
        /// Checks whether the Local storage contains this key
        /// </summary>
        /// <param name="key">key to check if exists</param>
        /// <returns>true if exists</returns>
        bool HasKeyAndNotNullValue(string key);

        /// <summary>
        /// Determines if the local storage is available, in the case of HTTP Context if it is a spawned
        /// thread then the context may not be available for access.
        /// </summary>
        /// <returns>True if available</returns>
        bool IsStorageAvailable();
    }
}
