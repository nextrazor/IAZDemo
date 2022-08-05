import { Task } from "../Gantt/src/types/public-types";

export function initTasks() {
  const currentDate = new Date();
  var tasks: Task[] = [
  {
    start: new Date(currentDate.getFullYear(), currentDate.getMonth(), 1),
    end: new Date(
      currentDate.getFullYear(),
      currentDate.getMonth(),
      2,
      12,
      28
    ),
    name: "Idea",
    id: "Task 99",
    progress: 45,
    type: "task",
    displayOrder: 2,
  }
  ];

  return tasks;
}

export function getStartEndDateForProject(tasks: Task[], projectId: string) {
  const projectTasks = tasks.filter(t => t.project === projectId);
  let start = projectTasks[0].start;
  let end = projectTasks[0].end;

  for (let i = 0; i < projectTasks.length; i++) {
    const task = projectTasks[i];
    if (start.getTime() > task.start.getTime()) {
      start = task.start;
    }
    if (end.getTime() < task.end.getTime()) {
      end = task.end;
    }
  }
  return [start, end];
}
