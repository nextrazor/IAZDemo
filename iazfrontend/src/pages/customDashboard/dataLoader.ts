import { request } from 'umi';
import { AnalysisData } from './types';

export async function testData(): Promise<{ data: AnalysisData }> {
  return request('http://localhost:5166/testData');
}
