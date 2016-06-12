using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class SolveAllConstants : BaseRule
    {
        public override bool Process(Node node)
        {
            //all constants
            if(node.Type == NodeType.Operator && node.Children.Any() && node.Children.All(x => x.Type == NodeType.Constant))
            {
                var constantVals = node.Children.Select(GetDouble);
                var result = double.NaN;

                if (node.Children.Count > 1)
                {
                    if (node.Name == "+")
                        result = constantVals.Aggregate((x, y) => x + y);
                    if (node.Name == "-")
                        result = constantVals.Aggregate((x, y) => x - y);
                    if (node.Name == "*")
                        result = constantVals.Aggregate((x, y) => x * y);
                    if (node.Name == "/")
                        result = constantVals.Aggregate((x, y) => x / y);
                    if (node.Name == "^")
                        result = constantVals.Aggregate((x, y) => Math.Pow(x, y));
                }
                else
                {
                    //unary
                    if (node.Name == "+")
                        result = constantVals.First();
                    if (node.Name == "-")
                        result = -1 * constantVals.First();
                }

                SetConstant(node, result.ToString());
                return true;
            }

            return false;
        }
    }
}
