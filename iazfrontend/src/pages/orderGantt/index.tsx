import type { FC } from 'react';
import { useRef } from 'react';
import { BryntumSchedulerPro } from '@bryntum/schedulerpro-react';
import type { GanttProps } from '../../MESAPS/service/types';
import { SchedulerProConfig } from '@bryntum/schedulerpro';
import '@bryntum/schedulerpro/schedulerpro.stockholm.css';

const Gantt: FC<GanttProps> = (props: GanttProps) => {
  const schedulerpro = useRef<BryntumSchedulerPro>(null);

  console.log();

  const schedulerproConfig: Partial<SchedulerProConfig> = {
    startDate: new Date(2022, 6, 1),
    endDate: new Date(2022, 8, 1),
    barMargin: 15,
    eventStyle: 'colored',
    viewPreset: 'hourAndDay-64by40',
    features: {
      percentBar: true
    },
    rowHeight: 90,

    columns: [{ type: 'resourceInfo', width: 150 }],

    project: {
      autoLoad: true,
      transport: {
        load: {
          url: 'http://localhost:5166/ordergantt/' + props.location.query.order,
        },
      },
    },
  };

  return <BryntumSchedulerPro ref={schedulerpro} {...schedulerproConfig} />;
};

export default Gantt;
