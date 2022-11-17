<template>
  <div class="flex py-5 my-5 justify-center" v-if="isLogin">
    <div class="grid grid-cols-1 gap-52" v-if="op==1">
      <div >
        <h1 class="text-black text-3xl">Datos de Origen</h1>
        <Forms @change-view="changeView" @last-view="lastView" :op="op" />
      </div>
    </div>
    <div class="grid grid-cols-1 gap-52" v-if="op==2">
      <div >
        <h1 class="text-black text-3xl">Datos de Destino</h1>
        <Forms @change-view="changeView" @last-view="lastView" :op="op"/>
      </div>
    </div>
    <div class="grid grid-cols-1 gap-52" v-if="op==3">
      <div >
        <toggles @change-view="changeView" @last-view="lastView" :op="op"/>
      </div>
    </div>
    <div class="grid grid-cols-1 gap-52" v-if="op==4">
      <div >
        <Checkout @change-view="changeView" @last-view="lastView" :op="op"/>
      </div>
    </div>
  </div>
  <div class="flex py-5 my-5 justify-center" v-else>
    <Message/>
  </div>
</template>
<script>
import { computed, ref } from 'vue';
import Forms from "./components/Forms.vue";
import toggles from './components/Package.vue';
import Message from './components/MessageLogin.vue';
import { useStore } from 'vuex'
import Checkout from './components/Checkout.vue';

export default {
  name: "NameA",
  components: {
    Forms,
    toggles,
    Message,
    Checkout
  },
  setup(){
    const store = useStore();
    const isLogin = computed(() => store.state.session.session);
    const op = ref(1);

    function changeView() {
      op.value = op.value + 1;
    }
    function lastView() {
      if(op.value > 0) {
        op.value = op.value - 1;
      }
    }

    return{
      isLogin,
      op,
      changeView,
      lastView
    }
  }
};
</script>
