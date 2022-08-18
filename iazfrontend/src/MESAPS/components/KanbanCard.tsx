import type { FC } from 'react';
import { useRef } from 'react';
import { BryntumTaskBoard } from '@bryntum/taskboard-react';
import type { KanbanProps } from '../../MESAPS/service/types';
import { TaskBoardConfig } from '@bryntum/taskboard';
import '@bryntum/taskboard/taskboard.stockholm.css';
import './test.css';
import { TaskModel, StringHelper, MessageDialog, Toast, TaskBoard } from '@bryntum/taskboard';

const KanbanCard: FC<KanbanProps> = (props: KanbanProps) => {
  const taskBoardRef = useRef<BryntumTaskBoard>(null);
  //const taskBoardInstance = () => taskBoardRef.current?.instance as TaskBoard;

  const taskboardConfig: Partial<TaskBoardConfig> = {
    columns: props.columns,

    // Field used to pair a task to a column
    columnField: 'status',

    features: {
      // Allow dragging columns
      columnDrag: true,
      // Customize the task editor to allow editing custom fields used in this demo
      taskEdit: {
        items: {
          progress: {
            type: 'number',
            min: 0,
            max: 100,
            label: 'Progress',
          },
        },
      },
      // Column header context menu, customized to not allow moving the Done column / any other column to after it
    },

    // Items added to each task body
    bodyItems: {
      // Progress bar
      progress: { type: 'progress' },
    },

	resourceImagePath : './images/',
		
    // Items added to each task footer
    footerItems: {
      // Team icon + text (using xss protection)
      team: {
        type: 'template',
        template: ({ value }) =>
          StringHelper.xss`<i class="b-fa b-fa-${teamIcons[value]}"></i>${value}`,
      },
    },

    project: {
      transport: {
        load: {
          url: 'http://localhost:5166/kanban',
        },
      },
      autoLoad: true,
    },

    taskRenderer({ cardConfig, taskRecord }) {
      // Append a new "details" element to each cards body, with some custom html in it to display field values
      cardConfig.children.body.children.details = {
        class: 'details',
        html: `
              <div>
                <label>Плановое начало</label>
                <div style="color:black; font-weight:bold; float:right ">${
                  taskRecord.start ?? 'None'
                }</div>
              </div>
              <div><label>Плановое завершение</label><div style="color:black; font-weight:bold; float:right ">${
                taskRecord.end ?? 'None'
              }</div></div>
              <div><label>Трудоемкость</label><div style="color:black; font-weight:bold; float:right ">${
                taskRecord.labour ?? 'None'
              }</div></div>
              <div><label>Деталь</label><div style="color:black; float:right ">${
                taskRecord.partNo ?? 'None'
              }</div></div>
          `,
      };

      // Color tasks by priority
      const prioColors = {
        Critical: 'red',
        High: 'orange',
        Medium: 'yellow',
        Low: 'green',
      };

      cardConfig.class[`b-taskboard-color-${prioColors[taskRecord.prio] ?? 'blue'}`] = true;
    },
  };
  return (
    //<Card loading={props.loading}>
    <BryntumTaskBoard ref={taskBoardRef} {...taskboardConfig} />
    //</Card>
  );
};

export default KanbanCard;
