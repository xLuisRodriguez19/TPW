import { ref } from "vue";
import { useRouter } from 'vue-router';
import { useStore } from "vuex";
import { useApi } from "@/composables/useApi";

export function tracking(){
    const { post } = useApi();
    const store = useStore();
    const router = useRouter();
    const hasError1 = ref(false);
    const updateTracking = async () => {
      console.log(store.state.tracking);
      hasError1.value = false;
      const login = await post('/api/Orders', {
        shippingId: store.state.tracking.shippingId,
        location: store.state.tracking.location,
        latitud: store.state.tracking.center[0],
        longitud: store.state.tracking.center[1],
        status: store.state.tracking.status
      });
      console.log(login);
      if (login.success) {
        console.log(login.data, 'asdasdasd');
        router.push({ name: 'Landing'});
      } else {
        hasError1.value = true;
        console.log(login.data);
      }
    };
  
    return {
      updateTracking,
      hasError1
    };
  }