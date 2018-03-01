// Copyright (c) Andr� N. Klingsheim. See License.txt in the project root for license information.

using NWebsec.Mvc.Common.Web;
using System.Web;
using NWebsec.Core.Common;

namespace NWebsec.Mvc.Web
{
    public class HttpContextWrapper : IHttpContextWrapper //TODO tests
    {
        private readonly HttpContextBase _context;

        public HttpContextWrapper(HttpContextBase context)
        {
            _context = context;
        }

        public NWebsecContext GetNWebsecContext()
        {
            if (!_context.Items.Contains(NWebsecContext.ContextKey))
            {
                _context.Items[NWebsecContext.ContextKey] = new NWebsecContext();
            }

            return (NWebsecContext)_context.Items[NWebsecContext.ContextKey];
        }

        public void AddItem(string key, string value)
        {
            _context.Items[key] = value;
        }

        public string GetItem(string key)
        {
            return _context.Items.Contains(key) ? (string)_context.Items[key] : null;
        }
    }
}