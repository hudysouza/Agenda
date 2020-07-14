<template>
    <section>
      <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"></b-loading>
      <div class="px-4 py-4" style="max-width: 400px">
        <span class="is-size-4">Nova Pessoa</span>
        <b-field label="Nome" class="pt-5">
            <b-input v-model="pessoa.nome"></b-input>
        </b-field>
        <b-field label="Sobrenome">
            <b-input v-model="pessoa.sobrenome"></b-input>
        </b-field>
        <b-field label="Data de Nascimento">
          <b-datepicker
              placeholder="Selecione a data de nascimento"
              icon="calendar-today"
              v-model="pessoa.nascimento"
              trap-focus>
          </b-datepicker>
        </b-field>

        <b-button class="mt-4" icon-left="account-plus" type="is-primary" @click="adicionarPessoa">Adicionar</b-button>
    </div>
    </section>

</template>
<script>
import axios from 'axios'
export default {
  data () {
    return {
      isLoading: false,
      pessoa: {
        nome: '',
        sobrenome: '',
        nascimento: new Date()
      }
    }
  },
  methods: {
    adicionarPessoa () {
      this.isLoading = true

      axios.post('http://localhost:5000/api/pessoa', this.pessoa).then(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Pessoa adicionada com sucesso.',
          type: 'is-success'
        })
      }).catch(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Ocorreu um erro ao adicionar a pesosa.',
          type: 'is-error'
        })
      })
    }
  }
}
</script>
