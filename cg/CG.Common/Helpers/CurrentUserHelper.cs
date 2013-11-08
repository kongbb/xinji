using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CG.Common.Interface;
using Microsoft.Practices.Unity;

namespace CG.Common.Helpers
{
    public static class CurrentUserHelper
    {
        private const string UserIdKey = "Cg.CurrentUserIdKey";

        private static ILocalStorage LocalStorage
        {
            get
            {
                return UnityHelper.Current.Resolve<ILocalStorage>();
            }
        }

        #region Methods

        /// <summary>
        /// Gets whether the current user is authenticated as per the identity on 
        /// the current thread.
        /// </summary>
        /// <returns>Whether the current thread identity user is authenticated</returns>
        public static bool IsCurrentUserAuthenticated()
        {
            // Don't want to add a System.Web reference here so use the Thread Identity instead. 
            // Should be the same as Page.Identity or HttpContext.Current.Identity provided 
            // no funny stuff is done in the Presentation layer.
            // The CurrentPrincipal.Identity.IsAuthenticated case returns the correct value in all
            // occassions except in the same request when the login occurred. In that case rely 
            // on the thread slot being set to the current User ID upon authentication.
            return IsCurrentUserIdSet() || Thread.CurrentPrincipal.Identity.IsAuthenticated;
        }

        /// <summary>
        /// Gets the full username (including domain prefix if Windows Auhtentication is on) 
        /// of the current user as set on the identity of the current thread.
        /// </summary>
        /// <returns>The username of the current user (without the domain portion).</returns>
        public static string GetCurrentUserUsername()
        {
            // Don't want to add a System.Web reference here so use the Thread Identity instead. 
            // Should be the same as Page.Identity or HttpContext.Current.Identity provided 
            // no funny stuff is done in the Presentation layer.
            return Thread.CurrentPrincipal.Identity.Name;
        }

        /// <summary>
        /// Sets the current authenticated user's ID from the local storage
        /// </summary>
        /// <param name="userId">The user id.</param>
        public static void SetCurrentUserId(long userId)
        {
            if (!LocalStorage.IsStorageAvailable())
            {
                return;
            }

            LocalStorage.Store(UserIdKey, userId);
        }

        /// <summary>
        /// Removes the current authenticated user's ID from the local storage.
        /// </summary>
        public static void UnsetCurrentUserId()
        {
            if (!LocalStorage.IsStorageAvailable())
            {
                return;
            }

            if (LocalStorage.HasKeyAndNotNullValue(UserIdKey))
            {
                LocalStorage.Store(UserIdKey, null);
            }
        }

        /// <summary>
        /// Gets whether the current authenticated user's ID from the local storage.
        /// </summary>
        /// <returns>True if Set</returns>
        public static bool IsCurrentUserIdSet()
        {
            if (LocalStorage.IsStorageAvailable())
            {
                return LocalStorage.HasKeyAndNotNullValue(UserIdKey);
            }

            return false;
        }

        /// <summary>
        /// Gets the current authenticated user's ID from the local storage.
        /// </summary>
        /// <returns>The current user's ID, or <c>null</c> if no current user ID has 
        /// been set.</returns>
        public static long? GetCurrentUserId()
        {
            if (!LocalStorage.IsStorageAvailable())
            {
                return null;
            }

            if (!IsCurrentUserIdSet())
            {
                return null;
            }
            var data = LocalStorage.Get(UserIdKey);
            return data != null ? Convert.ToInt64(data) : (long?)null;
        }

        #endregion
    }
}
