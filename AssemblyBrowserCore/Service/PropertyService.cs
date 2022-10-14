using System;
using System.Collections.Generic;

namespace AssemblyBrowserCore.Service
{
    public class PropertyService
    {
        public List<PropertyInfo> GetPropertyInfos(Type type)
        {
            List<PropertyInfo> propertyInfos = new();
            System.Reflection.PropertyInfo[] properties = type.GetProperties();
            foreach (var property in properties)
            {
                PropertyInfo propertyInfo = new PropertyInfo();
                propertyInfo.PropertyName = property.Name;
                propertyInfo.PropertyType = property.GetType().Name;
                propertyInfos.Add(propertyInfo);
            }
            
            return propertyInfos;
        }
    }
}