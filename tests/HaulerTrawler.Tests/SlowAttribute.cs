using System;
using System.Linq;
using System.Collections.Generic;
using Xunit.Sdk;
using Xunit.Abstractions;

[TraitDiscoverer("SlowAttributeDiscoverer", "HaulerTrawler.Tests")]
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class SlowAttribute : Attribute, ITraitAttribute
{
}

public class SlowAttributeDiscoverer : ITraitDiscoverer
{
    public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
    {
        yield return new KeyValuePair<string, string>("Category", "Slow");
    }
}
