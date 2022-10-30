<template>
    <div class="mx-auto h-full overflow-auto">
        <Navbar/>
        <div class="z-10 f-container">
            <div class="bg-white divide-y divide-gray-200 h-full">
                <div class="py-4">
                    <router-view/>                    
                </div>
            </div>
        </div>
        <Footers/>
    </div>
</template>
<script>
import Navbar from '@/components/Navbar/Nav.vue';
import Footers from '@/components/Footer.vue';

export default {
    name: 'LayoutA',
    components: {
        Navbar,
        Footers
    }
}
</script>
<style lang="scss">
    .f-container{
        height: calc(100vh - 56px);
    }
</style>