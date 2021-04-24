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
        <form @submit.prevent="verify" method="post">
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

          <div class="form-group ">
            <label for="">Nom d'utilisateur :*</label>
            <input
              type="text"
              class="form-control"
              v-model="agent.agentcin"
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
              v-model="agent.tel"
              placeholder="66558844"
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

          <!-- <div class="form-group">
            <label for="">Mot de passe: * </label>
            <input
              type="password"
              class="form-control"
              v-model="logininfo.password"
              placeholder="********"
            />
            <small id="helpId" class="form-text text-muted"
              >Le mot de passe doit:<br />
              <b-icon
                v-if="logininfo.password.length >= 8"
                icon="check"
                scale="2"
                variant="success"
              />
              <b-icon v-else icon="exclamation-circle-fill" variant="danger" />
              Contenir au moins 8 caractères. <br />
              <b-icon
                v-if="logininfo.password ? /[A-Z]/.test(logininfo.password) : false"
                icon="check"
                scale="2"
                variant="success"
              />
              <b-icon v-else icon="exclamation-circle-fill" variant="danger" />
              Lettre MJUSCULE <br />
              <b-icon
                v-if="logininfo.password ? /[0-9]/.test(logininfo.password) : false"
                icon="check"
                scale="2"
                variant="success"
              />
              <b-icon v-else icon="exclamation-circle-fill" variant="danger" />
              Nembre<br />
              <b-icon
                v-if="
                  logininfo.password
                    ? /[-!$%^&*()_+|~=`\{\}\[\]:\/;<>?,.@#]/.test(
                        logininfo.password
                      )
                    : false
                "
                icon="check"
                scale="2"
                variant="success"
              ></b-icon>
              <b-icon v-else icon="exclamation-circle-fill" variant="danger" />
              Un caractère spéciale. <br />
            </small>
          </div> -->

          <button type="submit" class="btn btn-primary">
            S'inscrir
          </button>
          <!-- :disabled="
              !(
                (logininfo.password ? /[A-Z]/.test(logininfo.password) : false) &&
                (logininfo.password ? /[0-9]/.test(logininfo.password) : false) &&
                (logininfo.password
                  ? /[-!$%^&*()_+|~=`\{\}\[\]:\/;<>?,.@#]/.test(logininfo.password)
                  : false) &&
                logininfo.password.length >= 8
              )
            " -->
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
      agent: {
        agentcin: "",
        nom: "",
        prenom: "",
        tel: "",
        adresse: "",

        function: 2,
        dateEmb: new Date(),
        salire: 50000,
      },
      // logininfo:{
      //   usermane: this.agent.agentcin,
      //   password: "",
      // }
    };
  },
  methods: {
    verify() {
      this.axios({
        method: "post",
        
           headers: {'X-Custom-Header': 'foobar',
           'ccess-Control-Allow-Origin' :'*'
           },
        url: "https://localhost:5001/api/agent/add",
        data: this.agent,
      })
        .then((result) => {
          console.log(result);
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
};
</script>
