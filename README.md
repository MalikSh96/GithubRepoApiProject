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

#### `Program.cs`
- ASP.NET Core web applications requires a *host* to be executed 
- The application starts executing from the entry point `public static void Main()` 
in `Program.cs` class where one can create a *host* for the web application
- Is the *entry* point of the application
- Whatever **code** you write inside `Program.cs`, inside its method will be executed in that same order
- The application will **NOT** run without `Program.cs`, it will return a build error

#### `Startup.cs`
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

### IoC (Inversion-of-Control)
- IoC means that one code calls another
- A DI (Dependency-Injection) or IoC container needs to instantiate objects (dependencies) and provide them to the application
- To do so, it must deal with constructor injection, setter injection, and interface injection
- The built-in IoC container supports three kinds of lifetimes
	1. **Singleton**: IoC container will create and share a single instance of a service throughout the application's lifetime
	2. **Transient**: The IoC container will create a new instance of the specified service type every time you ask for it
	3. **Scoped**: IoC container will create an instance of the specified service type once per request and will be shared in a single request
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
### DIP (Dependency Inversion Principle)
DIP definition:
    1. *High-level* modules should not depend on *low-level* modules. Both should depend on the *abstraction*
    2. **Abstractions** should not depend on details. Details should depend on abstractions
- A *high-level* module is a module which depends on other modules
- To achieve a level of *abstraction* in programming, it means to create an *interface* or an *abstract* class which is non-concrete
- `GithubRepoController` is a *high-level* module which "depends" on `GithubApiService` which is *low-level* module in this context
- `GithubApiService` is a concrete class and `IGithubApiService` is an abstraction, ie. non-concrete
- Both classes should depend on abstractions, meaning both classes should depend on an *interface* or an *abstract* class
- The advantages of implementing **DIP** is that the `GithubRepoController` and `GithubApiService` classes are loosely 
coupled classes because `GithubRepoController` does not depend on the concrete `GithubApiService` class, instead it includes a 
reference of the `IGithubApiService` interface. So now, if one potentially wanted to use another class, then one can easily use
another class which implements `IGithubApiService` with a different implementation

### DI (Dependency-Injection)
- Dependency Injection (DI) is a design pattern which implements the IoC principle to invert the creation of dependent objects
- Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them
- The Dependency Injection pattern involves 3 types of classes.
    1. **Client** Class: The client class (dependent class) is a class which depends on the service class
    2. **Service** Class: The service class (dependency) is a class that provides service to the client class.
    3. **Injector** Class: The injector class injects the service class object into the client class.
- The injector class injects dependencies broadly in three ways: through a *constructor*, through a *property*, or through a *method*
    1. **Constructor** Injection: In the constructor injection, the injector supplies the service (dependency) 
    through the client class constructor
    ```
    public GithubRepoController(IGithubApiService githubApiService)
    {
        _githubApiService = githubApiService;
    }
    ```
    2. **Property** Injection: In the property injection (aka the Setter Injection), the injector supplies the dependency through 
    a public property of the client class
    3. **Method** Injection: In this type of injection, the client class implements an interface which declares the method(s) to supply the dependency and the 
    injector uses this interface to supply the dependency to the client class

### IoC Container
Read [Here](https://www.tutorialsteacher.com/ioc/ioc-container)

## Objective of IoC, DIP, DI and IoC Container
- The whole objective is to minimize code dependency, module dependency
- It is all to achieve *"loosely coupled"* design/code/classes

#### Difference between IoC (Inversion-of-Control) and DI (Dependency-Injection)
- IoC is a principle and DI is a pattern
- IoC is the principle where the control flow of a program is inverted: instead of the 
programmer controlling the flow of a program, the external sources (framework, services, other components) take control of it
- Dependency Injection is a design pattern which implements IoC principle
- DI provides objects that an object needs. Let’s say, class *X* is dependent on *Y*. So rather than creating object of *Y* within 
the class *"X"*, we can inject the dependencies via a constructor or setter injection

##### Helpful links
About [IoC](https://www.tutorialsteacher.com/ioc) 
Difference between [IoC and DI](https://www.tutorialspoint.com/difference-between-ioc-and-dependency-injection-in-spring)

