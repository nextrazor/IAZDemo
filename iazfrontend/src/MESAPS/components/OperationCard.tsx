import type { FC } from 'react';
import type { OperationProps } from '../service/types';
import '@bryntum/calendar/calendar.stockholm.css';
import './calendar.css';
import { Statistic } from 'antd';
import React, { useState } from 'react';
import { Layout } from 'antd';

const { Header, Footer, Content } = Layout;
import { Col, Row, Card } from 'antd';
import { Badge, Descriptions } from 'antd';
const { Countdown } = Statistic;
import { Button } from 'antd';

import { Segmented } from 'antd';
import {
  CodepenOutlined,
  ReadOutlined,
  CheckCircleOutlined,
  FormOutlined,
} from '@ant-design/icons';
import { SegmentedValue } from 'antd/lib/segmented';

const OperationCard: FC<OperationProps> = (props: OperationProps) => {
  const [barsVisibility, setBarsVisibility] = useState([true, false, false, false]);

  let deadline = Date.parse(props.operation.startDate) + 4500000000; // Moment is also OK
  console.log(deadline);

  function changeVisibility(value: SegmentedValue) {
    let newSet = [];
    for (let i = 0; i < 4; i++) {
      newSet.push(i + 1 == value);
    }
    setBarsVisibility(newSet);
  }

  return (
    <Card title={props.title}>
      <Descriptions bordered>
        <Descriptions.Item label="Заказ" span={2}>
          {props.operation.orderNo}
        </Descriptions.Item>
        <Descriptions.Item label="Порядковый номер операции">
          {props.operation.opNo}
        </Descriptions.Item>
        <Descriptions.Item label="Операция" span={2}>
          {props.operation.operationName}
        </Descriptions.Item>
        <Descriptions.Item label="Деталь">{props.operation.partNo}</Descriptions.Item>
        <Descriptions.Item label="Ресурс" span={2}>
          {props.operation.resource}
        </Descriptions.Item>
        <Descriptions.Item label="Status" span={3}>
          <Badge status="processing" text="Не начато" />
        </Descriptions.Item>
        <Descriptions.Item label="Плановое время начала">
          {new Date(props.operation.startDate).toLocaleString()}
        </Descriptions.Item>
        <Descriptions.Item label="Плановое время завершения">
          {new Date(props.operation.endDate).toLocaleString()}
        </Descriptions.Item>
        <Descriptions.Item label="Тип продукции">
          {props.operation.isMilitary ? 'Военная' : 'Гражданская'}
        </Descriptions.Item>
        <Descriptions.Item label="Плановое количество">
          {props.operation.quantity}
        </Descriptions.Item>
        <Descriptions.Item label="Произведенное количество">
          {props.operation.finishedQuantity}
        </Descriptions.Item>
        <Descriptions.Item label="Брак">0</Descriptions.Item>

        <Descriptions.Item label="Время до начала">
          <Countdown value={deadline} />
        </Descriptions.Item>
      </Descriptions>

      <div style={{ 'margin-top': '2%', fontSize: '12px' }}>
        <Segmented
          onChange={changeVisibility}
          block
          options={[
            {
              label: 'Работа с операцией',
              value: 1,
              icon: <CheckCircleOutlined />,
            },
            {
              label: 'Инструкции',
              value: 2,
              icon: <ReadOutlined />,
            },
            {
              label: '3D модель',
              value: 3,
              icon: <CodepenOutlined />,
            },
            {
              label: 'Конторолируемые параметры',
              value: 4,
              icon: <FormOutlined />,
            },
          ]}
        />
      </div>

      <div>
        <div style={{ display: barsVisibility[0] ? 'inline-block' : 'none', width: '100%' }}>
          <div style={{ width: '100%', marginTop: '1%' }}>
            <Button type="primary" danger>
              Сообщить о проблеме
            </Button>

            <Button style={{ float: 'right', marginLeft: '5px' }} type="primary">
              Начать операцию
            </Button>
            <Button style={{ float: 'right' }}>Загрузить управляющую программу</Button>
          </div>
        </div>
        <div style={{ display: barsVisibility[1] ? 'inline-block' : 'none' }}>2</div>
        <div style={{ display: barsVisibility[2] ? 'inline-block' : 'none' }}>3</div>
        <div style={{ display: barsVisibility[3] ? 'inline-block' : 'none' }}>4</div>
      </div>

      <div>
        <></>
      </div>
    </Card>
  );
};

export default OperationCard;
