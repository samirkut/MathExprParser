using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class DivOne : BaseRule
    {
        public override bool Process(Node node)
        {
            if (node.Name == "/" && node.Children.Any() && node.Children[node.Children.Count-1].Name=="1")
            {
                //remove last child which is 1
                node.Children.RemoveAt(node.Children.Count - 1);
                if (node.Children.Count == 1)
                {
                    Copy(node.Children[0], node);
                }
                return true;
            }

            return false;
        }
    }
}
