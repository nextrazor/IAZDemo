import { Button, Divider, Drawer, message } from 'antd';
import React, { useRef, useState } from 'react';
import ReactDOM from 'react-dom';
import { Pie } from '@ant-design/plots';

type MyProps = {
  // using `interface` is also ok
  message: string;
};

class DemoPie extends React.Component<MyProps> {
   data = [
    {
      type: '分类一',
      value: 27,
    },
    {
      type: '分类二',
      value: 25,
    },
    {
      type: '分类三',
      value: 18,
    },
    {
      type: '分类四',
      value: 15,
    },
    {
      type: '分类五',
      value: 10,
    },
    {
      type: '其他',
      value: 5,
    },
  ]
  
  config = {
    appendPadding: 10,
    data: [
      {
        type: '分类一',
        value: 27,
      },
      {
        type: '分类二',
        value: 25,
      },
      {
        type: '分类三',
        value: 18,
      },
      {
        type: '分类四',
        value: 15,
      },
      {
        type: '分类五',
        value: 10,
      },
      {
        type: '其他',
        value: 5,
      },
    ],
    angleField: 'value',
    colorField: 'type',
    radius: 0.75,
    label: {
      type: 'spider',
      labelHeight: 28,
      content: '{name}\n{percentage}',
    },
    interactions: [
      {
        type: 'element-selected',
      },
      {
        type: 'element-active',
      },
    ],
  }

  render(){
    return <Pie {...this.config} />;
  } 
};

export default DemoPie;

//ReactDOM.render(<DemoPie />, document.getElementById('container'));
