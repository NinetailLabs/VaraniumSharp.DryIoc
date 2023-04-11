using System;
using System.Linq;
using FluentAssertions;
using VaraniumSharp.DryIoc.Tests.Fixtures;
using Xunit;

namespace VaraniumSharp.DryIoc.Tests
{
    public class ContainerSetupTest
    {
        [Fact]
        public void AutoResolveClassesAreCorrectlyResolved()
        {
            // arrange
            var sut = new ContainerSetup();
            sut.RetrieveClassesRequiringRegistration(true);

            // act
            sut.AutoResolveRequiredClasses();

            // assert
            var _ = sut.Resolve<AutoResolve>();
            AutoResolve.TimesResolved.Should().BeGreaterOrEqualTo(2);
        }

        [Fact]
        public void ClassWithMultipleConstructorsIsRegisteredCorrectly()
        {
            // arrange
            var sut = new ContainerSetup();
            var act = new Action(() => sut.RetrieveClassesRequiringRegistration(true));

            // act
            // assert
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void ConcretionAutoResolveClassesAreCorrectlyResolved()
        {
            // arrange
            var sut = new ContainerSetup();
            sut.RetrieveConcretionClassesRequiringRegistration(true);

            // act
            sut.AutoResolveRequiredClasses();

            // assert
            var autoResolves = sut.ResolveMany<AutoResolveBase>().ToList();
            autoResolves.Count.Should().Be(2);
            autoResolves.All(x => x.TimesResolved == 1).Should().BeTrue();
        }

        [Fact]
        public void ConcretionClassesAreResolvedCorrectly()
        {
            // arrange
            var sut = new ContainerSetup();

            // act
            sut.RetrieveConcretionClassesRequiringRegistration(true);

            // assert
            var resolvedClass = sut.ResolveMany<BaseClassDummy>().ToList();
            resolvedClass.Count.Should().Be(1);
            resolvedClass.First().GetType().Should().Be(typeof(InheritorClassDummy));
        }

        [Fact]
        public void ConcretionClassesCorrectlyApplyReuse()
        {
            // arrange
            var sut = new ContainerSetup();

            // act
            sut.RetrieveConcretionClassesRequiringRegistration(true);

            // assert
            var resolvedClasses = sut.ResolveMany<ITestInterfaceDummy>();
            var secondResolve = sut.ResolveMany<ITestInterfaceDummy>();
            resolvedClasses.Should().BeEquivalentTo(secondResolve);
        }

        [Fact]
        public void ConcretionClassesFromInterfaceAreCorrectlyResolved()
        {
            // arrange
            var sut = new ContainerSetup();

            // act
            sut.RetrieveConcretionClassesRequiringRegistration(true);

            // assert
            var resolvedClasses = sut.ResolveMany<ITestInterfaceDummy>().ToList();
            resolvedClasses.Count.Should().Be(2);
            resolvedClasses.Should().Contain(x => x.GetType() == typeof(ImplementationClassDummy));
            resolvedClasses.Should().Contain(x => x.GetType() == typeof(ImplementationClassTooDummy));
        }

        [Fact]
        public void ConcretionClassWithMultipleConstructorsIsRegisteredCorrectly()
        {
            // arrange
            var sut = new ContainerSetup();
            var act = new Action(() => sut.RetrieveConcretionClassesRequiringRegistration(true));

            // act
            // assert
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void MultiTypeRegistrationSingletonsWorkCorrectly()
        {
            // arrange
            var sut = new ContainerSetup();

            // act
            sut.RetrieveConcretionClassesRequiringRegistration(true);

            // assert
            var resolvedClasses = sut.ResolveMany<ITestInterfaceDummy>().ToList();
            var interfaceResolvedClass =
                resolvedClasses.FirstOrDefault(t => t.GetType() == typeof(ImplementationClassDummy));
            var directlyResolvedClass = sut.Resolve<ImplementationClassDummy>();

            interfaceResolvedClass.Should().Be(directlyResolvedClass);
        }

        [Fact]
        public void RegisteringAttributedDisposableTransientDoesNotThrowAnException()
        {
            // arrange
            var sut = new ContainerSetup();
            var act = new Action(() => sut.RetrieveClassesRequiringRegistration(true));

            // act
            // assert
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void RegistrationOfDisposableConcretionClassDoesNotThrowAnException()
        {
            // arrange
            var sut = new ContainerSetup();
            var act = new Action(() => sut.RetrieveConcretionClassesRequiringRegistration(true));

            // act
            // assert
            act.Should().NotThrow<Exception>();
        }

        [Fact]
        public void SetupContainer()
        {
            // arrange
            var sut = new ContainerSetup();

            // act
            sut.RetrieveClassesRequiringRegistration(true);

            // assert
            var resolvedClass = sut.Resolve<AutoRegistrationDummy>();
            resolvedClass.GetType().Should().Be<AutoRegistrationDummy>();
        }

        [Fact]
        public void SingletonRegistrationsAreResolvedCorrectly()
        {
            // arrange
            var sut = new ContainerSetup();

            // act
            sut.RetrieveClassesRequiringRegistration(true);

            // assert
            var resolvedClass = sut.Resolve<SingletonDummy>();
            var secondResolve = sut.Resolve<SingletonDummy>();
            resolvedClass.Should().Be(secondResolve);
        }

        [Fact]
        public void TransientRegistrationsAreResolvedCorrectly()
        {
            // arrange
            var sut = new ContainerSetup();

            // act
            sut.RetrieveClassesRequiringRegistration(true);

            // assert
            var resolvedClass = sut.Resolve<AutoRegistrationDummy>();
            var secondResolve = sut.Resolve<AutoRegistrationDummy>();
            resolvedClass.Should().NotBe(secondResolve);
        }
    }
}