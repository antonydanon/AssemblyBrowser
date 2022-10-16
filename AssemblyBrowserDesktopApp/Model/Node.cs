using System.Collections.Generic;

namespace AssemblyBrowserDesktopApp.Model
{
    public class Node
    {
        public string Title { get; set; }
        public List<Node> Nodes { get; set; } = new();
    }
}