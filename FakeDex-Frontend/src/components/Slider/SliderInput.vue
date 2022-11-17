<template>
  <div class="flex flex-col w-full justify-end items-center space-x-2 my-2">
    <form class="w-full max-w-sm" action="">
      <div class="flex flex-row items-center border-b border-purple-500 py-2 ">
        <input
          class="appearance-none placeholder-white font-bold bg-transparent border-none w-full text-2xl text-white mr-3 py-1 px-2 leading-tight focus:outline-none"
          type="text"
          placeholder="Ingrese número de rastreo"
          v-model="id"
        />
        <button
          class="flex-shrink-0 bg-purple-500 hover:bg-purple-700 border-purple-500 hover:border-purple-700 text-sm border-4 text-white py-1 px-2 rounded"
          type="button"
          @click="
            searchShipping();
          "
        >
          Buscar
        </button>
      </div>
    </form>
    <div class="flex flex-row " v-if="hasError">
      <h1 class="text-red-400 drop-shadow-3xl text-2xl font-bold underline underline-offset-8">No se encontró envío con numero de seguimiento ingresado</h1>
    </div>
  </div>
</template>
<script>
import { getShipping } from "@/views/Envios/composables/useShipping"

export default {
  name: "SliderInput",
  setup() {
    const { searchShipping, id, hasError } = getShipping();

    
    return {
      searchShipping,
      id,
      hasError
    };
  },
};
</script>
<style lang=""></style>
