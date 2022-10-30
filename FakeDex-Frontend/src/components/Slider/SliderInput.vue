<template>
  <div class="flex flex-row w-full justify-center items-end space-x-2 my-2">
    <form class="w-full max-w-sm" action="">
      <div class="flex items-center border-b border-purple-500 py-2">
        <input
          class="appearance-none font-bold bg-transparent border-none w-full text-2xl text-white mr-3 py-1 px-2 leading-tight focus:outline-none"
          type="text"
          placeholder="Ingrese número de rastreo"
        />
        <button
          class="flex-shrink-0 bg-purple-500 hover:bg-purple-700 border-purple-500 hover:border-purple-700 text-sm border-4 text-white py-1 px-2 rounded"
          type="button"
        >
          Buscar
        </button>
      </div>
    </form>
  </div>
</template>
<script>
export default {
  name: "SliderInput",
};
</script>
<style lang=""></style>
