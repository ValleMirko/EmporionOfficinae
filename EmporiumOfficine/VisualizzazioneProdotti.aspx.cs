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
    public partial class VisualizzazioneProdotti : System.Web.UI.Page
    {
        private DataTable prodotti = new DataTable();
        private DataTable categorie = new DataTable();
        private DataTable utente = new DataTable();
        private DataTable Quantita = new DataTable();
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

              if (divCarte.Visible == true)
              {
                  caricaCardProdotti(0);
              }
              else
              {
                  caricaStorico();
              }

              if (!Page.IsPostBack)
              {
                  caricaCmbCategorie();
              }
          }

          private void caricaCmbCategorie()
          {
              categorie.Clear();
              string strSQL = @"select distinct Categorie.IDCategoria, Categorie.NomeCategoria from (Categorie inner join Prodotti on Categorie.IDCategoria = Prodotti.IDCategoria)";
              adoNet adoWeb = new adoNet();

              categorie = adoWeb.eseguiQuery(strSQL, CommandType.Text);

              cmbCategorie.DataSource = categorie;
              cmbCategorie.DataTextField = "NomeCategoria";
              cmbCategorie.DataValueField = "IDCategoria";
              cmbCategorie.DataBind();
          }

          private void caricaCardProdotti(int idCat)
          {
              cmbCategorie.Visible = true;
              divCarte.Visible = true;
              prodotti.Clear();
              divCarte.Controls.Clear();
              string strSQL = string.Empty;
              adoNet adoWeb = new adoNet();

              if (idCat == 0)
                  strSQL = @"select Prodotti.IDProdotto, Prodotti.NomeProdotto, Prodotti.Descrizione, Prodotti.Immagine, Prodotti.Prezzo, Prodotti.IDCategoria from Prodotti where Prodotti.Validita = '1'";
              else
                  strSQL = @"select Prodotti.IDProdotto, Prodotti.NomeProdotto, Prodotti.Descrizione, Prodotti.Immagine, Prodotti.Prezzo, Prodotti.IDCategoria from Prodotti where Prodotti.Validita = '1' AND Prodotti.IDCategoria = " + idCat;

              prodotti = adoWeb.eseguiQuery(strSQL, CommandType.Text);

              HtmlGenericControl row;
              HtmlGenericControl img;
              HtmlGenericControl pNome;
              HtmlGenericControl pPrezzo;
              HtmlGenericControl pDescrizione;
              LinkButton btn;
              Label lbl;
              HtmlGenericControl hr;
              HtmlGenericControl card;
              HtmlGenericControl body;

              row = new HtmlGenericControl("div");
              row.Attributes.Add("class", "row");

              for (int i = 0; i <= prodotti.Rows.Count - 1; i++)
              {
                  if (i % 3 == 0)
                  {
                      row = new HtmlGenericControl("div");
                      row.Attributes.Add("class", "row");
                      row.Style.Add("margin", "5px");
                  }

                  card = new HtmlGenericControl("div");
                  card.ID = "Prodotto " + i;
                  card.Attributes.Add("class", "card mx-auto col-md-3 d-flex justify-content-center mt-3 text-center");
                  card.Style.Add("box-shadow", "0 4px 8px 0 rgba(0, 0, 0, 0.2)");
                  card.Style.Add("padding", "15px");
                  card.Style.Add("margin", "20px");
                  card.Style.Add("text-align", "center");
                  card.Style.Add("font-family", "Poppins, sans-serif");

                  img = new HtmlGenericControl("img");
                  img.Attributes.Add("src", "IMG/" + Convert.ToString(prodotti.Rows[i].ItemArray[3]));
                  img.Attributes.Add("width", "150px");
                  img.Attributes.Add("class", "mx-auto");

                  hr = new HtmlGenericControl("hr");
                  hr.Style.Add("border", "none");
                  hr.Style.Add("background-color", "rgb(157,121,231)");
                  hr.Style.Add("width", "100%");
                  hr.Style.Add("height", "2px");

                  pNome = new HtmlGenericControl("h3");
                  pNome.Attributes.Add("class", "card-title");
                  pNome.InnerText = Convert.ToString(prodotti.Rows[i].ItemArray[1]);

                  pPrezzo = new HtmlGenericControl("p");
                  pPrezzo.Attributes.Add("class", "card-text");
                  pPrezzo.InnerText = Convert.ToString(prodotti.Rows[i].ItemArray[4]);

                  pDescrizione = new HtmlGenericControl("p");
                  pDescrizione.Attributes.Add("class", "card-text");
                  pDescrizione.InnerText = Convert.ToString(prodotti.Rows[i].ItemArray[2]);

                  btn = new LinkButton();
                  btn.Attributes.Add("runat", "server");
                  //btn.Text = "Aggiungi al carrello";
                  btn.Attributes.Add("class", "account mx-auto");
                  btn.Style.Add("background-color", "rgb(157,121,231)");
                  btn.Click += new EventHandler(aggiuntaCarrello);
                  btn.ID = "btnProd_" + Convert.ToString(prodotti.Rows[i].ItemArray[0]);
                  //btn.Style.Add("margin-left", "40%");
                  //btn.Style.Add("margin-right", "40%");

                  lbl = new Label();
                  lbl.Attributes.Add("runat", "server");
                  lbl.Attributes.Add("class", "fa fa-shopping-cart");

                  body = new HtmlGenericControl("div");
                  body.Attributes.Add("class", "card-body");

                  card.Controls.Add(img);
                  card.Controls.Add(hr);
                  body.Controls.Add(pNome);
                  body.Controls.Add(pPrezzo);
                  body.Controls.Add(pDescrizione);

                  if (Session["codiceUtente"] != null)
                  {
                      body.Controls.Add(btn);
                      btn.Controls.Add(lbl);
                  }

                  card.Controls.Add(body);
                  row.Controls.Add(card);

                  divCarte.Controls.Add(row);
              }
          }

          protected void btnLogout_Click(object sender, EventArgs e)
          {
              Session["codiceUtente"] = null;
              Session["tipoUtente"] = null;
              Session["emailUtente"] = null;
              Response.Redirect("default.aspx");
          }

          protected void cmbCategorie_SelectedIndexChanged(object sender, EventArgs e)
          {
              caricaCardProdotti(Convert.ToInt32(cmbCategorie.SelectedValue));
          }

          protected void btnCarrello_Click(object sender, EventArgs e)
          {
              Response.Redirect("gestioneCarrello.aspx");
          }

          protected void aggiuntaCarrello(object sender, EventArgs e)
          {
              LinkButton who = (LinkButton)sender;
              int idProdotto = Convert.ToInt32((who.ID).Split('_')[1]);

              adoNet adoWeb = new adoNet();
              string strSQL = string.Empty;

              strSQL = @"SELECT IDFornitore From Prodotti where IDProdotto = " + idProdotto;
              int idFornitore = Convert.ToInt32(adoWeb.eseguiScalar(strSQL, CommandType.Text));

              strSQL = @"SELECT COUNT(*) FROM Carrello where IDProdotto = " + idProdotto;
              bool quantita = Convert.ToBoolean(Convert.ToInt32(adoWeb.eseguiScalar(strSQL, CommandType.Text)));

              if (quantita)
              {
                  strSQL = @"UPDATE Carrello SET Quantita = Quantita + 1 WHERE IDProdotto = " + idProdotto;

                  try
                  {
                      adoWeb.eseguiNonQuery(strSQL, CommandType.Text);
                  }
                  catch (Exception ex)
                  {
                      Response.Redirect("errore.aspx?errore=3");
                  }
              }
              else
              {
                  strSQL = @"SELECT Prezzo FROM Prodotti where IDProdotto= " + idProdotto;
                  decimal prezzo = Convert.ToDecimal(adoWeb.eseguiScalar(strSQL, CommandType.Text));

                  strSQL = @"SELECT IDCategoria FROM Prodotti where IDProdotto= " + idProdotto;
                  int idCat = Convert.ToInt32(adoWeb.eseguiScalar(strSQL, CommandType.Text));

                  strSQL = @"INSERT INTO Carrello (IDProdotto, IDUtente, IDFornitore,IDCategoria, Quantita, Prezzo) values (" + idProdotto + ", " + Convert.ToInt32(Session["codiceUtente"]) + ", " + idFornitore + ", " + idCat + ", 1, '" + prezzo.ToString().Replace(',', '.') + "' )";

                  try
                  {
                      adoWeb.eseguiNonQuery(strSQL, CommandType.Text);
                  }
                  catch (Exception ex)
                  {
                      Response.Redirect("errore.aspx?errore=3");
                  }
              }
          }

          protected void btnStorico_Click(object sender, EventArgs e)
          {
              if (btnStorico.Text == "Storico Ordini")
              {
                  caricaStorico();
              }
              else if (btnStorico.Text == "Torna ai prodotti")
              {
                  cmbCategorie.Visible = true;
                  caricaCardProdotti(0);
                  btnStorico.Text = "Storico Ordini";
              }
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

          private void caricaStorico()
          {
              divCarte.Visible = false;
              divStorico1.Visible = true;
              cmbCategorie.Visible = false;
              btnStorico.Text = "Torna ai prodotti";
              divStorico.Controls.Clear();

              string strSQL = string.Empty;
              adoNet adoWeb = new adoNet();
              strSQL = @"SELECT COUNT(*) FROM Vendite WHERE IDUtente =" + Convert.ToInt32(Session["codiceUtente"]);
              int n = Convert.ToInt32(adoWeb.eseguiScalar(strSQL, CommandType.Text));

              if (n == 0)
              {
                  lblStorico.Text = "Non hai effettuato nessun ordine.";
                  lblStorico.ForeColor = System.Drawing.Color.Red;
                  divStorico1.Visible = false;
              }
              else
              {
                  divStorico1.Visible = true;

                  HtmlGenericControl divS1;
                  HtmlGenericControl divS2;
                  HtmlGenericControl divS3;
                  HtmlGenericControl divS4;
                  HtmlGenericControl divS5;
                  HtmlGenericControl divS6;
                  HtmlGenericControl imgS1;
                  HtmlGenericControl divS7;
                  HtmlGenericControl divS8;
                  HtmlGenericControl divS9;
                  //HtmlGenericControl h6_S1;
                  HtmlGenericControl divS10;
                  HtmlGenericControl divS11;
                  HtmlGenericControl divS12;
                  //HtmlGenericControl divS13;
                  //HtmlGenericControl divS14; //inizio footer
                  //HtmlGenericControl divS15;
                  //HtmlGenericControl divS16;
                  //HtmlGenericControl divS17;
                  //HtmlGenericControl imgS2;
                  //HtmlGenericControl divS18;
                  HtmlGenericControl h2_S1;
                  HtmlGenericControl h2_S2;
                  //HtmlGenericControl divS19;

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

                  strSQL = @"select Data from Vendite where IDUtente = " + Convert.ToInt32(Session["codiceUtente"]) + " group by Data";
                  DataTable tabDate = adoWeb.eseguiQuery(strSQL, CommandType.Text);

                  DataTable tabOrdini = new DataTable();
                  decimal prezzoTot;

                  for (int d = 0; d < tabDate.Rows.Count; d++)
                  {
                      strSQL = @"SELECT Vendite.IDVendita, Vendite.Data, Vendite.Quantita, Prodotti.NomeProdotto, Prodotti.Immagine, Vendite.IDFornitore, Vendite.StatoOrdine, Categorie.NomeCategoria, Vendite.Prezzo from (Vendite inner join Prodotti on Vendite.IDProdotto = Prodotti.IDProdotto) inner join Categorie on Categorie.IDCategoria = Prodotti.IDCategoria where Vendite.IDUtente = " + Convert.ToInt32(Session["codiceUtente"]) + " and Vendite.Data = '" + tabDate.Rows[d].ItemArray[0] + "' ";

                      tabOrdini = adoWeb.eseguiQuery(strSQL, CommandType.Text);

                      strSQL = @"SELECT SUM(Prezzo) from Vendite where Data = '" + tabDate.Rows[d].ItemArray[0] + "' ";
                      prezzoTot = Convert.ToDecimal(adoWeb.eseguiScalar(strSQL, CommandType.Text));

                      //parte iniziale
                      divS1 = new HtmlGenericControl("div");
                      divS1.Attributes.Add("class", "container-fluid my-5 d-flex justify-content-center");

                      divS2 = new HtmlGenericControl("div");
                      divS2.Style.Add("min-width", "70%");
                      divS2.Attributes.Add("class", "card card-1");

                      divS3 = new HtmlGenericControl("div");
                      divS3.Attributes.Add("class", "card-header bg-white");

                      divS4 = new HtmlGenericControl("div");
                      divS4.Attributes.Add("class", "media flex-sm-row flex-column-reverse justify-content-between ");

                      divS5 = new HtmlGenericControl("div");
                      divS5.Attributes.Add("class", "col my-auto");

                      Label lblS1 = new Label();
                      lblS1.Style.Add("font-size", "25px");
                      lblS1.Style.Add("margin-top", "15px");
                      lblS1.Style.Add("margin-left", "15px");
                      lblS1.Text = "Ordini in data: " + tabDate.Rows[d].ItemArray[0];

                      divS6 = new HtmlGenericControl("div");
                      divS6.Attributes.Add("class", "card-body");

                      divStorico.Controls.Add(divS1);
                      divS2.Controls.Add(lblS1);
                      divS1.Controls.Add(divS2);
                      divS2.Controls.Add(divS3);
                      divS3.Controls.Add(divS4);
                      divS4.Controls.Add(divS5);
                      divS2.Controls.Add(divS6);

                      for (int r = 0; r < tabOrdini.Rows.Count; r++)
                      { // CONTENUTO 
                          div1 = new HtmlGenericControl("div");
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
                          img.Attributes.Add("src", "IMG/" + tabOrdini.Rows[r].ItemArray[4].ToString());
                          img.Attributes.Add("class", "img-fluid my-auto align-self-center mb-0 pt-3");
                          img.Style.Add("width", "135px");
                          //img.Style.Add("height", "135px");
                          //mr-2 mr-md-4 pl-0 p-0 m-0
                          div7 = new HtmlGenericControl("div");
                          div7.Attributes.Add("class", "media-body my-auto text-right");

                          div8 = new HtmlGenericControl("div");
                          div8.Attributes.Add("class", "row my-auto flex-column flex-md-row");

                          div9 = new HtmlGenericControl("div");
                          div9.Attributes.Add("class", "col my-auto");

                          h6_1 = new HtmlGenericControl("h6");
                          h6_1.Attributes.Add("class", "mb-0");
                          h6_1.InnerText = tabOrdini.Rows[r].ItemArray[3].ToString();

                          div10 = new HtmlGenericControl("div");
                          div10.Attributes.Add("class", "col-auto my-auto");

                          small1 = new HtmlGenericControl("small");
                          small1.InnerText = tabOrdini.Rows[r].ItemArray[7].ToString();

                          div11 = new HtmlGenericControl("div");
                          div11.Attributes.Add("class", "col my-auto");

                          small2 = new HtmlGenericControl("small");
                          small2.InnerText = tabOrdini.Rows[r].ItemArray[2].ToString();

                          div12 = new HtmlGenericControl("div");
                          div12.Attributes.Add("class", "col my-auto");

                          div13 = new HtmlGenericControl("div");
                          div13.Attributes.Add("class", "col my-auto");

                          h6_2 = new HtmlGenericControl("h6");
                          h6_2.Attributes.Add("class", "mb-0");
                          h6_2.InnerText = "€ " + tabOrdini.Rows[r].ItemArray[8].ToString();

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
                          div18.Style.Add("width", tabOrdini.Rows[r].ItemArray[6].ToString() + "%");
                          div18.Attributes.Add("role", "progressbar");
                          div18.Attributes.Add("aria-valuenow", tabOrdini.Rows[r].ItemArray[6].ToString());
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
                          div8.Controls.Add(div13);
                          div13.Controls.Add(h6_2);
                          div4.Controls.Add(hr);
                          div4.Controls.Add(div14);
                          div14.Controls.Add(div15);
                          div15.Controls.Add(small3); //
                          small3.Controls.Add(span1);
                          span1.Controls.Add(i1);
                          div14.Controls.Add(div16); //
                          div16.Controls.Add(div17); //
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

                          divS6.Controls.Add(div1);
                      }

                      //footer
                      divS7 = new HtmlGenericControl("div");
                      divS7.Attributes.Add("class", "card-footer");

                      divS8 = new HtmlGenericControl("div");
                      divS8.Attributes.Add("class", "jumbotron-fluid");

                      divS9 = new HtmlGenericControl("div");
                      divS9.Attributes.Add("class", "row justify-content-between");

                      divS10 = new HtmlGenericControl("div");
                      divS10.Attributes.Add("class", "col-sm-auto col-auto my-auto");

                      imgS1 = new HtmlGenericControl("img");
                      imgS1.Attributes.Add("class", "img-fluid my-auto align-self-center");
                      imgS1.Attributes.Add("src", "IMG/icons8-scontrino-40.png");
                      imgS1.Style.Add("width", "115");
                      imgS1.Style.Add("height", "115");

                      divS11 = new HtmlGenericControl("div");
                      divS11.Attributes.Add("class", "col-auto my-auto");

                      h2_S1 = new HtmlGenericControl("h2");
                      h2_S1.Attributes.Add("class", "mb-0 font-weight-bold");
                      h2_S1.InnerText = "TOTALE: ";

                      divS12 = new HtmlGenericControl("div");
                      divS12.Attributes.Add("class", "col-auto my-auto ml-auto");

                      h2_S2 = new HtmlGenericControl("h2");
                      h2_S2.Attributes.Add("class", "mb-0 font-weight-bold");
                      h2_S2.InnerText = prezzoTot.ToString();

                      //contenuto
                      divS2.Controls.Add(divS7);
                      divS7.Controls.Add(divS8);
                      divS8.Controls.Add(divS9);
                      divS9.Controls.Add(divS10);
                      divS10.Controls.Add(imgS1);
                      divS9.Controls.Add(divS11);
                      divS11.Controls.Add(h2_S1);
                      divS9.Controls.Add(divS12);
                      divS12.Controls.Add(h2_S2);

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