<template>
  <div class="flex py-5 my-5 justify-center">
    <div class="grid grid-cols-2 gap-52">
      <div>
        <h1 class="text-black text-3xl">Datos de origen</h1>
        <Forms />
      </div>
      <div>
        <h1 class="text-black text-3xl">Datos de envío</h1>
        <Forms />
      </div>
    </div>
  </div>
  <div class="flex flex-col flex-nowrap items-end">
    <div class="justify-center mx-10">
      <button
        class="bg-purple-500 hover:bg-purple-400 text-white font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
      >
        Siguiente
      </button>
    </div>
  </div>
</template>
<script>
import Forms from "./components/Forms.vue";

export default {
  name: "NameA",
  components: {
    Forms,
  },
};
</script>
