using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using System.IO;

namespace TestParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = GetExpression();

            while (!string.IsNullOrEmpty(expression))
            {
                var input = new AntlrInputStream(expression);
                var lexer = new MathExprLexer(input);
                var tokens = new CommonTokenStream(lexer);
                var parser = new MathExprParser(tokens);

                var visitor = new MathExprVisitor();
                var result = visitor.Visit(parser.expr());

                result.Dump();

                ExpressionProcessor.ApplyAlgebraRules(result);

                result.Dump();

                expression = GetExpression();
            }

            Console.Read();
            
        }

        static string GetExpression()
        {
            Console.Write("Expr: ");
            return Console.ReadLine();
        }
    }
}