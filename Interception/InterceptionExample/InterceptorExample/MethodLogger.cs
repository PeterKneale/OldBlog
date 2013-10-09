using System.IO;
using System.Linq;
using Castle.DynamicProxy;

namespace InterceptorExample
{
    public class MethodLogger : IInterceptor
    {
        readonly TextWriter _output;

        public MethodLogger(TextWriter output)
        {
            _output = output;
        }

        public void Intercept(IInvocation invocation)
        {
            var method = invocation.Method.Name;
            var parameters = string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray());
            var name = invocation.InvocationTarget.GetType().FullName;
            
            _output.Write("{0}.{1}({2})",name,method,parameters);
            invocation.Proceed();
            _output.WriteLine(" returned {0}.", invocation.ReturnValue);
        }
    }
}
