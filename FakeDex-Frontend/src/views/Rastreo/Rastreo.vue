<template>
    <div class="flex flex-col flex-nowrap space-y-10 items-center">
        <Slider />
        <div class="flex flex-col items-center">
            <div>
                <h1 class="text-3xl justify-self-center text-black">Historial de envío</h1>
            </div>
            <div>
                <Historial />
            </div>
        </div>
    </div>
</template>
<script>
import Slider from '@/components/Slider/Slider.vue';
import Historial from './components/Historial.vue';

export default {
    name: 'RastreoA',
    components: {
        Slider,
        Historial
    }
}
</script>
