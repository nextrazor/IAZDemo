import { request } from 'umi';
import type { AnalysisData } from '../../MESAPS/service/types';

export async function testData(): Promise<{ data: AnalysisData }> {
  return request('http://localhost:5166/testData');
}
