import { DataItem } from '@antv/g2plot/esm/interface/config';

export { DataItem };

export interface AnalysisData {
  lateOrders: DataObject;
  lateOpers: DataObject;
  oeeGauge: OeeGauge;
  loadingPlot: PlotData;
  painPoints: PainPointsData;
}

export interface DataObject {
  data: DataItem[];
}

export interface OeeGauge {
  percent: number;
  range: RangeData;
}

export interface RangeData {
  ticks: number[];
  color: string[];
}

export interface PlotData {
  data: DataItem[];
}

export interface PainPointsData {
  data: DataItem[];
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

export type ColumnProps = {
  loading: boolean;
  title: string;
  data: DataItem[];
};

export type KanbanProps = {
  loading: boolean;
  columns: [];
};

export type CalendarProps = {
  loading: boolean;
};

export type GanttProps = {
  order: string;
};

export type ColumnsData = {
  columns: [];
};

export type GaugeProps = {
  data: OeeGauge;
  loading: boolean;
  title: string;
};
