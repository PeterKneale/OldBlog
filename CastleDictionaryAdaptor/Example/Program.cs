using System;
using System.Configuration;
using System.Reflection;
using Autofac;
using Castle.Components.DictionaryAdapter;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            // Get this assembly
            var assembly = Assembly.GetExecutingAssembly();
            
            // Register all Services
            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            
            // Register the Castle Dictionary Adaptor Factory
            builder.RegisterType<DictionaryAdapterFactory>().As<IDictionaryAdapterFactory>().SingleInstance();
            
            // Resolve ISettings by resolving the DictionaryAdapterFactory and 
            // initialising it with AppSettings from App.config
            builder.Register(x => x.Resolve<IDictionaryAdapterFactory>()
                .GetAdapter<ISettings>(ConfigurationManager.AppSettings))
                .As<ISettings>().SingleInstance();
            
            // Resolve the specified settings by resolving ISettings then just taking the appropriate property
            builder.Register(x => x.Resolve<ISettings>().Email).As<IEmailSettings>();
            builder.Register(x => x.Resolve<ISettings>().Search).As<ISearchSettings>();
            
            var container = builder.Build();
            
            var userManagement = container.Resolve<IUserManagementService>();
            // Service resolved with all settings injected!
            userManagement.AddUser("Peter");
        }
    }

    public interface ISettings
    {
        Configuration Configuration { get; }

        // These settings need to be prefixed by "Email_" in app Settings
        [Component]
        IEmailSettings Email { get; }

        // These settings need to be prefixed by "Search_" in app Settings
        [Component]
        ISearchSettings Search { get; }
    }

    public interface ISearchSettings
    {
        string Index { get; }
    }

    public interface IEmailSettings
    {
        bool IsEnabled { get; set; }
        string Subject { get; set; }
    }

    public interface IEmailService
    {
        void SendWelcomeEmail(string name);
    }

    public interface ISearchService
    {
        void AddToIndex(string name);
    }

    public interface IUserManagementService
    {
        void AddUser(string name);
    }
    
    public class UserManagementService : IUserManagementService
    {
        private readonly IEmailService _emailService;
        private readonly ISearchService _searchService;
        private readonly ISettings _settings;

        public UserManagementService(IEmailService emailService, ISearchService searchService, ISettings settings)
        {
            _emailService = emailService;
            _searchService = searchService;
            _settings = settings;
        }

        public void AddUser(string name)
        {
            _searchService.AddToIndex(name);
            _emailService.SendWelcomeEmail(name);
            if (_settings.Configuration == Configuration.Development)
            {
                Console.WriteLine("Added user!");
            }
        }
    }

    public class EmailService : IEmailService
    {
        private readonly IEmailSettings _settings;

        public EmailService(IEmailSettings settings)
        {
            _settings = settings;
        }

        public void SendWelcomeEmail(string name)
        {
            if (_settings.IsEnabled)
            {
                Console.WriteLine("Sending email with subject '{0}' to user {1}", _settings.Subject, name);
            }
        }
    }

    public class SearchService : ISearchService
    {
        private readonly ISearchSettings _settings;

        public SearchService(ISearchSettings settings)
        {
            _settings = settings;
        }

        public void AddToIndex(string name)
        {
            Console.WriteLine("Adding user {0} to index {1}", name, _settings.Index);
        }
    }

    public enum Configuration
    {
        Development, Testing, Production
    }
}
