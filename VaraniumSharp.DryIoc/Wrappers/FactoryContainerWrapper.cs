using System.Collections.Generic;
using DryIoc;
using VaraniumSharp.Attributes;
using VaraniumSharp.Interfaces.DependencyInjection;

namespace VaraniumSharp.DryIoc.Wrappers
{
    /// <summary>
    /// Wrapper to provide access to the container in an abstract way
    /// </summary>
    [AutomaticContainerRegistration(typeof(IContainerFactoryWrapper))]
    public class FactoryContainerWrapper : IContainerFactoryWrapper
    {
        #region Constructor

        /// <summary>
        /// DI Constructor
        /// </summary>
        public FactoryContainerWrapper(IContainer container)
        {
            _container = container;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public TService Resolve<TService>()
        {
            return _container.Resolve<TService>();
        }

        /// <inheritdoc />
        public IEnumerable<TService> ResolveMany<TService>()
        {
            return _container.ResolveMany<TService>();
        }

        #endregion

        #region Variables

        /// <summary>
        /// Container instance
        /// </summary>
        private readonly IContainer _container;

        #endregion
    }
}