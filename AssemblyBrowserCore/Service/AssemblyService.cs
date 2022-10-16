using System;
using System.Reflection;
using AssemblyBrowserCore.Exception;

namespace AssemblyBrowserCore.Service
{
    public class AssemblyService
    {
        public string AssemblyPath { get; }
        public NamespaceService NamespaceService { get; }

        public AssemblyService(string assemblyPath)
        {
            
            AssemblyPath = assemblyPath;
            NamespaceService = new NamespaceService();
        }
        private Assembly GetAssembly()
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(AssemblyPath);
            }
            catch (System.Exception e)
            {
                throw new LoadAssemblyException("Can not load the assembly!");
            }

            return assembly;
        }
        
        public AssemblyInfo GetAssemblyInfo()
        {
            AssemblyInfo assemblyInfo = new AssemblyInfo();
            Assembly assembly = GetAssembly();
            assemblyInfo.NamespaciesInfos = NamespaceService.GetNamespaceInfo(assembly);
            return assemblyInfo;
        }
    }
}