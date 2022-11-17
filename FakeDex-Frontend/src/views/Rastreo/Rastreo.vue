<template>
  <div class="flex flex-col flex-nowrap space-y-10 items-center">
    <Slider />
    <div class="flex flex-col items-center" v-if="showHistorial">
      <div>
        <h1 class="text-3xl justify-self-center text-black">
          Historial de envío
        </h1>
        <div class="flex flex-row flex-nowrap space-x-10">
          <h1 class="text-base justify-self-start text-black">
            <b>Origen:</b> {{ nameO }}
          </h1>
          <h1 class="text-base justify-self-end text-black">
            <b>Destino:</b> {{ nameD }}
          </h1>
          <h1 class="text-base justify-self-end text-black">
            <b>Status:</b> {{ Status[status] }}
          </h1>
        </div>
      </div>
      <div>
        <Historial />
      </div>
    </div>
  </div>
</template>
<script>
import { computed, ref } from "vue";
import Slider from "@/components/Slider/Slider.vue";
import Historial from "./components/Historial.vue";
import { useStore } from "vuex";
import { Status } from "@/utils/constants";

export default {
  name: "RastreoA",
  components: {
    Slider,
    Historial,
  },
  setup() {
    const store = useStore();
    const showHistorial = computed(() => {
        if(store.state.shipping.value){
          console.log(store.state.shipping);
            nameO.value = store.state.shipping.value.addressO;
            nameD.value = store.state.shipping.value.addressD;
            status.value = store.state.shipping.value.status;
        }
        return store.state.shipping.value;
    });
    const nameO = ref("");
    const nameD = ref("");
    const status = ref("");

    window.openModal = function (modalId) {
      document.getElementById(modalId).style.display = "block";
      document
        .getElementsByTagName("body")[0]
        .classList.add("overflow-y-hidden");
    };

    window.closeModal = function (modalId) {
      document.getElementById(modalId).style.display = "none";
      document
        .getElementsByTagName("body")[0]
        .classList.remove("overflow-y-hidden");
    };

    // Close all modals when press ESC
    document.onkeydown = function (event) {
      event = event || window.event;
      if (event.keyCode === 27) {
        document
          .getElementsByTagName("body")[0]
          .classList.remove("overflow-y-hidden");
        let modals = document.getElementsByClassName("modal");
        Array.prototype.slice.call(modals).forEach((i) => {
          i.style.display = "none";
        });
      }
    };

    return {
      nameO,
      nameD,
      status,
      Status,
      showHistorial
    };
  },
};
</script>
