import apiService from "@/services/apiService";
// import tokenStore from '@/store/token';
import { ok, fail } from "@/shared/actions/responseModels";
import { useStore } from "vuex";

export function useApi() {
  const store = useStore();
  /// cuando ocupa token
  const get = async (path, params = {}) => {
    let response = null;
    try {
      console.log(store.state.user.token.length);
      if (store.state.user.token.length === 0) {
        console.log("asdadasd22222222222");
        response = await apiService.get(path, {params});
      } else {
        console.log("asdadasd");
        response = await apiService.get(
          path,
          {
            headers: {
              authorization: `Bearer ${store.state.user.token}`,
            },
          }
        );
      }
      return ok(response.data);
    } catch (e) {
      return fail(e.message);
    }
  };

  const post = async (path, params = {}) => {
    let response = null;
    try {
      response = await apiService.post(path, params, {
        headers: {
          authorization: `Bearer ${store.state.user.token}`,
        },
      });
      return ok(response.data);
    } catch (e) {
      return fail(e.message);
    }
  };

  //cuando no ocupa token
  const get1 = async (path, params = {}) => {
    let response = null;
    try {
        response = await apiService.get(path, {params});
      return ok(response.data);
    } catch (e) {
      return fail(e.message);
    }
  };

  const post1 = async (path, params = {}) => {
    let response = null;
    try {
      response = await apiService.post(path, params);
      return ok(response.data);
    } catch (e) {
      return fail(e.message);
    }
  }

  return {
    get,
    post,
    get1,
    post1
  };
}
