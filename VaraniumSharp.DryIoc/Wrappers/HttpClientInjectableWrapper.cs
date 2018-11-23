﻿using VaraniumSharp.Attributes;
using VaraniumSharp.DryIoc.Attributes;
using VaraniumSharp.Interfaces.Wrappers;
using VaraniumSharp.Wrappers;

namespace VaraniumSharp.DryIoc.Wrappers
{
    /// <inheritdoc />
    /// <summary>
    /// Inherits from <see cref="HttpClientWrapper"/> to provide a proper disposable transient for DryIoc,
    /// otherwise an error is thrown when the user tries to build the container
    /// </summary>
    [AutomaticContainerRegistration(typeof(IHttpClient), Priority = 1)]
    [DisposableTransient]
    public class HttpClientInjectableWrapper : HttpClientWrapper
    {}
}