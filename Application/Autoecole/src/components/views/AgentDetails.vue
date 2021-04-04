<template>
    <div>
    <Nav />
    <div class="container">
    <div class="card">
        <img class="card-img-top" src="holder.js/100x180/" alt="">
        <div class="card-body">
            <h4 class="card-title">{{Agentname}} Nom Prenom</h4>
            <h6>{{AgentFunction}}code/conduite</h6>
            Plain
            <hr />
            <!-- <Scheduler /> -->
        </div>
    </div>
    </div>
  </div>
</template>
<script>


import Nav from '@/components/views/Nav.vue'

export default {
  components: {
   
    Nav,
    // Scheduler
  }
}
 

</script>
<style lang="">
    
</style>