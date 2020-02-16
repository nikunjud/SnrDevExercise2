using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebSvc1.App_Start
{
    public class IPFilterHandler :DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.AllowIP())
            {
                return await base.SendAsync(request, cancellationToken);
            }
            return request.CreateErrorResponse(HttpStatusCode.Unauthorized
                        , "Not authorized to view/access this resource");
        }
    }

}