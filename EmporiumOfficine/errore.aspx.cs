using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmporiumOfficine
{
	public partial class errore : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string codErrore = string.Empty;

			if (!Page.IsPostBack)
			{
				if (Request.QueryString["errore"] != null)
					codErrore = Request.QueryString["errore"];

				switch (codErrore)
				{
					case "1":
						lblErrore.Text = "Login non effettuato!";
						break;
					case "2":
						lblErrore.Text = "Accesso non autorizzato!";
						break;

					case "3":
						lblErrore.Text = "Errore imprevisto nella query!";
						break;

					default:
						lblErrore.Text = "Assenza di Parametri";
						break;
				}
			}
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			Response.Redirect("default.aspx");
		}
	}
}