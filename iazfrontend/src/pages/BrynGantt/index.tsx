import React, { Fragment, FunctionComponent, useRef, useEffect } from 'react';
import { BryntumDemoHeader, BryntumThemeCombo, BryntumSchedulerPro } from '@bryntum/schedulerpro-react';
import { SchedulerPro } from '@bryntum/schedulerpro';
import { schedulerProConfig } from './config';
import { Button } from "antd";

import '@bryntum/schedulerpro/schedulerpro.classic.css';
//import './styles.scss';

const axios = require('axios').default;
// Init
const App: FunctionComponent = () => {
  const schedulerProRef = useRef<BryntumSchedulerPro>(null);
  const schedulerProInstance = () => schedulerProRef.current?.instance as SchedulerPro;

  


  useEffect(() => {
      // This shows loading data
      // To load data automatically configure project with `autoLoad : true`
      schedulerProInstance().project.load();
  });

  return (
      <Fragment>
          {/* BryntumDemoHeader component is used for Bryntum example styling only and can be removed */}
          <BryntumDemoHeader
              children={<BryntumThemeCombo />}
          />
          <BryntumSchedulerPro
              ref={schedulerProRef}
              {...schedulerProConfig}
          />
      </Fragment>
  );
};

export default App;
