import { createStore } from 'vuex';
import user from "./modules/user";
import shipping from "./modules/shipping";
import session from "./modules/session";
import delivery from "./modules/delivery";
import tracking from './modules/tracking';
import center from './modules/center';

export default createStore({
  modules: {
    user,
    shipping,
    session,
    delivery,
    tracking, center
  },
});
