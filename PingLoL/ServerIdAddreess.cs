using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingLoL
{
    class ServerIdAddreess
    {

        public string SendRealAddress(string region)
        {
            string realAddress ="noExiste";
            switch (region)
            {
                case "NA":
                    realAddress = "104.160.131.3";
                    break;
                case "LAS":
                    realAddress = "las.leagueoflegends.com"; //104.16.0.92
                    break;
                case "LAN":
                    realAddress = "104.160.136.3";
                    //66.151.33.4, 66.151.33.5, 66.151.33.6, 66.151.33.7, 66.151.33.9, 66.151.33.10, 66.151.33.11--> posibles IP rutados por el "tracert"
                    break;
                case "EUW":
                    realAddress = "104.160.141.3";
                    break;
                case "BR":
                    realAddress = "104.160.152.3";
                    break;
                case "OCE":
                    realAddress = "104.160.156.1";
                    break;
                default:
                    realAddress = "www.google.com";
                    break;
            }

            return realAddress;
        }
    }
}
