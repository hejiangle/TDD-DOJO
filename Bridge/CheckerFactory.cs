using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bridge.RuleCheckers;

namespace Bridge
{
    public class CheckerFactory
    {

        private readonly List<Checker> _checkers = new List<Checker>();

        private CheckerFactory()
        {
            Assembly
                .GetAssembly(typeof(Checker))
                .GetTypes()
                .Where(type => type.IsClass)
                .Where(type => !type.IsAbstract)
                .Where(type => type.IsSubclassOf(typeof(Checker)))
                .ToList()
                .ForEach(checkerType => _checkers.Add((Checker)Activator.CreateInstance(checkerType)));
        }

        public static CheckerFactory LaunchAllCheckers()
        {
            return new CheckerFactory();
        }

        public string Check(DescendingHandCards whiteCards, DescendingHandCards blackCards)
        {
            return _checkers.Find(checker => checker.IsCheckingFinished(whiteCards, blackCards)).ShowHand();
        }
    }
}