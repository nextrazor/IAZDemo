import { GridContent } from '@ant-design/pro-layout';
import { Col, Row } from 'antd';
import type { FC } from 'react';
import { useRequest } from 'umi';
import { testData } from './dataLoader';

import PieCard from './components/PieCard';
import GaugeCard from './components/GaugeCard';
import { OeeGauge } from './types';

type AnalysisProps = {
  loading: boolean;
};

const CustomDash: FC<AnalysisProps> = () => {
  const { loading, data } = useRequest(testData);

  return (
    <GridContent>
      <Row gutter={24}>
        <Col xl={8} lg={12} md={12} sm={24} xs={24}>
          <GaugeCard
            title="OEE"
            data={
              data?.oeeGauge ||
              ({
                percent: 0.75,
                range: {
                  ticks: [0, 1 / 3, 2 / 3, 1],
                  color: ['#F4664A', '#FAAD14', '#30BF78'],
                },
              } as OeeGauge)
            }
            loading={loading}
          />
        </Col>
        <Col xl={8} lg={12} md={12} sm={24} xs={24}>
          <PieCard title="Состояние заказов" data={data?.lateOrders.data || []} loading={loading} />
        </Col>
        <Col xl={8} lg={24} md={24} sm={24} xs={24}>
          <PieCard title="Состояние операций" data={data?.lateOpers.data || []} loading={loading} />
        </Col>
      </Row>
      <Row
        gutter={24}
        style={{
          marginTop: 24,
        }}
      >
        <Col xl={12} lg={24} md={24} sm={24} xs={24}>
          <PieCard
            title="Загрузка программиста"
            data={data?.lateOpers.data || []}
            loading={loading}
          />
        </Col>
      </Row>
    </GridContent>
  );
};

export default CustomDash;
