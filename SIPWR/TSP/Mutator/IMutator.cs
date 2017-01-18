
namespace SIPWR.TSP.Mutator
{
    public interface IMutator
    {
        void Mutate(Tour tour, double mutationProbability);
    }
}