using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class MulZero : BaseRule
    {
        public override bool Process(Node node)
        {
            if (node.Name == "*" && node.Children.Any(x => x.Name == "0"))
            {
                SetConstant(node, "0");
                return true;
            }
            
            return false;
        }
    }
}
