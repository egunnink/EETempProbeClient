using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;

namespace EETempProbeClient
{
    public class TempSampleSeries : LineSeries
    {
        private const int DEFAULT_SAMPLE_RATE = 1;
        private const int DEFAULT_MAX_POINTS = 300;
        public const double UNDEFINED_SAMPLE = Double.MinValue;

        public int SampleRate { get; set; }
        public int MaxPoints { get; set; }

        public TempSampleSeries(int maxPoints = DEFAULT_MAX_POINTS, int sampleRate = DEFAULT_SAMPLE_RATE)
            : base()
        {
            Color = OxyColors.SkyBlue;
            MarkerType = MarkerType.Circle;
            MarkerSize = 3;
            MarkerStroke = OxyColors.White;
            MarkerFill = OxyColors.SkyBlue;

            SampleRate = sampleRate;
            MaxPoints = maxPoints;
        }

        public void PushSample(double sample)
        {
            // remove the oldest item if we have filled our buffer
            if (Points.Count >= MaxPoints)
            {
                Points.RemoveAt(0);// remove oldest item
            }

            // adjust everyone's time
            for (int i = 0; i < Points.Count; i++)
            {
                var point = Points[i];
                Points[i] = new DataPoint(point.X - SampleRate, point.Y);
            }
            
            // add new point
            Points.Add(sample == UNDEFINED_SAMPLE
                        ? DataPoint.Undefined
                        : new DataPoint(0, sample));
        }
    }
}
