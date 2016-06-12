using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class DivZero : BaseRule
    {
        public override bool Process(Node node)
        {
            //if first child zero, the whole expression can be replaced by zero
            if (node.Name == "/" && node.Children.Any() && node.Children[0].Name == "0")
            {
                SetConstant(node, "0");
                return true;
            }
            
            return false;
        }
    }
}
