namespace IAZBackend.FrontendData
{
    /// <summary>
    /// Данные для Pie Plot
    /// </summary>
    /// <remarks>
    /// https://charts.ant.design/en/examples/pie/basic#basic
    /// Заполняется Data, нужно добавить Config
    /// </remarks>
    [Serializable]
    public class PiePlotData
    {
        public ColoredNamedValue[] data = null!;

        public PiePlotData(ColoredNamedValue[] data)
        {
            this.data = data;
        }
    }
}
