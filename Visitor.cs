using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace ANTLR4.ParserHelpers
{
    internal class Visitor : TreeWorker
    {
        public Visitor(ITreeBuilder treeBuilder) : base(treeBuilder)
        {            
        }

        public Visitor(ITreeBuilderStrategy treeBuilderStrategy) : base(new TreeBuilder(treeBuilderStrategy))
        {
        }

        public void VisitWith<TResult>(ICharStream input, IParseTreeVisitor<TResult> parseTreeVisitor)
        {
            if (input == null) 
                throw new ArgumentNullException("input");
            
            if(parseTreeVisitor == null)
                throw new ArgumentNullException("parseTreeVisitor");

            Func<ICharStream, IParseTree> createTree = base.CreateTree;
            var tree = createTree(input);
            
            if (tree != null)
                parseTreeVisitor.Visit(tree);
        }
    }
}