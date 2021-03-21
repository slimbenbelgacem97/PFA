import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@/components/views/Home.vue";
import Login from '@/components/views/login.vue'
import AddCandidate from '@/components/views/AddCandidate.vue'
import App from '@/App.vue'

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
    path: "/Login",
    component: Login,
    name:"Login"
  },
  {
    path: "/candidate/add",
    component: AddCandidate,
    name:"AddCandidate"
  }
 
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;
