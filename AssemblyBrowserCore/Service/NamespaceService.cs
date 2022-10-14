using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssemblyBrowserCore.Service
{
    public class NamespaceService
    {
        public TypeService TypeService { get; }
        public NamespaceService()
        {
            TypeService = new TypeService();
        }
        public List<NamespaceInfo> GetNamespaceInfo(Assembly assembly)
        {
            List<NamespaceInfo> namespaceInfos = new();
            IEnumerable<string> namespaces = GetNamespaces(assembly);
            
            foreach (var namespaceTitle in namespaces)
            {
                NamespaceInfo namespaceInfo = new NamespaceInfo();
                namespaceInfo.NamespaceTitle = namespaceTitle;
                namespaceInfo.TypeInfo = TypeService.GetTypeInfo(assembly, namespaceTitle);
                namespaceInfos.Add(namespaceInfo);
            }
            
            return namespaceInfos;
        }

        private IEnumerable<string?> GetNamespaces(Assembly assembly)
        {
            return assembly.GetTypes().Select(type => type.Namespace).Distinct();
        }
    }
}