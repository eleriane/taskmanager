<template>
  <div id="app">
    <header>
      <b-navbar toggleable="md" type="light" variant="light">
        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
        <b-navbar-brand to="/">Task Manager</b-navbar-brand>
        <b-collapse is-nav id="nav-collapse">
          <b-navbar-nav> 
            <b-nav-item to="/task-records">Tarefas</b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </header>
    <main>
      <router-view></router-view>
    </main>
  </div>
</template>

<script>
export default {
  name: "app",
  data() {
    return {
      user: null
    };
  },
  async created() {
    await this.refreshUser();
  },
  watch: {
    $route: "onRouteChange"
  },
  methods: {
    login() {},
    async onRouteChange() {
      // every time a route is changed refresh the user details
      await this.refreshUser();
    },
    async refreshUser() {
      // get new user details and store it to user object
      // this.user = await this.$auth.getUser();
    },
    async logout() {}
  }
};
</script>

<style>
body {
  margin: 0;
}

#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

main {
  text-align: center;
  margin-top: 40px;
}

header {
  margin: 0;
  height: 56px;
  padding: 0 16px 0 24px;
  background-color: #f8f9fa;
  color: #ffffff;
}

header span {
  display: block;
  position: relative;
  font-size: 20px;
  line-height: 1;
  letter-spacing: 0.02em;
  font-weight: 400;
  box-sizing: border-box;
  padding-top: 16px;
}
</style>
