import type { FC } from 'react';

//import { useRequest } from 'umi';
//import { testData } from './dataLoader';
// import { useRequest } from 'umi';

import CalendarCard from '../../MESAPS/components/CalendarCard';

type AnalysisProps = {
  loading: boolean;
};

const CustomDash: FC<AnalysisProps> = () => {
  //const { loading, data } = useRequest(testData);

  function selectedCalendarItem(calendarItem: any): any {
    console.log(calendarItem);
  }

  return (
    // <GridContent>
    //   <Row gutter={24}>
    //     <Col xl={8} lg={12} md={12} sm={24} xs={24}>
    <CalendarCard selectedCalendarItem={selectedCalendarItem} />
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
