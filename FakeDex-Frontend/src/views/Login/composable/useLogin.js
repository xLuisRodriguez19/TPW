import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { useStore } from 'vuex'
import { useApi } from '@/composables/useApi';

export function useLogin() {
    const router = useRouter();
    const { get } = useApi();
    const store = useStore();
  
    const clientId = ref('');
    const hasError = ref(false);
  
    const makeLogin = async () => {
      hasError.value = false;
      const login = await get('/api/Login', { email: clientId.value });
      if (login.success) {
        const { email, isAdmin, token } = login.data;
        store.dispatch('user/setUserId', email);
        store.dispatch('user/setIsAdmin', isAdmin);
        store.dispatch('session/isSession', true);
        store.dispatch('user/setToken', token);
        console.log(store.state.user);
        router.push({ name: 'Landing' });
      } else {
        hasError.value = true;
      }
    };
  
    return {
      makeLogin,
      clientId,
      hasError
    };
  }