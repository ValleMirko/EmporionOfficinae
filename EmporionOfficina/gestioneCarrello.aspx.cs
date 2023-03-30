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
using System.Net.Mail;

namespace EmporionOfficina
{
    public partial class visualizzaCarrello : System.Web.UI.Page
    {
        private DataTable utente = new DataTable();
        private DataTable carrello = new DataTable();
        private DataTable carrelloCompleto = new DataTable();
        private DataTable carrelloVendita = new DataTable();
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
            else if (Session["tipoUtente"].ToString() == "FOR" || Session["tipoUtente"] == null)
                Response.Redirect("errore.aspx?errore=2");

            if (Session["tipoUtente"].ToString() == "ADM")
            {
                cmbAdmin.Visible = true;
                btnLogout.Visible = false;
            }

            if (!Page.IsPostBack)
            {          
                caricaCarrello();
            }

            if (divCarrello.Visible == true)
            {
                caricaCarrello();
            }
        }

        protected void btnProdotti_Click(object sender, EventArgs e)
        {
            Response.Redirect("visualizzazioneProdotti.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["codiceUtente"] = null;
            Session["tipoUtente"] = null;
            Session["emailUtente"] = null;
            Response.Redirect("default.aspx");
        }

        protected void btnConferma_Click(object sender, EventArgs e)
        {
            string strSQL = "DELETE FROM Carrello WHERE IDUtente = " + Session["codiceUtente"];
            adoNet adoWeb = new adoNet();

            try
            {
                adoWeb.eseguiNonQuery(strSQL, CommandType.Text);
                divConferma.Visible = false;
                divCarrello.Visible = true;
                divTotale.Visible = false;
                divFooter.Visible = false;
            }
            catch (Exception ex)
            {
                lblErr.Text = "Errore: " + ex.Message;
            }          
        }

        protected void btnIndietro_Click(object sender, EventArgs e)
        {
            divConferma.Visible = false;
            divCarrello.Visible = true;
            lblErr.Visible = false;

            caricaCarrello();
        }

        private static Random random;
        private static object syncObj = new object();
        private static void InitRandomNumber(int seed)
        {
            random = new Random(seed);
        }
        private static int generaNum()
        {
            lock (syncObj)
            {
                if (random == null)
                    random = new Random(); // Or exception...
                return random.Next(100);
            }
        }

        private void caricaCarrello()
        {
            cardBody.Controls.Clear();
            string strSQL = "SELECT * FROM Carrello WHERE IDUtente = " + Session["codiceUtente"];
            adoNet adoWeb = new adoNet();
            int num;

            carrello.Clear();
            carrello = adoWeb.eseguiQuery(strSQL, CommandType.Text);

            carrelloCompleto.Clear();
            strSQL = @"select Carrello.IDCarrello, Carrello.IDProdotto, Carrello.IDUtente, Carrello.IDFornitore, Carrello.Quantita, Carrello.Prezzo, Prodotti.NomeProdotto, Prodotti.Immagine, Categorie.NomeCategoria, Prodotti.IDCategoria from (Carrello inner join Prodotti on Carrello.IDProdotto = Prodotti.IDProdotto) inner join Categorie on Prodotti.IDCategoria = Categorie.IDCategoria where Carrello.IDUtente = " + Convert.ToInt32(Session["codiceUtente"]);

            try
            {
                carrelloCompleto = adoWeb.eseguiQuery(strSQL, CommandType.Text);
                lblErrore.Visible = false;               
            }
            catch (Exception ex)
            {
                lblErrore.Text = "Errore: " + ex.Message;
                lblErrore.Visible = true;
                divTotale.Visible = true;
                divFooter.Visible = true;
                divCarrello.Visible = true;
            }

            if (carrello.Rows.Count == 0)
            {
                lblCarrello.Text = "Non ci sono prodotti nel carrello";
                imgCarrello.ImageUrl = @"/IMG/icons8-carrello-della-spesa-96.png";
                divTotale.Visible = false;
                divFooter.Visible = false;
                btnSvuota.Visible = false;
                btnAcquista.Visible = false;
            }
            else           
            {
                btnSvuota.Visible = true;
                btnAcquista.Visible = true;
                imgCarrello.ImageUrl = @"~/IMG/icons8-carrello-della-spesa.gif";
                calcolaDettagli();
                
                HtmlGenericControl div1;
                HtmlGenericControl div2;
                HtmlGenericControl div3;
                HtmlGenericControl div4;
                HtmlGenericControl div5;
                HtmlGenericControl div6;
                HtmlGenericControl img;
                HtmlGenericControl div7;
                HtmlGenericControl div8;
                HtmlGenericControl div9;
                HtmlGenericControl h6_1;
                HtmlGenericControl div10;
                HtmlGenericControl small1;
                HtmlGenericControl div11;
                HtmlGenericControl small2;
                HtmlGenericControl div12;
                HtmlGenericControl div13;
                HtmlGenericControl h6_2;
                HtmlGenericControl hr;
                HtmlGenericControl div14;
                HtmlGenericControl div15;
                HtmlGenericControl small3;
                HtmlGenericControl span1;
                HtmlGenericControl i1;
                HtmlGenericControl div16;
                HtmlGenericControl div17;
                HtmlGenericControl div18;
                HtmlGenericControl div19;
                HtmlGenericControl div20;
                HtmlGenericControl span2;
                HtmlGenericControl small4;
                HtmlGenericControl i2;
                HtmlGenericControl div21;
                HtmlGenericControl span3;
                HtmlGenericControl small5;
                HtmlGenericControl i3;
                HtmlGenericControl div22;
                HtmlGenericControl span4;
                HtmlGenericControl small6;
                HtmlGenericControl i4;

                for(int i = 0; i < carrelloCompleto.Rows.Count; i++)
                {
                    num = generaNum();

                    div1 = new HtmlGenericControl("div");
                    div1.ID = "idCarr_" + carrelloCompleto.Rows[i].ItemArray[0].ToString();
                    div1.Attributes.Add("class", "row mt-4");

                    div2 = new HtmlGenericControl("div");
                    div2.Attributes.Add("class", "col");

                    div3 = new HtmlGenericControl("div");
                    div3.Attributes.Add("class", "card card-2");

                    div4 = new HtmlGenericControl("div");
                    div4.Attributes.Add("class", "card-body");

                    div5 = new HtmlGenericControl("div");
                    div5.Attributes.Add("class", "media");

                    div6 = new HtmlGenericControl("div");
                    div6.Attributes.Add("class", "sq align-self-center");

                    img = new HtmlGenericControl("img");
                    img.Attributes.Add("src", "IMG/" + carrelloCompleto.Rows[i].ItemArray[7].ToString());
                    img.Attributes.Add("class", "img-fluid my-auto align-self-center mx-auto");
                    img.Style.Add("width", "135px");

                    div7 = new HtmlGenericControl("div");
                    div7.Attributes.Add("class", "media-body my-auto text-right");

                    div8 = new HtmlGenericControl("div");
                    div8.Attributes.Add("class", "row my-auto flex-column flex-md-row");

                    div9 = new HtmlGenericControl("div");
                    div9.Attributes.Add("class", "col my-auto");

                    h6_1 = new HtmlGenericControl("h6");
                    h6_1.Attributes.Add("class", "mb-0");
                    h6_1.InnerText = carrelloCompleto.Rows[i].ItemArray[6].ToString();

                    div10 = new HtmlGenericControl("div");
                    div10.Attributes.Add("class", "col-auto my-auto");

                    small1 = new HtmlGenericControl("small");
                    small1.InnerText = carrelloCompleto.Rows[i].ItemArray[8].ToString();

                    div11 = new HtmlGenericControl("div");
                    div11.Attributes.Add("class", "col my-auto");

                    small2 = new HtmlGenericControl("small");
                    small2.InnerText = carrelloCompleto.Rows[i].ItemArray[4].ToString();

                    div12 = new HtmlGenericControl("div");
                    div12.Attributes.Add("class", "col my-auto");

                    Button btn = new Button();
                    btn.Attributes.Add("runat", "server");
                    btn.Attributes.Add("class", "btn btn-danger");
                    btn.Text = "Elimina 1 Quantità";
                    btn.ID = "elimina_" + carrelloCompleto.Rows[i].ItemArray[0].ToString();
                    btn.Click += new EventHandler(eliminaProdottto_Click);

                    div13 = new HtmlGenericControl("div");
                    div13.Attributes.Add("class", "col my-auto");

                    h6_2 = new HtmlGenericControl("h6");
                    h6_2.Attributes.Add("class", "mb-0");
                    h6_2.InnerText = "€ " + carrelloCompleto.Rows[i].ItemArray[5].ToString();

                    hr = new HtmlGenericControl("hr");
                    hr.Attributes.Add("class", "my-3");

                    div14 = new HtmlGenericControl("div");
                    div14.Attributes.Add("class", "row");

                    div15 = new HtmlGenericControl("div");
                    div15.Attributes.Add("class", "col-md-3 mb-3");

                    small3 = new HtmlGenericControl("small");
                    small3.InnerText = "Stato Ordine";

                    span1 = new HtmlGenericControl("span");

                    i1 = new HtmlGenericControl("i");
                    i1.Attributes.Add("class", "ml-2 fa fa-refresh");
                    i1.Attributes.Add("aria-hidden", "true");

                    div16 = new HtmlGenericControl("div");
                    div16.Attributes.Add("class", "col mt-auto");

                    div17 = new HtmlGenericControl("div");
                    div17.Attributes.Add("class", "progress my-auto");

                    div18 = new HtmlGenericControl("div");
                    div18.Attributes.Add("class", "progress-bar progress-bar rounded");
                    div18.Style.Add("width", num.ToString() + "%");
                    div18.Attributes.Add("role", "progressbar");
                    div18.Attributes.Add("aria-valuenow", num.ToString());
                    div18.Attributes.Add("aria-valuemin", "0");
                    div18.Attributes.Add("aria-valuemax", "100");

                    div19 = new HtmlGenericControl("div");
                    div19.Attributes.Add("class", "media row justify-content-between");

                    div20 = new HtmlGenericControl("div");
                    div20.Attributes.Add("class", "col-auto text-right");

                    span2 = new HtmlGenericControl("span");

                    small4 = new HtmlGenericControl("small");
                    small4.Attributes.Add("class", "text-right mr-sm-2");

                    i2 = new HtmlGenericControl("i");
                    i2.Attributes.Add("class", "fa fa-circle active");

                    div21 = new HtmlGenericControl("div");
                    div21.Attributes.Add("class", "flex-col");

                    span3 = new HtmlGenericControl("span");

                    small5 = new HtmlGenericControl("small");
                    small5.Attributes.Add("class", "text-right mr-sm-2");
                    small5.InnerText = "Ordine in lavorazione";

                    i3 = new HtmlGenericControl("i");
                    i3.Attributes.Add("class", "fa fa-circle active");

                    div22 = new HtmlGenericControl("div");
                    div22.Attributes.Add("class", "col-auto flex-col-auto");

                    span4 = new HtmlGenericControl("span");

                    small6 = new HtmlGenericControl("small");
                    small6.Attributes.Add("class", "text-right mr-sm-2");
                    small6.InnerText = "Consegnato";

                    i4 = new HtmlGenericControl("i");
                    i4.Attributes.Add("class", "fa fa-circle");

                    
                    div1.Controls.Add(div2);
                    div2.Controls.Add(div3);
                    div3.Controls.Add(div4);
                    div4.Controls.Add(div5);
                    div5.Controls.Add(div6);
                    div6.Controls.Add(img);
                    div5.Controls.Add(div7);
                    div7.Controls.Add(div8);
                    div8.Controls.Add(div9);
                    div9.Controls.Add(h6_1);
                    div8.Controls.Add(div10);
                    div10.Controls.Add(small1);
                    div8.Controls.Add(div11);
                    div11.Controls.Add(small2);
                    div8.Controls.Add(div12);
                    div12.Controls.Add(btn);
                    div8.Controls.Add(div13);
                    div13.Controls.Add(h6_2);
                    div4.Controls.Add(hr);
                    div4.Controls.Add(div14);
                    div14.Controls.Add(div15);
                    //.Controls.Add(small3); //
                    small3.Controls.Add(span1);
                    span1.Controls.Add(i1);
                    //div14.Controls.Add(div16); //
                    //div16.Controls.Add(div17); //
                    div17.Controls.Add(div18);
                    div16.Controls.Add(div19);
                    div19.Controls.Add(div20);
                    div20.Controls.Add(span2);
                    span2.Controls.Add(small4);
                    span2.Controls.Add(i2);
                    div19.Controls.Add(div21);
                    div21.Controls.Add(span3);
                    span3.Controls.Add(small5);
                    span3.Controls.Add(i3);
                    div19.Controls.Add(div22);
                    div22.Controls.Add(span4);
                    span4.Controls.Add(small6);
                    span4.Controls.Add(i4);

                    cardBody.Controls.Add(div1);

                    num = generaNum();
                }            
            }
        }

        protected void calcolaDettagli()
        {
            decimal totale = 0;
            decimal prezzoFinale = 0;

            string strSQL = @"SELECT SUM(Prezzo) as PrezzoTotale from Carrello where IDUtente = " + Convert.ToInt32(Session["codiceUtente"]);
            adoNet adoWeb = new adoNet();

            totale = Convert.ToDecimal(adoWeb.eseguiScalar(strSQL, CommandType.Text));

            prezzoFinale = totale + (totale / 100 * 22);

            lblTotale.Text = prezzoFinale.ToString("0.00") + " €";
        }

        private void eliminaProdottto_Click(object sender, EventArgs e)
        {
            Button who = (Button)sender;
            string idCarrello = (who.ID).Split('_')[1];

            string strSQL = @"SELECT Quantita FROM Carrello where IDCarrello = " + Convert.ToInt32(idCarrello);
            adoNet adoWeb = new adoNet();
            
            int quantita = Convert.ToInt32(adoWeb.eseguiScalar(strSQL, CommandType.Text));

            if (quantita > 1)
            {
                strSQL = @"UPDATE Carrello SET Quantita = Quantita-1 where IDCarrello = " + Convert.ToInt32(idCarrello);

                adoWeb.eseguiNonQuery(strSQL, CommandType.Text);
            }
            else 
            {
                strSQL = @"DELETE FROM Carrello where IDCarrello = " + Convert.ToInt32(idCarrello);

                adoWeb.eseguiNonQuery(strSQL, CommandType.Text);
            }
        }

        protected void btnSvuota_Click(object sender, EventArgs e)
        {
            divConferma.Visible = true;
            divCarrello.Visible = false;
        }

        protected void btnAcquista_Click(object sender, EventArgs e)
        {
            divCarrello.Visible = false;
            divAcquista.Visible = true;
        }

        protected void btnIndietroAcquisto_Click(object sender, EventArgs e)
        {
            divAcquista.Visible = false;
            divCarrello.Visible = true;
            Response.Redirect("visualizzazioneProdotti.aspx");
        }

        protected void btnConfermaAcquisto_Click(object sender, EventArgs e)
        {
            if (txtNum.Text == string.Empty || txtNum.Text.Contains("'") || txtNum.Text.Contains("\""))
            {
                lblErroreAcquisto.Text = "Inserire un numero di carta valido";
                lblErroreAcquisto.ForeColor = System.Drawing.Color.Red;
                txtNum.Focus();
            }
            else if (txtNome.Text == string.Empty || txtNome.Text.Contains("'") || txtNome.Text.Contains("\""))
            {
                lblErroreAcquisto.Text = "Inserire un nome valido";
                lblErroreAcquisto.ForeColor = System.Drawing.Color.Red;
                txtNome.Focus();
            }
            else if (txtGiorno.Text == string.Empty || txtGiorno.Text.Contains("'") || txtGiorno.Text.Contains("\""))
            {
                lblErroreAcquisto.Text = "Inserire un giorno valido";
                lblErroreAcquisto.ForeColor = System.Drawing.Color.Red;
                txtGiorno.Focus();
            }
            else if (txtMese.Text == string.Empty || txtMese.Text.Contains("'") || txtMese.Text.Contains("\""))
            {
                lblErroreAcquisto.Text = "Inserire un mese valido";
                lblErroreAcquisto.ForeColor = System.Drawing.Color.Red;
                txtMese.Focus();
            }
            else if (txtAnno.Text == string.Empty || txtAnno.Text.Contains("'") || txtAnno.Text.Contains("\""))
            {
                lblErroreAcquisto.Text = "Inserire un anno valido";
                lblErroreAcquisto.ForeColor = System.Drawing.Color.Red;
                txtAnno.Focus();
            }
            else
            {
                string strSQL;
                string strSQL1;
                string strSQL2;
                string strSQLMailUser;
                string strSQLMailFor;
                string totaleEuro;
                adoNet adoWeb = new adoNet();

                strSQL = @"SELECT * FROM Carrello where IDUtente = " + Convert.ToInt32(Session["codiceUtente"]);
                carrelloVendita = adoWeb.eseguiQuery(strSQL, CommandType.Text);

                strSQLMailUser = @"select Carrello.Quantita, Carrello.Prezzo, Prodotti.NomeProdotto, Prodotti.IDCategoria from (Carrello inner join Prodotti on Prodotti.IDProdotto = Carrello.IDProdotto) where IDUtente =  " + Convert.ToInt32(Session["codiceUtente"]);

                /*strSQL = @"select Vendite.Quantita, Vendite.Prezzo, Prodotti.NomeProdotto from (Vendite inner join Prodotti on Prodotti.IDProdotto = Vendite.IDProdotto) where IDUtente = " + Convert.ToInt32(Session["codiceUtente"]);*/
                DataTable tabMail1 = new DataTable();
                tabMail1 = adoWeb.eseguiQuery(strSQLMailUser, CommandType.Text);

                strSQLMailUser = @"SELECT SUM(Prezzo) as PrezzoTotale from Carrello where IDUtente =" + Convert.ToInt32(Session["codiceUtente"]);
                totaleEuro = adoWeb.eseguiScalar(strSQLMailUser, CommandType.Text).ToString();

                strSQLMailFor = @"select distinct Utenti.Email from (Carrello inner join Utenti on Carrello.IDFornitore = Utenti.IDUtente) where Carrello.IDUtente =" + Convert.ToInt32(Session["codiceUtente"]);
                DataTable tabMail2 = new DataTable();
                tabMail2 = adoWeb.eseguiQuery(strSQLMailFor, CommandType.Text);

                int num;

                for (int i = 0; i < carrelloVendita.Rows.Count; i++)
                {
                    num = generaNum();

                    strSQL1 = @"INSERT INTO Vendite (Data, Quantita, IDProdotto, IDUtente, IDFornitore, IDCategoria, StatoOrdine, Prezzo) VALUES ('" + DateTime.Now.ToString("dd-MM-yyyy") + "'," + Convert.ToInt32(carrelloVendita.Rows[i].ItemArray[5]) + "," + Convert.ToInt32(carrelloVendita.Rows[i].ItemArray[1]) + "," + Convert.ToInt32(Session["codiceUtente"]) + "," + Convert.ToInt32(carrelloVendita.Rows[i].ItemArray[3]) + "," + Convert.ToInt32(carrelloVendita.Rows[i].ItemArray[4]) + "," + num + ",'" + carrelloVendita.Rows[i].ItemArray[6].ToString().Replace(',', '.') + "') ";

                    strSQL2 = @"DELETE FROM Carrello WHERE IDUtente = " + Convert.ToInt32(Session["codiceUtente"]);

                    try
                    {
                        adoWeb.eseguiNonQuery(strSQL1, CommandType.Text);
                        adoWeb.eseguiNonQuery(strSQL2, CommandType.Text);
                        lblErroreAcquisto.Text = "Acquisto effettuato con successo!";
                        lblErroreAcquisto.ForeColor = System.Drawing.Color.Green;
                        btnConfermaAcquisto.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        lblErroreAcquisto.Text = ex.Message;
                        lblErroreAcquisto.ForeColor = System.Drawing.Color.Red;
                    }
                    
                }

                MailMessage mailUsr = new MailMessage();
                MailMessage mailFor = new MailMessage();

                try
                {
                    //email utente

                    // Mittente
                    mailUsr.From = new MailAddress("tests2informatica@gmail.com");

                    // Destinatario - Collections selezionare i fornitori e l'utente
                    mailUsr.To.Add(new MailAddress(Session["emailUtente"].ToString()));

                    // CC - Collections
                    //mail.CC.Add(new MailAddress());

                    // CCN o BCC - Collections
                    mailUsr.Bcc.Add(new MailAddress("g.foti.1308@vallauri.edu"));

                    // Oggetto
                    mailUsr.Subject = "Acquisto Confermato";

                    // Corpo / Testo della Mail
                    mailUsr.IsBodyHtml = true;
                    mailUsr.Body = "<h3>Il tuo acquisto è stato confermato. Riepilogo acquisto:<h3><br/>";

                    for (int i = 0; i < tabMail1.Rows.Count; i++)
                    {
                        mailUsr.Body += "<p><h4> - " + tabMail1.Rows[i].ItemArray[2].ToString() + ", " + tabMail1.Rows[i].ItemArray[0].ToString() + "pezzi ("+ tabMail1.Rows[i].ItemArray[1].ToString() + ")<h3><p>";
                    }

                    mailUsr.Body += "<p><h4>Per un totale di: " + totaleEuro + " euro.<h4><p>";

                    // Priorità
                    mailUsr.Priority = MailPriority.Normal;


                    // Credeziali di Accesso a GMAIL
                    System.Net.NetworkCredential credenziali = new System.Net.NetworkCredential();
                    credenziali.UserName = "tests2informatica@gmail.com";
                    credenziali.Password = "tests2informatica@@";

                    // Imposto SMTP

                    // Secondo Metodo
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587; // 25
                    smtp.Credentials = credenziali;
                    smtp.EnableSsl = true;

                    // Invio la Mail
                    smtp.Send(mailUsr);

                    //lblErroreAcquisto.ForeColor = System.Drawing.Color.Green;
                    //lblErroreAcquisto.Text = "Mail inviata con successo";

                    //email fornitore
                    // Mittente
                    mailFor.From = new MailAddress("tests2informatica@gmail.com");

                    // Destinatario - Collections selezionare i fornitori e l'utente
                    //mailFor.To.Add(new MailAddress(Session["emailUtente"].ToString()));

                    // CC - Collections
                    for(int i = 0; i < tabMail2.Rows.Count; i++)
                        mailFor.CC.Add(new MailAddress(tabMail2.Rows[i].ItemArray[0].ToString()));

                    // CCN o BCC - Collections
                    mailFor.Bcc.Add(new MailAddress("g.foti.1308@vallauri.edu"));

                    // Oggetto
                    mailFor.Subject = "Acquisto Confermato";

                    // Corpo / Testo della Mail
                    mailFor.IsBodyHtml = true;
                    mailFor.Body = "<h4>Un tuo prodotto è stato acquistato.<h4>";

                    // Priorità
                    mailFor.Priority = MailPriority.Normal;

                    // Credeziali di Accesso a GMAIL
                    System.Net.NetworkCredential credenziali1 = new System.Net.NetworkCredential();
                    credenziali1.UserName = "tests2informatica@gmail.com";
                    credenziali1.Password = "tests2informatica@@";

                    // Imposto SMTP
                    
                    SmtpClient smtp1 = new SmtpClient();

                    smtp1.Host = "smtp.gmail.com";
                    smtp1.Port = 587; // 25
                    smtp1.Credentials = credenziali;
                    smtp1.EnableSsl = true;

                    // Invio la Mail
                    smtp1.Send(mailFor);

                    lblErroreAcquisto.ForeColor = System.Drawing.Color.Green;
                    lblErroreAcquisto.Text = "Mail inviata con successo";
                }
                catch (Exception ex)
                {

                    lblErroreAcquisto.ForeColor = System.Drawing.Color.Red;
                    lblErroreAcquisto.Text = "ATTENZIONE: " + ex.Message;

                }
            }                      
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