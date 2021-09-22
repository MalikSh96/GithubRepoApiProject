# GithubRepoApiProject
### wwwroot
- Treated as the web root folder
- Stores files that can be served over an `http` request
- The files are static
- These are assets that the app will serve directly to clients, including HTML files, 
CSS files, image files, and JavaScript files
- The wwwroot folder is the root of your web site
- Code files should be placed outside of wwwroot. That includes all of your C# files and Razor files
- Having a wwwroot folder keeps a clean separation between code files and static files
- The name `wwwroot` is not unique, and can be changed to your desire, but remember to make that change everywhere the `wwwroot`
is applied

### `Program.cs`
- ASP.NET Core web applications requires a *host* to be executed 
- The application starts executing from the entry point `public static void Main()` 
in `Program` class where one can create a host for the web application
- Is the *entry* point of the application
- Whatever *code* you write inside `Program.cs`, inside its method will be executed in that same order
- The application will **NOT** run without `Program.cs`, it will return a build error

### `Startup.cs`
- ASP.NET Core applications must include Startup class
- `Startup.cs` is executed first when the application starts
- Includes two public methods: `ConfigureServices` and `Configure`
- The `Startup.cs` class must include a `Configure` method and can optionally include `ConfigureService` method

#### `ConfigureServices()`
- The `ConfigureServices` method is a place where you can register your dependent 
classes with the built-in IoC (Inversion-of-Control) container.
- ASP.NET Core refers dependent class as a `Service`. So, whenever you read **"Service"** 
then understand it as a class which is going to be used in some other class
- `ConfigureServices` method includes `IServiceCollection` parameter to register services to the IoC container

#### `Configure()`
- The `Configure` method is a place where you can configure application request pipeline for your application 
using `IApplicationBuilder` instance that is provided by the built-in IoC container
- ASP.NET Core introduced the middleware components to define a request pipeline, which will be executed on every request
- You include only those middleware components which are required by your application and thus increase the 
performance of your application
- The parameters specified in the custom `Configure(IApplicationBuilder paramName, IWebHostEnvironment paramName)` 
are framework services injected by built-in IoC container

#### IoC (Inversion-of-Control)
- IoC means that one code calls another
- A DI (Dependency-Injection) or IoC container needs to instantiate objects (dependencies) and provide them to the application
- To do so, it must deal with constructor injection, setter injection, and interface injection
- The built-in IoC container supports three kinds of lifetimes
	1. Singleton: IoC container will create and share a single instance of a service throughout the application's lifetime
	2. Transient: The IoC container will create a new instance of the specified service type every time you ask for it
	3. Scoped: IoC container will create an instance of the specified service type once per request and will be shared in a single request
- Once we register a service, the IoC container automatically performs constructor injection if a service type is 
included as a parameter in a constructor.
```
namespace GithubApiProject.Controllers
{
    public class GithubRepoController : Controller
    {
        private readonly IGithubApiService _githubApiService;

        //Constructor injection, IoC pattern
        public GithubRepoController(IGithubApiService githubApiService)
        {
            _githubApiService = githubApiService;
        }
    }
}
```

#### DI (Dependency-Injection)
- Dependency Injection (DI) is a design pattern which implements the IoC principle to invert the creation of dependent objects
- Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them


