using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestParser
{
    public static class Extensions
    {
        public static bool Remove<T>(this IList<T> lst, Predicate<T> pred)
        {
            var toRemove = new List<T>();
            foreach (var item in lst)
                if (pred(item))
                    toRemove.Add(item);

            foreach (var item in toRemove)
                lst.Remove(item);

            return toRemove.Any();
        }

        public static void Dump(this Node node)
        {
            Console.WriteLine(GetHeirarchyAsString(node, string.Empty, false, true));
        }

        static string GetHeirarchyAsString(Node item, string indent, bool isLastSibling, bool isRoot = false)
        {
            var sb = new StringBuilder();
            if (item == null) item = new Node("<null>");

            if (isRoot)
                sb.AppendLine(item.Name);
            else
            {
                //add a blank line between each node (for clarity)
                //sb.AppendLine(indent + "\u2502");

                //Unicode char U+2514 (└) or U+251C (├) followed by U+2574 (╴) [changed to 2500 since 2574 doesnt render in win console]
                sb.AppendLine(indent + (isLastSibling ? "\u2514\u2500" : "\u251C\u2500") + item.Name);

                //add a blank line after the last child
                //if (isLastSibling && !item.Children.Any())
                //    sb.AppendLine(indent);

                //Space or U+2502 (│) followed by space
                indent += isLastSibling ? "  " : "\u2502 ";
            }

            for (var i = 0; i < item.Children.Count; i++)
                sb.Append(GetHeirarchyAsString(item.Children[i], indent, i == item.Children.Count - 1));
            return sb.ToString();
        }
    }
}
