import { GridContent } from '@ant-design/pro-layout';
import { Col, Row } from 'antd';
import { Suspense } from 'react';
import type { FC } from 'react';
import CustomChart from './components/PieCard';
import { useRequest } from 'umi';
import { testData } from './dataLoader';

type AnalysisProps = {
  loading: boolean;
};

const CustomDash: FC<AnalysisProps> = () => {
  const { loading, data } = useRequest(testData);

  return (
    <GridContent>
      <Row gutter={24}>
        <Col xl={6} lg={12} md={12} sm={24} xs={24}>
          <CustomChart title='Дагестанские проститутки' data={data?.dataSet || []} loading={loading}/>
        </Col>
        <Col xl={12} lg={24} md={24} sm={24} xs={24}>
          <CustomChart title='Загрузка программиста' data={data?.dataSet2 || []} loading={loading}/>
        </Col>
      </Row>
    </GridContent>
  );
};

export default CustomDash;
