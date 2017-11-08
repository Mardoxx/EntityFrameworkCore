// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.EntityFrameworkCore.Design.Internal
{
    /// <summary>
    ///     A custom string comparer to sort using statements to have System prefixed namespaces first.
    /// </summary>
    public class NamespaceComparer : IComparer<string>
    {
        /// <inheritdoc />
        public virtual int Compare(string x, string y)
            => x?.StartsWith("System", StringComparison.Ordinal) == true
                ? (y?.StartsWith("System", StringComparison.Ordinal) == true
                    ? string.CompareOrdinal(x, y)
                    : -1)
                : (y?.StartsWith("System", StringComparison.Ordinal) == true
                    ? 1
                    : string.CompareOrdinal(x, y));
    }
}
