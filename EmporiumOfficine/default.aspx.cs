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
using System.Security.Cryptography;

namespace EmporiumOfficine
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //btnUser.Attributes.Add("class", " btnSel account");
                //btnAdmin.Attributes.Add("class", " account");
                //btnFornitore.Attributes.Add("class", " account");
                //btnAdmin.Attributes.Remove("btnSel");
                //btnAdmin.ControlStyle.CssClass = "account ";
                //btnFornitore.ControlStyle.CssClass = "account ";
                //lblTipo.Text = "Login Utente";
                //lblAcc.Text = "Non hai un account Utente?";
                divReg.Visible = true;
                divRegistrazione.Visible = false;
                lblErroreLog.Text = string.Empty;
                lblErroreReg.Text = string.Empty;
                adoNet.impostaConnessione("App_Data/Carrello.mdf");
            }
        }

        /*protected void btnAdmin_Click(object sender, EventArgs e)
        {
            btnAdmin.Attributes.Add("class", " btnSel account");
            btnUser.Attributes.Add("class", " account");
            btnFornitore.Attributes.Add("class", " account");
            lblTipo.Text = "Login Admin";
            divReg.Visible = false;
            divRegistrazione.Visible = false;
            lblErroreLog.Text = string.Empty;
            lblErroreReg.Text = string.Empty;            
        }

        protected void btnFornitore_Click(object sender, EventArgs e)
        {
            btnFornitore.Attributes.Add("class", " btnSel account");
            btnUser.Attributes.Add("class", " account");
            btnAdmin.Attributes.Add("class", " account");
            lblTipo.Text = "Login Fornitore";
            lblAcc.Text = "Non hai un account Fornitore?";
            divReg.Visible = true;
            divRegistrazione.Visible = false;
            lblErroreLog.Text = string.Empty;
            lblErroreReg.Text = string.Empty;
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            btnUser.Attributes.Add("class", " btnSel account");
            btnAdmin.Attributes.Add("class", " account");
            btnFornitore.Attributes.Add("class", " account");
            lblTipo.Text = "Login Utente";
            lblAcc.Text = "Non hai un account Utente?";
            divReg.Visible = true;
            divRegistrazione.Visible = false;
            lblErroreLog.Text = string.Empty;
            lblErroreReg.Text = string.Empty;
        }*/

        protected void btnReg_Click(object sender, EventArgs e)
        {
            divLog.Visible = false;
            divRegistrazione.Visible = true;
            lblErroreLog.Text = string.Empty;
            lblErroreReg.Text = string.Empty;

            /*if (lblTipo.Text == "Login Utente")
                lblTitolo.Text = "Registrazione Utente";
            else if (lblTipo.Text == "Login Fornitore")
                lblTitolo.Text = "Registrazione Fornitore";*/

            txtCittaReg.Text = string.Empty;
            txtEmailReg.Text = string.Empty;
            txtIndirizzoReg.Text = string.Empty;
            txtNomeReg.Text = string.Empty;
            txtCognomeReg.Text = string.Empty;
            txtPasswordReg.Text = string.Empty;
        }

        protected void btnTornaLog_Click(object sender, EventArgs e)
        {
            divRegistrazione.Visible = false;
            divLog.Visible = true;
            lblErroreLog.Text = string.Empty;
            lblErroreReg.Text = string.Empty;
        }

        protected void btnRegistrati_Click(object sender, EventArgs e)
        {
            if (txtEmailReg.Text == string.Empty || txtEmailReg.Text.Contains("'") || txtEmailReg.Text.Contains("\""))
            {
                lblErroreReg.Text = "Email non valida.";
                lblErroreReg.ForeColor = Color.Red;
                txtEmailReg.Focus();
            }
            else if (txtPasswordReg.Text == string.Empty || txtPasswordReg.Text.Contains("'") || txtPasswordReg.Text.Contains("\""))
            {
                lblErroreReg.Text = "Password non valida.";
                lblErroreReg.ForeColor = Color.Red;
                txtPasswordReg.Focus();
            }
            else if (txtNomeReg.Text == string.Empty || txtNomeReg.Text.Contains("'") || txtNomeReg.Text.Contains("\""))
            {
                lblErroreReg.Text = "Nome non valido.";
                lblErroreReg.ForeColor = Color.Red;
                txtNomeReg.Focus();
            }
            else if (txtCognomeReg.Text == string.Empty || txtCognomeReg.Text.Contains("'") || txtCognomeReg.Text.Contains("\""))
            {
                lblErroreReg.Text = "Cognome non valido.";
                lblErroreReg.ForeColor = Color.Red;
                txtCognomeReg.Focus();
            }
            else if (txtIndirizzoReg.Text == string.Empty || txtIndirizzoReg.Text.Contains("'") || txtIndirizzoReg.Text.Contains("\""))
            {
                lblErroreReg.Text = "Indirizzo non valido.";
                lblErroreReg.ForeColor = Color.Red;
                txtIndirizzoReg.Focus();
            }
            else if (txtCittaReg.Text == string.Empty || txtCittaReg.Text.Contains("'") || txtCittaReg.Text.Contains("\""))
            {
                lblErroreReg.Text = "Città non valida.";
                lblErroreReg.ForeColor = Color.Red;
                txtCittaReg.Focus();
            }
            else
            {
                //string labelTitolo = lblTitolo.Text.Split(' ')[1];
                string tipo = string.Empty;

                if (chkTipoReg.Checked == false)
                    tipo = "USR";
                else if (chkTipoReg.Checked == true)
                    tipo = "FOR";

                string strSQL = string.Empty;
                adoNet adoWeb = new adoNet();

                strSQL = @"SELECT Count(*) FROM Utenti where Email = '" + txtEmailReg.Text.ToString() + "'";
                int numMail = Convert.ToInt32(adoWeb.eseguiScalar(strSQL, CommandType.Text));

                if (numMail == 0)
                {
                    strSQL = @"INSERT INTO Utenti (Email, Password, Nome, Cognome, Indirizzo, Citta, TipoUtente) VALUES ('" + txtEmailReg.Text + "', '" + calcolaMD5(txtPasswordReg.Text) + "', '" + txtNomeReg.Text + "', '" + txtCognomeReg.Text + "', '" + txtIndirizzoReg.Text + "', '" + txtCittaReg.Text + "', '" + tipo + "')";

                    try
                    {
                        if (adoWeb.eseguiNonQuery(strSQL, CommandType.Text) != -1)
                        {
                            lblErroreLog.Text = "Registrazione avvenuta con successo!";
                            lblErroreLog.ForeColor = Color.Green;
                            divRegistrazione.Visible = false;
                            divLog.Visible = true;
                        }
                        else
                        {
                            lblErroreReg.Text = "Errore nella Registrazione!";
                            lblErroreReg.ForeColor = Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblErroreReg.Text = "ATTENZIONE: " + ex.Message;
                    }
                }
                else
                {
                    lblErroreReg.Text = "Email già presente.";
                }

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //string labelTipo = lblTipo.Text.Split(' ')[1];
            string tipo = string.Empty;

            /*switch (labelTipo)
            {
                case "User":
                    tipo = "USR";
                    break;
                case "Admin":
                    tipo = "ADM";
                    break;
                case "Fornitore":
                    tipo = "FOR";
                    break;
                default:
                    tipo = "USR";
                    break;
            }*/

            string strSQL = string.Empty;
            adoNet adoWeb = new adoNet();
            //string codice = string.Empty;
            DataTable utente = new DataTable();

            lblErroreLog.Text = string.Empty;
            if (txtEmailLog.Text == string.Empty)
            {
                lblErroreLog.Text = "Email non valida.";
                lblErroreLog.ForeColor = Color.Red;
                txtEmailLog.Focus();
            }
            else if (txtPasswordLog.Text == string.Empty)
            {
                lblErroreLog.Text = "Password non valida.";
                lblErroreLog.ForeColor = Color.Red;
                txtPasswordLog.Focus();
            }
            else
            {
                if (txtEmailLog.Text.Contains("'") || txtEmailLog.Text.Contains("\"") ||
                        txtPasswordLog.Text.Contains("'") || txtPasswordLog.Text.Contains("\""))
                {
                    lblErroreLog.Text = "Caratteri non validi";
                    return;
                }

                strSQL = @"select IDUtente, Email, TipoUtente from Utenti " +
                          " where Email = '" + txtEmailLog.Text + "' and " +
                          " Password = '" + calcolaMD5(txtPasswordLog.Text) + "'";

                utente = adoWeb.eseguiQuery(strSQL, CommandType.Text);

                if (utente.Rows.Count == 0)
                    lblErroreLog.Text = "Email o Password non validi.";
                else
                {
                    Session["codiceUtente"] = utente.Rows[0].ItemArray[0].ToString();
                    Session["tipoUtente"] = utente.Rows[0].ItemArray[2].ToString();
                    Session["emailUtente"] = utente.Rows[0].ItemArray[1].ToString();

                    if (Session["tipoUtente"].ToString() == "USR")
                        Response.Redirect("visualizzazioneProdotti.aspx");
                    else if (Session["tipoUtente"].ToString() == "ADM")
                        Response.Redirect("pagPrincipaleAdmin.aspx");
                    else if (Session["tipoUtente"].ToString() == "FOR")
                        Response.Redirect("gestioneProdotti.aspx");
                }
            }
        }

        private string calcolaMD5(string strIN)
        {
            string ris = string.Empty;
            Byte[] buf1;
            Byte[] buf2;
            int I = 0;

            MD5CryptoServiceProvider md5OBJ = new MD5CryptoServiceProvider();

            // STEP 1 - Serializzo la STRINGA di Input
            buf1 = new Byte[strIN.Length];
            foreach (char c in strIN)
                buf1[I++] = Convert.ToByte(c);

            // STEP 2 - Converto in MD5

            /*
             * computeHash : riceve come Parametro un Stringa Serializzata
             *               e restituisce la corrispondente stringa 
             *               MD5 (sempre Serializzata !!!)
             */
            buf2 = md5OBJ.ComputeHash(buf1);

            // STEP 3 - Deserializzo il Buffer MD5
            foreach (Byte b in buf2)
            {
                ris += b.ToString("X2");
            }

            return ris;
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            divRegistrazione.Visible = false;
            divLog.Visible = true;
        }
    }
}