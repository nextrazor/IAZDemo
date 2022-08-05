using Newtonsoft.Json;

namespace IAZBackend
{
    public enum GantElementType { task, milestone, project }
    public class GanttData
    {
        List<IGanttElement> ganttElements = new List<IGanttElement>();

        public string Result() {
            string buffer = "[";
            ganttElements.ForEach(el=> {
                switch (el.type)
                {
                    case "milestone":
                        buffer += JsonConvert.SerializeObject((Milestone)el) + ", ";
                        break;
                    case "project":
                        buffer += JsonConvert.SerializeObject((Project)el) + ", ";
                        break;
                    case "task":
                        buffer += JsonConvert.SerializeObject((Task)el) + ", ";
                        break;
                }
            });
            buffer = buffer.Remove(buffer.Length - 2, 1);
            buffer += "]";
            return buffer;
        } 

        public void Add(IGanttElement ganttElement)
        {
            ganttElement.displayOrder = ganttElements.Count();
            ganttElements.Add(ganttElement);
        }
    }

    public interface IGanttElement
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public int progress { get; set; }
        public int displayOrder { get; set; }

        public object ReturnGantElement();
        
    }

    [Serializable]
    public class Project : IGanttElement
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public int progress { get; set; }
        public int displayOrder { get; set; }

        public Project(DateTime start, DateTime end, string name, string id, int progress)
        {
            this.start = start;
            this.end = end;
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
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public int progress { get; set; }
        public int displayOrder { get; set; }

        public string project;
        public string[] dependencies = new string[] { };
        public bool isDisabled;

        public Task(DateTime start, DateTime end, string name, string id, string project, string[] dependencies, int progress, bool isDisabled)
        {
            this.start = start;
            this.end = end;
            this.name = name;
            this.id = id;
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
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public int progress { get; set; }
        public int displayOrder { get; set; }

        public string project;
        public string[] dependencies = new string[] { };
        public bool isDisabled;

        public Milestone(DateTime start, DateTime end, string name, string id, string project, string[]? dependencies, int progress, bool isDisabled)
        {
            this.start = start;
            this.end = end;
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
