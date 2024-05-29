<template>
  <div>
    <form @submit.prevent="handleSubmit">
      <div>
        <label for="username">Username:</label>
        <input type="text" id="username" v-model="form.userName" />
      </div>
      <div>
        <label for="email">Email:</label>
        <input type="email" id="email" v-model="form.email" />
      </div>
      <div>
        <label for="password">Password:</label>
        <input type="password" id="password" v-model="form.password" />
      </div>
      <button type="submit">Create User</button>
    </form>
  </div>
</template>

<script lang="ts">
import axios from "axios";
import { defineComponent, reactive } from "vue";

export default defineComponent({
  name: "UserCreationForm",
  setup() {
    const form = reactive({
      userName: "",
      email: "",
      password: "",
    });

    const getUserId = async () => {
      const response = await axios.get("https://localhost:7282/api/user/1");
      console.log(response.data);
    };

    // getUserId();

    const handleSubmit = async () => {
      console.log(form);
      try {
        const response = await axios.post(
          "https://localhost:7282/api/user/createuser",
          form
        );
        console.log(response.data);
      } catch (error) {
        console.error("Error: " + error);
      }
    };

    return {
      form,
      handleSubmit,
      getUserId,
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
