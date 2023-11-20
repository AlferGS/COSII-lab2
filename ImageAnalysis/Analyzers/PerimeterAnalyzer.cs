using ImageAnalysis.Snapshot;
using Tools;

namespace ImageAnalysis.Analyzers
{
    public class PerimeterAnalyzer : Analyzer
    {
        public PerimeterAnalyzer(ConnectedAreasSnapshot snapshot) : base(snapshot)
        {
        }

        protected override long AnalyzeElement(int row, int column, int areaNumber)
        {
            foreach (var neighborPoint in NeighborIndexer.GetDirectNeighbors(column, row, snapshot.Width, snapshot.Height))
            {
                if (snapshot[neighborPoint.row, neighborPoint.column] == 0)
                {
                    return 1;
                }
            }   

            return 0;
        }
    }
}
