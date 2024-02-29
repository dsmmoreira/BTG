<template>
    <header>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container">
                <img src="../assets/logo.png" width="35" height="30" class="d-inline-block align-top" alt="">
                Vue JS 3.0
                <img src="../assets/logodotnet.png" width="40" height="30" class="d-inline-block align-top" alt="">
                .NET 8.0
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#conteudoNavbarSuportado" aria-controls="conteudoNavbarSuportado" aria-expanded="false" aria-label="Alterna navegação">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse"
                     v-bind:class="{show: isExpanded}">
                    <ul class="navbar-nav flex-grow">
                        <li class="nav-item active">
                            <router-link :to="{ name: 'Home' }" class="nav-link text-dark">Inicio</router-link>
                        </li>
                        <li class="nav-item active">
                            <router-link :to="{ name: 'ListKnights' }" class="nav-link text-dark">Guereiros</router-link>
                        </li>
                        <li class="nav-item active">
                            <router-link :to="{ name: 'ListHeroes' }" class="nav-link text-dark">Heróis</router-link>
                        </li>
                        <li class="nav-item active">
                            <router-link :to="{ name: 'CreateKnights' }" class="nav-link text-dark">Criar</router-link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </header>
</template>


<style>
  
</style>
<script>
    export default {
        name: "NavMenu",
        data() {
            return {
                isExpanded: false
            }
        },
        methods: {
            collapse() {
                this.isExpanded = false;
            },

            toggle() {
                this.isExpanded = !this.isExpanded;
            }
        }
    }
</script>