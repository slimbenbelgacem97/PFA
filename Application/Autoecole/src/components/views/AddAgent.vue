<template>
  <div class="container">
    <Nav />

    <div class="card text">
      <div class="card-body">
        <h4 class="card-title">Ajouter un Agent</h4>
        <b-form  @submit="c" method="post">
          <div class="form-group">
            <label for="">Nom: *</label>
            <input
              type="text"
              class="form-control"
              v-model="agent.nom"
              required
            />
          </div>
          <div class="form-group">
            <label for="">Prènom: *</label>
            <input
              type="text"
              class="form-control"
              v-model="agent.prenom"
              required
            />
          </div>
          <div class="form-group">
            <label for="">C.I.N: *</label>
            <input
              type="text"
              class="form-control"
              v-model="agent.cin"
              required
            />
          </div>
          <div class="form-group">
            <label for="">Date de Embauche :*</label>
            <input
              type="date"
              class="form-control"
              v-model="agent.dateEnm"
              required
            />
          </div>
          <div class="form-group">
            <label for="">Salaire: *</label>
            <input
              type="text"
              class="form-control"
              v-model="agent.salire"
              required
            />
          </div>
          <div class="form-group">
            <label for="">Adresse:*</label>
            <textarea
              class="form-control"
              v-model="agent.adresse"
              rows="2"
              placeholder="Rue - Ville -Code postal"
              required
            ></textarea>
          </div>
          <div class="form-group">
            <label for="">Téléphone:*</label>
            <input
              type="text"
              class="form-control"
              v-model="agent.tel"
              required
            />
          </div>
          <button type="submit" class="btn btn-primary">
            Ajouter
          </button>
        </b-form>
      </div>
    </div>
  </div>
</template>
<script>
import Nav from "@/components/views/Nav.vue";


export default {
  data() {
    return {
      agent: {
        nom: "",
        prenom: "",
        cin: "",
        dateEnm: "",
        adresse: "",
        tel: "",
        fonction: null
      },
    };
  },
  name: "AddAgent",
  components: Nav,
  methods: {
   
  }
  
};
</script>
<style lang=""></style>
