import type { FC } from 'react';

import { useRequest } from 'umi';
import { testData } from './dataLoader';
// import { useRequest } from 'umi';

import KanbanCard from '../../MESAPS/components/KanbanCard';

type AnalysisProps = {
  loading: boolean;
};

const CustomDash: FC<AnalysisProps> = () => {
  const { loading, data } = useRequest(testData);

  return (
    // <GridContent>
    //   <Row gutter={24}>
    //     <Col xl={8} lg={12} md={12} sm={24} xs={24}>
    <KanbanCard columns={data?.columns || []} loading={loading} />
    //     </Col>
    //     {/* <Col xl={8} lg={12} md={12} sm={24} xs={24}>
    //       <PieCard title="Состояние заказов" data={data?.lateOrders.data || []} loading={loading} />
    //     </Col>
    //     <Col xl={8} lg={24} md={24} sm={24} xs={24}>
    //       <PieCard title="Состояние операций" data={data?.lateOpers.data || []} loading={loading} />
    //     </Col> */}
    //   </Row>
    // </GridContent>
  );
};

export default CustomDash;
