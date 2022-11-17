import { ref } from "vue";
import { useRouter } from 'vue-router';
import { useStore } from "vuex";
import { useApi } from "@/composables/useApi";

export function useTracking() {
  const { get1 } = useApi();
  const store = useStore();
  const track = ref("");
  const hasError1 = ref(false);
  const id = ref("");
  const getTracking = async () => {
    hasError1.value = false;
    id.value = store.state.shipping.value.id;
    console.log(store.state.shipping.value.id);
    const login = await get1("/api/Tracking", { id: id.value });
    if (login.success) {
      console.log(login.data);
      track.value = login.data;
      store.dispatch('tracking/setId', track.value.id);
      store.dispatch('tracking/setShippId', track.value.shippingId);
    } else {
      hasError1.value = true;
      console.log(login.data);
    }
  };

  return {
    getTracking,
    hasError1,
    track,
  };
}
