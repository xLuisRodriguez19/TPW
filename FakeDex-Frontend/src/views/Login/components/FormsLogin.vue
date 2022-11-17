<template>
  <div class="flex">
    <section class="bg-gray-50 p-10 rounded-lg shadow-lg">
      <div
        class="w-full bg-white rounded-lg shadow dark:border md:mt-0 sm:max-w-md xl:p-0"
      >
        <div class="p-6 space-y-4 md:space-y-6 sm:p-8">
          <h1
            class="text-xl font-bold leading-tight tracking-tight text-black"
          >
            Inicia sesión como invitado
          </h1>
          <form class="space-y-4 md:space-y-6" @submit.prevent="makeLogin">
            <div>
              <label
                for="email"
                class="block mb-2 text-sm font-medium text-black"
                >Correo</label
              >
              <input
                type="email"
                name="email"
                id="email"
                class="bg-gray-50 border border-gray-300 text-black sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                placeholder="name@company.com"
                v-model="clientId"
                required
              />
            </div>
            <button
              type="submit"
              class="w-full text-white bg-purple-500 hover:bg-purple-400 font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
            >
              Continuar
            </button>
            {{threads}}
            <p v-if="hasError">Credenciales incorrectas, intente de nuevo.</p>
          </form>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import { useLogin } from '../composable/useLogin';
import { useStore } from 'vuex'

export default {
  name: 'FormLogin',
  setup() {
    const {
      makeLogin,
      clientId,
      hasError
    } = useLogin();
    
    const store = useStore();

    return {
      clientId,
      makeLogin,
      hasError,
      threads: store.getters.id
    };
  }
}
</script>