<template>
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col">
                    <h2>Detalhes do Cavaleiro</h2>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div v-if="knight" class="row">
                <div class="col">
                    <strong>Nome:</strong>
                </div>
                <div class="col">
                    {{ knight.name }}
                </div>
                <div class="col">
                    <strong>Apelido:</strong>
                </div>
                <div class="col">
                    {{ knight.nickname }}
                </div>
                <div class="col">
                    <strong>Aniversario:</strong>
                </div>
                <div class="col">
                    {{ new Date(knight.birthday).toLocaleDateString('pt-BR') }}
                </div>
                <div class="col">
                    <strong>Atributo:</strong>
                </div>
                <div class="col">
                    {{ knight.keyAttribute }}
                </div>
            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col">
                    <h3>Atributos:</h3>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col">
                    <strong>Força:</strong>
                </div>
                <div class="col">
                    {{ knight.attributes.strength }}
                </div>
                <div class="col">
                    <strong>Destreza:</strong>
                </div>
                <div class="col">
                    {{ knight.attributes.dexterity }}
                </div>
                <div class="col">
                    <strong>Constituição:</strong>
                </div>
                <div class="col">
                    {{ knight.attributes.constitution }}
                </div>
                <div class="col">
                    <strong>Inteligência:</strong>
                </div>
                <div class="col">
                    {{ knight.attributes.intelligence }}
                </div>
                <div class="col">
                    <strong>Sabedoria:</strong>
                </div>
                <div class="col">
                    {{ knight.attributes.wisdom }}
                </div>
                <div class="col">
                    <strong>Carisma:</strong>
                </div>
                <div class="col">
                    {{ knight.attributes.charisma }}
                </div>
            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col">
                    <h3>Armas:</h3>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col">
                    <ul class="list-group">
                        <li v-for="weapon in knight.weapons" :key="weapon.id" v-bind:class="{'list-group-item': true}">
                            {{ weapon.name }} - {{ weapon.attr }}
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                knight: null,
            }
        },
        async created() {
            try {
                const response = await axios.get(`/api/Knights/GetById/${this.$route.params.id}`);
                this.knight = response.data;

            } catch (error) {
                console.error(error);
            }
        },
    }
</script>