using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;

namespace TestParser
{
    public class MathExprVisitor : MathExprBaseVisitor<Node>
    {
        public override Node VisitMulDiv([NotNull] MathExprParser.MulDivContext context)
        {
            return new Node
            {
                Name = context.op.Type == MathExprParser.MUL ? "*" : "/",
                Type = NodeType.Operator,
                Children = new List<Node>
                {
                    Visit(context.expr(0)), Visit(context.expr(1))
                }
            };
        }

        //public override Node VisitImpliedMul([NotNull] MathExprParser.ImpliedMulContext context)
        //{
        //    return new Node
        //    {
        //        Name = "*",
        //        Children = new List<Node>
        //        {
        //            Visit(context.expr(0)), Visit(context.expr(1))
        //        }
        //    };
        //}

        public override Node VisitAddSub([NotNull] MathExprParser.AddSubContext context)
        {
            return new Node
            {
                Name = context.op.Type == MathExprParser.PLUS ? "+" : "-",
                Type = NodeType.Operator,
                Children = new List<Node>
                {
                    Visit(context.expr(0)), Visit(context.expr(1))
                }
            };
        }

        public override Node VisitUnaryAddSub([NotNull] MathExprParser.UnaryAddSubContext context)
        {
            return new Node
            {
                Name = context.op.Type == MathExprParser.PLUS ? "+" : "-",
                Type = NodeType.Operator,
                Children = new List<Node>
                {
                    Visit(context.expr())
                }
            };
        }

        public override Node VisitPower([NotNull] MathExprParser.PowerContext context)
        {
            return new Node
            {
                Name = "^",
                Type = NodeType.Operator,
                Children = new List<Node>
                {
                    Visit(context.expr(0)), Visit(context.expr(1))
                }
            };
        }

        public override Node VisitVariable([NotNull] MathExprParser.VariableContext context)
        {
            return new Node
            {
                Name = context.VARIABLE().GetText(),
                Type = NodeType.Variable
            };
        }

        public override Node VisitNumber([NotNull] MathExprParser.NumberContext context)
        {
            return new Node
            {
                Name = context.NUMBER().GetText(),
                Type = NodeType.Constant
            };
        }

        public override Node VisitParens([NotNull] MathExprParser.ParensContext context)
        {
            return Visit(context.expr());
        }
    }
}
