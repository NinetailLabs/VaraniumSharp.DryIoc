using FluentAssertions;
using Moq;
using VaraniumSharp.DryIoc.Tests.Fixtures;
using VaraniumSharp.DryIoc.Wrappers;
using Xunit;

namespace VaraniumSharp.DryIoc.Tests.Wrappers
{
    public class FactoryContainerWrapperTests
    {
        [Fact]
        public void ResolvingAnEntryFromTheContainerWorksCorrectly()
        {
            // arrange
            var containerDummy = new ContainerFixture();
            var resultDummy = new Mock<ITestHelper>();
            containerDummy.EntriesToReturn.Add(resultDummy.Object);
            var sut = new FactoryContainerWrapper(containerDummy);

            // act
            var _ = sut.Resolve<ITestHelper>();

            // assert
            containerDummy.ResolveCalls.Count.Should().Be(1);
            containerDummy.ResolveCalls[0].Should().Be(typeof(ITestHelper));
        }

        [Fact]
        public void ResolvingMultipleEntriesWorksCorrectly()
        {
            // arrange
            var containerDummy = new ContainerFixture();
            var resultDummy1 = new Mock<ITestHelper>();
            var resultDummy2 = new Mock<ITestHelper>();
            containerDummy.EntriesToReturn.Add(resultDummy1.Object);
            containerDummy.EntriesToReturn.Add(resultDummy1.Object);
            var sut = new FactoryContainerWrapper(containerDummy);

            // act
            var _ = sut.ResolveMany<ITestHelper>();

            // assert
            containerDummy.ResolveCalls.Count.Should().Be(1);
            containerDummy.ResolveCalls[0].Should().Be(typeof(ITestHelper));
        }
    }
}