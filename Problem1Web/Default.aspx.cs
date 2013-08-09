using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonEnviar_Click(object sender, EventArgs e)
    {
        ServiceReference1.ServiceProblem1Client service = new ServiceReference1.ServiceProblem1Client();
        LabelResult.Text = service.RegisterClient(TextBoxNome.Text, TextBoxEmail.Text, TextBoxData.Text, TextBoxCelular.Text, TextBoxTelefone.Text).Replace("\n", "<br/>");
    }
}