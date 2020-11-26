using System;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Json;
using System.Text;


public partial class Success : Page
{
    protected const String SecretKey = "test_ak_ZORzdMaqN3wQd5k6ygr5AkYXQGwy";
    protected const String PaymentConfirmUrl = "https://api.tosspayments.com/v1/payments/";

    protected String successData;
    protected String code;
    protected String message;
    protected bool isSuccess;

    protected void Page_Load(object sender, EventArgs e)
    {
        String paymentKey = Request["paymentKey"];

        var payload = new JsonObject();
        payload["orderId"] = Request["orderId"];
        payload["amount"] = Request["amount"];

        var credential = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(SecretKey + ":"));

        HttpClient client = new HttpClient();

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credential);


        var content = new StringContent(payload.ToString(), Encoding.UTF8, "application/json");

        var result = client.PostAsync(PaymentConfirmUrl + paymentKey, content).Result;

        if (result.StatusCode == HttpStatusCode.OK)
        {
            isSuccess = true;
            var successJson = JsonObject.Parse(result.Content.ReadAsStringAsync().Result);

            successData = successJson.ToString();
        } else
        {
            isSuccess = false;
            var failJson = JsonObject.Parse(result.Content.ReadAsStringAsync().Result);

            code = failJson["code"];
            message = failJson["message"];
        }

        client.Dispose();
    }
}

