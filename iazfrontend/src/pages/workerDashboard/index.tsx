import type { FC } from 'react';
import { GridContent } from '@ant-design/pro-layout';
import { Col, Row } from 'antd';
import './style.css';
import React, { useState } from 'react';

//import { useRequest } from 'umi';
//import { testData } from './dataLoader';
// import { useRequest } from 'umi';

import CalendarCard from '../../MESAPS/components/CalendarCard';
import OperationCard from '../../MESAPS/components/OperationCard';

type AnalysisProps = {
  loading: boolean;
};

const CustomDash: FC<AnalysisProps> = () => {
  //const { loading, data } = useRequest(testData);

  const [calendarWidth, setCalendarWidth] = useState(24);
  const [operaionsCardWidth, setOperaionsWidth] = useState(0);
  const [selectedOperaion, setOperaion] = useState({});

  function selectedCalendarItem(calendarItem: any): any {
    setOperaion(calendarItem);
    console.log(calendarItem);
    setCalendarWidth(10);
    setOperaionsWidth(14);
  }

  return (
    <GridContent style={{ height: '100%' }}>
      <Row gutter={24}>
        <Col xl={calendarWidth}>
          <CalendarCard selectedCalendarItem={selectedCalendarItem} />
        </Col>
        <Col xl={operaionsCardWidth} style={{ height: '100%', width: '30%', float: 'right' }}>
          <OperationCard title="Состояние заказов" operation={selectedOperaion}>
            Выберите операцию
          </OperationCard>
        </Col>
      </Row>
    </GridContent>
  );
};

export default CustomDash;
