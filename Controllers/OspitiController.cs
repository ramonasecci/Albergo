using Albergo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Albergo.Controllers
{
    public class OspitiController : Controller
    {
        // GET: Ospiti
        [HttpGet]
        [Authorize]
      
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Ospite ospite)
        {
            try
            {

                Db.conn.Open();
                var cmdOspite = new SqlCommand(@"INSERT INTO Ospiti
                                                 (Nome, Cognome, Citta, Provincia, Email, Telefono, Cod_Fisc)
                                                 VALUES (@nome, @cognome, @citta, @prov, @email, @tel, @cod_fisc)
                                                 SELECT SCOPE_IDENTITY()", Db.conn);
                cmdOspite.Parameters.AddWithValue("@nome", ospite.Nome);
                cmdOspite.Parameters.AddWithValue("@cognome", ospite.Cognome);
                cmdOspite.Parameters.AddWithValue("@citta", ospite.Citta);
                cmdOspite.Parameters.AddWithValue("@prov", ospite.Provincia);
                cmdOspite.Parameters.AddWithValue("@email", ospite.Email);
                cmdOspite.Parameters.AddWithValue("@tel", ospite.Telefono);
                cmdOspite.Parameters.AddWithValue("@cod_fisc", ospite.Cod_Fisc);
                int lastInsertedId = Convert.ToInt32(cmdOspite.ExecuteScalar());
                if (lastInsertedId > 0) 
                {
                    TempData["MessageSuccess"] = "Ospite inserito con successo";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MessageAlert"] = "Errore nell'inserimento";
                    return RedirectToAction("Index");
                }
                
            }catch (Exception ex) 
            {

            }finally 
            {
                Db.conn.Close();
            }


            return View();
        }


        }
}