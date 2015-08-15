using System;
using System.Threading.Tasks;
using RestSharp;

namespace EasyTag
{
    public static class RestSharpHelper
    {
        public static Task<IRestResponse> ExecuteTaskAsync(this RestClient @this, RestRequest request)
        {
            if (@this == null)
                throw new NullReferenceException();
            var tcs = new TaskCompletionSource<IRestResponse>();
            @this.ExecuteAsync(request, (response) =>
            {
                if (response.ErrorException != null)
                    tcs.TrySetException(response.ErrorException);
                else
                    tcs.TrySetResult(response);
            });
            return tcs.Task;
        }
    }
}
