import { Card, Divider } from 'antd';
import React from 'react'

import Ajax from '../../components/IAZ_TableTest';

class Users extends React.Component {
  render() {
    return (
      <Card bodyStyle={{ padding: 0 }} id="components-button-demo">
        

        <Divider orientation="left">
          <small>Пользователи</small>
        </Divider>
        <div className="p-4">
          <Ajax />
        </div>


      </Card>
    );
  }
}

export default Users;
