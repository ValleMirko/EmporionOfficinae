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
using System.Text.RegularExpressions;
using System.IO;
using System.Data.Odbc;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;

namespace EmporionOfficina
{
    public partial class gestioneProdotti : System.Web.UI.Page
    {
        private DataTable prodotti = new DataTable();
        private DataTable categorie = new DataTable();
        private DataTable utente = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            adoNet.impostaConnessione("App_Data/Carrello.mdf");

            if (Session["codiceUtente"] != null)
            {
                string strSQL = "select Nome, Cognome from Utenti where IDUtente = " + Session["codiceUtente"];
                adoNet adoWeb = new adoNet();

                utente = adoWeb.eseguiQuery(strSQL, CommandType.Text);

                lblUtente.Text = utente.Rows[0].ItemArray[0].ToString() + " " + utente.Rows[0].ItemArray[1].ToString();
            }

            if (Session["codiceUtente"] == null)
                Response.Redirect("errore.aspx?errore=1");
            else if (Session["tipoUtente"].ToString() == "USR" || Session["tipoUtente"] == null)
                Response.Redirect("errore.aspx?errore=2");

            if (Session["tipoUtente"].ToString() == "ADM")
            {
                cmbAdmin.Visible = true;
                btnLogout.Visible = false;
            }

            if (!Page.IsPostBack)
            {
                caricaCmbCategorie();
                lblErrore.Visible = false;
                tab.Visible = true;
                divNewProd.Visible = false;
            }

            if (divNewProd.Visible == true || divModifica.Visible == true)
            {

            }
            else
            {
                caricaTabellaProdotti();
            }                 
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["codiceUtente"] = null;
            Session["tipoUtente"] = null;
            Session["emailUtente"] = null;
            Response.Redirect("default.aspx");          
        }
        
        private void caricaTabellaProdotti()
        {
            string strSQL = "select Prodotti.IDProdotto, Prodotti.NomeProdotto, Prodotti.Descrizione,Prodotti.Immagine, Prodotti.Prezzo, Categorie.NomeCategoria from (Prodotti inner join Categorie on Categorie.IDCategoria = Prodotti.IDCategoria) where Prodotti.IDFornitore = " + Session["codiceUtente"] + " AND Prodotti.Validita = '1' order by Prodotti.IDProdotto desc";
            adoNet adoWeb = new adoNet();

            prodotti = adoWeb.eseguiQuery(strSQL, CommandType.Text);

            if (prodotti.Rows.Count > 0)
            {
                tab.Visible = true;
                contenutoTab.Visible = true;
                HtmlGenericControl tr;
                HtmlGenericControl tdGestione;
                HtmlGenericControl tdNome;
                HtmlGenericControl tdDescrizione;
                HtmlGenericControl tdImmagine;
                HtmlGenericControl tdPrezzo;
                HtmlGenericControl tdCategoria;
                HtmlGenericControl br;
                HtmlGenericControl ul;

                for (int i = 0; i < prodotti.Rows.Count; i++)
                {
                    br = new HtmlGenericControl("br");
                    tr = new HtmlGenericControl("tr");
                    tr.Style.Add("border-bottom", "2px solid white");
                    tdGestione = new HtmlGenericControl("td");
                    tdGestione.Style.Add("border", "none");
                    tdNome = new HtmlGenericControl("td");
                    tdNome.Style.Add("border", "none");
                    tdDescrizione = new HtmlGenericControl("td");
                    tdDescrizione.Style.Add("border", "none");
                    tdImmagine = new HtmlGenericControl("td");
                    tdImmagine.Style.Add("border", "none");
                    tdPrezzo = new HtmlGenericControl("td");
                    tdPrezzo.Style.Add("border", "none");
                    tdCategoria = new HtmlGenericControl("td");
                    tdCategoria.Style.Add("border", "none");

                    ul = new HtmlGenericControl("ul");
                    ul.Attributes.Add("class", "action-list");

                    tdNome.InnerText = Convert.ToString(prodotti.Rows[i].ItemArray[1]);
                    tdDescrizione.InnerText = Convert.ToString(prodotti.Rows[i].ItemArray[2]);
                    tdImmagine.InnerText = Convert.ToString(prodotti.Rows[i].ItemArray[3]);
                    tdPrezzo.InnerText = Convert.ToString(prodotti.Rows[i].ItemArray[4]);
                    tdCategoria.InnerText = Convert.ToString(prodotti.Rows[i].ItemArray[5]);

                    LinkButton btnModifica = new LinkButton();
                    Label lblModifica = new Label();
                    btnModifica.Attributes.Add("runat", "server");
                    btnModifica.Attributes.Add("class", "account");
                    btnModifica.ID = "modifica_" + Convert.ToString(prodotti.Rows[i].ItemArray[0]);
                    btnModifica.Style.Add("background-color", "rgb(81,7,64)");
                    lblModifica.Attributes.Add("runat", "server");
                    lblModifica.Attributes.Add("class", "fa fa-pen");
                    btnModifica.Click += new EventHandler(btnModifica_Click);

                    LinkButton btnElimina = new LinkButton();
                    Label lblElimina = new Label();
                    btnElimina.Attributes.Add("runat", "server");
                    btnElimina.Attributes.Add("class", "account");
                    btnElimina.ID = "elimina_" + Convert.ToString(prodotti.Rows[i].ItemArray[0]);
                    btnElimina.Style.Add("background-color", "rgb(81,7,64)");
                    lblElimina.Attributes.Add("runat", "server");
                    lblElimina.Attributes.Add("class", "fa fa-trash");
                    btnElimina.Click += new EventHandler(btnElimina_Click);

                    contenutoTab.Controls.Add(tdGestione);
                    tdGestione.Controls.Add(btnModifica);
                    tdGestione.Controls.Add(btnElimina);
                    tdGestione.Attributes.Add("class", "d-flex justify-content-center");
                    //tdGestione.Controls.Add(ul);
                    btnModifica.Controls.Add(lblModifica);
                    btnElimina.Controls.Add(lblElimina);
                    contenutoTab.Controls.Add(tdNome);
                    contenutoTab.Controls.Add(tdDescrizione);
                    contenutoTab.Controls.Add(tdImmagine);
                    contenutoTab.Controls.Add(tdPrezzo);
                    contenutoTab.Controls.Add(tdCategoria);
                    contenutoTab.Controls.Add(tr);

                }
            }
            else
            {
                tab.Visible = false;
                lblErrore.Text = "Non ci sono prodotti da mostrare";
                lblErrore.ForeColor = Color.Red;
                lblErrore.Visible = true;         
            }
            
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            tab.Visible = false;
            LinkButton who = (LinkButton)sender;
            string idProdotto = (who.ID).Split('_')[1];

            lblIdProd.Text = idProdotto;
            string strSQL = @"SELECT * FROM Prodotti WHERE IDProdotto = " + idProdotto;
            adoNet adoWeb = new adoNet();

            prodotti = adoWeb.eseguiQuery(strSQL, CommandType.Text);

            txtNomeMod.Text = Convert.ToString(prodotti.Rows[0].ItemArray[1]);
            txtDescrMod.Text = Convert.ToString(prodotti.Rows[0].ItemArray[2]);
            txtPrezzoMod.Text = Convert.ToString(prodotti.Rows[0].ItemArray[4]);
            chkFileMod.Checked = false;

            if (Convert.ToString(prodotti.Rows[0].ItemArray[5]) == "1")
            {
                chkValiditaMod.Checked = true;
            }
            else
            {
                chkValiditaMod.Checked = false;
            }

            cmbCategoriaMod.SelectedItem.Value = Convert.ToString(prodotti.Rows[0].ItemArray[6]);

            divModifica.Visible = true;
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            LinkButton who = (LinkButton)sender;
            string idProdotto = (who.ID).Split('_')[1];

            string strSQL = @"UPDATE Prodotti SET Validita = '0' WHERE IDProdotto = " + idProdotto;
            adoNet adoWeb = new adoNet();

            try
            {
                adoWeb.eseguiNonQuery(strSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                Response.Redirect("errore.aspx?errore=2");
            }

            caricaTabellaProdotti();
        }

        protected void btnNuovoProdotto_Click(object sender, EventArgs e)
        {
            divModifica.Visible = false;
            lblErrore.Visible = false;
            lblErroreInserimento.Visible = false;
            divNewProd.Visible = true;
            tab.Visible = false;
            txtNomeProd.Text = String.Empty;
            txtDescrProd.Text = String.Empty;
            txtPrezzoProd.Text = String.Empty;
            chkValidita.Checked = true;
            cmbCategorie.SelectedIndex = -1;
        }

        protected void btnAggiungi_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");

            if (fileUp.FileName != string.Empty)
            {
                fileUp.PostedFile.SaveAs(Server.MapPath("IMG/") + fileUp.FileName);
                try
                {
                    fileUp.PostedFile.SaveAs(Server.MapPath("IMG/") + fileUp.FileName);
                }
                catch (Exception ex)
                {
                    lblErroreInserimento.Visible = true;
                    lblErroreInserimento.Text = "Immagine non valida: " + ex.Message;
                    lblErroreInserimento.ForeColor = Color.Red;
                    fileUp.Focus();
                }
            }

            if (fileUp.FileName == string.Empty || fileUp.FileName.Contains("'") || fileUp.FileName.Contains("\""))
            {
                lblErroreInserimento.Visible = true;
                lblErroreInserimento.Text = "Immagine non valida.";
                lblErroreInserimento.ForeColor = Color.Red;
                fileUp.Focus();
            }           
            else if (txtNomeProd.Text == string.Empty || txtNomeProd.Text.Contains("'") || txtNomeProd.Text.Contains("\""))
            {
                lblErroreInserimento.Visible = true;
                lblErroreInserimento.Text = "Nome non valido.";
                lblErroreInserimento.ForeColor = Color.Red;
                txtNomeProd.Focus();
            }
            else if (txtDescrProd.Text == string.Empty || txtDescrProd.Text.Contains("'") || txtDescrProd.Text.Contains("\""))
            {
                lblErroreInserimento.Visible = true;
                lblErroreInserimento.Text = "Descrizione non valida.";
                lblErroreInserimento.ForeColor = Color.Red;
                txtDescrProd.Focus();
            }           
            else if (txtPrezzoProd.Text == string.Empty || txtValid.Text == "Prezzo non valido" || !Regex.IsMatch(txtPrezzoProd.Text.ToString(), @"^-?[0-9][0-9,\.]+$") || txtPrezzoProd.Text.Contains("-") )
            {
                lblErroreInserimento.Visible = true;
                lblErroreInserimento.Text = "Prezzo non valido.";
                lblErroreInserimento.ForeColor = Color.Red;
                txtPrezzoProd.Focus();

                //   /^\d*\.?\d*$/       || !Regex.IsMatch(txtPrezzoProd.Text.ToString(), @"/^\d*\.?\d*$/")
            }
            else if (cmbCategorie.SelectedItem.Value == string.Empty || cmbCategorie.SelectedIndex == -1)
            {
                lblErroreInserimento.Visible = true;
                lblErroreInserimento.Text = "Categoria non valida.";
                lblErroreInserimento.ForeColor = Color.Red;
                cmbCategorie.Focus();
            }
            else
            {
                int validita;
                
                if(chkValidita.Checked)
                {
                    validita = 1;
                }
                else
                {
                    validita = 0;
                }

                string strSQL = @"insert into Prodotti (NomeProdotto, Descrizione, Immagine, Prezzo, Validita, IDCategoria, IDFornitore) values ('" + txtNomeProd.Text + "', '" + txtDescrProd.Text + "', '" + fileUp.PostedFile.FileName.ToString() + "', '" + txtPrezzoProd.Text.ToString().Replace(',', '.') + "' , '" + validita.ToString() + "' , " + Convert.ToInt32(cmbCategorie.SelectedItem.Value) + ", " + Session["codiceUtente"] + ")";
                adoNet adoWeb = new adoNet();

                try
                {
                    adoWeb.eseguiNonQuery(strSQL, CommandType.Text);
                }
                catch (Exception ex)
                {
                    lblErroreInserimento.Visible = true;
                    lblErroreInserimento.Text = "Errore nell'esecuzione della query: " + ex.Message;
                    lblErroreInserimento.ForeColor = Color.Red;
                }

                lblErroreInserimento.Visible = true;
                lblErroreInserimento.Text = "Prodotto inserito con successo.";
                lblErroreInserimento.ForeColor = Color.Green;
            }
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            lblErrore.Visible = true;
            divNewProd.Visible = false;
            tab.Visible = true;
            txtNomeProd.Text = String.Empty;
            txtDescrProd.Text = String.Empty;
            txtPrezzoProd.Text = String.Empty;
            chkValidita.Checked = true;
            cmbCategorie.SelectedIndex = -1;
            contenutoTab.Visible = true;

            caricaTabellaProdotti();
        }
        
        private void caricaCmbCategorie()
        {
            categorie.Clear();
            string strSQL = @"select IDCategoria, NomeCategoria from Categorie where Validita = '1'";
            adoNet adoWeb = new adoNet();

            categorie = adoWeb.eseguiQuery(strSQL, CommandType.Text);

            cmbCategorie.DataSource = categorie;
            cmbCategorie.DataTextField = "NomeCategoria";
            cmbCategorie.DataValueField = "IDCategoria";
            cmbCategorie.DataBind();

            cmbCategoriaMod.DataSource = categorie;
            cmbCategoriaMod.DataTextField = "NomeCategoria";
            cmbCategoriaMod.DataValueField = "IDCategoria";
            cmbCategoriaMod.DataBind();
        }

        protected void btnModificaProd_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^-?[0-9][0-9,\.]+$");

            if (chkFileMod.Checked)
            {
                if (fileUpMod.FileName != string.Empty)
                {
                    fileUpMod.PostedFile.SaveAs(Server.MapPath("IMG/") + fileUpMod.FileName);
                    try
                    {
                        fileUpMod.PostedFile.SaveAs(Server.MapPath("IMG/") + fileUpMod.FileName);
                    }
                    catch (Exception ex)
                    {
                        lblErroreModifica.Visible = true;
                        lblErroreModifica.Text = "Immagine non valida: " + ex.Message;
                        lblErroreModifica.ForeColor = Color.Red;
                        fileUpMod.Focus();
                    }
                }

                if (fileUpMod.FileName == string.Empty || fileUpMod.FileName.Contains("'") || fileUpMod.FileName.Contains("\""))
                {
                    lblErroreModifica.Visible = true;
                    lblErroreModifica.Text = "Immagine non valida.";
                    lblErroreModifica.ForeColor = Color.Red;
                    fileUpMod.Focus();
                }
            }
            
            if (txtNomeMod.Text == string.Empty || txtNomeMod.Text.Contains("'") || txtNomeMod.Text.Contains("\""))
            {
                lblErroreModifica.Visible = true;
                lblErroreModifica.Text = "Nome non valido.";
                lblErroreModifica.ForeColor = Color.Red;
                txtNomeMod.Focus();
            }
            else if (txtDescrMod.Text == string.Empty || txtDescrMod.Text.Contains("'") || txtDescrMod.Text.Contains("\""))
            {
                lblErroreModifica.Visible = true;
                lblErroreModifica.Text = "Descrizione non valida.";
                lblErroreModifica.ForeColor = Color.Red;
                txtDescrMod.Focus();
            }
            else if (txtPrezzoMod.Text == string.Empty || txtValidMod.Text == "Prezzo non valido" || !Regex.IsMatch(txtPrezzoMod.Text.ToString(), @"^-?[0-9][0-9,\.]+$") || txtPrezzoMod.Text.Contains("-"))
            {
                lblErroreModifica.Visible = true;
                lblErroreModifica.Text = "Prezzo non valido.";
                lblErroreModifica.ForeColor = Color.Red;
                txtPrezzoMod.Focus();

                //   /^\d*\.?\d*$/       || !Regex.IsMatch(txtPrezzoProd.Text.ToString(), @"/^\d*\.?\d*$/")
            }
            else if (cmbCategoriaMod.SelectedItem.Value == string.Empty || cmbCategoriaMod.SelectedIndex == -1)
            {
                lblErroreModifica.Visible = true;
                lblErroreModifica.Text = "Categoria non valida.";
                lblErroreModifica.ForeColor = Color.Red;
                cmbCategoriaMod.Focus();
            }
            else
            {
                int validita;

                if (chkValiditaMod.Checked)
                {
                    validita = 1;
                }
                else
                {
                    validita = 0;
                }

                string strSQL = String.Empty;
                adoNet adoWeb = new adoNet();
                string idProdotto = lblIdProd.Text;

                if (chkFileMod.Checked)
                {
                    strSQL = @"UPDATE Prodotti SET NomeProdotto = '" + txtNomeMod.Text + "', Descrizione = '" + txtDescrMod.Text + "', Immagine = '" + fileUpMod.FileName + "', Prezzo = '" + txtPrezzoMod.Text.ToString().Replace(',', '.') + "', Validita = '" + validita + "', IDCategoria = '" + cmbCategoriaMod.SelectedItem.Value + "' WHERE IDProdotto = " + idProdotto + " ";
                }
                else
                {
                    strSQL = @"UPDATE Prodotti SET NomeProdotto = '" + txtNomeMod.Text + "', Descrizione = '" + txtDescrMod.Text + "', Prezzo = '" + txtPrezzoMod.Text.ToString().Replace(',', '.') + "', Validita = '" + validita.ToString() + "', IDCategoria = " + cmbCategoriaMod.SelectedItem.Value + " WHERE IDProdotto = " + idProdotto + " ";
                }

                try
                {
                    adoWeb.eseguiNonQuery(strSQL, CommandType.Text);

                    lblErroreModifica.Visible = true;
                    lblErroreModifica.Text = "Prodotto modificato con successo.";
                    lblErroreModifica.ForeColor = Color.Green;
                }
                catch (Exception ex)
                {
                    lblErroreModifica.Visible = true;
                    lblErroreModifica.Text = "Errore nell'esecuzione della query: " + ex.Message;
                    lblErroreModifica.ForeColor = Color.Red;
                }               
            }
            
        }

        protected void btnIndietroMod_Click(object sender, EventArgs e)
        {
            lblErroreModifica.Visible = false;
            divModifica.Visible = false;
            tab.Visible = true;
            caricaTabellaProdotti();          
        }

        protected void btnProdotti_Click(object sender, EventArgs e)
        {
            Response.Redirect("gestioneProdotti.aspx");
        }

        protected void btnAndamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("andamentoProdotti.aspx");
        }

        protected void cmbAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbAdmin.SelectedItem.Value.ToString())
            {
                case "0":
                    break;
                case "Admin":
                    Response.Redirect("pagPrincipaleAdmin.aspx");
                    break;
                case "Utente":
                    Response.Redirect("visualizzazioneProdotti.aspx");
                    break;
                case "Fornitore":
                    Response.Redirect("gestioneProdotti.aspx");
                    break;
                case "Logout":
                    Session["codiceUtente"] = null;
                    Session["tipoUtente"] = null;
                    Session["emailUtente"] = null;
                    Response.Redirect("default.aspx");
                    break;
                default:
                    break;
            }
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("modificaAccount.aspx");
        }
    }
}