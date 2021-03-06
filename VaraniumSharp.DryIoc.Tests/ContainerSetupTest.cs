﻿using System;
using System.Linq;
using FluentAssertions;
using VaraniumSharp.DryIoc.Tests.Fixtures;
using Xunit;

namespace VaraniumSharp.DryIoc.Tests
{
    public class ContainerSetupTest
    {
        #region Public Methods

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

        #endregion
    }
}