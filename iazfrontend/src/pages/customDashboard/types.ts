import { DataItem } from '@antv/g2plot/esm/interface/config';

export { DataItem };

export interface AnalysisData {
  dataSet: DataItem[];
  dataSet2: DataItem[];
}

export type ExampleData = {
  name: string;
  value: number;
};

export type AnalysisProps = {
  data: DataItem[];
  loading: boolean;
  title: string;
};