using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    public static class VisitorExtensions
    {
        public static void Visit<TResult>(this IParseTreeVisitor<TResult> visitor, ICharStream input, ITreeBuilder treeBuilder)
        {
            if (input == null) 
                throw new ArgumentNullException("input");

            if (treeBuilder == null) 
                throw new ArgumentNullException("treeBuilder");

            var treeVisitor = new Visitor(treeBuilder);
            treeVisitor.VisitWith(input, visitor);
        }

        public static void Visit<TResult>(this IParseTreeVisitor<TResult> visitor, ICharStream input, ITreeBuilderStrategy treeBuilderStrategy)
        {
            if (visitor == null) 
                throw new ArgumentNullException("visitor");

            if (input == null) 
                throw new ArgumentNullException("input");

            if (treeBuilderStrategy == null) 
                throw new ArgumentNullException("treeBuilderStrategy");

            var treeVisitor = new Visitor(treeBuilderStrategy);
            treeVisitor.VisitWith(input, visitor);
        }
    }
}