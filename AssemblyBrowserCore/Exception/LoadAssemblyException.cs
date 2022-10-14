using System;

namespace AssemblyBrowserCore.Exception
{
    public class LoadAssemblyException : SystemException
    {
        public LoadAssemblyException(string message) : base(message)
        {
        }
    }
}