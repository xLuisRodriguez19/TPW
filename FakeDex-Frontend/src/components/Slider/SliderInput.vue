<template>
    <div class="static w-full h-full">
        <div class="relative  w-full h-full flex flex-row flex-nowrap">
            <form class="relative w-full h-full" action="">
                <div class="relative w-full h-full flex items-center">
                    <input class="absolute left-96 right-96 -bottom-3 border-b border-purple-500 text-black mr-3 py-2 px-2 leading-tight focus:outline-none" type="text" placeholder="Ingrese número de seguimiento">
                    <button class="flex-shrink-0 bg-purple-500 hover:bg-purple-700 border-purple-500 hover:border-purple-700 text-sm border-4 text-white py-1 px-2 rounded absolute left-[22.5rems] right-96 -bottom-3">Buscar</button>
                </div>
            </form>
        </div>
    </div>
</template>
<script>
export default {
    name: 'SliderInput'
}
</script>
<style lang="">
    
</style>