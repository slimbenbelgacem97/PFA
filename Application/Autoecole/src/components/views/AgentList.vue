<template lang="">
    <div class="container vert-align" >
        <Nav/>
        <div class="card   ">
            <div class="card-body">
                <div class ="row" >
                    <h4 class="card-title " >{{Agentname + AgentLast}}</h4> <p class="col-4" >   {{state}}</p>
                    <hr/>
                </div>
                <div class="card-text">
                    <h6>Fonction: {{AgentFunction}}</h6>
                    Next seance:{{DateSeance}}  {{ avec(AgentFunction)}} 
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
            AgentFunction:'Code',
            Candidat:'Wassime',
            DateSeance:'22/03/2021',
            vehicle:'Ford 2009',
            nbCandidat:15,
        }
    },
    name:"AgentList",
    components:Nav,
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