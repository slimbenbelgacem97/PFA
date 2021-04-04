import Vue from "vue"
import App from '@/App.vue'
import VueRouter from "vue-router"
import Home from "@/components/views/Home.vue"
import Login from '@/components/views/login.vue'
import AddCandidate from '@/components/views/AddCandidate.vue'
import AddAgent from '@/components/views/AddAgent.vue'
import ListAgent from '@/components/views/AgentList.vue'
import AgentDetails from '@/components/views/AgentDetails'
import SignUp from '@/components/views/SignUp.vue'
Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'Main',
    component: App
  },
  {
    path: "/home",
    name: "Home",
    component: Home
  },
  {
    path: "/signUp",
    component: SignUp,
    name: "SignUp"
  },
  // Lonin
  {
    path: "/login",
    component: Login,
    name:"Login"
  },
  // CAndidate routes
  {
    path: "/candidate/add",
    component: AddCandidate,
    name:"AddCandidate"
  },
  // Agent routes
  {
    path: "/agent/add",
    component: AddAgent,
    name:"AddAgent"
  },
 {
    path: "/agent/list",
    component: ListAgent,
    name:"Agent List"
  },
  {
    path: "/agent/details",
    component: AgentDetails,
    name: "Agent Details"
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;
