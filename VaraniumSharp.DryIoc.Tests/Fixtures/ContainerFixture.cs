using System;
using System.Collections.Generic;
using System.Linq;
using DryIoc;
using DryIoc.FastExpressionCompiler.LightExpression;
using DryIoc.ImTools;

namespace VaraniumSharp.DryIoc.Tests.Fixtures
{
    public class ContainerFixture : IContainer
    {
        #region Properties

        public IScope CurrentOrSingletonScope { get; }
        public IScope CurrentScope { get; }
        public object DisposeInfo { get; }

        /// <summary>
        /// Entries to return each time resolve is called
        /// </summary>
        public List<object> EntriesToReturn { get; } = new();

        public bool IsDisposed { get; }
        public IScope OwnCurrentScope { get; }
        public IResolverContext Parent { get; }

        /// <summary>
        /// Calls made to resolve.
        /// This contains the type requests
        /// </summary>
        public List<Type> ResolveCalls { get; } = new();

        public IResolverContext Root { get; }

        public Rules Rules { get; }
        public IScopeContext ScopeContext { get; }
        public IScope SingletonScope { get; }

        #endregion

        #region Public Methods

        public bool ClearCache(Type serviceType, FactoryType? factoryType, object serviceKey)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public KV<object, Factory>[] GetAllServiceFactories(Type serviceType, bool bothClosedAndOpenGenerics = false)
        {
            throw new NotImplementedException();
        }

        public Expression GetConstantExpression(object item, Type itemType = null, bool throwIfStateRequired = false)
        {
            throw new NotImplementedException();
        }

        public Expression GetDecoratorExpressionOrDefault(Request request)
        {
            throw new NotImplementedException();
        }

        public Factory[] GetDecoratorFactoriesOrDefault(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public Factory[] GetDecoratorFactoriesOrDefault(int serviceTypeHash, Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DecoratorRegistrationInfo> GetDecoratorRegistrations()
        {
            throw new NotImplementedException();
        }

        public Factory[] GetRegisteredFactories(Type serviceType, object serviceKey, FactoryType factoryType)
        {
            throw new NotImplementedException();
        }

        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public Factory GetServiceFactoryOrDefault(Request request)
        {
            throw new NotImplementedException();
        }

        public KV<object, Factory>[] GetServiceRegisteredAndDynamicFactories(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceRegistrationInfo> GetServiceRegistrations()
        {
            throw new NotImplementedException();
        }

        public Type GetWrappedType(Type serviceType, Type requiredServiceType)
        {
            throw new NotImplementedException();
        }

        public Type GetWrappedType(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public Factory GetWrapperFactoryOrDefault(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void InjectPropertiesAndFields(object instance, string[] propertyAndFieldNames)
        {
            throw new NotImplementedException();
        }

        public bool IsRegistered(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition)
        {
            throw new NotImplementedException();
        }

        public bool IsWrapper(Type serviceType, Type openGenericServiceType = null)
        {
            throw new NotImplementedException();
        }

        public void Register(Factory factory, Type serviceType, object serviceKey, IfAlreadyRegistered? ifAlreadyRegistered,
            bool isStaticallyChecked)
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

        public Factory ResolveFactory(Request request)
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

        public void Unregister(Type serviceType, object serviceKey, FactoryType factoryType, Func<Factory, bool> condition)
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

        public IResolverContext WithCurrentScope(IScope scope)
        {
            throw new NotImplementedException();
        }

        public IContainer WithNoMoreRegistrationAllowed(bool ignoreInsteadOfThrow = false)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        void IContainer.Use(Type serviceType, object instance)
        {
            throw new NotImplementedException();
        }

        void IRegistrator.Use(Type serviceType, object instance)
        {
            throw new NotImplementedException();
        }

        void IResolverContext.Use(Type serviceType, object instance)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}