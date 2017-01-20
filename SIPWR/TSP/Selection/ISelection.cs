using System.Collections.Generic;

namespace SIPWR.TSP.Selection
{
    public interface ISelection
    {
        Tour Selection(
            List<Tour> populations,
            Dictionary<string, Dictionary<string, double>> distances);
    }
}
