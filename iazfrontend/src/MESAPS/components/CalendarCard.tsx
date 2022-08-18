import type { FC } from 'react';
import { useRef } from 'react';
import { BryntumCalendar } from '@bryntum/calendar-react';
import type { CalendarProps } from '../service/types';
import { CalendarConfig } from '@bryntum/calendar';
import '@bryntum/calendar/calendar.stockholm.css';
import './calendar.css';

const KanbanCard: FC<CalendarProps> = (props: CalendarProps) => {
  const taskBoardRef = useRef<BryntumCalendar>(null);
  //const taskBoardInstance = () => taskBoardRef.current?.instance as TaskBoard;

  const calendarConfig: Partial<CalendarConfig> = {
    // Field used to pair a task to a column

    date: new Date('2022-07-01'),

    modes: {
      month: null,
      year: null,
      //week: null,
    },

    // onActiveItemChange({ value }) {
    //   props.selectedCalendarItem(value);
    // },

    resourceImagePath: './images/',

    modeDefaults: {
      hourHeight: 90,

      // These two settings decide what time span is rendered
      dayStartTime: 7,
      dayEndTime: 20,

      // Scroll to 7am initially
      visibleStartTime: 7,

      // Hours before 9am and after 5pm will be shaded grey.
      // coreHours: {
      //   start: 8,
      //   end: 20,
      // },
    },

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
