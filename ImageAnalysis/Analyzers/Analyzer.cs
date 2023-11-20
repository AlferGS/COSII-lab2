using System;
using ImageAnalysis.Snapshot;

namespace ImageAnalysis.Analyzers
{
    public abstract class Analyzer
    {
        protected readonly ConnectedAreasSnapshot snapshot;
        
        protected Analyzer(ConnectedAreasSnapshot snapshot)
        {
            if (snapshot is null)
            {
                throw new ArgumentNullException(nameof(snapshot));
            }

            this.snapshot = snapshot;
        }
        
        public long Analyze(int areaNumber)
        {
            long result = 0;
            for(int row = 0; row < snapshot.Height; ++row)
            {
                for (int column = 0; column < snapshot.Width; ++column)
                {
                    if (snapshot[row, column] == areaNumber)
                    { 
                        result += AnalyzeElement(row, column, areaNumber);
                    }
                }
            }

            return result;
        }

        protected abstract long AnalyzeElement(int row, int column, int areaNumber);
    }
}
