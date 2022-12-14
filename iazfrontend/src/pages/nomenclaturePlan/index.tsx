import { GridContent } from '@ant-design/pro-layout';
import type { FC } from 'react';
import type { ListItemDataType } from './data.d';
import styles from './style.less';
import { useRequest } from 'umi';
import { testData } from './dataLoader';
import moment from 'moment';
import { history } from 'umi';
//  import { useNavigate } from 'umi';
//import router from 'umi/router';

import {
  Avatar,
  Button,
  Card,
  Col,
  Dropdown,
  Input,
  List,
  Menu,
  Modal,
  Progress,
  Radio,
  Row,
} from 'antd';

type AnalysisProps = {
  loading: boolean;
};

const ListContent = ({
  data: {
    orderNo,
    dueDate,
    endTime,
    partNo,
    quantity,
    isMilitary,
    workGroup,
    dateStatus,
    orderStatus,
    percent,
  },
}: {
  data: ListItemDataType;
}) => (
  <div className={styles.listContent}>
    <div className={styles.listContentItem}>
      <span>Тип продукции</span>
      <p style={{ color: 'black' }}>{isMilitary ? 'Военная' : 'Гражданская'}</p>
    </div>
    <div className={styles.listContentItem}>
      <span>Крайний срок</span>
      <p style={{ color: 'black' }}>{moment(dueDate).format('YYYY-MM-DD HH:mm')}</p>
    </div>
    <div className={styles.listContentItem}>
      <span>Плановая дата завершения</span>
      <p style={{ color: setColor(orderStatus) }}>
        {endTime != null ? moment(endTime).format('YYYY-MM-DD HH:mm') : 'Не спланировано'}
      </p>
    </div>
    <div className={styles.listContentItem}>
      <span>Количество</span>
      <p style={{ color: 'black' }}>{quantity}</p>
    </div>
    <div className={styles.listContentItem}>
      <Progress percent={percent} status={orderStatus} strokeWidth={6} style={{ width: 180 }} />
    </div>
    <div className={styles.listContentItem}>
      <span>Группа</span>
      <p style={{ color: 'black' }}>{workGroup}</p>
    </div>
  </div>
);

function setColor(name) {
  switch (name) {
    case 'success':
      return 'gray';
    case 'exception':
      return 'red';
    case 'active':
      return 'green';
    case 'normal':
      return 'black';
  }
}

const CustomDash: FC<AnalysisProps> = () => {
  const { loading, data } = useRequest(testData);
  //let navigate = useNavigate();

  return (
    <div className={styles.standardList}>
      <Card
        className={styles.listCard}
        bordered={false}
        title="Номенклатурный план"
        style={{ marginTop: 24 }}
      >
        <List
          size="large"
          rowKey="orderNo"
          loading={loading}
          //pagination={paginationProps}
          dataSource={data}
          renderItem={(item) => (
            <List.Item
              actions={[
                <a
                  key="edit"
                  onClick={(e) => {
                    e.preventDefault();
                    history.push('/orderGantt?order=' + item.orderNo);
                    //router.push('/orderGantt/$' + item.orderNo);
                    //navigate('/orderGantt/${item.orderNo as string}');
                  }}
                >
                  Гантт
                </a>,
              ]}
            >
              <List.Item.Meta title={item.orderNo} description={item.partNo} />
              <ListContent data={item as unknown as ListItemDataType} />
            </List.Item>
          )}
        />
      </Card>
    </div>
  );
};

export default CustomDash;
