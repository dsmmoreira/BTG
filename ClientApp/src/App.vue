<template>
    <div class="container-fluid">
        <nav-menu></nav-menu>
        <router-view />
    </div>
</template>

<script>
    import NavMenu from './components/NavMenu.vue'

    export default {
        name: 'App',
        components: {
            NavMenu
        }
    };
    
</script>

<style>
   
</style>
