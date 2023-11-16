<script setup lang="ts">
import { onMounted } from 'vue';
import { RouterView, useRoute } from 'vue-router';
import { NConfigProvider } from 'naive-ui';
import { useAptosStore } from '@/stores/aptos';
console.log('process.env ==>', import.meta.env);

const aptosStore = useAptosStore();

onMounted(() => {
  console.log('APP init');
  const href = location.href;
  if (href.indexOf('www.') > -1) {
    location.href = href.replace('www.', '');
    return;
  }
  aptosStore.initPetraWallet();
});

const themeOverrides = {
  common: {
    primaryColor: '#1CEAEE',
    primaryColorHover: '#1CEAEE',
    primaryColorPressed: '#cda710',
    primaryColorSuppl: '#1CEAEE',
  },
};
</script>

<template>
  <n-config-provider :theme-overrides="themeOverrides">
    <RouterView />
  </n-config-provider>
</template>

<style lang="scss" scoped>
.n-config-provider {
  width: 100%;
  height: 100%;
}
</style>
