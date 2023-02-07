using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp1.Models;


namespace tp1.Controllers
{
    public class VoituresController : Controller
    {
        // GET: landing Page
        public ActionResult Index()
        {
            return View();
        }

        // GET: Voitures/Contacts permet d'afficher le form pour enregistrer des nouvelles voitures 
        public ActionResult Contact()
        {
            return View();
        }


        // GET: voitures/Liste permet d'afficher la liste de voitures enregistrer
       

        public ActionResult ListerTout() // fonction qui permet de lister toutes les voitures 
        {
            Voiture uneVoiture= new Voiture();
            string ligne;
            string[] attributs;
            char delimiteur = ':';
            var listeVoitures = new List<Voiture> { };
            if (System.IO.File.Exists(Server.MapPath(@"~/Content/Donnees/Voitures.txt")))
            {
                // Lecture ligne par ligne 
                StreamReader fichVoiture =
                    new StreamReader(Server.MapPath(@"~/Content/Donnees/Voitures.txt"));
                while ((ligne = fichVoiture.ReadLine()) != null)
                {
                    attributs = ligne.Split(delimiteur);
                    uneVoiture = new Voiture() {NoSerie = int.Parse(attributs[0]), Sorte = attributs[1], Annee = int.Parse(attributs[2]), Prix = double.Parse(attributs[3]) };
                    listeVoitures.Add(uneVoiture);
                }

                fichVoiture.Close();
            }
            
            Console.WriteLine(listeVoitures.Count());
            return View(listeVoitures);
        }
    

        // POST: Voitures/Enregistrer
        [HttpPost]
        public ActionResult Enregistrer(FormCollection collection)
        {
            int taille = collection.Count;
            string ligne = "";
            try
            {
                using (System.IO.StreamWriter ficMembres =
                new System.IO.StreamWriter(Server.MapPath(@"~/Content/Donnees/membres.txt"), true))
                {
                    ligne += Convert.ToString(collection["NoSerie"]) + ":";
                    ligne += Convert.ToString(collection["Sorte"]) + ":";
                    ligne += Convert.ToString(collection["Annee"]) + ":";
                    ligne += Convert.ToString(collection["Prix"]) + ":";
                    ficMembres.WriteLine(ligne);
                }
                return RedirectToAction("/Index");
                //return Content(taille.ToString()); Pour debogger
                //return Content(ligne);
            }
            catch
            {
                return View();//avec les messages d'erreur appropriés
            }
        }

        // GET: Voitures/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Voitures/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Voitures/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Voitures/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
