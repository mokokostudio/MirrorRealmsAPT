import http from './request';

/**
 * 获取账号信息
 * @returns
 */
export const getAccountInfo = () => {
  return http.post('/mrbev1/GetAccountInfo');
};

export const test = () => {};
