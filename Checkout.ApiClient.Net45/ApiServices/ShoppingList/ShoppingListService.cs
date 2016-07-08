using System;
using Checkout.ApiServices.SharedModels;
using System.Collections.Generic;

namespace Checkout.ApiServices.ShoppingList
{
    public class ShoppingListService
    {
        /// <summary>
        /// Add an item to the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponse<OkResponse> AddItem(Product item)
        {
            var uri = $"{ApiUrls.ShoppingList}/Post";
            return new ApiHttpClient().PostRequest<OkResponse>(uri, AppSettings.SecretKey, item);
        }

        /// <summary>
        /// Clear the entire list of items
        /// </summary>
        /// <returns></returns>
        public HttpResponse<OkResponse> ClearList()
        {
            var uri = $"{ApiUrls.ShoppingList}/ClearList";
            return new ApiHttpClient().GetRequest<OkResponse>(uri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Request an item from the list by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public HttpResponse<Product> GetItem(string name)
        {
            var uri = $"{ApiUrls.ShoppingList}/Get/{name}";
            return new ApiHttpClient().GetRequest<Product>(uri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Delete an item from the list by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public HttpResponse<OkResponse> DeleteItem(string name)
        {
            var uri = $"{ApiUrls.ShoppingList}/Delete/{name}";
            return new ApiHttpClient().DeleteRequest<OkResponse>(uri, AppSettings.SecretKey);
        }

        /// <summary>
        /// Update the quantity of an item by name
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public HttpResponse<OkResponse> UpdateItem(Product item)
        {
            var uri = $"{ApiUrls.ShoppingList}/Put";
            return new ApiHttpClient().PutRequest<OkResponse>(uri, AppSettings.SecretKey, item);
        }

        /// <summary>
        /// Request the full list of items to be returned
        /// </summary>
        /// <returns></returns>
        public HttpResponse<List<Product>> GetList()
        {
            var uri = $"{ApiUrls.ShoppingList}/GetList";
            return new ApiHttpClient().GetRequest<List<Product>>(uri, AppSettings.SecretKey);
        }
    }
}
