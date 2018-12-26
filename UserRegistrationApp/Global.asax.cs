using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UserRegistrationApp.Validators;
using FluentValidation.Mvc;


namespace UserRegistrationApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ValidationConfiguration();
        }
        private void ValidationConfiguration()  
        {  
            FluentValidationModelValidatorProvider.Configure(provider =>  
            {  
                provider.ValidatorFactory = new ValidatorFactory();  
            });  
        }  
    }
}
