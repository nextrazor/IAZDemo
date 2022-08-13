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
  data: PlotElement[];
}

export interface PlotElement {
  machineName: string;
  loadingCategory: string;
  value: number;
}

export interface PainPointsData {
  Data: PainPointsElements[];
}

export interface PainPointsElements {
  guid: string;
  category: string;
  severity: number;
  message: string;
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

export type GaugeProps = {
  data: OeeGauge;
  loading: boolean;
  title: string;
};
