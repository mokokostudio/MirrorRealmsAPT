<template>
  <HeaderBar show-logo />
  <div class="swiper-page">
    <!-- <BackGround :bg-url="getImgUrl('bgnormal.png', 'orig')" /> -->
    <!-- <div class="coming-tips">Coming soon！</div> -->
    <div class="swiper-page-content">
      <div class="page-content">
        <div class="title">Worldview Card NFT is minting !</div>
        <div class="box-info">
          <img
            src="https://kgcdn.shenmezhideke.com/wvbox.png?x-oss-process=style/offical_90"
            alt=""
          />
          <!-- <div class="cost">{{ cost }} APT</div> -->
          <div class="left-num">{{ restCount }} Left</div>
        </div>

        <n-button class="purchase-btn" :loading="loading" color="#1CEAEE" @click="whiteListMint"
          >Mint</n-button
        >

        <div class="tip">Only whitelisted players can mint</div>
      </div>
    </div>
  </div>

  <TheModal
    class="mint-success-modal-wrapper"
    width="initial"
    :visible="visible"
    padding="3% 4%"
    @close="visible = false"
  >
    <div class="title">Mint Success!</div>
    <div class="info">You can check your NFT in wallet library.</div>
  </TheModal>
</template>

<script lang="ts" setup>
import { ref, watch, onMounted } from 'vue';
import { storeToRefs } from 'pinia';
import { NButton } from 'naive-ui';
import HeaderBar from '../components/common/HeaderBar.vue';
import BackGround from '@/components/common/BackGround.vue';
import TheModal from '@/components/common/TheModal.vue';
import { useUserStore } from '@/stores/user';
import { useAptosStore } from '@/stores/aptos';
import { useNftsStore } from '@/stores/nfts';
import { getImgUrl } from '@/utils';

const userStore = useUserStore();
const aptosStore = useAptosStore();
const { connected, networkUrl, token } = storeToRefs(aptosStore);
const nftsStore = useNftsStore();

const loading = ref(false);
const visible = ref(false);
const WorldviewModalRef = ref();
const restCount = ref('0');

watch(
  () => networkUrl.value,
  (newNetworkUrl) => {
    console.log('watch networkUrl', newNetworkUrl);
    if (newNetworkUrl) {
      // userStore.getBalance();
    }
  },
);
watch(
  () => connected.value,
  async (newConnected) => {
    console.log('watch connected', newConnected);
    if (newConnected && networkUrl.value) {
      // userStore.getBalance();
      restCount.value = (await nftsStore.getWhiteListNftPoolCount()) as string;
    }
  },
);

watch(
  () => token.value,
  async (newToken) => {
    console.log('watch token', newToken);
    if (newToken && connected.value && networkUrl.value) {
      restCount.value = (await nftsStore.getWhiteListNftPoolCount()) as string;
    }
  },
);

onMounted(async () => {
  if (networkUrl.value && connected.value) {
    // userStore.getBalance();
    restCount.value = (await nftsStore.getWhiteListNftPoolCount()) as string;
  }
});

async function whiteListMint() {
  try {
    loading.value = true;
    await nftsStore.whiteListMint();
    visible.value = true;
    // userStore.getBalance();
    restCount.value = (await nftsStore.getWhiteListNftPoolCount()) as string;
  } finally {
    loading.value = false;
  }
}

function onPurchase(res: any) {
  WorldviewModalRef.value.open(res);
  // userStore.getBalance();
}
</script>

<style lang="scss" scoped>
.swiper-page {
  background-image: url('https://kgcdn.shenmezhideke.com/bgnormal.png?x-oss-process=style/orig');
  background-size: 100% 100%;
  background-repeat: no-repeat;
}

.coming-tips {
  position: absolute;
  left: 0;
  top: 50%;
  transform: translate3d(0, -50%, 0);
  width: 100%;
  text-align: center;
  color: #fff;
  font-size: 36px;
}

.page-content {
  text-align: center;
  color: #fff;

  .title {
    font-size: 48px;
    font-weight: bold;
    text-align: center;
    margin: 0 auto;
    margin-bottom: 94px;
  }

  .box-info {
    width: 250px;
    margin: 0 auto;
    margin-bottom: 25px;

    img {
      width: 100%;
      // height: 250px;
      // margin-bottom: 27px;
    }

    .cost {
      height: 45px;
      font-size: 36px;
      font-weight: bold;
      line-height: 29px;
    }

    .left-num {
      position: relative;
      top: -10px;
      font-size: 18px;
      text-align: center;
      color: #ffd24c;
    }
  }

  .purchase-btn {
    width: 493px;
    height: 63px;
    margin: 0 auto;
    border-radius: 8px;
    font-size: 24px;
    font-weight: bold;
    color: #000;
  }

  .tip {
    font-size: 18px;
    line-height: 29px;
    text-align: center;
    margin-top: 40px;
  }
}

:deep(.the-modal-content) {
  background-color: rgba(0, 0, 0, 0.85);
  color: #fff;
  min-height: 300px;
  text-align: center;
  min-height: auto;

  .title {
    font-size: 36px;
    font-weight: bold;
    margin-bottom: 40px;
  }

  .info {
    font-size: 24px;
  }
}
</style>
