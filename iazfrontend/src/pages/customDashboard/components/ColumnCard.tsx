import { Card } from 'antd';
import type { FC } from 'react';
import type { ColumnProps } from '../service/types';
import { Column } from '@ant-design/plots';

const ColumnCard: FC<ColumnProps> = (props: ColumnProps) => {
  return (
    <Card title={props.title} loading={props.loading}>
      <Column
        data={props.data}
        xField="machineName"
        yField="value"
        seriesField="loadingCategory"
        isPercent={true}
        isStack={true}
        label={{
          position: 'middle',
          content: (item) => {
            return item.value.toFixed(2);
          },
          style: {
            fill: '#fff',
          },
        }}
      />
    </Card>
  );
};

export default ColumnCard;
