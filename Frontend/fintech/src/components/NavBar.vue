<template>
  <div>
    <ul>
      <router-link
        v-for="nav in filteredNavItems"
        :key="nav.name"
        :to="nav.route"
        class="routerLink"
        @click.prevent="handleClick(nav)"
      >
        {{ nav.name }}
      </router-link>
    </ul>
  </div>
</template>

<script lang="ts">
import { computed, defineComponent } from "vue";
import { useRouter } from "vue-router";
import { useStore } from "vuex";

export default defineComponent({
  name: "NavComponent",
  setup() {
    const store = useStore();
    const router = useRouter();
    const navItems = [
      { name: "Home", route: "/" },
      { name: "About us", route: "/About" },
      { name: "Profile", route: "/Profile", shownWhenLoggedOut: false },
      {
        name: "UserCreation",
        route: "/UserCreation",
        shownWhenLoggedOut: true,
      },
      { name: "Login", route: "/Login", shownWhenLoggedOut: true },
      {
        name: "Logout",
        route: "/",
        shownWhenLoggedOut: false,
        isLogout: true,
      },
    ];
    const isLoggedIn = computed(() => store.getters.isLoggedIn);

    const filteredNavItems = computed(() =>
      navItems.filter(
        (nav) =>
          nav.shownWhenLoggedOut === undefined ||
          nav.shownWhenLoggedOut !== isLoggedIn.value
      )
    );

    const handleClick = (navItem: { isLogout: boolean }) => {
      if (navItem.isLogout) {
        console.log("asd");
        store.dispatch("logoutUser");
        router.push("/");
      }
    };
    return {
      filteredNavItems,
      handleClick,
    };
  },
});
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
.routerLink {
  display: inline;
  width: 100px;
  height: 100px;
  padding: 10px;
  margin: 5px;
  color: white;
  background-color: black;
  text-decoration: none;
}

.routerLink:hover {
  cursor: pointer;
  background-color: white;
  color: black;
  border: 1px solid black;
}
</style>
