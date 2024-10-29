using System;
using System.Collections.Generic;

namespace MKubiak.Services
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<TService>(TService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            if (IsRegistered<TService>())
            {
                throw new ServiceLocatorException($"Type {typeof(TService).Name} is already registered in ServiceLocator");
            }

            _services.Add(typeof(TService), service);
        }

        public static void Unregister<TService>()
        {
            var type = typeof(TService);
            if (_services.ContainsKey(typeof(TService)))
            {
                _services.Remove(type);
            }
        }

        public static TService Get<TService>()
        {
            return (TService)Get(typeof(TService));
        }

        private static object Get(Type typeOfService)
        {
            if (_services.TryGetValue(typeOfService, out var instance))
            {
                return instance;
            }

            return null;
        }

        public static bool IsRegistered<TService>()
        {
            return _services.ContainsKey(typeof(TService));
        }
    }

    public class ServiceLocatorException : Exception
    {
        public ServiceLocatorException(string message) : base(message)
        { 
        }
    }
}
