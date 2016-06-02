using System;
using System.Web;
using EC.Infra.Data.Interfaces;

namespace EC.Infra.Data.Context
{
    public class ContextManager : IContextManager
    {
        private const string ContextKey = "ContextManager.Context";
        public DataContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new DataContext();
            }

            return (DataContext)HttpContext.Current.Items[ContextKey];
        }
    }
}