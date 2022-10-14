using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssemblyBrowserCore.Service
{
    public class TypeService
    {
        public FieldService FieldService { get; set; }
        public PropertyService PropertyService { get; set; }
        public MethodService MethodService { get; set; }

        public TypeService()
        {
            FieldService = new FieldService();
            PropertyService = new PropertyService();
            MethodService = new MethodService();
        }
        
        public List<TypeInfo> GetTypeInfo(Assembly assembly, string namespaceTitle)
        {
            List<TypeInfo> typeInfos = new();
            
            IEnumerable<Type> types = assembly.GetTypes().Where(type => namespaceTitle == type.Namespace);
            foreach (var type in types)
            {
                TypeInfo typeInfo = new TypeInfo();
                typeInfo.FieldInfos = FieldService.GetFieldInfos();
                typeInfo.PropertyInfos = PropertyService.GetPropertyInfos();
                typeInfo.MethodInfos = MethodService.GetMethodInfos();
                typeInfo.TypeName = type.Name;
            }
            return typeInfos;
        }
    }
}