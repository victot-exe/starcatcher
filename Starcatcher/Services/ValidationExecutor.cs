using System.Reflection;
using Starcatcher.Contracts;

namespace Starcatcher.Services
{
    public class ValidationExecutor
    {
        public void ExecuteAll<T>(T obj)//TODO usar para validar varias coisas pendentes
        {
            var validationTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IValidation<T>).IsAssignableFrom(t) & !t.IsInterface & !t.IsAbstract);

            foreach (var type in validationTypes)
            {
                var validator = (IValidation<T>)Activator.CreateInstance(type)!;
                validator.Valid(obj);
            }
        }
    }
}