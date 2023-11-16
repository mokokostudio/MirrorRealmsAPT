import { ref } from 'vue';
import { defineStore, storeToRefs } from 'pinia';
import { useAptosStore } from '@/stores/aptos';

import { getTransaction, getDataByType } from '@/utils/aptos';

export const useNftsStore = defineStore('nfts', () => {
  const aptosStore = useAptosStore();
  const { token } = storeToRefs(aptosStore);
  const leftNftCount = ref('0');

  /**
   * 购买nft
   */
  function purchase() {
    return new Promise(async (resolve, reject) => {
      const client = aptosStore.getAptosClient();
      if (!client) {
        reject();
        return;
      }

      if (!token.value) {
        aptosStore.signAndVerify();
        reject();
        return;
      }

      try {
        // 交易
        const transaction = getTransaction('mint');
        console.log('transaction ==>', transaction);
        const pendingTransaction = await window.aptos.signAndSubmitTransaction(transaction);
        console.log('pendingTransaction', pendingTransaction);
        const txn = await client.waitForTransactionWithResult(pendingTransaction.hash);
        console.log('txn', txn);

        // 查询nft属性
        const eventData = getDataByType(txn, '0x4::collection::MintEvent');
        const nftTransaction = getTransaction('get_weapon_by_object', [eventData?.token]);
        const res = await client.view(nftTransaction);
        console.log('nft info ==>', res);
        resolve(res[0]);
      } catch (error: any) {
        console.log('purchase error', error);
        reject(error);
      }
    });
  }

  /**
   * 融合武器
   */
  function summon(nameList: string[]) {
    return new Promise(async (resolve, reject) => {
      const client = aptosStore.getAptosClient();
      if (!client) {
        reject();
        return;
      }

      if (!token.value) {
        aptosStore.signAndVerify();
        reject();
        return;
      }

      try {
        // 交易
        const transaction = getTransaction('craft', nameList);
        console.log('transaction ==>', transaction);
        const pendingTransaction = await window.aptos.signAndSubmitTransaction(transaction);
        console.log('pendingTransaction', pendingTransaction);
        const txn = await client.waitForTransactionWithResult(pendingTransaction.hash);
        console.log('txn', txn);

        // 查询nft属性
        const eventData = getDataByType(txn, '0x4::collection::MintEvent');
        const nftTransaction = getTransaction('get_weapon_by_object', [eventData?.token]);
        const res = await client.view(nftTransaction);
        console.log('nft info ==>', res);
        resolve(res[0]);
      } catch (error: any) {
        console.log('purchase error', error);
        reject(error);
      }
    });
  }

  function whiteListMint() {
    return new Promise(async (resolve, reject) => {
      const client = aptosStore.getAptosClient();
      if (!client) {
        reject();
        return;
      }

      if (!token.value) {
        aptosStore.signAndVerify();
        reject();
        return;
      }

      try {
        // 交易
        const transaction = getTransaction('white_list_mint');
        console.log('transaction ==>', transaction);
        const pendingTransaction = await window.aptos.signAndSubmitTransaction(transaction);
        console.log('pendingTransaction', pendingTransaction);
        const txn = await client.waitForTransactionWithResult(pendingTransaction.hash);
        console.log('txn', txn);

        // 查询nft属性
        const address = (txn as any)?.payload?.function.split('::')[0];
        console.log(address);
        const eventData = getDataByType(txn, `${address}::nft::MintEvent`);
        console.log(eventData);
        resolve(eventData);
      } catch (error: any) {
        console.log('purchase error', error);
        reject(error);
      }
    });
  }

  function getNftById(id: string) {
    return new Promise(async (resolve, reject) => {
      const client = aptosStore.getAptosClient();
      if (!client) {
        reject();
        return;
      }

      // if (!token.value) {
      //   aptosStore.signAndVerify();
      //   reject();
      //   return;
      // }

      try {
        // 查询nft属性
        const nftTransaction = getTransaction('get_nft_by_id', [id]);
        const res = await client.view(nftTransaction);
        console.log('nft info ==>', res);
        resolve(res[0]);
      } catch (error: any) {
        console.log('purchase error', error);
        reject(error);
      }
    });
  }

  /**
   * 获取白名单nft池子数量
   * @returns
   */
  function getWhiteListNftPoolCount() {
    return new Promise(async (resolve, reject) => {
      const client = aptosStore.getAptosClient();
      if (!client) {
        reject();
        return;
      }

      // if (!token.value) {
      //   aptosStore.signAndVerify();
      //   reject();
      //   return;
      // }

      try {
        // 查询nft属性
        const nftTransaction = getTransaction('get_white_list_nft_pool_count');
        const res = await client.view(nftTransaction);
        console.log('get_white_list_nft_pool_count ==>', res);
        leftNftCount.value = (res[0] as string) || '';
        resolve(res[0]);
      } catch (error: any) {
        console.log('purchase error', error);
        reject(error);
      }
    });
  }

  return {
    purchase,
    summon,
    whiteListMint,
    getNftById,
    getWhiteListNftPoolCount,
  };
});
