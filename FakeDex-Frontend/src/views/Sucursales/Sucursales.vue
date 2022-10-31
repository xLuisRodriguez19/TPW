<template>
    <div class="flex-col flex-nowrap px-20 py-10 justify-center items-center flex w-full h-96">
        <div class="mb-5">
            <h1 class="text-5xl text-black">Nuestras sucursales cerca de ti.</h1>
        </div>
        <Maps />
    </div>
</template>
<script>
import Maps from './components/Map.vue';

export default {
    name: 'SucursalesA',
    components: {
        Maps
    }
}
</script>
<style lang="">
    
</style>