<template>
  <div class="flex flex-col items-center" v-if="showHistorial">
    <div>
      <h1 class="text-3xl justify-self-center text-black">Datos de envío</h1>
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
      <form
        @submit.prevent="updateTracking"
        class="w-full max-w-lg my-5 p-5 border-sm shadow-lg"
      >
        <h1 class="text-3xl justify-self-center text-black">
          Actualizar de envío
        </h1>
        <div class="flex flex-wrap -mx-3 mb-6">
          <div class="w-full md:w-1/2 px-3 mb-6 md:mb-0">
            <label
              class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
              for="grid-first-name"
            >
              C.P.
            </label>
            <input
              class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
              id="grid-first-name"
              v-model="cp"
              type="text"
              required
              @change="search"
            />
            <!-- <p class="text-red-500 text-xs italic">Please fill out this field.</p> -->
          </div>
          <div class="w-full md:w-1/2 px-3 mb-6 md:mb-0">
            <label
              class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
              for="grid-first-name"
            >
              Ciudad
            </label>
            <input
              class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
              id="grid-first-name"
              v-model="city"
              type="text"
            />
            <!-- <p class="text-red-500 text-xs italic">Please fill out this field.</p> -->
          </div>
          <div class="w-full md:w-1/2 px-3 mb-6 md:mb-0">
            <label
              class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
              for="grid-first-name"
            >
              Ubicación
            </label>
            <input
              class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
              id="grid-first-name"
              v-model="state"
              required
              type="text"
            />
            <!-- <p class="text-red-500 text-xs italic">Please fill out this field.</p> -->
          </div>
          <div class="w-full md:w-1/3 px-3 mb-6 md:mb-0">
            <label
              class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
              for="grid-state"
            >
              Estado
            </label>
            <div class="relative">
              <select
                class="block appearance-none w-full bg-gray-200 border border-gray-200 text-gray-700 py-3 px-4 pr-8 rounded leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
                id="grid-state"
                required
                v-model="status1"
              >
                <option value="0">{{ Status[0] }}</option>
                <option value="1">{{ Status[1] }}</option>
                <option value="2">{{ Status[2] }}</option>
                <option value="3">{{ Status[3] }}</option>
                <option value="4">{{ Status[4] }}</option>
              </select>
              <div
                class="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700"
              >
                <svg
                  class="fill-current h-4 w-4"
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 20 20"
                >
                  <path
                    d="M9.293 12.95l.707.707L15.657 8l-1.414-1.414L10 10.828 5.757 6.586 4.343 8z"
                  />
                </svg>
              </div>
            </div>
          </div>
        </div>
        <div class="justify-self-end mx-10">
          <button
            type="submit"
            class="bg-purple-500 hover:bg-purple-400 text-white font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
          >
            Confirmar
          </button>
        </div>
      </form>
    </div>
    <Historial />
  </div>
</template>

<script>
import { computed, ref } from "vue";
import { useStore } from "vuex";
import { useAddress } from "../../Envios/composables/useAddress";
import { Status } from "@/utils/constants";
import { useTracking } from "../../Rastreo/composables/useTracking";
import { tracking } from "../composables/tracking";
import Historial from "../../Rastreo/components/Historial.vue";

export default {
  name: "UpdateT",
  components: {
    Historial,
  },
  setup() {
    const store = useStore();
    const { search, cp, places1, city, state, center } = useAddress();

    const { getTracking, hasError, track } = useTracking();
    getTracking();

    const { updateTracking, hasError1 } = tracking();
    console.log(store.state.tracking);
    const nameO = ref("");
    const nameD = ref("");
    const status = ref("");
    const status1 = ref("");
    const showHistorial = computed(() => {
      if (store.state.shipping.value) {
        nameO.value = store.state.shipping.value.addressO;
        store.dispatch("tracking/setShippId", store.state.shipping.value.id);
        nameD.value = store.state.shipping.value.addressD;
        store.dispatch("tracking/setLocation", `${city.value}, ${state.value}`);
        status.value = store.state.shipping.value.status;
        store.dispatch("tracking/setStatus", status1.value);
        store.dispatch("tracking/setCenter", center.value);
        console.log(store.state.tracking.center);
      }
      return store.state.shipping.value;
    });
    return {
      nameO,
      nameD,
      showHistorial,
      status,
      search,
      cp,
      places1,
      city,
      state,
      center,
      Status,
      getTracking,
      hasError,
      track,
      updateTracking,
      hasError1,
      status1,
    };
  },
};
</script>
