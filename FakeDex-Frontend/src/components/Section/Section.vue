<template>
  <div class="flex">
    <div class="w-full h-96 flex flex-row flex-nowrap">
      <div class="w-full grid grid-rows-3 grid-flow-col gap-4">
        <div class="row-span-3 p-4 w-full bg-white rounded-lg shadow-lg  text-black">
            <div class="flex flex-col flex-nowrap justify-center items-center">
                <h1 class="text-5xl underline decoration-purple-500/90">{{ $t('SERVICES.INTERNATIONAL.TITLE') }}</h1>
                <p class="text-lg">{{ $t('SERVICES.INTERNATIONAL.DESCRIPTION') }}</p>
                <Mundo :width="250" :height="250"/>
            </div>
        </div>
        <div class="col-span-2 p-4 w-full bg-white rounded-lg shadow-lg  text-black">
            <div class="grid grid-cols-2 gap-2">
                <div>
                    <h1 class="text-3xl underline decoration-purple-500/90">{{ $t('SERVICES.PACKAGE.TITLE') }}</h1>
                    <p class="text-lg">{{ $t('SERVICES.PACKAGE.DESCRIPTION') }}</p>
                </div>
                <div class="justify-self-end">
                    <Paquete :width="100" :height="90"/>
                </div>
            </div>
        </div>

        <div class="row-span-2 p-4 w-full bg-white rounded-lg shadow-lg col-span-2  text-black">
            <div class="grid grid-row-2 gap-2">
                <div>
                    <h1 class="text-3xl underline decoration-purple-500/90">{{ $t('SERVICES.WEEKEND.TITLE') }}</h1>
                    <p class="text-lg">{{ $t('SERVICES.WEEKEND.DESCRIPTION') }}</p>
                </div>
                <div class="justify-self-center">
                    <Truck :width="300" :height="150"/>
                </div>
            </div>
        </div>

      </div>
    </div>
  </div>
</template>
<script>
import messages from './i18n/messages';
import Mundo from '@/components/icons/Mundo.vue';
import Paquete from '@/components/icons/Paquetes.vue'
import Truck from '@/components/icons/Truck.vue'


export default {
  name: "SectionA",
  components: {
    Mundo,
    Paquete,
    Truck
  },
  i18n: {
    messages
  }
};
</script>
