import { Card } from 'antd';
import type { FC } from 'react';
import type { GaugeProps } from '../service/types';
import { Gauge } from '@ant-design/plots';

const GaugeCard: FC<GaugeProps> = (props: GaugeProps) => {
  return (
    <Card title={props.title} loading={props.loading}>
      <Gauge
        percent={props.data.percent}
        range={props.data.range}
        indicator={{
          pointer: {
            style: {
              stroke: '#D0D0D0',
            },
          },
          pin: {
            style: {
              stroke: '#D0D0D0',
            },
          },
        }}
        statistic={{
          content: {
            style: {
              fontSize: '36px',
              lineHeight: '36px',
            },
          },
        }}
      />
    </Card>
  );
};

export default GaugeCard;
