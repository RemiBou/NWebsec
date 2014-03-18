// Copyright (c) Andr� N. Klingsheim. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace NWebsec.Core.HttpHeaders.Configuration
{
    public class CspDirectiveUnsafeEvalConfiguration : ICspDirectiveUnsafeEvalConfiguration
    {
        public CspDirectiveUnsafeEvalConfiguration()
        {
            Enabled = true;
        }

        public bool Enabled { get; set; }
        public bool NoneSrc { get; set; }
        public bool SelfSrc { get; set; }
        public IEnumerable<string> CustomSources { get; set; }
        public bool UnsafeInlineSrc { get; set; }
        public bool UnsafeEvalSrc { get; set; }
    }
}