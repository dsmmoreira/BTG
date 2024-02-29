<template>
    <h1 id="tableLabel">Lista de Heróis</h1>

    <p v-if="!knights"><em>Loading...</em></p>

    <table class='table table-striped' aria-labelledby="tableLabel" v-if="knights">
        <thead>
            <tr>
                <th>Nome</th>
                <th>Idade</th>
                <th>Apelido</th>
                <th>Qauntidade Armas</th>
                <th>Ataque</th>
                <th>Experiencia</th>
                <th>Consultar</th>
                <th>Alterar Apelido</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="knight of knights" v-bind:key="knight">
                <td>{{ knight.nome }}</td>
                <td>{{ knight.idade }}</td>
                <td>{{ knight.apelido }}</td>
                <td>{{ knight.armas }}</td>
                <td>{{ knight.ataque }}</td>
                <td>{{ knight.experiencia }}</td>
                <td><button type="button" v-bind:class="{'btn': true, 'btn-info': true}" @click="goToDetails(knight.id)">Consultar</button></td>
                <td><button type="button" v-bind:class="{'btn': true, 'btn-warning': true}" @click="goToEditNickname(knight.id)">Alterar Apelido</button></td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "ListHeroes",
        data() {
            return {
                knights: []
            }
        },
        methods: {
            GetAll() {
                axios.get('/api/Knights/ListHeroes')
                    .then((response) => {
                        this.knights = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            goToDetails(id) {
                this.$router.push(`/DetailsKnight/${id}`);
            },
            goToEditNickname(id) {
                this.$router.push(`/EditKnights/${id}`);
            }
        },
        mounted() {
            this.GetAll();
        }
    }
</script>