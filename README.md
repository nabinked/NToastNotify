# Features
 - ##### Server side toast notification rendering.
 - ##### Toast notification on AJAX calls. XMLHTTPRequests - Full Support. fetch API - Partial Support (See sample).
 - ##### Supports Feature folder project structure.
 - ##### Supports multiple client libraries: toastr.js & noty.js. Can easily be extended to support more.
 
 # DEMO
- ## [Noty](http://notyjs.azurewebsites.net/)
- ## [Toastr](http://toastrjs.azurewebsites.net/)

# Get Started
## 1. Install From [Nuget](https://www.nuget.org/packages/NToastNotify/)

Visual Studio Nuget Package Manager - `Install-Package NToastNotify`

dotnet CLI - `dotnet add package NToastNotify`

## 2. Add NtoastNotify to the ASP.NET Core Services. Use the extension method on `IMVCBuilder` or `IMVCCoreBuilder`
- ### For Toastr.js [**Note: toastr library depends on jQuery**]
    ```C#
    using NToastNotify.Libraries;


    services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
    {
                ProgressBar = false,
                PositionClass = ToastPositions.BottomCenter
    });

    //Or simply go 
    services.AddMvc().AddNToastNotifyToastr();
    ```

- ### For Noty.js
    ```C#
    using NToastNotify.Libraries;

    services.AddMvc().AddFeatureFolders().AddNToastNotifyNoty(new NotyOptions {
                    ProgressBar = true,
                    Timeout = 5000,
                    Theme = "mint"
                });

    //Or Simply go
    services.AddMvc().AddNToastNotifyNoty();
    ```
**Note: Make sure you have necessary using statements.**

The ToastrOption parameter acts as the global options for the toast library. If no options are  provided the global settings will be the default toastr options.

## 3. Add the middleware
```c#
 public void Configure(IApplicationBuilder app, IHostingEnvironment env)
 {
        //NOTE this line must be above .UseMvc() line.
        app.UseNToastNotify();
        
        app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
 }
```

## 4. Add the following line in you html file. Preferably in your Layout Page.
```c#
@await Component.InvokeAsync("NToastNotify")
```
The above line renders the View necessary for the view component. Although you can place this line anywhere inside your ```head``` or ```body``` tag, It is recommended that you place this line at the end before the closing ```body``` tag. 

## 5. Add your toast messages.

### using toastr
```C#
public class HomeController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            //Testing Default Methods

            //Success
            _toastNotification.AddSuccessToastMessage("Same for success message");
            // Success with default options (taking into account the overwritten defaults when initializing in Startup.cs)
            _toastNotification.AddSuccessToastMessage();

            //Info
            _toastNotification.AddInfoToastMessage();

            //Warning
            _toastNotification.AddWarningToastMessage();

            //Error
            _toastNotification.AddErrorToastMessage();

            return View();
        }

        public IActionResult About()
        {
            _toastNotification.AddInfoToastMessage("You got redirected");
            return View();
        }

        public IActionResult Contact()
        {
            _toastNotification.AddAlertToastMessage("You will be redirected");
            return RedirectToAction("About");
        }

        public IActionResult Error()
        {
            _toastNotification.AddErrorToastMessage("There was something wrong with this request.");
            return View();
        }

        public IActionResult Empty()
        {

            return View();
        }

        public IActionResult Ajax()
        {
            _toastNotification.AddInfoToastMessage("This page will make ajax requests and show notifications.");
            return View();
        }

        public IActionResult AjaxCall()
        {
            System.Threading.Thread.Sleep(2000);
            _toastNotification.AddSuccessToastMessage("This toast is shown on Ajax request. AJAX CALL " + DateTime.Now.ToLongTimeString());
            return PartialView("_PartialView", "Ajax Call");
        }

        public IActionResult NormalAjaxCall()
        {
            return PartialView("_PartialView", "Normal Ajax Call");
        }

        public IActionResult ErrorAjaxCall()
        {
            throw new Exception("Error occurred");
        }
    }
```

### using noty (basically the same thing only thing that changes is the options type, here its NotyOptions)
```C#

public class HomeController : Controller
    {
        private readonly IToastNotification _toastNotification;

        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            _toastNotification.AddSuccessToastMessage();
            _toastNotification.AddErrorToastMessage("Test Erro", new NotyOptions()
            {
                Timeout = 0
            });
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            _toastNotification.AddAlertToastMessage("My About Warning Message");
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            _toastNotification.AddInfoToastMessage("Dont get confused. <br /> <strong>You were redirected from Contact Page. <strong/>");
            return RedirectToAction("About");
        }

        public IActionResult Error()
        {
            _toastNotification.AddErrorToastMessage("There was something wrong with this request.");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Ajax()
        {
            _toastNotification.AddInfoToastMessage("This page will make ajax requests and show notifications.");
            return View();
        }

        public IActionResult AjaxCall()
        {
            System.Threading.Thread.Sleep(2000);
            _toastNotification.AddSuccessToastMessage("This toast is shown on Ajax request. AJAX CALL " + DateTime.Now.ToLongTimeString());
            return PartialView("_PartialView", "Ajax Call");
        }

        public IActionResult NormalAjaxCall()
        {
            return PartialView("_PartialView", "Normal Ajax Call");
        }

        public IActionResult ErrorAjaxCall()
        {
            throw new Exception("Error occurred");
        }
    }
```
## Possible Issue
 - [Cannot find compilation library location for package 'Microsoft.Win32.Registry](https://github.com/dotnet/core-setup/issues/2113)
 
    **Fix** : https://github.com/dotnet/core-setup/issues/2113#issuecomment-337341068  
