namespace IAZBackend.FrontendData
{
    [Serializable]
    public class Demand
    {
        public string orderNo { get; set; } = string.Empty;
        public DateTime? dueDate { get; set; }
        public DateTime? endTime { get; set; }
        public string partNo { get; set; } = string.Empty;
        public double quantity { get; set; }
        public bool isMilitary { get; set; }
        public int? workGroup { get; set; }

        public override string ToString() => orderNo;
    }
}
