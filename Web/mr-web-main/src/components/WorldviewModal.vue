<template>
  <TheModal
    class="worldview-modal-wrapper"
    width="initial"
    :visible="visible"
    padding="3% 4%"
    @close="close"
  >
    <div class="content">
      <n-spin size="small" :show="!imgLoaded" stroke="#f2f2f2">
        <div class="nft-img">
          <img :class="{ show: imgLoaded }" :src="data?.uri" alt="" />
        </div>
      </n-spin>

      <div class="nft-info">
        <div class="title">{{ data?.name }}</div>
        <div class="info-content">
          <div class="item">
            <span class="label">Rank</span>
            <span class="value">{{ data?.props?.rank }}</span>
          </div>
          <div class="item">
            <span class="label">Chess</span>
            <span class="value">{{ data?.props?.chess }}</span>
          </div>
          <div class="item">
            <span class="label">Material</span>
            <span class="value">{{ data?.props?.material }}</span>
          </div>
          <div class="item">
            <span class="label">Character</span>
            <span class="value">{{ data?.props?.character }}</span>
          </div>
        </div>

        <div class="owner-box">
          <div class="title">owner</div>
          <div class="owner-info">
            <div class="address">{{ formatAddress(data?.owner) }}</div>
          </div>
        </div>
      </div>
    </div>
  </TheModal>
</template>

<script lang="ts" setup>
import { ref } from 'vue';
import { NSpin } from 'naive-ui';
import TheModal from '../components/common/TheModal.vue';
import { formatAddress } from '@/utils/format';

defineProps({
  showPurchase: {
    type: Boolean,
    default: true,
  },
});

const emit = defineEmits(['onPurchase', 'close']);

const visible = ref(false);
const loading = ref(false);
const data = ref();
const imgLoaded = ref(false);

function open(_data: any) {
  visible.value = true;
  loading.value = false;
  console.log('open worldviewModal ==>', _data);
  data.value = _data || null;

  const img = new Image();
  img.src = data.value?.uri;
  img.onload = () => {
    console.log('onload!!!');
    imgLoaded.value = true;
  };
}

function close() {
  if (loading.value) return;
  visible.value = false;
  emit('close');
}

defineExpose({
  open,
  close,
});
</script>

<style scoped lang="scss">
.worldview-modal-wrapper {
  .content {
    display: flex;
  }

  .nft-info {
    width: 540px;
    margin-left: 208px;

    & > .title {
      font-size: 48px;
      font-weight: bold;
      margin-bottom: 70px;
      text-align: center;
    }
  }

  .nft-img {
    width: 348px;
    height: 656px;
    flex-shrink: 0;

    img {
      height: 100%;
      display: none;
    }

    .show {
      display: block;
    }
  }

  .item {
    margin-bottom: 40px;
    font-size: 24px;
    font-weight: bold;
    line-height: 26px;

    .label {
      display: inline-block;
      width: 100px;
      font-size: 18px;
      font-weight: normal;
      line-height: 26px;
      margin-right: 30px;
    }
  }

  .owner-box {
    padding: 12px 24px;
    border-radius: 10px;
    background: rgba(255, 255, 255, 0.2);
    margin-top: 140px;

    .title {
      font-size: 18px;
      margin-bottom: 16px;
    }

    .owner-info {
      display: flex;
      justify-content: space-between;

      .address {
        font-size: 24px;
        font-weight: bold;
      }
    }
  }

  :deep(.the-modal-content) {
    background-color: rgba(0, 0, 0, 0.85);
    color: #fff;
    min-height: 300px;
  }
}
</style>
