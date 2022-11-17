<template>
  <form class="w-full max-w-lg my-5 p-5 border-sm shadow-lg">
    <div class="flex flex-wrap -mx-3 mb-6">
      <div class="w-full md:w-1/2 px-3 mb-6 md:mb-0">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-first-name"
        >
          Nombre
        </label>
        <input
          class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
          id="grid-first-name"
          v-model="name"
          type="text"
          required
        />
        <!-- <p class="text-red-500 text-xs italic">Please fill out this field.</p> -->
      </div>
      <div class="w-full md:w-1/2 px-3">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-last-name"
        >
          Apellido
        </label>
        <input
          class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
          id="grid-last-name"
          v-model="lastname"
          type="text"
          required
        />
      </div>
    </div>
    <div class="flex flex-wrap -mx-3 mb-6">
      <div class="w-full px-3">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-password"
        >
          Direccion
        </label>
        <input
          class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 mb-3 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
          id="grid-password"
          v-model="address"
          type="text"
          required
        />
      </div>
    </div>
    <div class="flex flex-wrap -mx-3 mb-2">
      <div class="w-full md:w-1/3 px-3 mb-6 md:mb-0">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-zip"
        >
          C.P.
        </label>
        <input
          class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
          id="grid-zip"
          v-model="cp"
          type="text"
          required
          @change="search"
        />
      </div>
      <div class="w-full md:w-1/3 px-3 mb-6 md:mb-0">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-city"
        >
          Ciudad
        </label>
        <input
          class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
          id="grid-city"
          v-model="city"
          type="text"
          required
        />
      </div>
      <div class="w-full md:w-1/3 px-3 mb-6 md:mb-0">
        <label
          class="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
          for="grid-state"
        >
          Estado
        </label>
        <div class="relative">
          <input
            class="appearance-none block w-full bg-gray-200 text-gray-700 border border-gray-200 rounded py-3 px-4 leading-tight focus:outline-none focus:bg-white focus:border-gray-500"
            id="grid-city"
            v-model="state"
            type="text"
            required
          />
        </div>
      </div>
      <div v-if="city === ''">
        <h1 class="text-black">
          Por favor, ingrese un C.P. válido.
        </h1>
      </div>
    </div>
    <div
      class="flex flex-row flex-nowrap items-center justify-center py-5 my-5"
    >
      <div class="justify-start mx-10">
        <button
          class="bg-purple-500 hover:bg-purple-400 text-white font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
          v-if="op!==1"
          @click="$emit('lastView')"
        >
          Atrás
        </button>
      </div>
      <div class="justify-self-end mx-10">
        <button
          class="bg-purple-500 hover:bg-purple-400 text-white font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
          v-if="op == 3"
        >
          Confirmar
        </button>
        <button
          class="bg-purple-500 hover:bg-purple-400 text-white font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
          v-else
          @click="
            value();
            $emit('changeView');
          "
        >
          Siguiente
        </button>
      </div>
    </div>
  </form>
</template>

<script>
import { ref, computed, onMounted } from "vue";
import { useStore } from "vuex";
import { useAddress } from "../composables/useAddress";

export default {
  name: "FormShipping",
  props: {
    op: Number,
  },
  setup(props) {
    const store = useStore();
    const name = ref("");
    const lastname = ref("");
    const { search, cp, places1, city, state, center } = useAddress();
    // const city = ref("");
    // const state = ref("");
    const address = ref("");
    let n, n1;
    const na = ref("");

    onMounted(() => {
      switch (props.op) {
        case 1:
          n = computed(() => store.state.shipping.nameO);
          if (n.value !== undefined) {
            name.value = store.state.shipping.nameO.Name;
            lastname.value = store.state.shipping.nameO.LastName;
            address.value = store.state.shipping.AddressO.Address;
            city.value = store.state.shipping.AddressO.City;
            state.value = store.state.shipping.AddressO.State;
            cp.value = store.state.shipping.AddressO.CP;
          }
          break;
        case 2:
          n1 = computed(() => store.state.shipping.NameD);
          if (n1.value !== undefined) {
            name.value = store.state.shipping.NameD.Name;
            lastname.value = store.state.shipping.NameD.LastName;
            address.value = store.state.shipping.AddressD.Address;
            city.value = store.state.shipping.AddressD.City;
            state.value = store.state.shipping.AddressD.State;
            cp.value = store.state.shipping.AddressD.CP;
          }
          break;
      }
    });

    const pkg = computed(() => store.state.shipping.PriceP);
    function value() {
      switch (props.op) {
        case 1:
          store.dispatch("shipping/setNameO", {
            Name: name.value,
            LastName: lastname.value,
          });
          store.dispatch("shipping/setAddressO", {
            Address: address.value,
            CP: cp.value,
            City: city.value,
            State: state.value,
          });
          store.dispatch('delivery/setOrigin', center.value);
          console.log(store.state.shipping);
          console.log(store.state.delivery);
          break;
        case 2:
          store.dispatch(
            "shipping/setNameD",
            {
            Name: name.value,
            LastName: lastname.value,
          }
          );
          store.dispatch(
            "shipping/setAddressD",{
            Address: address.value,
            CP: cp.value,
            City: city.value,
            State: state.value,
          }
          );store.dispatch('delivery/setPosting', center.value);
          console.log(store.state.shipping);
          break;
      }
    }

    function isSelected() {
      console.log("cambiaaa", pkg.value);
      pkg.value = true;
      console.log("cambiaaa", pkg.value);
    }

    return {
      value,
      name,
      lastname,
      address,
      city,
      state,
      cp,
      isSelected,
      search,
      places1,
      na,
      center
    };
  },
};
</script>
