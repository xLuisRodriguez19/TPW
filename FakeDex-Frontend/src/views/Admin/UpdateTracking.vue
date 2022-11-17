<template>
    <div class="flex flex-col flex-nowrap space-y-10 items-center">
        <Slider />
        <TrackFormVue />
    </div>
</template>
<script>
import Slider from '@/components/Slider/Slider.vue';
import TrackFormVue from './components/TrackForm.vue';

export default {
    name: 'RastreoA',
    components: {
        Slider,
        TrackFormVue
    },
    setup(){
    }
}
</script>