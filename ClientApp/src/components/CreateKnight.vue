<template>
    <div>
        <form @submit.prevent="createKnight">
            <div class="card">
                <div class="card-body">
                    <div class="card">
                        <div class="card-header">
                            <h2>Criar Guerreiro</h2>
                        </div>
                        <div class="card-body">
                            <div class="form-row">
                                <div class="form-group col-md-3">
                                    <label for="name" class="form-label">Nome:</label>
                                    <input type="text" id="name" v-model="knight.name" required class="form-control" placeholder="Nome">
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="nickname" class="form-label">Apelido:</label>
                                    <input type="text" id="nickname" v-model="knight.nickname" required class="form-control" placeholder="Apelido" />
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="birthday" class="form-label">Birthday:</label>
                                    <input type="date" id="birthday" v-model="knight.birthday" required class="form-control" />
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="attributes" class="form-label"> Principal Atributo:</label>
                                    <select id="attributes" v-bind:class="{'form-select': true}" aria-label="Selecione uma atributo" v-model="knight.keyAttribute">
                                        <option v-for="(attribute, index) in attributes" :key="index" :value="attribute">
                                            {{ attribute }}
                                        </option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <h2>Atributos</h2>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-row">
                                <div v-for="(value, key) in knight.attributes" :key="key" class="form-group col-md-2">
                                    <label class="form-label" :for="key">{{ key }}:</label>
                                    <input type="number" :id="key" v-model.number="knight.attributes[key]" min="0" max="20" class="form-control">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <div class="form-row">
                                <div class="form-group col-md-12">
                                    <h2>Armas:</h2>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="form-row">
                                <div v-for="(weapon, index) in knight.weapons" :key="index" class="form-group col-md-12">
                                    <div class="form-row">
                                        <div class="form-group col-md-6">
                                            <label class="form-label" for="'weapon-' + index">Nome da Arma:</label>
                                            <input type="text" :id="'weapon-' + index" v-model="weapon.name" placeholder="Nome da Arma" required class="form-control">
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label class="form-label" for="'weapon-' + index">Nível:</label>
                                            <input type="number" :id="'weapon-' + index" v-model="weapon.mod" min="0" max="10" class="form-control">
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label class="form-label" for="'weapon-' + index">Atributo:</label>
                                            <select id="'weapon-' + index" v-model="weapon.attr" required v-bind:class="{'form-select': true}">
                                                <option v-for="(attribute, index) in attributes" :key="index" :value="attribute" class="form-control">
                                                    {{ attribute }}
                                                </option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row flex-row-reverse">
                                <div class="form-group col-md-12 bd-highlight">
                                    <button type="button" @click="addWeapon" class="btn btn-primary">Adicionar arma</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-12 float-right">
                            <button type="submit" class="btn btn-primary">Criar</button>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                knight: {
                    name: '',
                    nickname: '',
                    birthday: '',
                    keyAttribute: '',
                    weapons: [{
                        name: '',
                        attr: '',
                        mod: 0
                    }],
                    attributes: {
                        strength: 0,
                        dexterity: 0,
                        constitution: 0,
                        intelligence: 0,
                        wisdom: 0,
                        charisma: 0
                    }

                },
                attributes: ['Strength',
                    'Dexterity',
                    'Constitution',
                    'Intelligence',
                    'Wisdom',
                    'Charisma']
            }
        },
        methods: {
            addWeapon() {
                this.knight.weapons.push({ name: '' }); // Adiciona uma nova arma vazia
            },
            async createKnight() {
                try {
                    await axios.post('/api/Knights/Create', this.knight);
                    this.$router.push('/ListKnights'); // Redireciona para a lista de cavaleiros após a criação
                } catch (error) {
                    console.error(error);
                }
            }
        }
    }
</script>
