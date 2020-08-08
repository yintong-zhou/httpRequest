using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;

namespace httpRequest
{
    class Request
    {
        HttpClient client = new HttpClient();

        HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create("https://www.nike.com/ch/en/launch/t/ispa-overreact-sandal-thunder-grey");
        WebProxy myProxy = new WebProxy();
        string proxyAddress = "http://3.83.44.199:8080";


        public async void RequestWithoutProxy()
        {
            var result = await client.GetAsync("https://icpn.github.io/");
            
            if(result.IsSuccessStatusCode)
            {
                Console.WriteLine(result.StatusCode);
                Console.WriteLine(result.Content);
            }
            else
            {
                Console.WriteLine(result.StatusCode);
            }
        }

        public void RequestProxy()
        {
            IWebProxy proxy = myWebRequest.Proxy;
           
            if (proxy != null)
            {
                Console.WriteLine("Proxy: {0}", proxy.GetProxy(myWebRequest.RequestUri));
            }
            else
            {
                Console.WriteLine("Proxy is null; no proxy will be used");
            }

            try
            {
                if (proxyAddress.Length > 0)
                {
                    // LOGIN PROXY SERVER
                    //Console.WriteLine("\nPlease enter the Credentials (may not be needed)");
                    //Console.WriteLine("Username:");
                    //string username;
                    //username = Console.ReadLine();
                    //Console.WriteLine("\nPassword:");
                    //string password;
                    //password = Console.ReadLine();

                    Uri newUri = new Uri(proxyAddress);
                    myProxy.Address = newUri;
                    
                    // myProxy.Credentials = new NetworkCredential(username, password);
                    myWebRequest.Proxy = myProxy;
                }
                Console.WriteLine("\nThe Address of the new Proxy settings are {0}", myProxy.Address);
                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                Console.WriteLine($"{myWebResponse.Method} {myWebResponse.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
