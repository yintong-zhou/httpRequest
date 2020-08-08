using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;


namespace httpRequest
{
    class Program
    {
        static void Main(string[] args)
        {
            Request r = new Request();
            
            for(int i=0; i<10; i++)
            {
                r.RequestProxy();
            }

            r.RequestWithoutProxy();
        }
    }
}
