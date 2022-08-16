import { Card } from 'antd';
import type { FC } from 'react';
import { useRef } from 'react';
import { Store, StoreConfig, ModelConfig } from '@bryntum/taskboard';
import { TaskBoard } from '@bryntum/taskboard';
import { BryntumTaskBoard } from '@bryntum/taskboard-react';
import type { KanbanProps } from '../../customDashboard/service/types';
import { TaskBoardConfig } from '@bryntum/taskboard';
import '@bryntum/taskboard/taskboard.stockholm.css';

const KanbanCard: FC<KanbanProps> = (props: KanbanProps) => {
  const taskBoardRef = useRef<BryntumTaskBoard>(null);
  //const taskBoardInstance = () => taskBoardRef.current?.instance as TaskBoard;

  const taskboardConfig: Partial<TaskBoardConfig> = {
    columns: props.columns,

    // Field used to pair a task to a column
    columnField: 'status',

    project: {
      transport: {
        load: {
          url: 'http://localhost:5166/kanban',
        },
      },
      autoLoad: true,
    },
  };
  return (
    //<Card loading={props.loading}>
    <BryntumTaskBoard ref={taskBoardRef} {...taskboardConfig} />
    //</Card>
  );
};

export default KanbanCard;
