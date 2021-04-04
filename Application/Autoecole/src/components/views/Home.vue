<template>
  <div class="home">
    <Nav />
    <router-view></router-view>
  </div>
</template>

<script>
// @ is an alias to /src
import Nav from "@/components/views/Nav.vue";
export default {
  name: "Home",
  components: {
    Nav
  }
};
</script>
