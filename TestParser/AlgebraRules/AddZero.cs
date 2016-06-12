using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class AddZero : BaseRule
    {
        public override bool Process(Node node)
        {
            if (node.Name != "+" || node.Children.Count < 2)
                return false;

            var hasChanges = node.Children.Remove(chd => chd.Name == "0");

            if (node.Children.Count == 0)
            {
                SetConstant(node, "0");
            }
            if (node.Children.Count == 1)
            {
                Copy(node.Children[0], node);             
            }

            return hasChanges;
        }
    }
}
