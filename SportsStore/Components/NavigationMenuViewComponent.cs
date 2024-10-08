using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using static Azure.Core.HttpHeader;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent: ViewComponent
    {
        private IStoreRepository repository;
       
        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            //highlight or indicate the currently selected category in the navigation menu
            ViewBag.SelectedCategory = RouteData?.Values["category"]; 

            return View(
                repository.Products // Give all products from (.Models.EFStoreRepository)repository).Products)
                .Select(x=>x.Category)
                .Distinct() //For removing duplicate category names
                .OrderBy(x => x) //For sorting the distinct category names in alphabet order.
                );
        }
    }
}
