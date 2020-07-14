<template>
  <section>
    <span class="is-size-4 pr-3">Agenda</span>
    <b-button type="is-primary mr-3" @click="getPessoas" icon-left="refresh">Atualizar</b-button>
    <b-button type="is-primary" tag="router-link" to="/novapessoa" icon-left="account-plus">Novo</b-button>
    <b-table :data="pessoas">
      <template slot-scope="props">
        <b-table-column
          field="id"
          label="Id"
          sortable
          numeric>
          {{props.row.id}}
        </b-table-column>
        <b-table-column
          field="nome"
          label="Nome"
          sortable>
          {{props.row.nome}}
        </b-table-column>
        <b-table-column
          field="sobrenome"
          label="Sobrenome"
          sortable>
          {{props.row.sobrenome}}
        </b-table-column>
        <b-table-column
          field="nascimento"
          label="Nascimento"
          sortable>
          {{dataFormatada(props.row.nascimento)}}
        </b-table-column>
        <b-table-column
          field="acoes"
          label="Ações">
          <b-button type="is-primary mr-1" icon-left="account-edit" tag="router-link" :to="'/editarpessoa/' + props.row.id">Editar</b-button>
          <b-button type="is-danger" icon-left="delete" @click="deletePessoa(props.row.id)">Excluir</b-button>
        </b-table-column>
      </template>

    </b-table>
  </section>
</template>
<script>
import axios from 'axios'
export default {
  data () {
    return {
      pessoas: [],
      columns: [
        { field: 'id', label: 'ID', numeric: true },
        { field: 'nome', label: 'Nome' },
        { field: 'sobrenome', label: 'Sobrenome' },
        { field: 'nascimento', label: 'Nascimento' }
      ]
    }
  },
  methods: {
    getPessoas () {
      axios.get('http://localhost:5000/api/pessoa').then(ret => {
        this.pessoas = ret.data
      })
    },
    deletePessoa (id) {
      axios.delete('http://localhost:5000/api/pessoa/' + id).then(() => {
        this.$buefy.toast.open({
          message: 'Pessoa deletada com sucesso.',
          type: 'is-success'
        })
        this.getPessoas()
      }).catch(() => {
        this.$buefy.toast.open({
          message: 'erro ao deletar pessoa.',
          type: 'is-danger'
        })
      })
    },
    dataFormatada (date) {
      const data = new Date(date)
      const dia = data.getDate().toString()
      const diaF = (dia.length === 1) ? '0' + dia : dia
      const mes = (data.getMonth() + 1).toString() // +1 pois no getMonth Janeiro começa com zero.
      const mesF = (mes.length === 1) ? '0' + mes : mes
      const anoF = data.getFullYear()
      return diaF + '/' + mesF + '/' + anoF
    }
  },
  mounted () {
    this.getPessoas()
  }
}
</script>
