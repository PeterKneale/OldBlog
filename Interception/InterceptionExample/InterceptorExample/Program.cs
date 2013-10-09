using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy2;

namespace InterceptorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Calculator>().As<ICalculator>()    
                   .EnableInterfaceInterceptors()                   // Enable the use of Interceptors
                   .InterceptedBy(typeof(MethodLogger));            // And specify which interceptor to use

            var methodLogger = new MethodLogger(Console.Out);       // Constuct an interceptor
            builder.Register(c => methodLogger);                    // Register it in the container

            var container = builder.Build();

            var calculator = container.Resolve<ICalculator>();      // This will return a proxy with the interceptors enabled
            var total = calculator.AddTwoNumbers(1, 2);             // This method call will be intercepted
            Console.WriteLine("Method call returned {0}", total);       
        }
    }

}
