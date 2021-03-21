<template >

   <div class="container">
    <Nav/>
    
     <div class="card text">
       <div class="card-body">
         <h4 class="card-title">Ajouter un Agent</h4>
         <b-form >
            <div class="form-group">
              <label for="">Nom: *</label>
              <input type="text"
                class="form-control" v-model="nom" id="" aria-describedby="helpId" placeholder="" required>
            </div>
            <div class="form-group">
              <label for="">Prènom: *</label>
              <input type="text"
                class="form-control" v-model="prenom" aria-describedby="helpId" placeholder="" required>
            </div>
            <div class="form-group">
              <label for="">C.I.N: *</label>
              <input type="text"
                class="form-control" v-model="cin" aria-describedby="helpId" placeholder="" required>
            </div>
            <div class="form-group">
              <label for="">Date de Embauche :*</label>
              <input type="date"
                class="form-control" v-model="dateEnm" id="" aria-describedby="helpId" placeholder="" required>
            </div>
            <div class="form-group">
              <label for="">Salaire: *</label>
              <input type="text"
                class="form-control" v-model="salire" id="" aria-describedby="helpId" placeholder="" required>
            </div>
            <div class="form-group">
              <label for="">Adresse:*</label>
              <textarea class="form-control" v-model="adresse" id="" rows="2" placeholder="Rue - Ville -Code postal" required></textarea>
            </div>
            <div class="form-group">
              <label for="">Téléphone:*</label>
              <input type="text"
                class="form-control" v-model="tel" id="" aria-describedby="helpId" placeholder="" required>
            </div>
            <button type="submit" class="btn btn-primary" @submit = verify>Ajouter</button>
         </b-form>
       </div>
     </div>

     
   </div>
</template>
<script>
import Nav from '@/components/views/Nav.vue'
export default {
    data() {
        return {
            nom:'',
            prenom:'',
            cin:'',
            dateEnm:'',
            adresse:'',
            tel:''

        }
    },
   name:"AddAgent" ,
   components: Nav,
   methods: {
       verify(event){
            event.preventDefault()
            alert(JSON.stringify(this.form))
       }
   },
}
</script>
<style lang="">
    
</style>