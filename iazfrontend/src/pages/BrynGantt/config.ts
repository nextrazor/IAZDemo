import { BryntumSchedulerProProps } from '@bryntum/schedulerpro-react';

const schedulerProConfig: BryntumSchedulerProProps = {
    
    forceFit   : true,
    columns    : [
        {
            type           : 'resourceInfo',
            text           : 'Name',
            field          : 'name',
            showEventCount : false,
            width          : 150
        }
    ],

    // Project using inline data
    project : {
        // autoLoad: true,
        transport : {
            load : {
                url : 'http://localhost:5166/ganttData'
            }
        }
    }
};

export { schedulerProConfig };
