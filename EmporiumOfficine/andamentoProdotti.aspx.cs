using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using adoNetWebSQlServer;
using System.Data;
using System.IO;
using System.Web.UI.DataVisualization.Charting;

namespace EmporiumOfficine
{
    public partial class andamentoProdotti : System.Web.UI.Page
    {
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

            caricaGraficoProdotti();
        }

        private void caricaGraficoProdotti()
        {
            string strSQL = string.Empty;
            adoNet adoWeb = new adoNet();

            DataTable tabStatProd = new DataTable();
            DataTable tabStatCat = new DataTable();

            Series Prodotti = new Series();
            Series Categorie = new Series();

            string prodotto = string.Empty;
            string categoria = string.Empty;
            int vendite = 0;


            strSQL = @"select Prodotti.NomeProdotto, Vendite.IDProdotto, SUM(Vendite.Quantita) as Quantita from (Vendite inner join Prodotti on Vendite.IDProdotto = Prodotti.IDProdotto) where Vendite.IDFornitore = " + Convert.ToInt32(Session["codiceUtente"]) + " group by Prodotti.NomeProdotto, Vendite.IDProdotto order by Quantita desc ";

            tabStatProd = adoWeb.eseguiQuery(strSQL, CommandType.Text);

            for (int i = 0; i < tabStatProd.Rows.Count; i++)
            {
                prodotto = tabStatProd.Rows[i].ItemArray[0].ToString();
                vendite = Convert.ToInt32(tabStatProd.Rows[i].ItemArray[1]);
                Prodotti.Points.AddXY(prodotto, vendite);
            }

            strSQL = @"select Categorie.NomeCategoria, Sum(Vendite.Quantita) as Quantita
                       from (Vendite inner join Prodotti on Vendite.IDProdotto = Prodotti.IDProdotto) inner join Categorie on Prodotti.IDCategoria = Categorie.IDCategoria where Vendite.IDFornitore = " + Convert.ToInt32(Session["codiceUtente"]) + " group by Categorie.NomeCategoria order by Quantita desc";

            tabStatCat = adoWeb.eseguiQuery(strSQL, CommandType.Text);

            for (int i = 0; i < tabStatCat.Rows.Count; i++)
            {
                categoria = tabStatCat.Rows[i].ItemArray[0].ToString();
                vendite = Convert.ToInt32(tabStatCat.Rows[i].ItemArray[1]);
                Categorie.Points.AddXY(categoria, vendite);
            }

            chartProdotti.ChartAreas[0].AxisX.Title = "Prodotti";
            chartProdotti.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.White;
            chartProdotti.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartProdotti.ChartAreas[0].AxisX.LineColor = System.Drawing.Color.White;
            chartProdotti.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartProdotti.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartProdotti.ChartAreas[0].AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;

            chartCategorie.ChartAreas[0].AxisX.Title = "Categorie";
            chartCategorie.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.White;
            chartCategorie.ChartAreas[0].AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartCategorie.ChartAreas[0].AxisX.LineColor = System.Drawing.Color.White;
            chartCategorie.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartCategorie.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartCategorie.ChartAreas[0].AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;

            //strSQL = @"select P.idCategoria, C.descrizione, sum(D.quantità) as totVendite
            //                from Prodotti as P, dettagliOrdini as D, Categorie as C
            //                where P.idProdotto = D.idProdotto and P.idCategoria = C.idCategoria
            //                group by P.idCategoria, C.descrizione
            //                order by totVendite DESC
            //                ";
            //
            //dt = adoWeb.eseguiQuery( strSQL , CommandType.Text );
            //
            //for ( int i = 0 ; i < dt.Rows.Count ; i++ )
            //{
            //    categoria = dt.Rows[i].ItemArray[1].ToString();
            //    vendite = Convert.ToInt32( dt.Rows[i].ItemArray[2] );
            //    Categorie.Points.AddXY( categoria , vendite );
            //}

            aggiornaGrafico(Prodotti, Categorie);
        }

        private void aggiornaGrafico(Series datiProdotti, Series datiCategorie)
        {
            pulisciCollection();

            chartProdotti.ChartAreas.Add("Chart Prodotti");
            chartProdotti.ChartAreas[0].Area3DStyle.Enable3D = false;
            chartProdotti.Legends.Add("Vendite prodotti");
            chartProdotti.Titles.Add("");

            chartProdotti.Series.Add(datiProdotti);
            chartProdotti.Series[0].Name = "Prodotti";
            chartProdotti.Series[0].IsValueShownAsLabel = true;
            chartProdotti.Series[0].BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartProdotti.Series[0].ChartType = SeriesChartType.Bar;
            chartProdotti.Width = 600;

            chartProdotti.ChartAreas[0].AxisX.Title = "Prodotto";
            chartProdotti.ChartAreas[0].AxisY.Title = "Vendite";

            chartCategorie.ChartAreas.Add("Chart Categorie");
            chartCategorie.ChartAreas[0].Area3DStyle.Enable3D = false;
            chartCategorie.Legends.Add("Vendite categorie");
            chartCategorie.Titles.Add("");

            chartCategorie.Series.Add(datiCategorie);
            chartCategorie.Series[0].Name = "Prodotti";
            chartCategorie.Series[0].IsValueShownAsLabel = true;
            chartCategorie.Series[0].BackImageTransparentColor = System.Drawing.Color.Transparent;

            chartCategorie.Series[0].ChartType = SeriesChartType.Bar;
            chartCategorie.Width = 600;

            chartCategorie.ChartAreas[0].AxisX.Title = "Categoria";
            chartCategorie.ChartAreas[0].AxisY.Title = "Vendite";
            /*****/

            //chartCategorie.ChartAreas.Add( "Chart Categorie" );
            //chartCategorie.ChartAreas[0].Area3DStyle.Enable3D = false;
            //chartCategorie.Legends.Add( "Vendite prodotti" );
            //chartCategorie.Titles.Add( "Vendite per categoria" );
            //
            //chartCategorie.Series.Add( datiCategorie );
            //chartCategorie.Series[0].Name = "Categorie";
            //chartCategorie.Series[0].IsValueShownAsLabel = true;
            //
            //chartCategorie.Series[0].ChartType = SeriesChartType.Bar;
            //
            //chartCategorie.ChartAreas[0].AxisX.Title = "Categorie";
            //chartCategorie.ChartAreas[0].AxisY.Title = "Vendite";
        }

        private void pulisciCollection()
        {
            chartProdotti.ChartAreas.Clear();
            chartProdotti.Legends.Clear();
            chartProdotti.Titles.Clear();
            chartProdotti.Series.Clear();

            chartCategorie.ChartAreas.Clear();
            chartCategorie.Legends.Clear();
            chartCategorie.Titles.Clear();
            chartCategorie.Series.Clear();
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("modificaAccount.aspx");
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["codiceUtente"] = null;
            Session["tipoUtente"] = null;
            Session["emailUtente"] = null;
            Response.Redirect("default.aspx");
        }

        protected void btnProdotti_Click(object sender, EventArgs e)
        {
            Response.Redirect("gestioneProdotti.aspx");
        }
    }
}