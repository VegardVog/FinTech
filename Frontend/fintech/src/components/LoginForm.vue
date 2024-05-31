<template>
  <div>
    <form @submit.prevent="handleSubmit">
      <div>
        <label for="username">Username:</label>
        <input type="text" id="username" v-model="form.userName" />
      </div>
      <div>
        <label for="password">Password:</label>
        <input type="password" id="password" v-model="form.password" />
      </div>
      <button type="submit">Login</button>
    </form>
  </div>
</template>

<script lang="ts">
import axios from "axios";
import { computed, defineComponent, reactive } from "vue";
import { User } from "@/interfaces/types";
import store from "@/store";
import { getStockData } from "../StockAPI/stockData";

export default defineComponent({
  name: "LoginForm",
  setup() {
    const form = reactive({
      userName: "",
      password: "",
    });

    const handleSubmit = async () => {
      console.log(form);
      try {
        const response = await axios.post(
          "https://localhost:7282/api/user/login",
          form
        );

        login();

        console.log(computed(() => store.getters.isLoggedIn));
      } catch (error) {
        console.error("Error: " + error);
      }
    };

    const login = async () => {
      store.dispatch("loginUser");
      getStockData("AAPL");
    };

    return {
      form,
      handleSubmit,
      login,
    };
  },
});
</script>

<style scoped lang="scss">
form {
  display: flex;
  flex-direction: column;
  width: 300px;
  margin: 0 auto;

  div {
    margin-bottom: 10px;
  }

  label {
    margin-bottom: 5px;
  }

  input {
    padding: 5px;
    font-size: 16px;
  }

  button {
    padding: 10px;
    font-size: 16px;
    background-color: #42b983;
    color: white;
    border: none;
    cursor: pointer;
  }
}
</style>
