using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrunkenWizard_SharedProject.Container
{
    public class ServiceContainer
    {
        static object locker = new object();
        static ServiceContainer instance;

        private ServiceContainer()
        {
            Services = new Dictionary<Type, Lazy<object>>();
        }

        private Dictionary<Type, Lazy<object>> Services { get; set; }

        private static ServiceContainer Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new ServiceContainer();
                    return instance;
                }
            }
        }

        public static void Register<T>(T service)
        {
            Instance.Services[typeof(T)] = new Lazy<object>(() => service);
        }

        public static void Reset()
        {
            Instance.Services.Clear();
        }

        public static void Register<T>()
            where T : new()
        {
            if (Instance.Services.Any(i => i.GetType() == typeof(T)))
                return;

            Instance.Services[typeof(T)] = new Lazy<object>(() => new T());
        }

        public static void Register<T>(Func<object> function)
        {
            Instance.Services[typeof(T)] = new Lazy<object>(function);
        }

        public static T Resolve<T>(params object[] constructorParams)
        {
            Lazy<object> service;
            if (Instance.Services.TryGetValue(typeof(T), out service))
            {
                return (T)service.Value;
            }

            try
            {
                T val = constructorParams?.Length > 0 ? (T)Activator.CreateInstance(typeof(T), constructorParams) : (T)Activator.CreateInstance(typeof(T));
                Register(val);
                return val;
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.WriteLine($"ServiceContainer: Resolve {typeof(T).FullName} failed\n\r" + exception);
            }

            throw new KeyNotFoundException($"Service not found for type '{typeof(T)}'");
        }


        public static List<T> ResolveAll<T>()
        {
            var service = new List<T>();
            foreach (var s in Instance.Services.Where(s => IsSubclassOfRawGeneric(typeof(T), s.Key)))
            {

                if (s.Value != null)
                    service.Add((T)s.Value.Value);
            }
            return service;
        }

        static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }
}