﻿using Bogus;
using Xunit;
using Xunit.Priority;

namespace FastEndpoints.Testing;

/// <summary>
/// abstract class for implementing a test-class with an assembly level app fixture.
/// </summary>
/// <typeparam name="TAppFixture">
/// the type of the assembly level app fixture.
/// </typeparam>
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public abstract class TestBaseWithAssemblyFixture<TAppFixture> : IAsyncLifetime, IFaker, IAssemblyFixture<TAppFixture> where TAppFixture : BaseFixture
{
    static readonly Faker _faker = new();

    public Faker Fake => _faker;

    /// <summary>
    /// override this method if you'd like to do some one-time setup for the test-class.
    /// it is run before any of the test-methods of the class is executed.
    /// </summary>
    protected virtual Task SetupAsync()
        => Task.CompletedTask;

    /// <summary>
    /// override this method if you'd like to do some one-time teardown for the test-class.
    /// it is run after all test-methods have executed.
    /// </summary>
    protected virtual Task TearDownAsync()
        => Task.CompletedTask;

    Task IAsyncLifetime.InitializeAsync()
        => SetupAsync();

    Task IAsyncLifetime.DisposeAsync()
        => TearDownAsync();
}

/// <summary>
/// abstract class for implementing a test-class with an assembly level app fixture.
/// </summary>
/// <typeparam name="TAppFixture">
/// the type of the assembly level app fixture.
/// </typeparam>
/// <typeparam name="TState">the type of the shared state fixture.</typeparam>
public abstract class TestBaseWithAssemblyFixture<TAppFixture, TState> : TestBaseWithAssemblyFixture<TAppFixture>, IClassFixture<TState>
    where TAppFixture : BaseFixture where TState : StateFixture;