namespace IAZBackend.FrontendData
{
    /// <summary>
    /// Данные для Percent Column Plot
    /// </summary>
    /// <remarks>
    /// https://charts.ant.design/en/examples/column/percent#basic
    /// Заполняется Data, нужно добавить Config
    /// </remarks>
    [Serializable]
    public class LoadingPlotData
    {
        public LoadingValue[] Data = null!;

        public LoadingPlotData(LoadingValue[] data)
        {
            Data = data;
        }
    }
}
