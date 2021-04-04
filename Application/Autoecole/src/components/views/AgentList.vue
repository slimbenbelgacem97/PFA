<template lang="">
    
    <div >
       <Nav /> 
        <div class="container card  vert-align my-3 ">
            <div class="card-body">
                <div class ="row pl-4" >
                    <div class="col=''">
                        <div class ="row border-bottom  " >
                            
                              <h4 class="card-title " >{{Agentname + AgentLast}}</h4>  
                              <h6 class="px-4 " > {{state}}</h6> 
                            
                        </div>
                    </div>  
                    
                 </div> 
                <div class="card-text">
                    <h6>Fonction: {{AgentFunction}}</h6>
                    Next seance:{{DateSeance}}  {{ avec(AgentFunction)}}    
                </div>
                <div class =" row justify-content-end" >
                <div clas=" pr-5 " style="padding-right:20px" >
                 <router-link to="/agent/details/">
                 <b-icon icon="plus-circle" aria-hidden="true"></b-icon> Détailles 
                 </router-link> 
                 </div>
                </div>
            </div>
        </div>

        

    </div>
</template>
<script>
import Nav from '@/components/views/Nav.vue'
export default {
    data() {
        return {
            Agentname:'Abddsatar ',
            AgentLast: 'Akrouti',
            state:'Répos',
            AgentFunction:'Conduite',
            Candidat:'Wassime',
            DateSeance:'22/03/2021',
            vehicle:'Ford 2009',
            nbCandidat:15,
        }
    },
    name:"AgentList",
    components:{
        Nav
    },
    methods: {
        avec(AgentFunction){
            if(AgentFunction=="Conduite")
                return "avec "+ this.Candidat+' ' +this.vehicle;
            else if (AgentFunction=="Code")
                return " le nember des candidats: "+ this.nbCandidat;
            
        }
    },
    
}
</script>
<style lang="">
    
</style>