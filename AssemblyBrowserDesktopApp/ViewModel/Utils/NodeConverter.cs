using System.Collections.Generic;
using AssemblyBrowserCore;
using AssemblyBrowserDesktopApp.Model;

namespace AssemblyBrowserDesktopApp.ViewModel.Utils
{
    public class NodeConverter
    {
        public List<Node> ConvertAssemblyInfoInNodes(AssemblyInfo assemblyInfo)
        {
            List<Node> nodes = new();
            foreach (var namespaceInfo in assemblyInfo.NamespaciesInfos)
            {
                Node node = new Node();
                node.Title = "Namespace: " + namespaceInfo.NamespaceTitle;
                node.Nodes = GetTypeNodes(namespaceInfo.TypeInfo);
                nodes.Add(node);
            }

            return nodes;
        }

        private List<Node> GetTypeNodes(List<TypeInfo> typeInfos)
        {
            List<Node> nodes = new();
            foreach (var typeInfo in typeInfos)
            {
                Node node = new Node();
                node.Title = typeInfo.Type + " " + typeInfo.TypeName;
                node.Nodes = GetTypeMemberNodes(typeInfo);
                nodes.Add(node);
            }

            return nodes;    
        }

        private List<Node> GetTypeMemberNodes(TypeInfo typeInfo)
        {
            List<Node> nodes = new();
            foreach (var fieldInfo in typeInfo.FieldInfos)
            {
                Node node = new Node();
                node.Title = "Field: " + fieldInfo.FieldType + " "  + fieldInfo.FieldName;
                nodes.Add(node);
            }
            foreach (var propertyInfo in typeInfo.PropertyInfos)
            {
                Node node = new Node();
                node.Title = "Property: " + propertyInfo.PropertyType + " "  + propertyInfo.PropertyName;
                nodes.Add(node);
            }
            foreach (var methodInfo in typeInfo.MethodInfos)
            {
                Node node = new Node();
                node.Title = "Method: " + methodInfo.ReturnType + " " + methodInfo.MethodName + "()";
                node.Nodes = GetParamNodesForMethodNode(methodInfo); 
                nodes.Add(node);
            }

            return nodes;     
        }

        private List<Node> GetParamNodesForMethodNode(MethodInfo methodInfo)
        {
            List<Node> nodes = new();
            foreach (var fieldInfo in methodInfo.FieldInfos)
            {
                Node node = new Node();
                node.Title = "Param: " + fieldInfo.FieldType + " "  + fieldInfo.FieldName;
                nodes.Add(node);
            }

            return nodes;
        }
    }
}