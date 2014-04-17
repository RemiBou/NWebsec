﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using System.Configuration;
using NWebsec.Core.HttpHeaders.Configuration;
using NWebsec.Modules.Configuration.Csp.Validation;

namespace NWebsec.Modules.Configuration.Csp
{
    public class CspConfigurationElement : CspHeaderConfigurationElement, ICspConfiguration
    {

        [ConfigurationProperty("default-src", IsRequired = false)]
        [CspDirectiveBaseConfigurationElementValidator]
        public CspDirectiveBaseConfigurationElement DefaultSrc
        {
            get
            {
                return (CspDirectiveBaseConfigurationElement)this["default-src"];
            }
            set
            {
                this["default-src"] = value;
            }
        }

        [ConfigurationProperty("script-src", IsRequired = false)]
        [CspDirectiveUnsafeInlineUnsafeEvalConfigurationElementValidator]
        public CspDirectiveUnsafeInlineUnsafeEvalConfigurationElement ScriptSrc
        {
            get
            {
                return (CspDirectiveUnsafeInlineUnsafeEvalConfigurationElement)this["script-src"];
            }
            set
            {
                this["script-src"] = value;
            }
        }

        [ConfigurationProperty("object-src", IsRequired = false)]
        [CspDirectiveBaseConfigurationElementValidator]
        public CspDirectiveBaseConfigurationElement ObjectSrc
        {
            get
            {
                return (CspDirectiveBaseConfigurationElement)this["object-src"];
            }
            set
            {
                this["object-src"] = value;
            }
        }

        [ConfigurationProperty("style-src", IsRequired = false)]
        [CspDirectiveUnsafeInlineConfigurationElementValidator]
        public CspDirectiveUnsafeInlineConfigurationElement StyleSrc
        {
            get
            {
                return (CspDirectiveUnsafeInlineConfigurationElement)this["style-src"];
            }
            set
            {
                this["style-src"] = value;
            }
        }

        [ConfigurationProperty("img-src", IsRequired = false)]
        [CspDirectiveBaseConfigurationElementValidator]
        public CspDirectiveBaseConfigurationElement ImgSrc
        {
            get
            {
                return (CspDirectiveBaseConfigurationElement)this["img-src"];
            }
            set
            {
                this["img-src"] = value;
            }
        }

        [ConfigurationProperty("media-src", IsRequired = false)]
        [CspDirectiveBaseConfigurationElementValidator]
        public CspDirectiveBaseConfigurationElement MediaSrc
        {
            get
            {
                return (CspDirectiveBaseConfigurationElement)this["media-src"];
            }
            set
            {
                this["media-src"] = value;
            }
        }

        [ConfigurationProperty("frame-src", IsRequired = false)]
        [CspDirectiveBaseConfigurationElementValidator]
        public CspDirectiveBaseConfigurationElement FrameSrc
        {
            get
            {
                return (CspDirectiveBaseConfigurationElement)this["frame-src"];
            }
            set
            {
                this["frame-src"] = value;
            }
        }

        [ConfigurationProperty("font-src", IsRequired = false)]
        [CspDirectiveBaseConfigurationElementValidator]
        public CspDirectiveBaseConfigurationElement FontSrc
        {
            get
            {
                return (CspDirectiveBaseConfigurationElement)this["font-src"];
            }
            set
            {
                this["font-src"] = value;
            }
        }

        [ConfigurationProperty("connect-src", IsRequired = false)]
        [CspDirectiveBaseConfigurationElementValidator]
        public CspDirectiveBaseConfigurationElement ConnectSrc
        {
            get
            {
                return (CspDirectiveBaseConfigurationElement)this["connect-src"];
            }
            set
            {
                this["connect-src"] = value;
            }
        }

        [ConfigurationProperty("report-uri", IsRequired = false)]
        public CspReportUriDirectiveConfigurationElement ReportUri
        {
            get
            {
                return (CspReportUriDirectiveConfigurationElement)this["report-uri"];
            }
            set
            {
                this["report-uri"] = value;
            }
        }

        public ICspDirectiveConfiguration DefaultSrcDirective
        {
            get { return DefaultSrc; }
            set { throw new NotImplementedException(); }
        }
        public ICspDirectiveUnsafeEvalConfiguration ScriptSrcDirective
        {
            get { return ScriptSrc; }
            set { throw new NotImplementedException(); }
        }
        public ICspDirectiveConfiguration ObjectSrcDirective
        {
            get { return ObjectSrc; }
            set { throw new NotImplementedException(); }
        }
        public ICspDirectiveUnsafeInlineConfiguration StyleSrcDirective
        {
            get { return StyleSrc; }
            set { throw new NotImplementedException(); }
        }
        public ICspDirectiveConfiguration ImgSrcDirective
        {
            get { return ImgSrc; }
            set { throw new NotImplementedException(); }
        }
        public ICspDirectiveConfiguration MediaSrcDirective
        {
            get { return MediaSrc; }
            set { throw new NotImplementedException(); }
        }
        public ICspDirectiveConfiguration FrameSrcDirective
        {
            get { return FrameSrc; }
            set { throw new NotImplementedException(); }
        }
        public ICspDirectiveConfiguration FontSrcDirective
        {
            get { return FontSrc; }
            set { throw new NotImplementedException(); }
        }
        public ICspDirectiveConfiguration ConnectSrcDirective
        {
            get { return ConnectSrc; }
            set { throw new NotImplementedException(); }
        }

        public ICspReportUriDirectiveConfiguration ReportUriDirective
        {
            get { return ReportUri; }
            set { throw new NotImplementedException(); }
        }
    }
}
