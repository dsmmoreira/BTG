<template>
    <h1 id="tableLabel">List Guereiros</h1>

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
                <th>Excluir</th>
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
                <td><button type="button" class="btn btn-info" @click="goToDetails(knight.id)">Consultar</button></td>
                <td><button type="button" class="btn btn-warning" @click="goToEditNickname(knight.id)">Alterar Apelido</button></td>
                <td><button type="button" class="btn btn-danger" @click="deleteKnight(knight.id)">Excluir</button></td>
            </tr>
        </tbody>
    </table>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "ListKnights",
        data() {
            return {
                knights: []
            }
        },
        methods: {
            async deleteKnight(id) {
                try {
                    await axios.delete(`/api/Knights/Delete/${id}`);
                    this.knights = this.knights.filter(knight => knight.id !== id);
                } catch (error) {
                    console.error(error);
                }
            },
            GetAll() {
                axios.get('/api/Knights/GetAllKnights')
                    .then((response) => {
                        this.knights = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            goToDetails(id) {
                this.$router.push(`/View/${id}`);
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