import { ref, reactive } from 'vue';
import axios from 'axios';
// or "const mapboxgl = require('mapbox-gl');"

// eslint-disable-next-line
export function useAddress() {
  const api = axios.create({
    baseURL: 'https://api.mapbox.com/geocoding/v5/mapbox.places',
    params: {
      limit: 3,
      language: 'es',
      country: 'mx',
      access_token: 'pk.eyJ1IjoibHVpc3NreWIxOSIsImEiOiJjbDl2d2xyMDEwY3JnM3FtdGhvdG4zMWx0In0.jF-WPH9KFzfm72CP5T8FNQ'
    }
  });
  const cp = ref('');
  const places1 = reactive(ref([]));
  const na1 = ref('');
  const city = ref("");
  const state = ref("");
  const center = ref('');

  const search = async () => {
    const places = await api.get(`/${cp.value}.json`);
    const { features } = places.data;
    const { ...place_name } = features;
    console.log(place_name);
    let n = place_name[0].place_name_es;
    na1.value = n.split(", ");
    city.value = na1.value[0];
    state.value = na1.value[1];
    center.value = place_name[0].center
    console.log(center.value);
  };
  return {
    search,
    cp,
    places1,
    na1,
    city,
    state,
    center
  };
}