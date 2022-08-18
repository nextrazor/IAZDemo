import { Settings as LayoutSettings } from '@ant-design/pro-layout';

const Settings: LayoutSettings & {
  pwa?: boolean;
  logo?: string;
} = {
  navTheme: 'light',
  // 拂晓蓝
  primaryColor: '#1890ff',
  layout: 'mix',
  contentWidth: 'Fluid',
  fixedHeader: false,
  fixSiderbar: true,
  colorWeak: false,
  title: 'NEXT.ИАЗ',
  pwa: false,
  logo: 'https://tadviser.com/images/6/68/Logo_LANIT.png',
  iconfontUrl: '',
};

export default Settings;
