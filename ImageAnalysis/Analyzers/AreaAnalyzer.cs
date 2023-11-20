using ImageAnalysis.Snapshot;

namespace ImageAnalysis.Analyzers
{
    public class AreaAnalyzer : Analyzer
    {
        public AreaAnalyzer(ConnectedAreasSnapshot snapshot) : base(snapshot)
        {
        }

        protected override long AnalyzeElement(int row, int column, int areaNumber) => 1;
    }
}
