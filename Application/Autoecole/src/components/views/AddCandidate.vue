<template lang="">
<div>
    <Nav/>
 <div class="container">
    
    <div class="card row h-100 vert-align">
    <img class="card-img-top" src="holder.js/100px180/" alt="">
    <div class="card-body">
     <h4 class="card-title">Ajouter un Candidat</h4>
     <div class="row">
         <div class="col-xs-1-12">
            <div class="form-group">
              <label for="">Nom: *</label>
              <input type="text"
                class="form-control" v-model="nom" id="" aria-describedby="helpId" placeholder="" required>
            </div>
            <div class="form-group">
              <label for="">Prénom:*</label>
              <input type="text"
                class="form-control" v-model="prenom" id="" aria-describedby="helpId" placeholder="" required>
            </div>
            <div class="form-group">
              <label for="">C.I.N</label>
              <input type="number"
                class="form-control" v-model="cin" id="" aria-describedby="helpId" placeholder="">
              
            </div>
            <div class="form-group">
              <label for="">Date de naissance:*</label>
              <input type="date"
                class="form-control" v-model="dateofbirth" id="" aria-describedby="helpId" placeholder="" required>
            </div>
            <div class="form-group">
              <label for="">Adresse:</label>
              <textarea class="form-control" v-model="adresse" id="" rows="2" placeholder="Rue - Ville -Code postal"></textarea>
            </div>
            <div class="form-group">
              <label for="">Téléphone</label>
              <input type="text"
                class="form-control" v-model="tel" id="" aria-describedby="helpId" placeholder="66 559 988">
            </div>
            <button type="submit" class="btn btn-primary" @submit="verify">Ajouter</button>
         </div>
  
        
     </div>
     
   </div>
   
 </div>
 </div>  
</div>
 
</template>

<script>
import Nav from '@/components/views/Nav.vue'
export default {
    name:'addCandidate',
    data() {
        return {
            nom:'',
            prenom:'',
            cin:'',
            dateofbirth:'',
            adresse:'',
            tel:'',
        }
    },
   
    methods: {
        verify(event){
            event.preventDefault()
            alert(JSON.stringify(this.form))
        }
    },
  components:{
    Nav
  }
}
</script>
<style lang="">
    
</style>