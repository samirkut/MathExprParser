using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public abstract class ProcessEmbeddedConstants : BaseRule
    {
        public override bool Process(Node node)
        {
            //more than one constants
            if (node.Type == NodeType.Operator && node.Children.Count(x => x.Type == NodeType.Constant) > 1)
            {
                double result;

                if (node.Name == "+" || node.Name == "*")
                {
                    result = node.Name == "+" ? 0 : 1;
                    for(var i = 0; i < node.Children.Count; i++)
                    {
                        if (node.Children[i].Type != NodeType.Constant)
                            continue;

                        if (node.Name == "+")
                            result += GetDouble(node.Children[i]);
                        if (node.Name == "-")
                            result -= GetDouble(node.Children[i]);
                        else if (node.Name == "*")
                            result *= GetDouble(node.Children[i]);
                    }

                    if (node.Children.All(x => x.Type == NodeType.Constant))
                    {
                        SetConstant(node, result.ToString());
                    }
                    else
                    {
                        node.Children.Remove(item => item.Type == NodeType.Constant);
                        node.Children.Add(new Node
                        {
                            Name = result.ToString(),
                            Type = NodeType.Constant
                        });
                    }

                    return true;
                }
             
                //SetConstant(node, result.ToString());
               // return true;
            }

            return false;
        }
    }
}
