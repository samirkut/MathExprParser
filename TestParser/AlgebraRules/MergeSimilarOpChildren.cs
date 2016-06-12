using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public class MergeSimilarOpChildren : BaseRule
    {
        public override bool Process(Node node)
        {
            if (node.Type == NodeType.Operator 
                && (node.Name=="+" || node.Name == "-" || node.Name == "*" || node.Name == "/")
                && node.Children.Any(x => x.Type == NodeType.Operator && x.Name == node.Name))
            {
                var matchingNodes = node.Children.Where(x => x.Type == NodeType.Operator && x.Name == node.Name).ToList();
                foreach (var matchNode in matchingNodes)
                {
                    var idx = node.Children.IndexOf(matchNode);
                    node.Children.Remove(matchNode);

                    //insert children in the same place
                    foreach (var matchChild in matchNode.Children)
                    {
                        node.Children.Insert(idx, matchChild);
                        idx++;
                    }
                }
                return true;
            }

            return false;
        }
    }
}
