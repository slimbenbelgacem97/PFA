import Vue from "vue";
import router from "./router";
import { BootstrapVue, IconsPlugin } from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import App from "@/App.vue";
import axios from "axios";
import VueAxios from "vue-axios";
//scheduler
import "@progress/kendo-ui";
import '@progress/kendo-theme-default/dist/all.css'
import { Scheduler } from '@progress/kendo-scheduler-vue-wrapper'
import { SchedulerInstaller } from '@progress/kendo-scheduler-vue-wrapper'

Vue.use(SchedulerInstaller)
Vue.use(VueAxios, axios);
Vue.use(BootstrapVue);
Vue.use(IconsPlugin);

Vue.config.productionTip = false;

new Vue({
  components: {
        Scheduler
    },
  router,
  render: h => h(App)
}).$mount("#app");
