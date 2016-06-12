using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class PowZero : BaseRule
    {
        public override bool Process(Node node)
        {
            if (node.Name == "^" && node.Children.Any(x => x.Name == "0"))
            {
                //find the idx of child which is zero
                var zeroChild = node.Children.FirstOrDefault(x => x.Name == "0");
                var zeroIdx = node.Children.IndexOf(zeroChild);

                //if idx is 0, then replace the whole thing with 0, otherwise 1
                if (zeroIdx == 0)
                    SetConstant(node, "0");
                else
                    SetConstant(node, "1");
                return true;
            }

            return false;
        }
    }
}
