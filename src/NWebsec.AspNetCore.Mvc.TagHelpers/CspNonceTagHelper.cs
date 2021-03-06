﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NWebsec.AspNetCore.Core.Helpers;
using NWebsec.AspNetCore.Core.Web;
using NWebsec.Mvc.Common.Helpers;

namespace NWebsec.AspNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement(ScriptTag, Attributes = CspNonceAttributeName)]
    [HtmlTargetElement(StyleTag, Attributes = CspNonceAttributeName)]
    public class CspNonceTagHelper : TagHelper
    {
        private const string ScriptTag = "script";
        private const string StyleTag = "style";
        private const string CspNonceAttributeName = "nws-csp-add-nonce";
        private readonly ICspConfigurationOverrideHelper _cspConfigOverride;
        private readonly IHeaderOverrideHelper _headerOverride;

        public CspNonceTagHelper()
        {
            _cspConfigOverride = new CspConfigurationOverrideHelper();
            _headerOverride = new HeaderOverrideHelper(new CspReportHelper());
        }

        internal CspNonceTagHelper(ICspConfigurationOverrideHelper overrideHelper,
            IHeaderOverrideHelper headerOverride)
        {
            _cspConfigOverride = overrideHelper;
            _headerOverride = headerOverride;
        }

        /// <summary>
        /// Specifies a whether a nonce should be added to the tag and the CSP header.
        /// </summary>
        [HtmlAttributeName(CspNonceAttributeName)]
        public bool UseCspNonce { get; set; }

        [HtmlAttributeNotBound, ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!UseCspNonce) return;

            var httpContext = new HttpContextWrapper(ViewContext.HttpContext);
            string nonce;
            string contextMarkerKey;
            var tag = output.TagName;

            if (tag == ScriptTag)
            {
                nonce = _cspConfigOverride.GetCspScriptNonce(httpContext);
                contextMarkerKey = "NWebsecScriptNonceSet";
            }
            else if (tag == StyleTag)
            {
                nonce = _cspConfigOverride.GetCspStyleNonce(httpContext);
                contextMarkerKey = "NWebsecStyleNonceSet";
            }
            else
            {
                throw new Exception($"Something went horribly wrong. You shouldn't be here for the tag {tag}.");
            }

            // First reference to a nonce, set header and mark that header has been set. We only need to set it once.
            if (httpContext.GetItem<string>(contextMarkerKey) == null)
            {
                httpContext.SetItem(contextMarkerKey, "set");
                _headerOverride.SetCspHeaders(httpContext, false);
                _headerOverride.SetCspHeaders(httpContext, true);
            }

            output.Attributes.Add(new TagHelperAttribute("nonce", nonce));
        }
    }
}