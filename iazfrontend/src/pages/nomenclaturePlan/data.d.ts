export type Member = {
  avatar: string;
  name: string;
  id: string;
};

export type BasicListItemDataType = {
  id: string;
  owner: string;
  title: string;
  avatar: string;
  cover: string;
  status: 'normal' | 'exception' | 'active' | 'success';
  percent: number;
  logo: string;
  href: string;
  body?: any;
  updatedAt: number;
  createdAt: number;
  subDescription: string;
  description: string;
  activeUser: number;
  newUser: number;
  star: number;
  like: number;
  message: number;
  content: string;
  members: Member[];
};

export type ListItemDataType = {
  orderNo: string;
  dueDate: string;
  endTime: string;
  partNo: string;
  quantity: number;
  isMilitary: boolean;
  workGroup: string;
  dateStatus: string;
  orderStatus: 'normal' | 'exception' | 'active' | 'success';
  percent: number;
};