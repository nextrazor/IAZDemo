import { request } from 'umi';
import type { DataItem } from '../../MESAPS/service/types';

export async function testData(): Promise<{ data: DataItem[] }> {
  return request('http://localhost:5166/demands');
}
