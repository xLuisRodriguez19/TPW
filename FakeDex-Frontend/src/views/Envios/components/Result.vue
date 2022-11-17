<template>
    <div class="flex flex-col justify-center items-center p-5">
        <h1 class="text-black text-3xl">Su número de seguimiento es el siguiente: {{id}}</h1>
    </div>
</template>

<script>
import { useStore } from 'vuex';

export default {
    setup(){
        const store = useStore();
        const id = store.state.shipping.id;

        return{
            id
        }
    }
}
</script>