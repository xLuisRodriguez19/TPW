<template>
  <div>
    <div class="flex flex-wrap justify-center items-center shadow-lg mx-36">
      <div
        class="flex flex-col gap-4 flex-wrap -mx-3 mb-2 justify-center items-center"
      >
        <div>
          <h1 class="text-2xl text-black">Tipo de paquete</h1>
          <h1 class="text-sm text-red-700" v-if="!isNotSelected">FAVOR DE SELECCIONAR UN PAQUETE</h1>
          <h1 class="text-sm text-red-700" v-if="hasError">Ocurrio un error, vuelva a intentar</h1>
        </div>
        <div class="flex">
          <ul class="flex gap-4 w-full md:grid-cols-2">
            <li>
              <input
                type="radio"
                id="hosting-small"
                name="hosting"
                v-model="po"
                value="1"
                class="hidden peer"
                required
              />
              <label
                for="hosting-small"
                class="flex flex-col space-y-5 justify-between items-center p-5 w-full bg-white rounded-lg border border-purple-200 cursor-pointer dark:hover:text-gray-300  peer-checked:border-green-600 hover:bg-gray-300"
              >
                <sobre :width="100" :height="50"/>
                <h3 class="text-black">$ {{ PricePackage['1'] }}</h3>
              </label>
            </li>
            <li>
              <input
                type="radio"
                id="hosting-big"
                name="hosting"
                v-model="po"
                value="2"
                class="hidden peer"
              />
              <label
                for="hosting-big"
                class="flex flex-col space-y-5 justify-between items-center p-5 w-full bg-white rounded-lg border border-purple-200 cursor-pointer dark:hover:text-gray-300  peer-checked:border-green-600 hover:bg-gray-300"
              >
                <p1 :width="100" :height="50"/>
                <h3 class="text-black">$ {{ PricePackage['2'] }}</h3>
              </label>
            </li>
            <li>
              <input
                type="radio"
                id="hosting-1"
                name="hosting"
                v-model="po"
                value="3"
                class="hidden peer"
              />
              <label
                for="hosting-1"
                class="flex flex-col space-y-5 justify-between items-center p-5 w-full bg-white rounded-lg border border-purple-200 cursor-pointer dark:hover:text-gray-300  peer-checked:border-green-600 hover:bg-gray-300"
              >
                <p2 :width="100" :height="50"/>
                <h3 class="text-black">$ {{ PricePackage['3'] }}</h3>
              </label>
            </li>
            <li>
              <input
                type="radio"
                id="hosting-2"
                name="hosting"
                v-model="po"
                value="4"
                class="hidden peer"
              />
              <label
                for="hosting-2"
                class="flex flex-col space-y-5 justify-between items-center p-5 w-full bg-white rounded-lg border border-purple-200 cursor-pointer dark:hover:text-gray-300  peer-checked:border-green-600 hover:bg-gray-300"
              >
                <p3 :width="100" :height="50"/>
                <h3 class="text-black">$ {{ PricePackage[4] }}</h3>
              </label>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div
      class="flex flex-row flex-nowrap items-center justify-center py-5 my-5"
    >
      <div class="justify-start mx-10">
        <button
          class="bg-purple-500 hover:bg-purple-400 text-white font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
          @click="$emit('lastView')"
        >
          Atrás
        </button>
      </div>
      <div class="justify-self-end mx-10">
        <button
          class="bg-purple-500 hover:bg-purple-400 text-white font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
          v-if="op == 3"
          @click="value();
            $emit('changeView');"
        >
          Siguiente
        </button>
      </div>
    </div>
  </div>
</template>
<script>
import { ref } from 'vue';
import p1 from "@/components/icons/Package1.vue";
import p2 from "@/components/icons/Package2.vue";
import p3 from "@/components/icons/Package3.vue";
import sobre from "@/components/icons/Sobre.vue";
import { useStore } from "vuex"
import { PricePackage } from '@/utils/constants';
import { setDelivery } from '../composables/calculateDelivery';

export default {
  name: "PackageA",
  components: {
    p1,
    p2,
    p3,
    sobre
  },
  props: {
    op: Number
  },
  setup(){
    const store = useStore();
    const po = ref(0);
    const isNotSelected = ref(true);
    function value(){
      if (po.value != 0) {
        const c1 = store.state.delivery;
        console.log(store.state.delivery);
        const delivery = setDelivery(c1.Origin[1], c1.Posting[1], c1.Origin[0], c1.Posting[0]);
        store.dispatch("shipping/setPriceP", PricePackage[po.value]);
        store.dispatch('shipping/setPriceD', delivery);
        store.dispatch('shipping/setTotal');
        console.log(store.state.shipping);
        isNotSelected.value = true;
      }else{
        isNotSelected.value = false;
      }
    }


    return{
      po,
      value,
      isNotSelected,
      PricePackage
    }
  }
};
</script>
<style></style>
