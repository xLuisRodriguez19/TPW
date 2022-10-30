<template>
  <div class="z-0">
    <div class="p-5 flex bg-white items-center justify-center">
      <footer class="p-4 w-full bg-white rounded-lg shadow-md md:px-6 md:py-8">
        <div class="flex items-center justify-center">
          <a
            href="#"
            class="flex items-center mb-4 sm:mb-0"
          >
            <Fakedex
            :width="150"
              class="mr-3 h-8"
            />
          </a>
        </div>
        <hr
          class="my-6 border-purple-200 sm:mx-auto dark:border-purple-700 lg:my-8"
        />
        <span class="block text-sm text-purple-600 sm:text-center"
          >© 2022
          <a href="#" class="hover:underline">FakeDex</a>.
          All Rights Reserved.
        </span>
      </footer>
    </div>
  </div>
</template>
<script>
import Fakedex from '@/components/icons/FakeDex.vue';
export default {
  name: "FooterA",
  components: {
    Fakedex
  }
};
</script>
