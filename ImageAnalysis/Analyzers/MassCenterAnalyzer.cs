using ImageAnalysis.Snapshot;
using Tools;

namespace ImageAnalysis.Analyzers
{
    public class MassCenterAnalyzer : Analyzer
    {
        public MassCenterAnalyzer(ConnectedAreasSnapshot snapshot) : base(snapshot)
        { 
        }

        public Axis Axis { get; set; } = Axis.X;

        protected override long AnalyzeElement(int row, int column, int areaNumber)
            => Axis == Axis.X ? column : row;
    }
}
