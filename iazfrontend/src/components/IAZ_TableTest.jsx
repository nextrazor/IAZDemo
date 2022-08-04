import { Table } from 'antd';
import React from 'react'
const axios = require('axios').default;

const columns = [
  {
    title: 'Name',
    dataIndex: 'fio',
    sorter: true,
    //render: name => `${name.first} ${name.last}`,
    width: '20%'
  },
  {
    title: 'Цех',
    dataIndex: 'workShop',
    sorter: true
  },
  {
    title: 'Группа',
    dataIndex: 'workGroup',
    sorter: true
  }

  // ,
  // {
  //   title: 'Gender',
  //   dataIndex: 'gender',
  //   filters: [
  //     { text: 'Male', value: 'male' },
  //     { text: 'Female', value: 'female' }
  //   ],
  //   width: '20%'
  // }
];

class App extends React.Component {
  state = {
    data: [],
    pagination: {},
    loading: false
  };

  handleTableChange = (pagination, filters, sorter) => {
    const pager = { ...this.state.pagination };
    pager.current = pagination.current;
    this.setState({
      pagination: pager
    });
    this.fetch({
      results: pagination.pageSize,
      page: pagination.current,
      sortField: sorter.field,
      sortOrder: sorter.order,
      ...filters
    });
  };

  fetch = (params = {}) => {
    console.log('params:', params);
    this.setState({ loading: true });
   
    console.log('params:', params);
    this.setState({ loading: true });
    const pagination = { ...this.state.pagination };
    axios(
      {
        method: 'get',
        url: 'http://localhost:5166/workers',
        data: 
        {
          results: 10,
          ...params  
        }
      })
    .then(response => {
      
      // Read total count from server
      // pagination.total = data.totalCount;
      pagination.total = response.data.length;
       this.setState({
         loading: false,
         data: response.data,
         pagination
       });
    })
    .catch(function (error) {
      // handle error
      console.log(error);
    })
    .then(function () {
      // always executed
    });
  };

  componentDidMount() {
    this.fetch();
  }

  render() {
    return (
      <Table
        columns={columns}
        rowKey={record => record.workerCode}
        dataSource={this.state.data}
        pagination={this.state.pagination}
        loading={this.state.loading}
        onChange={this.handleTableChange}
      />
    );
  }
}

export default App;
