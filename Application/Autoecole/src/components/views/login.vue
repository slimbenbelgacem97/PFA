<template>
<div class="row h-100">
    <b-container  class=" vert-align " >
    
    <b-row align-h="center" class="mt-5 ">
            
            <b-col cols=5  >
                <b-card title="Connexion">
                    
                <b-form  @submit="onSubmit">
                    <div class="form-group">
                    <label for="">Nom d'utilisateur: *</label>
                    <input type="text"
                        class="form-control" v-model="form.username" id="" aria-describedby="helpId" placeholder="Exemple: 12345678" required >
                    
                    </div>
                    <div class="form-group">
                    <label for="">Mot de passe: *</label>
                    <input type="password" class="form-control" v-model="form.password" id="" placeholder="" required>
                    </div>
                    <small id="helpId" class="form-text text-muted" style="color:red">* : Champs obligatoire </small>
                </b-form>
                    <button type="submit" class="btn btn-primary">Connexion</button>
                </b-card>
                
            </b-col>
    </b-row>
    
    
    </b-container>
</div>


</template>
<script>
export default {
    name:"Login",
    data() {
        return {
           form:{
               username:'',
               password:''
           }
        }
    },
    methods: {
        onSubmit(event){
            event.preventDefault()
            alert(JSON.stringify(this.form))
            this.$route.push("/")
        }
    },
}
</script>
<style>

    .vert-align{
        margin-top: auto;
        margin-bottom: auto;
    }
</style>

