using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssemblyBrowserCore.Service
{
    public class NamespaceService
    {
        public TypeService TypeService { get; set; }
        public NamespaceService()
        {
            TypeService = new TypeService();
        }
        public List<NamespaceInfo> GetNamespaceInfo(Assembly assembly)
        {
            List<NamespaceInfo> namespaceInfos = new();
            IEnumerable<string?> namespaces = GetNamespaces(assembly);

            int index = 0;
            foreach (var namespaceTitle in namespaces)
            {
                namespaceInfos[index].NamespaceTitle = namespaceTitle;
                namespaceInfos[index].TypeInfo = TypeService.GetTypeInfo(assembly, namespaceTitle);
            }
            
            return new List<NamespaceInfo>();
        }

        private IEnumerable<string?> GetNamespaces(Assembly assembly)
        {
            return assembly.GetTypes().Select(type => type.Namespace).Distinct();
        }
    }
}