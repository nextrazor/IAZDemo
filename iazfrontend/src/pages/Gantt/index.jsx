import React, { useCallback, useEffect } from "react";

import GSTC from "gantt-schedule-timeline-calendar/dist/gstc.wasm.esm.min.js";
import { Plugin as TimelinePointer } from "gantt-schedule-timeline-calendar/dist/plugins/timeline-pointer.esm.min.js";
import { Plugin as Selection } from "gantt-schedule-timeline-calendar/dist/plugins/selection.esm.min.js";
import { Plugin as ItemResizing } from "gantt-schedule-timeline-calendar/dist/plugins/item-resizing.esm.min.js";
import { Plugin as ItemMovement } from "gantt-schedule-timeline-calendar/dist/plugins/item-movement.esm.min.js";
import { Plugin as HighlightWeekends } from 'gantt-schedule-timeline-calendar/dist/plugins/highlight-weekends.esm.min.js';
import { Plugin as DependencyLines } from 'gantt-schedule-timeline-calendar/dist/plugins/dependency-lines.esm.min.js';
import { Plugin as ItemTypes } from 'gantt-schedule-timeline-calendar/dist/plugins/item-types.esm.min.js';
import { Plugin as ProgressBar } from 'gantt-schedule-timeline-calendar/dist/plugins/progress-bar.esm.min.js';
import { Plugin as CalendarScroll } from 'gantt-schedule-timeline-calendar/dist/plugins/calendar-scroll.esm.min.js';

import "gantt-schedule-timeline-calendar/dist/style.css";

let gstc, state;

const GSTCID = GSTC.api.GSTCID;
const startDate = GSTC.api.date().subtract(2, 'month').valueOf();

const itemTypes = ['project', 'milestone', 'task'];

function getRandomItemType() {
  return itemTypes[Math.floor(Math.random() * itemTypes.length)];
}

const colors = ['#E74C3C', '#DA3C78', '#7E349D', '#0077C0', '#07ABA0', '#0EAC51', '#F1892D'];
function getRandomColor() {
  return colors[Math.floor(Math.random() * colors.length)];
}

// helper functions

function generateRows() {
  /**
   * @type { import("gantt-schedule-timeline-calendar").Rows }
   */
  const rows = {};
  for (let i = 0; i < 100; i++) {
    const id = GSTC.api.GSTCID(i.toString());
    rows[id] = {
      id,
      label: `Row ${i}`,
    };
  }
  return rows;
}

function generateItems() {
  /**
   * @type { import("gantt-schedule-timeline-calendar").Items }
   */
  const items = {};
  // @ts-ignore
  let start = GSTC.api.date().startOf("day").subtract(6, "day");
  for (let i = 0; i < 100; i++) {
    const id = GSTC.api.GSTCID(i.toString());
    const rowId = GSTC.api.GSTCID(Math.floor(Math.random() * 100).toString());
    start = start.add(1, "day");
    const type = getRandomItemType();
    items[id] = {
      type,
      id,
      fill: getRandomColor(),
      progress: Math.round(Math.random() * 100),
      label: `Item ${i}`,
      rowId,
      time: {
        start: start.valueOf(),
        end: start.add(1, "day").endOf("day").valueOf(),
      },
    };
  }

  items[GSTCID('0')].linkedWith = [GSTCID('1')];
  items[GSTCID('0')].label = 'Task 0 linked with 1 (clone)';
  items[GSTCID('0')].type = 'task';
  items[GSTCID('0')].fill = colors[0];
  items[GSTCID('1')].fill = colors[0];
  items[GSTCID('1')].label = 'Task 1 linked with 0 (clone)';
  items[GSTCID('1')].type = 'task';
  items[GSTCID('1')].time = { ...items[GSTCID('0')].time };
  
  items[GSTCID('3')].dependant = [GSTCID('5')];
  items[GSTCID('3')].time.start = GSTC.api.date(startDate).add(2, 'day').startOf('day').add(5, 'day').valueOf();
  items[GSTCID('3')].time.end = GSTC.api.date(items[GSTCID('3')].time.start).endOf('day').add(2, 'day').valueOf();
  
  items[GSTCID('5')].time.start = GSTC.api.date(items[GSTCID('3')].time.end).startOf('day').add(5, 'day').valueOf();
  items[GSTCID('5')].time.end = GSTC.api.date(items[GSTCID('5')].time.start).endOf('day').add(2, 'day').valueOf();
  items[GSTCID('5')].dependant = [GSTCID('7'), GSTCID('9')];
  
  items[GSTCID('7')].time.start = GSTC.api.date(items[GSTCID('5')].time.end).startOf('day').add(3, 'day').valueOf();
  items[GSTCID('7')].time.end = GSTC.api.date(items[GSTCID('7')].time.start).endOf('day').add(2, 'day').valueOf();
  items[GSTCID('9')].time.start = GSTC.api.date(items[GSTCID('5')].time.end).startOf('day').add(2, 'day').valueOf();
  items[GSTCID('9')].time.end = GSTC.api.date(items[GSTCID('9')].time.start).endOf('day').add(3, 'day').valueOf();

  return items;
}

function initializeGSTC(element) {
  /**
   * @type { import("gantt-schedule-timeline-calendar").Config }
   */
  const config = {
    licenseKey:
      "====BEGIN LICENSE KEY====\nTY6HoVzmn8BUt19vCzlV3CBn9nokRlQJIFf6U8geKJI3lzsAlT0J394JtYr4ldkG9tTSrx88C61eDPPL3ZnLcFas9VGgjbSnTqEi2dJ1wxc7BKhPbSR4mMvQQcL61O1BTw1cbAT75WOtmIlLUGRhXkJIdMfWbysjV4sLa2T03gMxb2IOmJ1tb66G9eUQ3hoI3yp/nOq2JUPZ6IeHWJNxcClOw3KDPF3BjVUO9RcmEIJ1Eduv8GOAa99ytPqJG23td+NwK8cAsnIeyJhUV/3OiO1tFPYpWWpPBeud853nQRsC6coTU5MJmxo8GP0sYwz/Qp+Y8ZJ4c+tvcZPqhqCUUA==||U2FsdGVkX1/6SEBAPra0YUSYtwXsei7Dnvg/e0fvqycvrjlvJzNNgfj/SxGk1JKURC8iGSlXmK1IgqaoylMtT0kmDAcVFSOONb6C4+r0KSY=\nQTPBIrTCbXcc+zcZ0AxmK9QmxYuVgZ0V/By7IovgGtv2AbWOBdjmvGevy97fssP+rBGO84HqFfVMOmNdMVyyYtqjQewZDmeb/7JqgAIIY9cxJiX8oUIbHh1AeVNAMCMy25J+4TkqGuaTbC/dYPzhr8s2WWBGZzl7FJtorviCFmHJa3YflSN8j95wVan6mrGlruDUMHOZr6/vH4ItW8JKnESzvdUx0Afg2a4R3QlqUYH+QdjB1efUr28T0GvsCeonSuXHa8VJ6U0fj0aF7kcz8KpJA8Scqle7TNrbmiZjqxRjh3ZLLVOsGWYm5t1DJVCwL6AuOB1+Wa0FMFv+9WhqRA==\n====END LICENSE KEY====",
    plugins: [TimelinePointer(), Selection(), ItemResizing({
      snapToTime: {
        start({ startTime }) {
          return startTime;
        },
        end({ endTime }) {
          return endTime;
        },
      },
    }), 
    ItemMovement({
      snapToTime: {
        start({ startTime }) {
          return startTime;
        },
        end({ endTime }) {
          return endTime;
        },
      },
      autoScroll: {
        speed: {
          horizontal: 1,
          vertical: 1,
        },
      },
    }),
    ProgressBar(),
    HighlightWeekends(),
    DependencyLines(),
    CalendarScroll(),
  
    ItemTypes()],
    list: {
      columns: {
        data: {
          [GSTC.api.GSTCID("id")]: {
            id: GSTC.api.GSTCID("id"),
            width: 60,
            data: ({ row }) => GSTC.api.sourceID(row.id),
            header: {
              content: "ID",
            },
          },
          [GSTC.api.GSTCID("label")]: {
            id: GSTC.api.GSTCID("label"),
            width: 200,
            data: "label",
            header: {
              content: "Label",
            },
          },
        },
      },
      rows: generateRows(),
    },
    chart: {
      items: generateItems(),
    },
    slots: {
      // item content slot that will show circle with letter next to item label
      'chart-timeline-items-row-item': {
        content: [
          (vido, props) => {
            const { onChange, html } = vido;
            let letter = props.item.label.charAt(0).toUpperCase();
            onChange((newProps) => {
              if (newProps && newProps.item) {
                props = newProps;
                letter = props.item.label.charAt(0).toUpperCase();
              }
            });
            return (content) => {
              if (!props || !props.item) return content;
              return html`<div
                  class="item-img"
                  style="width:24px;height:24px;background:${props.item
                    .imgColor};border-radius:100%;text-align:center;line-height:24px;font-weight:bold;margin-right:10px;"
                >
                  ${letter}
                </div>
                ${content}`;
            };
          },
        ],
      },
    },
  };
  

  state = GSTC.api.stateFromConfig(config);

  gstc = GSTC({
    element,
    state,
  });
}

function Gantt() {
  const callback = useCallback((element) => {
    if (element) initializeGSTC(element);
  }, []);

  useEffect(() => {
    return () => {
      if (gstc) {
        gstc.destroy();
      }
    };
  });

  function updateFirstRow() {
    state.update(`config.list.rows.${GSTC.api.GSTCID("0")}`, (row) => {
      row.label = "Changed dynamically";
      return row;
    });
  }

  function changeZoomLevel() {
    state.update("config.chart.time.zoom", 21);
  }

  return (
    <div className="Gantt" start = "height:100%">
      <div className="toolbox">
        <button onClick={updateFirstRow}>Update first row</button>
        <button onClick={changeZoomLevel}>Change zoom level</button>
      </div>
      <div className="gstc-wrapper" ref={callback}></div>
    </div>
  );
}

export default Gantt;
