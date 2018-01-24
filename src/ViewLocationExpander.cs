using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Razor;

namespace NToastNotify
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (viewLocations == null)
                throw new ArgumentNullException(nameof(viewLocations));
            var locations = viewLocations as string[] ?? viewLocations.ToArray();
            locations.Concat(new List<string>()
            {
                "/Views/Shared/Componens/Toastr/{0}.cshtml"
            });
            return locations;
        }
    }
}
