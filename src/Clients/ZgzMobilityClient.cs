﻿using Java.Util.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPICHI.Clients
{
    public static class ZgzMobilityClient
    {
        static readonly string Url = "https://www.zaragoza.es/sede/servicio/urbanismo-infraestructuras/transporte-urbano";
        static HttpClient client;

        private static async Task<HttpClient> GetClient()
        {
            if (client != null)
                return client;

            client = new HttpClient();

            return client;
        }

        public static async Task<string> GetTimeByMarqueeId(string id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return "";
         
                
        }
    }
}
