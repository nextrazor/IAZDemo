import { GridContent } from '@ant-design/pro-layout';
import { Col, Row } from 'antd';
import type { FC } from 'react';
import type { BasicListItemDataType } from './data.d';
import styles from './style.less';
import { useRequest } from 'umi';
import { testData } from './dataLoader';
import moment from 'moment';
// import { useRequest } from 'umi';
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
  data: { owner, createdAt, percent, status },
}: {
  data: BasicListItemDataType;
}) => (
  <div className={styles.listContent}>
    <div className={styles.listContentItem}>
      <span>Owner</span>
      <p>{owner}</p>
    </div>
    <div className={styles.listContentItem}>
      <span>开始时间</span>
      <p>{moment(createdAt).format('YYYY-MM-DD HH:mm')}</p>
    </div>
    <div className={styles.listContentItem}>
      <Progress percent={percent} status={status} strokeWidth={6} style={{ width: 180 }} />
    </div>
  </div>
);

const CustomDash: FC<AnalysisProps> = () => {
  const { loading, data } = useRequest(testData);

  return (
    <GridContent>
      <Row gutter={24}>
        <Card bordered={false} title="Номенклатурный план" style={{ marginTop: 24 }}>
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
                      showEditModal(item);
                    }}
                  >
                    编辑
                  </a>,
                  <MoreBtn key="more" item={item} />,
                ]}
              >
                <List.Item.Meta title={item.partNo} description={item.orderNo} />
                <ListContent data={item} />
              </List.Item>
            )}
          />
        </Card>
      </Row>
    </GridContent>
  );
};

export default CustomDash;
