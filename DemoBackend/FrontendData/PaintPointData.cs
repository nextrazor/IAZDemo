namespace IAZBackend.FrontendData
{
    /// <summary>
    /// Список проблемных точек
    /// </summary>
    /// <remarks>
    /// https://ant.design/components/table/
    /// </remarks>
    [Serializable]
    public class PainPointData
    {
        public PainPoint[] Data;

        public PainPointData(PainPoint[] data)
        {
            Data = data;
        }
    }
}
