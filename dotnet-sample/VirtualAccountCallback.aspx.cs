using System;
using System.Web;
using System.Web.Services;
using System.Web.UI;


public partial class VirtualAccountCallback : Page
{
    [WebMethod]
    public static string Process(string status, string orderId, string secret)
    {
        if (status == "DONE")
        {
            // handle deposit result

            Console.WriteLine(status);
            Console.WriteLine(orderId);
            Console.WriteLine(secret);
        }

        return "ok";
    }
}

