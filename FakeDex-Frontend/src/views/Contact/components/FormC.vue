<template>
  <section class="bg-white">
    <div class="py-8 lg:py-16 px-4 mx-auto max-w-screen-md">
      <h2
        class="mb-4 text-4xl tracking-tight font-extrabold text-center text-gray-900"
      >
        {{ $t('CONTACT.TITLE') }}
      </h2>
      <h1 class="mb-4 text-4xl tracking-tight font-extrabold text-center text-green-400" v-if="isSuggestion">¡Su sugerencia ha sido enviada con exito!</h1>
      <p
        class="mb-8 lg:mb-16 font-light text-center text-gray-500 sm:text-xl"
      >
      {{ $t('CONTACT.DESCRIPTION') }}
      </p>
      <form @submit.prevent="setSuggestion">
        <div>
          <label
            for="email"
            class="block mb-2 text-sm font-medium text-black"
            >Correo</label
          >
          <input
            type="email"
            id="email"
            class="shadow-sm bg-gray-50 border border-gray-300 text-black text-sm rounded-lg focus:ring-primary-500 focus:border-primary-500 block w-full p-2.5 "
            placeholder="name@flowbite.com"
            v-model="email"
            required
          />
        </div>
        <div>
          <label
            for="subject"
            class="block mb-2 text-sm font-medium text-black"
            >Asunto</label
          >
          <input
            type="text"
            id="subject"
            class="block p-3 w-full text-sm text-black bg-gray-50 rounded-lg border border-gray-300 shadow-sm focus:ring-primary-500 focus:border-primary-500"
            placeholder="Cuentanos en que podemos ayudarte"
            v-model="asunto"
            required
          />
        </div>
        <div class="sm:col-span-2">
          <label
            for="message"
            class="block mb-2 text-sm font-medium text-black"
            >Tu mensaje</label
          >
          <textarea
            id="message"
            rows="6"
            class="block p-2.5 w-full text-sm text-black bg-gray-50 rounded-lg shadow-sm border border-gray-300 focus:ring-primary-500 focus:border-primary-500"
            placeholder="Escribre un comentario..."
            v-model="desc"
            required
          ></textarea>
        </div>
        <button
          type="submit"
          class="bg-purple-500 hover:bg-purple-400 text-white font-bold py-2 px-4 border-b-4 border-purple-700 hover:border-purple-500 rounded"
        >
          Enviar mensaje
        </button>
      </form>
    </div>
  </section>
  
</template>
<script>
import messages from '../i18n/messages';
import { useSuggestion } from '../composables/useSuggestion';

export default {
    name: 'FormContact',
    i18n: {
        messages
    },
    setup(){
      const {
        setSuggestion,
        getSuggestion,
        hasError1,
        email,
        asunto,
        desc,
        isSuggestion,
        sugg
      } = useSuggestion();

      return{
        setSuggestion,
        getSuggestion,
        hasError1,
        email,
        asunto,
        desc,
        isSuggestion,
        sugg
      }
    }
}
</script>