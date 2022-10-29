<template>
    <div>
      <Navbar/>
      <Slider/>
    </div>
</template>
<script>
import Navbar from '@/components/Navbar/Nav.vue';
import Slider from '@/components/Slider/Slider.vue';
export default {
  name: 'LandingA',
  components: {
    Navbar,
    Slider
  },
  setup() {
    
  }
}
</script>
