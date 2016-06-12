using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class PruneOpWithSingleChild : BaseRule
    {
        public override int Order { get { return base.Order + 10; } }

        public override bool Process(Node node)
        {
            if((node.Name=="+"|| node.Name == "/" || node.Name == "*" || node.Name == "^") && node.Children.Count == 1)
            {
                Copy(node.Children[0], node);
               
                return true;
            }

            return false;
        }
    }
}
