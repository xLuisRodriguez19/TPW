<template>
  <div class="z-0">
    <div class="p-5 bg-purple-900 grid grid-cols-3 gap-2">

      <FakeIcon @click="goHome" class="flex-none w-20 h-7 cursor-pointer"/>

      <div class="flex flex-row flex-nowrap nav-center-container justify-self-center space-x-5 items-center">
        <router-link to="/rastreo" class="flex flex-row flex-nowrap  space-x-5" v-if="!isAdmin"><TrackIcon/>Rastreo</router-link>
        <router-link to="/envios" class="flex flex-row flex-nowrap  space-x-5" v-if="!isAdmin"><PackageIcon/>Envíos</router-link>
        <router-link to="/sucursales" class="flex flex-row flex-nowrap  space-x-5" v-if="!isAdmin"><LocationIcon/>Sucursales</router-link>
        <router-link to="/contact" class="flex flex-row flex-nowrap  space-x-5" v-if="!isAdmin"><ContactIcon/>Contacto</router-link>
        <router-link to="/admin" class="flex flex-row flex-nowrap  space-x-5" v-if="isAdmin"><ContactIcon/>Admin</router-link>
      </div>
      <div class="flex flex-row flex-nowrap justify-self-end space-x-5 items-center">
        <router-link to="/login" class="text-xs text-white" v-if="!isLogin">Registro/Inicio Sesión </router-link>
        <p class="text-xs text-white cursor-pointer" @click="logout" v-else>Cerrar Sesión</p>
        <router-link to="/user" class="text-white" v-if="isLogin"><UserIcon :width="30" :height="30"/></router-link>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue';
import FakeIcon from "@/components/icons/FakeDex.vue";
import UserIcon from "@/components/icons/User.vue";
import ContactIcon from "@/components/icons/Contact.vue";
import LocationIcon from "@/components/icons/Location.vue";
import PackageIcon from "@/components/icons/Package.vue";
import TrackIcon from "@/components/icons/Track.vue";
import { useRouter } from 'vue-router';
import store from '@/store';

export default {
  name: "NavBar",
  components: {
    FakeIcon,
    UserIcon,
    ContactIcon,
    LocationIcon,
    PackageIcon,
    TrackIcon,
  },
  setup() {
    const router = useRouter();
    const isLogin = computed(() => store.state.session.session);
    const isAdmin = computed(() => store.state.user.isAdmin);
    function goHome() {
      router.push({ name: 'Landing' });
    }

    function logout() {
      console.log(store.getters);
      console.log('asdas');
      store.dispatch('session/reset');
      store.dispatch('user/reset');
      console.log(store.getters);
      router.push({ name: 'Landing' });
    }

    return {
      goHome,
      logout,
      isLogin,
      isAdmin
    }
  }
};
</script>
<style>
.nav-center-container{
  @apply text-center text-base text-white cursor-default h-fit w-fit;
}

.nav-center-container a{
  text-transform: uppercase;
  letter-spacing: 2px;
}
</style>