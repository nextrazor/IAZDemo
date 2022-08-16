import { request } from 'umi';
import type { ColumnsData } from '../../MESAPS/service/types';

export async function testData(): Promise<{ data: ColumnsData }> {
  return request('http://localhost:5166/kanbanColumns');
}
