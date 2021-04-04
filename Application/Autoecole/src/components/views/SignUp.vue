<template>
  <div class="container">
    <div class="card">
      <div class="card-body">
        <h4 class="card-title">S'inscrir</h4>
        <h5>
          <b-icon
            icon="exclamation-triangle-fill"
            scale="1"
            variant="warning"
          ></b-icon>
          Seul le directeur de l'autoécole s'inscrire
        </h5>
        <form @submit.prevent="verify">
          <div class="form-group">
            <label for="">Nom: *</label>
            <input
              type="text"
              class="form-control"
              v-model="user.nom"
              required
            />
          </div>

          <div class="form-group">
            <label for="">Prènom: *</label>
            <input
              type="text"
              class="form-control"
              v-model="user.prenom"
              required
            />
          </div>

          <div class="form-group ">
            <label for="">Nom d'utilisateur :*</label>
            <input
              type="text"
              class="form-control"
              v-model="user.usermane"
              placeholder="N° C.I.N"
              required
            />
            <small id="helpId" class="form-text text-muted"
              >le nom d'utilisateur doit être le N° C.I.N</small
            >
          </div>

          <div class="form-group mb-2">
            <label for="">Téléphone:*</label>
            <input
              type="text"
              class="form-control"
              v-model="user.tel"
              placeholder="66558844"
              required
            />
          </div>

          <div class="form-group">
            <label for="">Adresse:*</label>
            <textarea
              class="form-control"
              v-model="user.adresse"
              rows="2"
              placeholder="Rue - Ville -Code postal"
              required
            ></textarea>
          </div>

          <div class="form-group">
            <label for="">Mot de passe: * </label>
            <input
              type="password"
              class="form-control"
              v-model="user.password"
              placeholder="********"
            />
            <small id="helpId" class="form-text text-muted"
              >Le mot de passe doit:<br />
              <b-icon icon="check" scale="2" variant="success"></b-icon>
              Contenir au moins 8 caractères. <br />
              <b-icon icon="check" scale="2" variant="success"></b-icon>
              Lettre MJUSCULE <br />
              <b-icon icon="check" scale="2" variant="success"></b-icon>
              Un caractère spéciale. <br />
            </small>
          </div>

          <button type="submit" class="btn btn-primary">S'inscrir</button>
        </form>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "SignUP",
  data() {
    return {
      user: {
        nom: "",
        prenom: "",
        tel: "",
        adresse: "",
        usermane: "",
        password: "",
      },
    };
  },
  methods: {
    verify() {
      alert(JSON.stringify(this.user));
    },
    v() {
      let obj = {
        nom: this.user.nom,
        prenom: this.user.prenom,
        tel: this.user.tel,
        adresse: this.user.adresse,
        username: this.user.usermane,
        password: this.user.password,
      };
      alert(JSON.stringify(obj));
    },
  },
};
</script>
