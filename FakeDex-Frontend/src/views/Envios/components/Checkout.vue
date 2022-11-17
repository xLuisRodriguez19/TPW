<template>
  <h1 v-if="hasError" class="text-center text-red-600 drop-shadow-3xl text-2xl font-bold underline underline-offset-8">Ocurrio un error, favor de volver a intentar</h1>
    <div class="w-full max-w-lg my-5 p-5 border-sm shadow-lg">
    <div class="flex flex-wrap -mx-3 mb-6">
        <div class="w-full md:w-1/2 px-3 mb-6 md:mb-0">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-first-name"
        >
          Origen: {{aO.Address}}, {{aO.CP}}, {{aO.City}}, {{aO.State}}
        </label>
      </div>

      <div class="w-full md:w-1/2 px-3 mb-6 md:mb-0">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-first-name"
        >
          Destino: {{aD.Address}}, {{aD.CP}}, {{aD.City}}, {{aD.State}}
        </label>
      </div>

      <div class="w-full md:w-1/2 px-3 mb-6 md:mb-0">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-first-name"
        >
          Nombre: {{nO.Name}} {{nO.LastName}}
        </label>
      </div>

      <div class="w-full md:w-1/2 px-3 mb-6 md:mb-0">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-first-name"
        >
          Nombre: {{nD.Name}} {{ nD.LastName}}
        </label>
      </div>

      <div class="w-full md:w-1/2 px-3 mb-6 md:mb-0">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-first-name"
        >
          Precio: {{total.toFixed(2)}}
        </label>
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
          @click="makeShipping"
        >
          Confirmar
        </button>
      </div>
    </div>
  </div>
</template>
<script>
import { useStore } from "vuex";
import { useShipping } from '../composables/useShipping';

export default {
  name: "PackageA",

  props: {
    op: Number
  },
  setup(){
    const store = useStore();
    const nO = store.state.shipping.nameO;
    const nD = store.state.shipping.NameD;
    const aO = store.state.shipping.AddressO;
    const aD = store.state.shipping.AddressD;
    const total = store.state.shipping.Total;

    const {
      makeShipping,
      hasError
    } = useShipping();

    return{
        nO,
        nD,
        aO,
        aD,
        total,
        hasError,
        makeShipping
    }
  }
};
</script>