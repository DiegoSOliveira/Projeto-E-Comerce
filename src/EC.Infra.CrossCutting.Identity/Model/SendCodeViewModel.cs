using System.Collections.Generic;
using System.Web.Mvc;

namespace EC.Infra.CrossCutting.Identity.Model
{
    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }

        [HiddenInput]
        public string UserId { get; set; }
    }
}