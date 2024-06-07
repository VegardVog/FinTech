import { defineStore } from "pinia";

interface LoggedInState {
  isLoggedIn: boolean;
}

export const useLoggedInStore = defineStore({
  id: "loggedIn",
  state: (): LoggedInState => ({
    isLoggedIn: false,
  }),

  getters: {
    isLoggedInGetter: (state): boolean => state.isLoggedIn,
  },
  actions: {
    login(): void {
      this.isLoggedIn = true;
    },
    logout(): void {
      this.isLoggedIn = false;
    },
  },
});
