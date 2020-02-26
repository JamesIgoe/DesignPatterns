using System;

namespace DesignPatterns
{
    //simle client interface
    public interface IWcfClient
    {
        IWcfService Service{ get; }
    }

    //simple service interface
    public interface IWcfService
    {
        string Host { get; set; }
        string Port { get; set; }

        string Connect();
        void Detach();
    }

    //client factory
    public class WcfClient : IWcfClient
    {
        public IWcfService Service { get; set; } 
        private readonly IWcfClient _Client;
        public WcfClient(string name)
        {
            switch (name)
            {
                case "Excel":
                    _Client = new WcfClientForExcel();
                    break;
                case "Other":
                    _Client = new WcfClientForApps();
                    break;
                default:
                    _Client = new WcfClientForApps();
                    break;
            }
            Service = _Client.Service;       
        }
    }

    //implementation of one client
    public class WcfClientForExcel : IWcfClient
    {
        public IWcfService Service { get; set;  } = new WcfService("ExcelServer", "9056");        
        public WcfClientForExcel()
        {
            Service.Connect();
        }
    }

    //imlementation of second client
    public class WcfClientForApps : IWcfClient
    {
        public IWcfService Service { get; set; } = new WcfService("AppServer", "9057");
        public WcfClientForApps()
        {
            Service.Connect();
        }
    }

    //service implementation
    public class WcfService : IWcfService
    {
        public string Host { get; set; } 
        public string Port { get; set; } 

        public WcfService(string host, string port)
        {
            Host = host;
            Port = port;
        }

        public string Connect()
        {
            //code here to start channel

            //dummy code to return value
            //would show different values depending on which client attached to it.
            return string.Format("{0}:{1}", Host, Port);
        }

        public void Detach()
        {
            //code here to disconnect client
        }
    }

    //calling application
    //its type defiens which service type is returned
    public class Application
    {
        public Application()
        {
            string name = this.GetType().Name;
            WcfClient client = new WcfClient(name);
            string connectedTo = client.Service.Connect();
            Console.WriteLine(connectedTo);
        }
    }
}
