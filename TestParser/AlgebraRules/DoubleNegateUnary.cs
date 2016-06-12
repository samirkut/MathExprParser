using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class DoubleNegateUnary : BaseRule
    {
        public override bool Process(Node node)
        {
            if(node.Name == "-" && node.Children.Count==1 && node.Children[0].Name=="-")
            {
                Copy(node.Children[0], node);
                node.Name = "+";//- of - is +
                return true;
            }

            return false;
        }
    }
}
