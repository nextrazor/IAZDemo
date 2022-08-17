import type { FC } from 'react';
import { useRef } from 'react';
import { BryntumSchedulerPro } from '@bryntum/schedulerpro-react';
import type { GanttProps } from '../../MESAPS/service/types';
import { SchedulerProConfig } from '@bryntum/schedulerpro';
import '@bryntum/schedulerpro/schedulerpro.stockholm.css';
import { Button, Switch, Card } from 'antd';
import { GridContent } from '@ant-design/pro-layout';
import { Col, Row } from 'antd';

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
      percentBar: true,
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

  var allowAllResorces = true;
  var allowManualOperations = true;

  function onChangeAllowAllResorces(): any {
    allowAllResorces = !allowAllResorces;
    loadData();
  }

  function onChangeAllowManualOperations(): any {
    allowManualOperations = !allowManualOperations;
    loadData();
  }

  function loadData(): any {
    var project = schedulerpro.current?.instance.project;
    project.loadUrl =
      'http://localhost:5166/ordergantt/' +
      props.location.query.order +
      '/' +
      allowAllResorces +
      '/' +
      allowManualOperations;
    project.load();
    console.log(schedulerpro.current?.instance.project.transport.load.url);
  }

  return (
    <div style={{ height: '100%' }}>
      <GridContent>
        <Row gutter={24}>
          <Col xl={5} lg={12} md={12} sm={24} xs={24}>
            <Card title={'Настройки'}>
              <span>Отображать все ресурсы</span>
              <span style={{ float: 'right' }}>
                <Switch onChange={onChangeAllowAllResorces} />
              </span>
              <br />
              <br />
              <span>Отображать ручные операции</span>
              <span style={{ float: 'right' }}>
                <Switch onChange={onChangeAllowManualOperations} />
              </span>
            </Card>
          </Col>
        </Row>
      </GridContent>

      {/* <Button type="primary" onClick={addBul}>
        Primary Button
      </Button> */}
      <BryntumSchedulerPro ref={schedulerpro} {...schedulerproConfig} />
    </div>
  );
};

export default Gantt;
