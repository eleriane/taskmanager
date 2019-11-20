<template>
  <div>
    <b-jumbotron header="Controle de Tarefas" lead>
      <hr/>
      <b-alert :show="loading" variant="info">Loading...</b-alert>
      <b-row>
        <b-col>
          <table class="table table-striped">
            <thead>
              <tr>
                <th>Título</th>
                <th>Descrição</th>
                <th>Concluído?</th>
                <th>Data de Inclusão</th>
                <th>&nbsp;</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="record in records" :key="record.id">
                <td>{{ record.titulo }}</td>
                <td>{{ record.descricao }}</td>
                <td>{{ record.statusConclusao }}</td>
                <td>{{ record.dataCriacao }}</td>
                <td class="text-right">
                  <a href="#" @click.prevent="updateTaskRecord(record)">Edit</a> -
                  <a href="#" @click.prevent="deleteTaskRecord(record.id)">Delete</a>
                </td>
              </tr>
            </tbody>
          </table>
        </b-col>
        <b-col lg="3" class="text-left">
          <b-card :title="(model.id ? 'Editando tarefa ID#' + model.titulo : 'Nova tarefa')">
            <form @submit.prevent="createTaskRecord">
              <b-form-group label="Título">
                <b-form-input type="text" v-model="model.titulo"></b-form-input>
              </b-form-group>

              <b-form-textarea
                id="textarea"
                v-model="model.descricao"
                placeholder="Descrição ..."
                rows="3"
                max-rows="6"
              ></b-form-textarea>

              <b-form-checkbox
                id="checkbox-1"
                v-model="model.StatusConcluido"
                name="checkbox-1"
                value="accepted"
                unchecked-value="not_accepted"
              >Concluído</b-form-checkbox>
              <div>
                <b-btn type="submit" variant="success">Salvar Tarefa</b-btn>
              </div>
            </form>
          </b-card>
        </b-col>
      </b-row>
    </b-jumbotron>
  </div>
</template>

<script>
import api from "@/TaskRecordsApiService";

export default {
  data() {
    return {
      loading: false,
      records: [],
      model: {}
    };
  },
  async created() {
    console.log(this.getAll());
    this.getAll();
  },
  methods: {
    async getAll() {
      this.loading = true;

      try {
        console.log(api.getAll())
        this.records = await api.getAll();
      } finally {
        this.loading = false;
      }
    },
    async updateTaskRecord(taskRecord) {
      // We use Object.assign() to create a new (separate) instance
      this.model = Object.assign({}, taskRecord);
    },
    async createTaskRecord() {
      const isUpdate = !!this.model.id;

      if (isUpdate) {
        await api.update(this.model.id, this.model);
      } else {
        console.log("Entrou no create");
        await api.create(this.model);
      }

      // Clear the data inside of the form
      this.model = {};

      // Fetch all records again to have latest data
      await this.getAll();
    },
    async deleteTaskRecord(id) {
      if (confirm("Are you sure you want to delete this record?")) {
        // if we are editing a task record we deleted, remove it from the form
        if (this.model.id === id) {
          this.model = {};
        }

        await api.delete(id);
        await this.getAll();
      }
    }
  }
};
</script>