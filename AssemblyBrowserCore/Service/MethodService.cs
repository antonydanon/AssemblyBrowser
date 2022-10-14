using System;
using System.Collections.Generic;

namespace AssemblyBrowserCore.Service
{
    public class MethodService
    {
        public FieldService FieldService { get; set; }

        public MethodService()
        {
            FieldService = new FieldService();
        }
        
        
        public List<MethodInfo> GetMethodInfos(Type type)
        {
            List<MethodInfo> methodInfos = new();
            System.Reflection.MethodInfo[] methods = type.GetMethods();
            foreach (var method in methods)
            {
                MethodInfo methodInfo = new MethodInfo();
                methodInfo.MethodName = method.Name;
                methodInfo.ReturnType = method.GetType().Name;
                methodInfo.FieldInfos = FieldService.GetFieldInfos(method.GetParameters());
                methodInfos.Add(methodInfo);
            }
            
            return methodInfos;
        }
    }
}