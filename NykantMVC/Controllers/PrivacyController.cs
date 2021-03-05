using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;

namespace NykantMVC.Controllers
{
    public class PrivacyController : BaseController
    {
        public PrivacyController(ILogger<BaseController> logger) : base(logger)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public ContentResult UpdateConsent(int consent)
        {
            if(consent == 0)
            {
                var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
                consentFeature.WithdrawConsent();
                return Content("cookie has been removed from your browser");
            }
            else
            {
                var consentFeature = HttpContext.Features.Get<ITrackingConsentFeature>();
                consentFeature.GrantConsent();
                return Content("cookie has been added to your broswer");
            }
        }
    }
}
