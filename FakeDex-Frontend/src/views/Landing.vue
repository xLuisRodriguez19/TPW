<template>
    <div class="flex flex-col space-y-6">
      <Slider/>
      <Sections/>
    </div>
</template>
<script>
import Slider from '@/components/Slider/Slider.vue';
import Sections from '@/components/Section/Section.vue';
export default {
  name: 'LandingA',
  components: {
    Slider,
    Sections
  },
  setup() {

  }
}
</script>
