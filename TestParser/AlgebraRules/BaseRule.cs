using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser.AlgebraRules
{
    public abstract class BaseRule
    {
        public virtual int Order { get { return 10; } }

        public string Name { get { return GetType().Name; } }
        
        public abstract bool Process(Node node);

        protected void Copy(Node from, Node to)
        {
            to.Name = from.Name;
            to.Type = from.Type;
            to.Children = from.Children;
        }

        protected void SetConstant(Node node, string value)
        {
            node.Name = value;
            node.Type = NodeType.Constant;
            node.Children.Clear();
        }

        protected double GetDouble(Node node)
        {
            var ret = double.NaN;
            double.TryParse(node.Name, out ret);
            return ret;
        }
    }
}
