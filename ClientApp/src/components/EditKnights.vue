<template>
    <div>
        <form @submit.prevent="updateName">
            <div class="card">
                <div class="card-header">
                    <h2>Alterar Nome</h2>
                </div>
                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <label for="nickname" class="form-label">Novo Apelido:</label>
                            <input type="text" id="nickname" v-model="newnickname" class="form-control" placeholder="Apelido">
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-3">
                                <button type="submit" class="btn btn-primary">Alterar</button>
                            </div>
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
                newnickname: '',
            }
        },
        methods: {
            async updateName() {
                try {

                    await axios.put(`/api/Knights/Edit/${this.$route.params.id}`, {
                        nickname: this.newnickname,
                    });
                    this.$router.push('/ListKnights');
                } catch (error) {
                    console.error(error);
                }
            },
        },
    }
</script>
