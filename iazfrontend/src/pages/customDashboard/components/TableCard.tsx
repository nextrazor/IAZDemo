import { Card } from 'antd';
import type { FC } from 'react';
import type { ColumnProps } from '../service/types';
import { Space, Table, Tag } from 'antd';
import type { ColumnsType } from 'antd/es/table';
import type { DataItem } from '../service/types';

const TableCard: FC<ColumnProps> = (props: ColumnProps) => {
  interface DataType {
    guid: string;
    category: string[];
    severity: number;
    message: string;
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
          <a>Invite {record.category}</a>
          <a>Delete</a>
        </Space>
      ),
    },
  ];

  return (
    <Card title={props.title} loading={props.loading}>
      <Table columns={columns} dataSource={props.data as DataItem[]} />
    </Card>
  );
};

export default TableCard;
