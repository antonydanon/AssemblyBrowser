using System.Collections.Generic;

namespace AssemblyBrowserCore
{
    public class MethodInfo
    {
        public string MethodName { get; set; }
        public string ReturnType { get; set; }
        public List<FieldInfo> FieldInfos { get; set; }
    }
}