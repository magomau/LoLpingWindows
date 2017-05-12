using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace PingLoL
{
    class SendPing
    {
        public string regionLOL;
        public SendPing(string rg)
        {
            regionLOL = rg;
        }

        public String SenderPing (string region)
        {
            string ping = "0";
            string IpAddress;
            bool pingBool = false;
            ServerIdAddreess sIP = new ServerIdAddreess();

            IpAddress = sIP.SendRealAddress(region);

            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(IpAddress, 1000);
                pingBool = reply.Status == IPStatus.Success;
                if (pingBool)
                {
                    //ping = pingBool.ToString() + " " + reply.RoundtripTime.ToString() + "ms";
                    ping = reply.RoundtripTime.ToString() + " " + "ms";
                    //Console.WriteLine("Direccion: {0}", reply.Address.ToString());
                    //Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime + "ms"); // tiempo de respuesta mas conocido como "MS"
                    //Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                    //Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    //Console.WriteLine("Buffer size: {0}", reply.Buffer.Length); //Ni puta idea que es
                }

            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }


            return ping;
        }

        public int ColorType(string ping)
        {
            int color = 0;
            int numer = 0;
            string[] separate;

            separate = ping.Split(' ');
            numer = Int32.Parse(separate[0]);
            if (numer <= 70)
            {
                color = 1;//"#36ff33"; //green
            }
            else if ((numer > 70) && (numer <= 160))
            {
                color = 2; //"#ff7433"; //orange
            }
            else {
                color = 3; //"#f90f0f"; //red
            }
            return color;
        }
    }
}
