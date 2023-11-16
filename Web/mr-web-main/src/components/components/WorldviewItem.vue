<template>
  <div class="worldview-item-wrapper" @click="onClick(detail)">
    <n-spin size="small" :show="!imgLoaded" stroke="#f2f2f2">
      <div class="weapon-img">
        <img :class="{ show: imgLoaded }" :src="detail?.token_uri" alt="" />
      </div>
    </n-spin>

    <div class="name">{{ nftName }}</div>
    <div class="no">{{ nftNo }}</div>
  </div>
</template>
<script lang="ts" setup>
import { computed, watch, onMounted, ref } from 'vue';
import { NSpin } from 'naive-ui';

const emit = defineEmits(['click']);
const imgLoaded = ref(false);

const props = withDefaults(
  defineProps<{
    detail: any;
    imgSize?: string | number;
  }>(),
  {
    detail: null,
    imgSize: 275,
  },
);

watch(
  () => props.detail,
  (val) => {
    console.log('watch props.detail ==>', val);
  },
);

onMounted(() => {
  const img = new Image();
  img.src = props?.detail?.token_uri;
  img.onload = () => {
    console.log('onload!!!');
    imgLoaded.value = true;
  };
});

const nftName = computed(() => {
  return props.detail?.token_name?.split(' ')[0];
});

const nftNo = computed(() => {
  return props.detail?.token_name?.split(' ')[1];
});

function onClick(detail: any) {
  emit('click', detail);
}
</script>
<style lang="scss" scoped>
.worldview-item-wrapper {
  width: 173px;
  height: 300px;
  padding: 10px 26px;
  border-radius: 10px;
  margin-bottom: 25px;
  background: rgba(0, 0, 0, 0.15);
  color: #fff;
  text-align: center;
  cursor: pointer;

  .weapon-img {
    width: 100%;
    height: 226px;
    margin-bottom: 10px;
    // background-color: #f2f2f2;

    img {
      height: 100%;
      display: none;
    }

    .show {
      display: block;
    }
  }

  .name {
    margin-bottom: 6px;
  }

  .name,
  .no {
    font-size: 14px;
    line-height: 20px;
  }
}
</style>
