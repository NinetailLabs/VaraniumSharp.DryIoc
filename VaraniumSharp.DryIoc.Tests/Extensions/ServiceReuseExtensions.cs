using DryIoc;
using FluentAssertions;
using VaraniumSharp.DryIoc.Extensions;
using VaraniumSharp.Enumerations;
using Xunit;

namespace VaraniumSharp.DryIoc.Tests.Extensions
{
    public class ServiceReuseExtensions
    {
        #region Public Methods

        [Fact]
        public void ConvertDefaultVaraniumReuseToDryIocReuse()
        {
            // arrange
            const ServiceReuse varaniumReuse = ServiceReuse.Default;
            var dryIocReuse = Reuse.Transient;

            // act
            var result = varaniumReuse.ConvertFromVaraniumReuse();

            // assert
            result.Should().Be(dryIocReuse);
        }

        [Fact]
        public void ConvertSingletonVaraniumReuseToDryIocReuse()
        {
            // arrange
            const ServiceReuse varaniumReuse = ServiceReuse.Singleton;
            var dryIocReuse = Reuse.Singleton;

            // act
            var result = varaniumReuse.ConvertFromVaraniumReuse();

            // assert
            result.Should().Be(dryIocReuse);
        }

        #endregion
    }
}