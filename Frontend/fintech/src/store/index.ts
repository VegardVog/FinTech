import { createStore } from "vuex";
import { User } from "../interfaces/types";

export default createStore({
  state: {
    isLoggedIn:
      JSON.parse(localStorage.getItem("isLoggedIn") as string) || false,
  },
  getters: {
    isLoggedIn(state): boolean {
      return state.isLoggedIn;
    },
  },
  mutations: {
    SET_LOGIN_STATE(state, isLoggedIn: boolean) {
      state.isLoggedIn = isLoggedIn;
      localStorage.setItem("isLoggedIn", JSON.stringify(isLoggedIn));
    },
  },
  actions: {
    loginUser({ commit }) {
      commit("SET_LOGIN_STATE", true);
    },
    logoutUser({ commit }) {
      commit("SET_LOGIN_STATE", false);
    },
  },
  modules: {},
});
