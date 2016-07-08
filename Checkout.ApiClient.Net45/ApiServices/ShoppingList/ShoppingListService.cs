using System;
using Checkout.ApiServices.SharedModels;
using System.Collections.Generic;

namespace Checkout.ApiServices.ShoppingList
{
    public class ShoppingListService
    {

        //public HttpResponse<Item> GetItem(string itemName)
        //{
        //    return new ApiHttpClient().GetRequest<Item>(ApiUrls.ReportingTransactions, AppSettings.SecretKey);
        //}

        public HttpResponse<OkResponse> AddItem(Product item)
        {
            var uri = $"{ApiUrls.ShoppingList}/Post";
            return new ApiHttpClient().PostRequest<OkResponse>(uri, AppSettings.SecretKey, item);
        }

        public HttpResponse<OkResponse> ClearList()
        {
            var uri = $"{ApiUrls.ShoppingList}/ClearList";
            return new ApiHttpClient().GetRequest<OkResponse>(uri, AppSettings.SecretKey);
        }

        public HttpResponse<Product> GetItem(string name)
        {
            var uri = $"{ApiUrls.ShoppingList}/Get/{name}";
            return new ApiHttpClient().GetRequest<Product>(uri, AppSettings.SecretKey);
        }

        public HttpResponse<OkResponse> DeleteItem(string name)
        {
            var uri = $"{ApiUrls.ShoppingList}/Delete/{name}";
            return new ApiHttpClient().DeleteRequest<OkResponse>(uri, AppSettings.SecretKey);
        }

        public HttpResponse<OkResponse> UpdateItem(Product item)
        {
            var uri = $"{ApiUrls.ShoppingList}/Put";
            return new ApiHttpClient().PutRequest<OkResponse>(uri, AppSettings.SecretKey, item);
        }

        public HttpResponse<List<Product>> GetList()
        {
            var uri = $"{ApiUrls.ShoppingList}/GetList";
            return new ApiHttpClient().GetRequest<List<Product>>(uri, AppSettings.SecretKey);
        }

        ///// <summary>
        ///// Search for a customer’s chargebacks by a date range and then drill down using further filters.
        ///// </summary>
        ///// <param name="requestModel"></param>
        ///// <returns></returns>
        //public HttpResponse<QueryChargebackResponse> QueryChargeback(QueryRequest requestModel)
        //{
        //    return new ApiHttpClient().PostRequest<QueryChargebackResponse>(ApiUrls.ReportingChargebacks, AppSettings.SecretKey, requestModel);
        //}
    }
}
