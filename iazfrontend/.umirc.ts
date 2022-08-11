import { defineConfig } from '@umijs/max';

export default defineConfig({
  antd: {},
  access: {},
  model: {},
  initialState: {},
  request: {},
  layout: {
     title: '@umijs/max2',
     navTheme: 'dark',
     primaryColor: '#1890ff',
     layout: 'side',
     contentWidth: 'Fluid',
     fixedHeader: false,
     fixSiderbar: true,
     pwa: false,
     logo: 'https://gw.alipayobjects.com/zos/rmsportal/KDpgvguMpGfqaHPjicRK.svg',
     headerHeight: 48,
     splitMenus: false
   },
  routes: [
    {
      path: '/',
      redirect: '/home',
    },
    {
      name: '首页',
      path: '/home',
      component: './Home',
    },
    {
      name: '权限演示',
      path: '/access',
      component: './Access',
    },
    {
        name: ' CRUD 示例',
        path: '/table',
        component: './Table',
    },
    {
        name: ' Gantt',
        path: '/Gantt',
        component: './Gantt',
    },
    {
        name: 'New Gantt',
        path: '/BrynGantt',
        component: './BrynGantt',
    },
    {
      name: 'IAZ Users',
      path: '/Users',
      component: './Users',
    },
    {
      name: 'Main Dashboard',
      path: '/MainDashboard',
      component: './MainDashboard',
    },
  ],
  npmClient: 'npm',
});
