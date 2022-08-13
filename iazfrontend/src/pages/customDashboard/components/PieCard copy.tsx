import { Card } from 'antd';
import type { FC } from 'react';
//import React, { useState, useEffect } from 'react';
//import { useRequest } from 'umi';
//import {  testData, DataItem } from '../dataLoader';
import { AnalysisProps } from '../types';
import { Pie } from '@ant-design/charts';

const CustomChart: FC<AnalysisProps> = (props: AnalysisProps) => {
  // const [data, setData] = useState([]);
  // //const { loading, data } = useRequest(testData);

  // const asyncFetch = () => {
  //   fetch('http://localhost:5166/testData')
  //     .then((response) => response.json())
  //     .then((json) => setData(json))
  //     .catch((error) => {
  //       console.log('fetch data failed', error);
  //     });
  // };

  // useEffect(() => {
  //   asyncFetch();
  // }, []);

  return (
    <Card title={props.title} loading={props.loading}>
      <Pie data={props.data} angleField="value" colorField="name" />
    </Card>
  );
};

export default CustomChart;
