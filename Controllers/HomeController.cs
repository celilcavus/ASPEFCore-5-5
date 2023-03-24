using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Data.Context.EFCoreContext;


namespace AspEFCore.Controllers;

public class HomeController : Controller
{
    EFCoreContext db = new EFCoreContext();
    public IActionResult Index()
    {
        // db.Add(new Product{
        //     name = "Telefon",
        //     price = 3000
        // });

        // db.Update(new Product{
        //     Id = 1,
        //     name = "Bilgisayar",
        //     price = 5000
        // });

        // var value = db.products!.Find(1);
        // db.products.Remove(value!);
        // db.SaveChanges();

        

        
        return View();
    }
}
