using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowserCore
{
    public class TypeInfo
    {
        private string TypeName { get; set; }
        private List<FieldInfo> FieldInfos { get; set; }
        private List<PropertyInfo> PropertyInfos { get; set; }
        private List<MethodInfo> MethodInfos { get; set; }
    }
}