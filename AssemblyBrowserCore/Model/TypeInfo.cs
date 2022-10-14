using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowserCore
{
    public class TypeInfo
    {
        public string TypeName { get; set; }
        public List<FieldInfo> FieldInfos { get; set; }
        public List<PropertyInfo> PropertyInfos { get; set; }
        public List<MethodInfo> MethodInfos { get; set; }
    }
}