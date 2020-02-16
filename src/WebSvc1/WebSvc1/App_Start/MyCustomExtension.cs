using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web;

namespace WebSvc1.App_Start
{
    public static class MyCustomExtension
    {

        public static string GetIP(this HttpRequestMessage requestMessage)
        {
            // Web Hosting 
            if (requestMessage.Properties.ContainsKey("MS_HttpContext"))
            {
                return HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : null;
            }
            // Self Hosting 
            if (requestMessage.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty property =
            (RemoteEndpointMessageProperty)requestMessage.Properties[RemoteEndpointMessageProperty.Name];
                return property != null ? property.Address : null;
            }
            return null; 
        }

        public static bool AllowIP(this HttpRequestMessage request)
        {
            var whiteListedIPs = "10.278.210.22,10.89.65.231,::1";
            if (!string.IsNullOrEmpty(whiteListedIPs))
            {
                var whiteListIPList = whiteListedIPs.Split(',').ToList();
                var ipAddressString = request.GetIP();
                var ipAddress = IPAddress.Parse(ipAddressString);
                var isInwhiteListIPList =
                        whiteListIPList
                            .Where(a => a.Trim()
                            .Equals(ipAddressString, StringComparison.InvariantCultureIgnoreCase))
                            .Any();
                return isInwhiteListIPList;
            }
            return true;
        }

    }
}