using Newtonsoft.Json;

namespace IAZBackend
{
    public enum GantElementType { task, milestone, project }
    public class GanttData
    {
        List<Resource> resources = new List<Resource>();

        List<IGanttElement> ganttElements = new List<IGanttElement>();

        public string Result() {
            string resourcesBuffer = "\"resources\" :  { \"rows\": [";
            resources.ToList().ForEach(el => {
                resourcesBuffer += JsonConvert.SerializeObject(el) + ", ";
            });
            resourcesBuffer = resourcesBuffer.Remove(resourcesBuffer.Length - 2, 1);
            resourcesBuffer += "] } ";


            string elementsBuffer = "\"events\" : { \"rows\": [";
            ganttElements.ToList().ForEach(el=> {
                switch (el.type)
                {
                    case "milestone":
                        elementsBuffer += JsonConvert.SerializeObject((Milestone)el) + ", ";
                        break;
                    case "project":
                        elementsBuffer += JsonConvert.SerializeObject((Project)el) + ", ";
                        break;
                    case "task":
                        elementsBuffer += JsonConvert.SerializeObject((Task)el) + ", ";
                        break;
                }
            });
            elementsBuffer = elementsBuffer.Remove(elementsBuffer.Length - 2, 1);
            elementsBuffer += "] } ";


            return "{ " + resourcesBuffer + " , " + elementsBuffer + " }";
        } 

        public void Add(IGanttElement ganttElement)
        {
            ganttElement.displayOrder = ganttElements.Count();
            ganttElements.Add(ganttElement);
        }

        public void Add(Resource[] res)
        {
            resources.AddRange(res);
        }
    }

    public class Resource
    {
        public int id { get; set; }
        public string name { get; set; }

        public Resource(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }

    public interface IGanttElement
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public string name { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public int progress { get; set; }
        public int displayOrder { get; set; }

        public object ReturnGantElement();
        
    }

    [Serializable]
    public class Project : IGanttElement
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public int progress { get; set; }
        public int displayOrder { get; set; }

        public Project(DateTime start, DateTime end, string name, int id, int progress)
        {
            this.startDate = start;
            this.endDate = end;
            this.name = name;
            this.id = id;
            type = GantElementType.project.ToString();
            this.progress = progress;
        }

        
        public object ReturnGantElement()
        {
            return this;
        }
    }


    [Serializable]
    public class Task : IGanttElement
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public int resourceId { get; set; }
        public string type { get; set; }
        public int progress { get; set; }
        public int displayOrder { get; set; }

        public string project;
        public string[] dependencies = new string[] { };
        public bool isDisabled;

        public Task(DateTime start, DateTime end, string name, int id, int resourceId, string project, string[] dependencies, int progress, bool isDisabled)
        {
            this.startDate = start;
            this.endDate = end;
            this.name = name;
            this.id = id;
            this.resourceId = resourceId;
            type = GantElementType.task.ToString();
            this.project = project;
            this.dependencies = dependencies;
            this.progress = progress;
            this.displayOrder = displayOrder;
            this.isDisabled = isDisabled;
        }

        public object ReturnGantElement()
        {
            return this;
        }
    }


    [Serializable]
    public class Milestone : IGanttElement
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public int progress { get; set; }
        public int displayOrder { get; set; }

        public string project;
        public string[] dependencies = new string[] { };
        public bool isDisabled;

        public Milestone(DateTime start, DateTime end, string name, int id, string project, string[]? dependencies, int progress, bool isDisabled)
        {
            this.startDate = start;
            this.endDate = end;
            this.name = name;
            this.id = id;
            type = GantElementType.milestone.ToString();
            this.project = project;
            this.dependencies = dependencies;
            this.progress = progress;
            this.displayOrder = displayOrder;
            this.isDisabled = isDisabled;
        }

        public object ReturnGantElement()
        {
            return this;
        }
    }
}
