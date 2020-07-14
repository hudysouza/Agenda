<template>
    <section>
      <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"></b-loading>
      <div class="px-4 py-4" style="max-width: 400px">
        <span class="is-size-4">Editar Pessoa</span>
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
              v-model="nascimento"
              trap-focus>
          </b-datepicker>
        </b-field>

        <b-button class="mt-4" icon-left="account-plus" type="is-primary" @click="alterarPessoa">Alterar</b-button>
    </div>
    </section>

</template>
<script>
import axios from 'axios'
export default {
  data () {
    return {
      isLoading: false,
      pessoaid: '',
      pessoa: {
        nome: '',
        sobrenome: '',
        nascimento: new Date()
      }
    }
  },
  computed: {
    nascimento: {
      get () {
        return new Date(this.pessoa.nascimento)
      },
      set (val) {
        this.pessoa.nascimento = val
      }
    }
  },
  mounted () {
    this.isLoading = true
    this.pessoaid = this.$route.params.id
    axios.get('http://localhost:5000/api/pessoa/' + this.pessoaid).then(ret => {
      this.pessoa = ret.data
      this.isLoading = false
    }).catch(() => {
      this.isLoading = false
      this.$buefy.toast.open({
        message: 'pessoa não encontrada.',
        type: 'is-danger'
      })
      this.$router.push('/')
    })
  },
  methods: {
    alterarPessoa () {
      this.isLoading = true

      axios.put('http://localhost:5000/api/pessoa/' + this.pessoaid, this.pessoa).then(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Pessoa alterada com sucesso.',
          type: 'is-success'
        })
      }).catch(() => {
        this.isLoading = false
        this.$buefy.toast.open({
          message: 'Ocorreu um erro ao alterar a pesosa.',
          type: 'is-danger'
        })
      })
    }
  }
}
</script>
