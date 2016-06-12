using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class PowOne : BaseRule
    {
        public override bool Process(Node node)
        {
            if (node.Name == "^" && node.Children.Any(x => x.Name == "1"))
            {
                //find the idx of child which is one
                var oneChild = node.Children.FirstOrDefault(x => x.Name == "1");
                var oneIdx = node.Children.IndexOf(oneChild);

                //if idx is 0, then replace the whole thing with 1, otherwise prune it
                if (oneIdx == 0)
                    SetConstant(node, "1");
                else
                {
                    node.Children.Remove(oneChild);
                    if (node.Children.Count == 1)
                        Copy(node.Children[0], node);
                }

                return true;
            }

            return false;
        }
    }
}
