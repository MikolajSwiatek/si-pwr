using System;

namespace SIPWR.TSP.Selection
{
    public static class SelectionFactory
    {
        public static ISelection Get(SelectionType type)
        {
            switch (type)
            {
                case SelectionType.Roulette:
                    return new Roulette() as ISelection;
                case SelectionType.Tournament:
                    return new Tournament() as ISelection;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}