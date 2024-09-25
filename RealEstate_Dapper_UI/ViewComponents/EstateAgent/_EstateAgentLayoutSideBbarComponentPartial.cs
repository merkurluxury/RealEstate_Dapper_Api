using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLayoutSideBbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}
