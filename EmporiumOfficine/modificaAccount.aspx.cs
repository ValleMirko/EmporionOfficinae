using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using adoNetWebSQlServer;
using System.Data;
using System.Drawing;

namespace EmporiumOfficine
{
    public partial class modificaAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["codiceUtente"] == null)
                Response.Redirect("errore.aspx?errore=1");

            if (!Page.IsPostBack)
            {
                caricaDati();
            }
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            Session["codiceUtente"] = null;
            Session["tipoUtente"] = null;
            Session["emailUtente"] = null;
            Response.Redirect("default.aspx");
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == string.Empty || txtEmail.Text.Contains("'") || txtEmail.Text.Contains("\""))
            {
                lblErrore.Text = "Email non valida.";
                lblErrore.ForeColor = Color.Red;
                txtEmail.Focus();
            }
            else if (txtNome.Text == string.Empty || txtNome.Text.Contains("'") || txtNome.Text.Contains("\""))
            {
                lblErrore.Text = "Nome non valido.";
                lblErrore.ForeColor = Color.Red;
                txtNome.Focus();
            }
            else if (txtCognome.Text == string.Empty || txtCognome.Text.Contains("'") || txtCognome.Text.Contains("\""))
            {
                lblErrore.Text = "Cognome non valido.";
                lblErrore.ForeColor = Color.Red;
                txtCognome.Focus();
            }
            else if (txtIndirizzo.Text == string.Empty || txtIndirizzo.Text.Contains("'") || txtIndirizzo.Text.Contains("\""))
            {
                lblErrore.Text = "Indirizzo non valido.";
                lblErrore.ForeColor = Color.Red;
                txtIndirizzo.Focus();
            }
            else if (txtCitta.Text == string.Empty || txtCitta.Text.Contains("'") || txtCitta.Text.Contains("\""))
            {
                lblErrore.Text = "Città non valida.";
                lblErrore.ForeColor = Color.Red;
                txtCitta.Focus();
            }
            else
            {
                string strSQL = string.Empty;
                adoNet adoWeb = new adoNet();

                strSQL = @"SELECT Count(*) FROM Utenti where Email = '" + txtEmail.Text.ToString() + "'";
                int numMail = Convert.ToInt32(adoWeb.eseguiScalar(strSQL, CommandType.Text));

                if (numMail == 0)
                {
                    strSQL = @"UPDATE Utenti SET Email='" + txtEmail.Text + "', Nome='" + txtNome.Text + "', Cognome='" + txtCognome.Text + "', Indirizzo='" + txtIndirizzo.Text + "',  Citta ='" + txtCitta.Text + "' where IDUtente=" + Convert.ToInt32(Session["codiceUtente"]);

                    try
                    {
                        if (adoWeb.eseguiNonQuery(strSQL, CommandType.Text) != -1)
                        {
                            lblErrore.Text = "Modiica avvenuta con successo!";
                            lblErrore.ForeColor = Color.Green;
                        }
                        else
                        {
                            lblErrore.Text = "Errore nella Modifica!";
                            lblErrore.ForeColor = Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblErrore.Text = "ATTENZIONE: " + ex.Message;
                    }
                }
                else
                {
                    lblErrore.Text = "Email già presente.";
                }
            }
        }

        private void caricaDati()
        {
            string strSQL = string.Empty;
            adoNet adoWeb = new adoNet();
            DataTable dt = new DataTable();

            strSQL = @"SELECT * FROM Utenti WHERE IDUtente = " + Convert.ToInt32(Session["codiceUtente"]);

            try
            {
                dt = adoWeb.eseguiQuery(strSQL, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtNome.Text = dt.Rows[0]["Nome"].ToString();
                    txtCognome.Text = dt.Rows[0]["Cognome"].ToString();
                    txtIndirizzo.Text = dt.Rows[0]["Indirizzo"].ToString();
                    txtCitta.Text = dt.Rows[0]["Citta"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblErrore.Text = "ATTENZIONE: " + ex.Message;
            }
        }
    }
}