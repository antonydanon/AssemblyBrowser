using System;
using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowserCore.Service
{
    public class FieldService
    {
        public List<FieldInfo> GetFieldInfos(Type type)
        {
            List<FieldInfo> fieldInfos = new();
            System.Reflection.FieldInfo[] fields = type.GetFields();
            foreach (var field in fields)
            {
                FieldInfo fieldInfo = new FieldInfo();
                fieldInfo.FieldName = field.Name;
                fieldInfo.FieldType = field.FieldType.Name;
                fieldInfos.Add(fieldInfo);
            }
            
            return fieldInfos;
        }
        
        public List<FieldInfo> GetFieldInfos(ParameterInfo[] parameterInfos)
        {
            List<FieldInfo> fieldInfos = new();
            foreach (var parameterInfo in parameterInfos)
            {
                FieldInfo fieldInfo = new FieldInfo();
                fieldInfo.FieldName = parameterInfo.Name;
                fieldInfo.FieldType = parameterInfo.ParameterType.Name;
                fieldInfos.Add(fieldInfo);
            }
            
            return fieldInfos;
        }
    }
}