import type { FC } from 'react';
import { useRef } from 'react';
import { BryntumCalendar } from '@bryntum/calendar-react';
import type { CalendarProps } from '../service/types';
import { CalendarConfig } from '@bryntum/calendar';
import '@bryntum/calendar/calendar.stockholm.css';

const KanbanCard: FC<CalendarProps> = (props: CalendarProps) => {
  const taskBoardRef = useRef<BryntumCalendar>(null);
  //const taskBoardInstance = () => taskBoardRef.current?.instance as TaskBoard;

  const calendarConfig: Partial<CalendarConfig> = {
    // Field used to pair a task to a column

    date: new Date(),

    modes: {
      //month: null,
      year: null,
      week: null,
    },

    // onActiveItemChange({ value }) {
    //   props.selectedCalendarItem(value);
    // },

    onEventClick(value) {
      props.selectedCalendarItem(value);
      console.log(taskBoardRef);
    },

    crudManager: {
      transport: {
        load: {
          url: 'http://localhost:5166/calendar',
        },
      },
      autoLoad: true,
    },
  };
  return (
    //<Card loading={props.loading}>
    <BryntumCalendar ref={taskBoardRef} {...calendarConfig} />
    //</Card>
  );
};

export default KanbanCard;
