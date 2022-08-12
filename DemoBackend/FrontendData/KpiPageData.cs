using Newtonsoft.Json;

namespace IAZBackend.FrontendData
{
    [Serializable]
    public class KpiPageData : FrontendData
    {
        public PiePlotData LateOrders;
        public PiePlotData LateOpers;
        public GaugePlotData OeeGauge;
        public LoadingPlotData LoadingPlot;
        public PainPointData PainPoints;

        public KpiPageData(NamedValue[] lateOrdersData, NamedValue[] lateOpersData, double oee, LoadingValue[] loadingData, PainPoint[] painPoints)
        {
            LateOrders = new PiePlotData(lateOrdersData);
            LateOpers = new PiePlotData(lateOpersData);
            OeeGauge = new GaugePlotData(oee, GaugeRange.GetRgrRange(0.4, 0.7));
            LoadingPlot = new LoadingPlotData(loadingData);
            PainPoints = new PainPointData(painPoints);
        }

        public override string GetJson()
        {
            return $"{{\"data\": {JsonConvert.SerializeObject(this)}}}";
        }
    }
}
