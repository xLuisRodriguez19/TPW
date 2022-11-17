<template>
  <div class="flex p-5">
    <div class="grid grid-flow-row-dense grid-cols-3 w-full">
      <div>
        <User/>
      </div>
      <div class="col-span-2">
        <div class="grid grid-col-2">
            <div class="flex flex-col items-center">
                <h1 class="text-3xl text-black">Historial de envíos</h1>
            </div>
            <div>
                <HistorialU/>
            </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import User from './components/User.vue';
import HistorialU from './components/HistorialU.vue';
export default {    
  name: "PerfilA",
  components: {
    User,
    HistorialU
  },
  
};
</script>
