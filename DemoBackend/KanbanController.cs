using IAZBackend.FrontendData;
using IAZBackend.Models.ApsEntities;

namespace IAZBackend
{
    public static class MasterKanbanController
    {
        public static List<KanbanColumnData> GetKanbanColumns(int groupNumber)
        {
            ColorSelector colorSelector = new ColorSelector();

            using IAZ_ApsContext dbContext = new();
            return dbContext.Workgroups
                .Where(wg => wg.Number == groupNumber)
                .SelectMany(wg => wg.Workers)
                .OrderBy(wr => wr.ProfessionCode)
                .Select(wr => new KanbanColumnData()
                {
                    id = wr.SecConstraintId.ToString(),
                    text = wr.Name,
                    color = colorSelector.GetColor(wr.ProfessionCode),
                    tooltip = $"{wr.Name}<br>Код профессии: {wr.ProfessionCode}<br>Произв. группы: {GetWorkerGroupsStr(wr)}"
                })
                .ToList();
        }

        private static object GetWorkerGroupsStr(SecConstraint worker)
        {
            if (!worker.Workgroups.Any())
                return "нет";
            string s = worker.Workgroups
                .OrderBy(wg => wg.Number)
                .Aggregate("", (seed, gr) => $"{seed}{gr.Number}, ");
            return s.Substring(0, s.Length - 2);
        }

        //public static List<KanbanTaskData> GetKanbanTasks(Dataset dataset, int groupNumber)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
