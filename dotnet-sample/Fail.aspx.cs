using System;
using System.Web;
using System.Web.UI;

public partial class Fail : Page
{
    protected String code;
    protected String message;

    protected void Page_Load(object sender, EventArgs e)
    {
        code = Request["code"];
        message = Request["message"];
    }
}
