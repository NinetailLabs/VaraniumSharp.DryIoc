using System;
using System.Collections.Generic;
using System.Linq;
using DryIoc;
using FastExpressionCompiler.LightExpression;
using ImTools;
using Moq;

namespace VaraniumSharp.DryIoc.Tests.Fixtures
{
    public class ContainerFixture : IContainer
    {
        public void Register(Factory factory, Type serviceType, object serviceKey, IfAlreadyRegistered? ifAlreadyRegistered,
            bool isStaticallyChecked)
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition)
        {
            throw new NotImplementedException();
        }

        public void Unregister(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceRegistrationInfo> GetServiceRegistrations()
        {
            throw new NotImplementedException();
        }

        public Factory[] GetRegisteredFactories(Type serviceType, object serviceKey, FactoryType factoryType)
        {
            throw new NotImplementedException();
        }

        void IContainer.UseInstance(Type serviceType, object instance, IfAlreadyRegistered IfAlreadyRegistered, bool preventDisposal,
            bool weaklyReferenced, object serviceKey)
        {
            throw new NotImplementedException();
        }

        public Rules Rules { get; }
        public IScope OwnCurrentScope { get; }

        public IResolverContext WithCurrentScope(IScope scope)
        {
            throw new NotImplementedException();
        }

        void IContainer.Use(Type serviceType, FactoryDelegate factory)
        {
            throw new NotImplementedException();
        }

        void IResolverContext.UseInstance(Type serviceType, object instance, IfAlreadyRegistered IfAlreadyRegistered, bool preventDisposal,
            bool weaklyReferenced, object serviceKey)
        {
            throw new NotImplementedException();
        }

        public IContainer With(Rules rules, IScopeContext scopeContext, RegistrySharing registrySharing, IScope singletonScope)
        {
            throw new NotImplementedException();
        }

        public IContainer With(IResolverContext parent, Rules rules, IScopeContext scopeContext, RegistrySharing registrySharing,
            IScope singletonScope, IScope currentScope)
        {
            throw new NotImplementedException();
        }

        public IContainer With(IResolverContext parent, Rules rules, IScopeContext scopeContext, RegistrySharing registrySharing,
            IScope singletonScope, IScope currentScope, IsRegistryChangePermitted? isRegistryChangePermitted)
        {
            throw new NotImplementedException();
        }

        public IContainer WithNoMoreRegistrationAllowed(bool ignoreInsteadOfThrow = false)
        {
            throw new NotImplementedException();
        }

        public Factory ResolveFactory(Request request)
        {
            throw new NotImplementedException();
        }

        public Factory GetServiceFactoryOrDefault(Request request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KV<object, Factory>> GetAllServiceFactories(Type serviceType, bool bothClosedAndOpenGenerics = false)
        {
            throw new NotImplementedException();
        }

        public Factory GetWrapperFactoryOrDefault(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public Factory[] GetDecoratorFactoriesOrDefault(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public Expression GetDecoratorExpressionOrDefault(Request request)
        {
            throw new NotImplementedException();
        }

        public Type GetWrappedType(Type serviceType, Type requiredServiceType)
        {
            throw new NotImplementedException();
        }

        public Expression GetConstantExpression(object item, Type itemType = null, bool throwIfStateRequired = false)
        {
            throw new NotImplementedException();
        }

        public bool ClearCache(Type serviceType, FactoryType? factoryType, object serviceKey)
        {
            throw new NotImplementedException();
        }

        void IResolverContext.Use(Type serviceType, FactoryDelegate factory)
        {
            throw new NotImplementedException();
        }

        public void InjectPropertiesAndFields(object instance, string[] propertyAndFieldNames)
        {
            throw new NotImplementedException();
        }

        public bool IsDisposed { get; }
        public IResolverContext Parent { get; }
        public IResolverContext Root { get; }
        public IScope SingletonScope { get; }
        public IScopeContext ScopeContext { get; }
        public IScope CurrentScope { get; }

        void IRegistrator.UseInstance(Type serviceType, object instance, IfAlreadyRegistered IfAlreadyRegistered, bool preventDisposal,
            bool weaklyReferenced, object serviceKey)
        {
            throw new NotImplementedException();
        }

        void IRegistrator.Use(Type serviceType, FactoryDelegate factory)
        {
            throw new NotImplementedException();
        }

        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type serviceType, IfUnresolved ifUnresolved)
        {
            ResolveCalls.Add(serviceType);
            var entryToReturn = EntriesToReturn.First();
            EntriesToReturn.Remove(entryToReturn);
            return entryToReturn;
        }

        public object Resolve(Type serviceType, object serviceKey, IfUnresolved ifUnresolved, Type requiredServiceType,
            Request preResolveParent, object[] args)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ResolveMany(Type serviceType, object serviceKey, Type requiredServiceType, Request preResolveParent,
            object[] args)
        {
            ResolveCalls.Add(serviceType);
            var entryToReturn = EntriesToReturn.First();
            EntriesToReturn.Remove(entryToReturn);
            return new List<object>{ entryToReturn };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calls made to resolve.
        /// This contains the type requests
        /// </summary>
        public List<Type> ResolveCalls { get; } = new();

        /// <summary>
        /// Entries to return each time resolve is called
        /// </summary>
        public List<object> EntriesToReturn { get; } = new();
    }
}