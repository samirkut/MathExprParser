using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser
{
    public class Node : IEqualityComparer<Node>
    {
        public IList<Node> Children { get; set; }
        public string Name { get; set; }
        public NodeType Type { get; set; }

        public Node()
        {
            Children = new List<Node>();
        }

        public Node(string name)
            :this()
        {
            Name = name;
        }

        public bool Equals(Node x, Node y)
        {
            if (!string.Equals(x.Name, y.Name) || x.Children.Count != y.Children.Count)
                return false;
            for(var i = 0; i < x.Children.Count; i++)
                if (!Equals(x.Children[i], y.Children[i]))
                    return false;
            return true;
        }

        public int GetHashCode(Node obj)
        {
            return Name.GetHashCode();
        }
    }
}
