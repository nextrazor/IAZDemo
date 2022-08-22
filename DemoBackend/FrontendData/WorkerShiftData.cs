namespace IAZBackend.FrontendData
{
    [Serializable]
    public class WorkerMonthShiftData
    {
        public string workerCode { get; set; } = null!;
        public string fio { get; set; } = null!;
        public List<WorkerShiftData> shifts { get; set; } = new();
    }

    [Serializable]
    public class WorkerShiftData
    {
        public DateTime date { get; set; }
        public int shift { get; set; }
        public double hours { get; set; }
    }
}
