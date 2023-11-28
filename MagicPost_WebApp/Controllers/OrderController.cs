using Microsoft.AspNetCore.Mvc;

using MagicPost_ApiIntergration;

using shopCommerce_ApiIntergration;

namespace MagicPost_WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;
   

        public OrderController(IOrderApiClient orderApiClient)
        {
			_orderApiClient = orderApiClient;
       
        }

       /* public async Task<IActionResult> Detail(int id, string culture)
		{
            var order = await _orderApiClient.GetById(id, culture);
            return View(new OrderDetailViewModel()
            {
                Product = product
            });
        }*/

       
    }
}
