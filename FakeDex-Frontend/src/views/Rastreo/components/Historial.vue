<template>
  <div class="overflow-x-auto w-full shadow-md sm:rounded-lg m-5">
    <table class="w-full text-sm text-left text-purple-500">
      <thead class="text-xs text-purple-700 uppercase bg-gray-100">
        <tr>
          <th scope="col" class="py-3 px-6">Ubicación</th>
          <th scope="col" class="py-3 px-6">Fecha y Hora</th>
          <th scope="col" class="py-3 px-6"></th>
        </tr>
      </thead>
      <tbody>
        <tr class="bg-white border-b" v-for="t of track" :key="t">
          <th
            scope="row"
            class="py-4 px-6 font-medium text-purple-900 whitespace-nowrap"
          >
            {{ t.location }}
          </th>
          <td class="py-4 px-6">{{ new Date(t.fecha).toLocaleString() }}</td>
          <td class="py-4 px-6">
            <!-- <button
              class="font-medium text-orange-600 hover:underline"
              type="button"
              data-modal-toggle="defaultModal"
              @click="viewPointer"
            >
              Ver
            </button> -->
            <button
              class="font-medium text-orange-600 hover:underline"
              @click="openModal(t.longitud, t.latitud)"
            >
              Ver
            </button>
          </td>

          <!-- <modal v-if="Pointer">
            <Maps :LNG="t.longitud" :LAT="t.latitud" />
          </modal> -->
        </tr>
      </tbody>
    </table>
  </div>
  <div class="flex justify-center pt-5">
    <div class="h-36 w-96" ref="mapDiv"></div>
  </div>
  <!-- Modal toggle -->
</template>
<script>
import { ref, onMounted } from "vue";
import Mapboxgl from "mapbox-gl";
import { useTracking } from "../composables/useTracking";
import {useStore} from "vuex";

export default {
  setup() {
    const store = useStore();
    const { getTracking, hasError, track } = useTracking();
    getTracking();
    const Pointer = ref(false);
    const mapDiv = ref(HTMLDivElement);
    const isVisible = ref(false);

    function viewPointer() {
      Pointer.value = true;
    }

    function openModal (l, la) {
      store.dispatch('center/setLNG', l);
        
        store.dispatch('center/setLAT', la);
        console.log(store.state.center);
        isVisible.value = true;
        setPlace(l, la);
    }

    function setPlace(l, la) {
      if(l !== 0 && la !== 0){
        Mapboxgl.accessToken = "pk.eyJ1IjoibHVpc3NreWIxOSIsImEiOiJjbDl2d2xyMDEwY3JnM3FtdGhvdG4zMWx0In0.jF-WPH9KFzfm72CP5T8FNQ";
      const map = new Mapboxgl.Map({
        container: mapDiv.value, // container ID
        style: "mapbox://styles/mapbox/streets-v11", // style URL
        center: [store.state.center.LAT, store.state.center.LNG], // starting position [lng, lat]
        zoom: 8, // starting zoom
        projection: "globe", // display the map as a 3D globe
      });

      const mark = new Mapboxgl.Marker().setLngLat({lng: store.state.center.LAT, lat: store.state.center.LNG});
      mark.addTo(map);

      map.on("style.load", () => {
        map.setFog({}); // Set the default atmosphere style
        new Mapboxgl.Marker().setLngLat({lng: store.state.center.LAT, lat: store.state.center.LNG}).addTo(map);
      });
      }
    }

     onMounted(() => {
       setPlace(0,0);
     });
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
      getTracking,
      hasError,
      track,
      viewPointer,
      Pointer,
      openModal,
      setPlace,
      mapDiv,
      isVisible
    };
  },
};
</script>
