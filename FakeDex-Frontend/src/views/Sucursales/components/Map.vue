<template>
  <div class="h-screen w-full border-1 shadow-xl" ref="mapDiv"></div>
</template>
<script>
import Mapboxgl from "mapbox-gl";
import { ref, onMounted } from "vue";

export default {
  name: "MapA",
  setup() {
    const mapDiv = ref(HTMLDivElement);
    const lt = { lng: -109.932298, lat: 27.4846619 };

    function setPlace() {
      Mapboxgl.accessToken = "pk.eyJ1IjoibHVpc3NreWIxOSIsImEiOiJjbDl2d2xyMDEwY3JnM3FtdGhvdG4zMWx0In0.jF-WPH9KFzfm72CP5T8FNQ";
      const map = new Mapboxgl.Map({
        container: mapDiv.value, // container ID
        style: "mapbox://styles/mapbox/streets-v11", // style URL
        center: [-109.932298, 27.4846619], // starting position [lng, lat]
        zoom: 11, // starting zoom
        projection: "globe", // display the map as a 3D globe
      });

      const mark = new Mapboxgl.Marker().setLngLat(lt);
      mark.addTo(map);

      map.on("style.load", () => {
        map.setFog({}); // Set the default atmosphere style
        new Mapboxgl.Marker().setLngLat(lt).addTo(map);
      });
    }
    onMounted(() => {
      setPlace(null);
    });
    return {
      mapDiv,
      lt,
      setPlace,
    };
  },
};
</script>
