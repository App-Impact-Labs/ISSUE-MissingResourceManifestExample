using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace AppImpact.I18n.AspNetCore.Common.Controllers
{
    public class StaticResourcesController : ControllerBase
    {
        IStringLocalizerFactory _factory;

        public StaticResourcesController(IStringLocalizerFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            CultureInfo.CurrentUICulture = new CultureInfo("bs-Latn-BA");

            IStringLocalizer localizer = null;

            localizer = _factory.Create("Buttons", "AppImpact.AspNetCore");

            IEnumerable<LocalizedString> lstrings = localizer.GetAllStrings();

            JObject dict = new JObject();

            foreach (LocalizedString lstring in lstrings)
            {
                dict.Add(lstring.Name, lstring.Value);
            }

            return Ok(dict);
        }
    }
}
