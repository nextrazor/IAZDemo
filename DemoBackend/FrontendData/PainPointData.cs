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
        public PainPoint[] data;

        public PainPointData(PainPoint[] data)
        {
            this.data = data;
        }
    }
}
