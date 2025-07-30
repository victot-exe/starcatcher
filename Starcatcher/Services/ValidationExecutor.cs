using System.Reflection;
using Starcatcher.Contracts;

namespace Starcatcher.Services
{
    public class ValidationExecutor
    {
        public void ExecuteAll<T>(T obj)
        {
            var validationTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IValidation<T>).IsAssignableFrom(t) & !t.IsInterface & !t.IsAbstract);

            foreach (var type in validationTypes)
            {
                var validator = (IValidation<T>)Activator.CreateInstance(type)!;//A exclamação é para garantir que não vai retornar null
                validator.Valid(obj);
            }
        }
    }
}