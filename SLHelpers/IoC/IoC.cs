using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Exceptions;
using Unity.Injection;
using Unity.Lifetime;

namespace SLHelpers
{
    public static class IoC
    {
        private static IUnityContainer _container = new UnityContainer();

        public static IUnityContainer Container
        {
            get { return _container; }
        }

        public static T Resolve<T>()
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (ResolutionFailedException)
            {
                return default(T);
            }
        }

        public static T Resolve<T>(string name)
        {
            try
            {
                return _container.Resolve<T>(name);
            }
            catch (ResolutionFailedException)
            {
                return default(T);
            }
        }

        public static void RegisterType<TFrom, TTo>(bool asSingleton) where TTo : TFrom
        {
            if (asSingleton)
                _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
            else
                _container.RegisterType<TFrom, TTo>();
        }

        public static void RegisterType<TFrom, TTo>(bool asSingleton, params object[] values) where TTo : TFrom
        {
            if (asSingleton)
                _container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager(), new InjectionConstructor(values));
            else
                _container.RegisterType<TFrom, TTo>(new InjectionConstructor(values));
        }

        public static void RegisterType<TFrom, TTo>(string name, bool asSingleton, params object[] values) where TTo : TFrom
        {
            if (asSingleton)
                _container.RegisterType<TFrom, TTo>(name, new ContainerControlledLifetimeManager(), new InjectionConstructor(values));
            else
                _container.RegisterType<TFrom, TTo>(name, new InjectionConstructor(values));
        }

        public static void RegisterInstance<T>(string name, T instance)
        {
            if (!IsRegistered<T>(name)) _container.RegisterInstance<T>(name, instance);
        }

        public static bool IsRegistered<T>()
        {
            return _container.IsRegistered<T>();
        }

        public static bool IsRegistered<T>(string name)
        {
            return _container.IsRegistered<T>(name);
        }
    }
}
