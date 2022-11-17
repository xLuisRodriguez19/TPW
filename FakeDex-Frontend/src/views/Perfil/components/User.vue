<template>
    <section class="w-64 mx-10 bg-white rounded-2xl px-8 py-6 shadow-lg">
      <div class="flex items-center justify-between">
      </div>
      <div class="mt-6 w-fit mx-auto">
        <Icon
        class="text-black"
          :width="150"
          :height="150"
        />
      </div>

      <div class="mt-8">
        <h2 class="text-black font-bold text-2xl tracking-wide">
          {{user}}
        </h2>
      </div>
      <p class="text-purple-400 font-semibold mt-2.5">Correo</p>
    </section>
</template>

<script>
import Icon from '@/components/icons/User.vue';
import { useStore } from 'vuex';
export default {
    name: 'UserA',
    components: {
        Icon
    },
    setup() {
    const store = useStore();
    const user = store.state.user.id;

    return{
      user
    }
  }

}
</script>
