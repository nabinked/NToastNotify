# NToastNotify
##### ASP.NET abstraction for javascript toastr to render server side managed Toast Notifications.

## Get Started
### 1. Install From [Nuget](https://www.nuget.org/packages/NToastNotify/)
Visual Studio Nuget Package Manager - `Install-Package NToastNotify`

dotnet CLI - `dotnet add package NToastNotify`

### 2. Add NtoastNotify to the ASP.NET Core Services
```C#
services.AddNToastNotify(new ToastOption()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.BottomCenter
            });
```
**Or Simply**
```C#
services.AddNToastNotify();
```
The ToastOption parameter acts as the global options for the toast library. If no options are  provided the global settings will be the default toastr options.


### 3. Include the reference to [toastr](http://codeseven.github.io/toastr/) Css and Javascript files in your html.
Download the toastr library files if you haven't done that already and include them in your project.
```html
<link href="toastr.css" rel="stylesheet"/>
<script src="toastr.js"></script>
```
**NOTE: toastr library depends on jQuery**

### 4. Add the following line in you html file. Preferably in your Layout Page.
```c#
@await Component.InvokeAsync("NToastNotify.Toastr")
```
This renders the View necessary for the view component

### Add your toast messages.

```c#
namespace NToastNotify.Web.Controllers
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
        _toastNotification.AddSuccessToastMessage();
        //Info
        _toastNotification.AddInfoToastMessage("This is an info message");
        //Warning
        _toastNotification.AddWarningToastMessage("This is a warning message");
        //Wrror
        _toastNotification.AddErrorToastMessage();

        _toastNotification.AddToastMessage("Custom Title", "My Custom Message", ToastEnums.ToastType.Success, new ToastOption()
        {
            PositionClass = ToastPositions.BottomLeft
        });
        return View();
    }

    public IActionResult About()
    {
        _toastNotification.AddToastMessage("Success About Title", "My About Warning Message", ToastEnums.ToastType.Warning, new ToastOption()
        {
            PositionClass = ToastPositions.BottomFullWidth
        });

        return View();
    }

    public IActionResult Contact()
    {
        _toastNotification.AddToastMessage("Redirected...", "You were redirected from Contact Page.", ToastEnums.ToastType.Info, new ToastOption()
        {
            PositionClass = ToastPositions.TopCenter
        });
        return RedirectToAction("About"); ;
    }

    public IActionResult Error()
    {
        _toastNotification.AddErrorToastMessage("ERROR", "There was something wrong with this request.");
        return View();
    }
}
```
and they will be rendered as 

##### Home Page
![Home Page](https://raw.githubusercontent.com/nabinked/NToastNotify/master/sample/NToastNotify.Web/wwwroot/images/home-2-0-1.png)
##### About Page
![About Page](https://raw.githubusercontent.com/nabinked/NToastNotify/master/sample/NToastNotify.Web/wwwroot/images/about-2-0-1.PNG)
##### Contact Page
![Contact Page](https://raw.githubusercontent.com/nabinked/NToastNotify/master/sample/NToastNotify.Web/wwwroot/images/contact-2-0-1.PNG)
