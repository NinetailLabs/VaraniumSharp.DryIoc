﻿using DryIoc;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
using VaraniumSharp.Attributes;
using VaraniumSharp.DependencyInjection;
using VaraniumSharp.DryIoc.Attributes;
using VaraniumSharp.DryIoc.Extensions;

namespace VaraniumSharp.DryIoc
{
    /// <summary>
    /// Set up the DryIoC container and register all classes that implement the AutomaticContainerRegistrationAttribute
    /// </summary>
    public class ContainerSetup : AutomaticContainerRegistration
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ContainerSetup()
        {
            _container = new Container();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Resolve a Service from the Container
        /// </summary>
        /// <typeparam name="TService">Service to resolve</typeparam>
        /// <returns>Resolved service</returns>
        public override TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }

        /// <summary>
        /// Resolve Services from the container via a shared interface of parent class
        /// </summary>
        /// <typeparam name="TService">Interface or parent class that children are registered under</typeparam>
        /// <returns>Collection of children classes that inherit from the parent or implement the interface</returns>
        public override IEnumerable<TService> ResolveMany<TService>()
        {
            return _container.ResolveMany<TService>();
        }

        #endregion

        #region Variables

        private readonly IContainer _container;

        #endregion

        #region Protected Methods

        /// <inheritdoc />
        protected override void RegisterClasses()
        {
            foreach (var @class in ClassesToRegister)
            {
                var registrationAttribute =
                    (AutomaticContainerRegistrationAttribute)
                    @class.GetCustomAttribute(typeof(AutomaticContainerRegistrationAttribute));

                var disposableTransient = CheckIfClassIsDisposableTransient(@class);

                if (registrationAttribute.MultipleConstructors)
                {
                    _container.Register(registrationAttribute.ServiceType, @class,
                        registrationAttribute.Reuse.ConvertFromVaraniumReuse(),
                        FactoryMethod.ConstructorWithResolvableArguments,
                        Setup.With(allowDisposableTransient: disposableTransient));
                }
                else
                {
                    _container.Register(registrationAttribute.ServiceType, @class,
                        registrationAttribute.Reuse.ConvertFromVaraniumReuse(),
                        setup: Setup.With(allowDisposableTransient: disposableTransient));
                }
            }
        }

        /// <summary>
        /// Checks if a class has the <see cref="DisposableTransientAttribute"/> applied
        /// </summary>
        /// <param name="class">Type that should be checked</param>
        /// <returns>True - Class has the attribute applied, otherwise false</returns>
        private static bool CheckIfClassIsDisposableTransient(MemberInfo @class)
        {
            return (DisposableTransientAttribute)
                   @class.GetCustomAttribute(typeof(DisposableTransientAttribute)) != null;
        }

        /// <inheritdoc />
        protected override void RegisterConcretionClasses()
        {
            foreach (var @class in ConcretionClassesToRegister)
            {
                var registrationAttribute =
                    (AutomaticConcretionContainerRegistrationAttribute)
                    @class.Key.GetCustomAttribute(typeof(AutomaticConcretionContainerRegistrationAttribute));

                var disposableTransient = CheckIfClassIsDisposableTransient(@class.Key);

                @class.Value.ForEach(x =>
                {
                    if (registrationAttribute.MultipleConstructors)
                    {
                        _container.RegisterMany(new[] { @class.Key, x }, x,
                            registrationAttribute.Reuse.ConvertFromVaraniumReuse(),
                            FactoryMethod.ConstructorWithResolvableArguments,
                            Setup.With(allowDisposableTransient: disposableTransient));
                    }
                    else
                    {
                        _container.RegisterMany(new[] { @class.Key, x }, x,
                            registrationAttribute.Reuse.ConvertFromVaraniumReuse(),
                            setup: Setup.With(allowDisposableTransient: disposableTransient));
                    }
                });
            }
        }

        /// <inheritdoc />
        protected override void AutoResolveStartupInstance()
        {
            foreach (var entry in ClassesToAutoRegister)
            {
                var registrationAttribute =
                    (AutomaticConcretionContainerRegistrationAttribute)
                    entry.GetCustomAttribute(typeof(AutomaticConcretionContainerRegistrationAttribute));

                if (registrationAttribute != null)
                {
                    var _ = _container.ResolveMany(entry);
                }
                else
                {
                    var _ = _container.Resolve(entry);
                }
            }
        }

        #endregion Protected Methods
    }
}