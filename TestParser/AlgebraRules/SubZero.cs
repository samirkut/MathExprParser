using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class SubZero : BaseRule
    {
        public override bool Process(Node node)
        {
            if (node.Name == "-" && node.Children.Any(x => x.Name == "0"))
            {
                //find the idx of child which is zero
                var zeroChild = node.Children.FirstOrDefault(x => x.Name == "0");
                var zeroIdx = node.Children.IndexOf(zeroChild);

                //if idx is 0 and there is more than one child we create a unary -ve expression
                if (zeroIdx == 0 && node.Children.Count > 1)
                {
                    var nodeToNegate = node.Children[1];
                    node.Children[1] = new Node
                    {
                        Name = "-",
                        Type = NodeType.Operator,
                        Children = new List<Node> { nodeToNegate }
                    };
                }

                node.Children.Remove(zeroChild);

                //-0 would translate to 0
                if (!node.Children.Any())
                    SetConstant(node, "0");

                return true;
            }

            return false;
        }
    }
}
