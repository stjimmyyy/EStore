namespace E_Store.Controllers
{
    using Classes;
    using Business.Interfaces;
    using E_Store.Data.Models;
    using Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    
    [ExceptionsToMessageFilter]
    public class ReviewController : Controller
    {
        private readonly IReviewManager reviewManager;
        private UserManager<ApplicationUser> userManager;

        public ReviewController(IReviewManager reviewManager, UserManager<ApplicationUser> userManager)
        {
            this.reviewManager = reviewManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Insert(string productUrl)
        {
            return RedirectToActionPermanent("Detail", "Product", new {url = productUrl});
        }

        [HttpPost]
        [Authorize]
        public IActionResult Insert(Review review)
        {
            if (ModelState.IsValid)
            {
                review.UserId = this.userManager.GetUserId(HttpContext.User);
                this.reviewManager.AddReview(review);
                
                this.AddFlashMessage(new FlashMessage("The review was successfully submitted, thank you", 
                    FlashMessageType.Success));
            }

            return Redirect(ControllerContext.HttpContext.Request.Headers["Referer"].ToString());
        }
    }
}