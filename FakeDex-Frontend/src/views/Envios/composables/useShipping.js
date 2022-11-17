import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { useStore } from 'vuex'
import { useApi } from '@/composables/useApi';

export function useShipping() {
    const router = useRouter();
    const { post } = useApi();
    const store = useStore();

    const hasError = ref(false);
    const makeShipping = async () => {
      hasError.value = false;
      console.log(store.state.user);
      console.log(store.state.shipping);
      const login = await post('/api/Shippings', {
        idUser: store.state.user.id,
        nameO: `${store.state.shipping.nameO.Name} ${store.state.shipping.nameO.LastName}`,
        addressO: `${store.state.shipping.AddressO.Address}, ${store.state.shipping.AddressO.CP}, ${store.state.shipping.AddressO.City}, ${store.state.shipping.AddressO.State}`,
        nameD: `${store.state.shipping.NameD.Name} ${store.state.shipping.NameD.LastName}`,
        addressD: `${store.state.shipping.AddressD.Address}, ${store.state.shipping.AddressD.CP}, ${store.state.shipping.AddressD.City}, ${store.state.shipping.AddressD.State}`,
        priceP: store.state.shipping.PriceP,
        priceD: store.state.shipping.PriceD,
        total: store.state.shipping.Total
      });
      if (login.success) {
        console.log(login.data);
        store.dispatch('shipping/reset');
        store.dispatch('shipping/setShippingId', login.data)
        router.push({ name: 'Result' });
      } else {
        hasError.value = true;
      }
    };
  
    return {
      makeShipping,
      hasError
    };
  }

  export function getShipping() {
    const router = useRouter();
    const { get1 } = useApi();
    const store = useStore();
    const id = ref('');
    const hasError = ref(false);
    
    const searchShipping = async () => {
      hasError.value = false;
      console.log(`id ${id.value}`);
      const login = await get1('/api/Shippings/id', { id: id.value
      });
      if (login.success) {
        if(login.data !== ''){
        store.dispatch('shipping/setShipping', login.data)
        console.log(store.state.shipping);
        if(store.state.user.isAdmin){
          router.push({ name: 'Admin' });
        } else {
          router.push({ name: 'Rastreo' });
        }
      }else{
        hasError.value = true;
      }
      } else {
        hasError.value = true;
      }
    };
  
    return {
      searchShipping,
      id,
      hasError
    };
  }

  export function getShippingUser() {
    const { get1, get } = useApi();
    const store = useStore();
    const id = ref('');
    const hasError = ref(false);
    
    const searchShippingById = async () => {
      hasError.value = false;
      console.log(`id ${store.state.user.id}`);
      const login = ref('');
      if (store.state.user.isAdmin){
        login.value = await get('/api/Shippings/');
      }else{
        login.value = await get1(`/api/Shippings/user/${store.state.user.id}`);
      }
      if (login.value.success) {
        console.log(login.value.data);
        // store.dispatch('shipping/setShipping', login.data)
        id.value = login.value.data;
      } else {
        hasError.value = true;
      }
    };
  
    return {
      searchShippingById,
      id,
      hasError
    };
  }