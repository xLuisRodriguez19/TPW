<template>
    <div class="flex">
        <div class="h-96 w-screen flex flex-row flex-nowrap bg-truck rounded-2xl">
            <Inputs/>
        </div>
    </div>
</template>
<script>
import Inputs from './SliderInput.vue';

export default{
    name: 'SliderBackground',
    components: {
        Inputs
    }
}
</script>
<style>
.bg-truck{
    background-image: url('@/assets/img/logistica-y-transporte-1200x685.jpg');
    background-size: cover;
    background-repeat: no-repeat;
    background-position: center;
}
</style>