using System;
using System.Reflection;
using AssemblyBrowserCore.Exception;

namespace AssemblyBrowserCore
{
    public class AssemblyBrowser
    {
        private string _assemblyPath;

        public AssemblyBrowser(string assemblyPath)
        {
            _assemblyPath = assemblyPath;
        }

        public AssemblyInfo GetAssemblyInfo()
        {
            AssemblyInfo assemblyInfo = new AssemblyInfo();
            Assembly assembly = GetAssembly();
            return assemblyInfo;
        }

        private Assembly GetAssembly()
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(_assemblyPath);
            }
            catch (System.Exception e)
            {
                throw new LoadAssemblyException("Can not load the assembly!");
            }

            return assembly;
        }
    }
}