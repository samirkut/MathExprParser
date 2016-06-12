using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestParser.AlgebraRules;

namespace TestParser
{
    public static class ExpressionProcessor
    {
        private readonly static BaseRule[] _rules;

        static ExpressionProcessor()
        {
            _rules = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.BaseType == typeof(BaseRule) && !type.IsAbstract)
                .Select(type => Activator.CreateInstance(type))
                .OfType<BaseRule>()
                .OrderBy(rule => rule.Order)
                .ToArray();
        }

        public static void ApplyAlgebraRules(Node node)
        {
            var hasChanges = true;
            while (hasChanges)
            {
                hasChanges = ApplyRulesOnNode(node);
            }
        }

        static bool ApplyRulesOnNode(Node node)
        {
            var hasChanges = false;
            foreach (var rule in _rules)
                hasChanges = hasChanges || rule.Process(node);

            if (hasChanges) return true;

            //apply for children now
            foreach (var chld in node.Children)
                hasChanges = hasChanges || ApplyRulesOnNode(chld);

            return hasChanges;
        }
        
    }
}
