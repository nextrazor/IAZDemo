using Newtonsoft.Json;

namespace IAZBackend.FrontendData
{
    [Serializable]
    public class KpiPageData : FrontendData
    {
        public PiePlotData lateOrders;
        public PiePlotData lateOpers;
        public GaugePlotData oeeGauge;
        public LoadingPlotData loadingPlot;
        public PainPointData painPoints;

        public KpiPageData(NamedValue[] lateOrdersData, NamedValue[] lateOpersData, double oee, LoadingValue[] loadingData, PainPoint[] pPoints)
        {
            lateOrders = new PiePlotData(lateOrdersData);
            lateOpers = new PiePlotData(lateOpersData);
            oeeGauge = new GaugePlotData(oee, GaugeRange.GetRgrRange(0.4, 0.7));
            loadingPlot = new LoadingPlotData(loadingData);
            painPoints = new PainPointData(pPoints);
        }

        public override string GetJson()
        {
            return $"{{\"data\": {JsonConvert.SerializeObject(this)}}}";
        }
    }
}
