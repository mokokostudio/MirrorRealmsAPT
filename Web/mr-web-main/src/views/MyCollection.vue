<template>
  <HeaderBar show-logo />
  <div class="page-wrapper" :class="[plantform]">
    <!-- <BackGround :bg-url="getImgUrl('bgnormal.png', 'orig')" /> -->

    <div class="page-content">
      <div class="title">My Collection</div>

      <div class="tabs">
        <div
          class="tab"
          :class="{ active: activeTab === item.value }"
          v-for="item in tabList"
          :key="item.value"
          @click="activeTab = item.value"
        >
          {{ item.label }}
        </div>
      </div>

      <n-spin :show="loading">
        <div class="weapon-list" v-if="activeTab === 'weapon'">
          <!-- <WeaponItem
            v-for="(item, index) in weaponList"
            :key="index"
            :detail="item"
            :img-size="175"
            @summon="callSummon"
          /> -->
          <WorldviewItem
            v-for="(item, index) in weaponList"
            :key="index"
            :detail="item"
            :img-size="175"
            @click="showWorldviewDetail"
          />
        </div>
        <div class="weapon-list" v-if="activeTab === 'worldview'">
          <WorldviewItem
            v-for="(item, index) in weaponList"
            :key="index"
            :detail="item"
            :img-size="175"
            @click="showWorldviewDetail"
          />
        </div>
      </n-spin>
    </div>
  </div>

  <SummonWeaponModal ref="SummonWeaponModalRef" :weapon-list="weaponList" @on-summon="onSummon" />
  <PurchaseModal ref="PurchaseModalRef" :show-purchase="false" @close="onPurchaseClose" />
  <WorldviewModal ref="WorldviewModalRef" />
</template>

<script lang="ts" setup>
import { ref, onMounted, computed } from 'vue';
import { NSpin } from 'naive-ui';
import np from 'number-precision';
import HeaderBar from '../components/common/HeaderBar.vue';
import BackGround from '@/components/common/BackGround.vue';
import WeaponItem from '@/components/components/WeaponItem.vue';
import WorldviewItem from '@/components/components/WorldviewItem.vue';
import SummonWeaponModal from '@/components/SummonWeaponModal.vue';
import PurchaseModal from '@/components/PurchaseModal.vue';
import WorldviewModal from '@/components/WorldviewModal.vue';

import { getImgUrl, plantform } from '@/utils';
import { useNftsStore } from '@/stores/nfts';
import * as api from '@/api/nfts';

const weaponList = ref<any>([]);
const tabList = ref([
  // { label: 'Weapon', value: 'weapon' },
  { label: 'Worldview Card', value: 'worldview' },
]);
const activeTab = ref('worldview');
const SummonWeaponModalRef = ref();
const PurchaseModalRef = ref();
const WorldviewModalRef = ref();
const loading = ref(false);
const nftsStore = useNftsStore();

onMounted(() => {
  getAptosNFTsV2();
});

async function getAptosNFTsV2() {
  try {
    loading.value = true;
    const res = await api.getAptosNFTsV2({});
    weaponList.value = res.nfts || [];
    // for (let index = 0; index < 20; index++) {
    //   weaponList.value = [...weaponList.value, ...(res.nfts || [])];
    // }
  } finally {
    loading.value = false;
  }
}

function callSummon(detail: any) {
  SummonWeaponModalRef.value.open({ selectedId: detail?.token_name });
}

function onSummon(detail: any) {
  PurchaseModalRef.value.open(detail);
}

function onPurchaseClose() {
  getAptosNFTsV2();
}

async function showWorldviewDetail(item: any) {
  console.log('showWorldviewDetail', item.token_name);
  const tokenId = item.token_name?.split('#')[1];
  if (tokenId) {
    try {
      loading.value = true;
      const res = await nftsStore.getNftById(tokenId);
      console.log('getNftById', res);
      WorldviewModalRef.value.open(res);
    } finally {
      loading.value = false;
    }
  }
}
</script>

<style lang="scss" scoped>
.page-wrapper {
  background-image: url('https://kgcdn.shenmezhideke.com/bgnormal.png?x-oss-process=style/orig');
  background-size: 100% 100%;
  background-repeat: no-repeat;
  height: 100vh;
}

.page-content {
  color: #fff;
  padding: 160px 180px 0 !important;
  overflow-y: auto;

  .title {
    font-size: 42px;
    font-weight: bold;
    margin-bottom: 30px;
  }

  .tabs {
    display: flex;
    padding-bottom: 23px;
    margin-bottom: 20px;
    border-bottom: 1px solid #fff;

    .tab {
      height: 36px;
      padding: 0 10px;
      font-size: 18px;
      border-radius: 16px;
      text-align: center;
      line-height: 36px;
      border: 1px solid #fff;
      color: #fff;
      transition: all 0.15s;
      cursor: pointer;

      &.active {
        background-color: #fff;
        color: #000;
      }
    }
  }

  .weapon-list {
    display: flex;
    flex-wrap: wrap;
    // justify-content: space-between;
    height: 700px;
    overflow-y: auto;

    &::-webkit-scrollbar {
      display: none;
    }
  }

  :deep(.worldview-item-wrapper) {
    margin-left: 24px;
    margin-right: 24px;
  }
}

.win {
  .weapon-list {
    height: 640px;
  }
}
</style>
