import { Card } from 'antd';
import type { FC } from 'react';
import type { ColumnProps } from '../../MESAPS/service/types';
import { Space, Table, Tag } from 'antd';
import type { ColumnsType } from 'antd/es/table';
import { history } from 'umi';

const TableCard: FC<ColumnProps> = (props: ColumnProps) => {
  interface DataType {
    guid: string;
    category: string[];
    severity: number;
    message: string;
    navigatable: boolean;
  }

  function openPainPoint(entity: string){
    history.push('/orderGantt?order=' + entity);
  }

  function setVisibility(navigatable:boolean): string {
    return navigatable? "initial":"collapse";
  }

  const columns: ColumnsType<DataType> = [
    {
      title: 'Проблемная точка',
      dataIndex: 'message',
      key: 'message',
    },
    {
      title: 'Тип',
      key: 'category',
      dataIndex: 'category',
      filters: [
        {
          text: 'Low',
          value: 'Low',
        },
        {
          text: 'Normal',
          value: 'Normal',
        },
        {
          text: 'High',
          value: 'High',
        },
        {
          text: 'Critical',
          value: 'Critical',
        },
      ],
      onFilter: (value: any, record) => record.category.includes(value) as boolean,
      render: (_, { category }) => (
        <>
          {category.map((tag) => {
            switch (tag) {
              case 'Оборудование':
                return (
                  <Tag color={'geekblue'} key={tag}>
                    {tag}
                  </Tag>
                );
              case 'Low':
                return (
                  <Tag color={'green'} key={tag}>
                    {tag}
                  </Tag>
                );
              case 'Normal':
                return (
                  <Tag color={'yellow'} key={tag}>
                    {tag}
                  </Tag>
                );
              case 'High':
                return (
                  <Tag color={'volcano'} key={tag}>
                    {tag}
                  </Tag>
                );
              case 'Critical':
                return (
                  <Tag color={'red'} key={tag}>
                    {tag}
                  </Tag>
                );
              case 'Заказ':
                return (
                  <Tag color={'volcano'} key={tag}>
                    {tag}
                  </Tag>
                );
              default:
                return (
                  <Tag color={'green'} key={tag}>
                    {'Проблемка'}
                  </Tag>
                );
            }
          })}
        </>
      ),
    },
    {
      title: 'Действие',
      key: 'action',
      render: (_, record) => (
        <Space size="middle">
          <a style={{'visibility':setVisibility(record.navigatable)}} onClick={() => { openPainPoint(record.guid) }}>Открыть гант</a>
        </Space>
      ),
    },
  ];

  return (
    <Card title={props.title} loading={props.loading}>
      <Table columns={columns} dataSource={props.data as unknown as DataType[]} />
    </Card>
  );
};

export default TableCard;
