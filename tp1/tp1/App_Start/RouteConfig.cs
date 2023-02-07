using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace tp1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

             //cette route permet d'afficher la page d'acceuil par default
            routes.MapRoute(
                  name: "Default",
                  url: "{controller}/{action}/{id}",
                  defaults: new { controller = "Voitures", action = "Index", id = UrlParameter.Optional }
              );
            //cette route permet d'afficher la page index
            routes.MapRoute(
                                name: "accueil",
                                url: "Index",
                                defaults: new { controller = "Voitures", action = "Index", id = UrlParameter.Optional }
                            );

            //cette route permet d'afficher la page contact
            routes.MapRoute(
              name: "Contact",
              url: "Contact",
              defaults: new { controller = "Voitures", action = "Contact", id = UrlParameter.Optional }
              );

            //cette route permet de afficher la page qui contient toutes les voitures
            routes.MapRoute(
              name: "listerTout",
              url: "listerTout",
              defaults: new { controller = "Voitures", action = "ListerTout" });

            routes.MapRoute(
              name: "Enregistrer",
              url: "Enregistrer",
              defaults: new { controller = "Voitures", action = "Enregistrer" });

        }
    }
}
