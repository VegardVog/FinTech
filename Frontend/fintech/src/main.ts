import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import HighchartsVue from "highcharts-vue";
import { createPinia } from "pinia";

const pinia = createPinia();
createApp(App).use(pinia).use(router).use(HighchartsVue).mount("#app");
