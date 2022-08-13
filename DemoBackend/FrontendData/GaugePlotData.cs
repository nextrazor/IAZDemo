using System.Drawing;

namespace IAZBackend.FrontendData
{
    /// <summary>
    /// Данные для GaugePlot
    /// </summary>
    /// <remarks>
    /// https://charts.ant.design/en/examples/progress-plots/gauge#custom-color
    /// Заполняется percent и range, надо добавить indicator, statistic
    /// </remarks>
    [Serializable]
    public class GaugePlotData
    {
        public double percent;
        public GaugeRange range = null!;

        public GaugePlotData(double percent, GaugeRange range)
        {
            this.percent = percent;
            this.range = range;
        }
    }

    [Serializable]
    public class GaugeRange
    {
        public static GaugeRange GetTrafficLightRange(double redLevel, double yellowLevel)
        {
            return new GaugeRange(new double[] { 0, redLevel, yellowLevel, 1 },
                new Color[] { System.Drawing.Color.PaleVioletRed, System.Drawing.Color.LightYellow, System.Drawing.Color.PaleGreen });
        }

        public static GaugeRange GetRgrRange(double lowerBound, double upperBound)
        {
            return new GaugeRange(new double[] { 0, lowerBound, upperBound, 1 },
                new Color[] { System.Drawing.Color.PaleVioletRed, System.Drawing.Color.PaleGreen, System.Drawing.Color.PaleVioletRed });
        }

        public double[] ticks;
        public string[] color;

        public GaugeRange(double[] ticks, Color[] color)
        {
            if (ticks.Length != color.Length + 1)
                throw new ArgumentException("Array lengths do not match", nameof(color));
            this.ticks = ticks;
            this.color = color.Select(c => c.ToHexString()).ToArray();
        }
    }

    public static class ColorExtension
    {
        public static string ToHexString(this Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}
