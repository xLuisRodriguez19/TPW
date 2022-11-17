function userDefault() {
  return {
    id: "",
    isAdmin: "",
    token: ""
  };
}

const state = userDefault();

const getters = {
  userId: (state, getters, rootState) => {
    return state.id;
  },
  isAdmin: (state, getters, rootState) => {
    return state.isAdmin;
  },
  token: (state, getters, rootState) => {
    return state.token;
  }
};

// actions
const actions = {
  setUserId ({ commit, state }, id) {
    commit('setUserId', id)
    state.id = id;
  },
  setIsAdmin({ commit, state }, isadmin) {
    commit('setIsAdmin', isadmin)
    state.isAdmin = isadmin;
  },
  setToken({ commit, state }, t) {
    commit('setToken', t)
    state.token = t;
  },
  reset({ commit, state }) {
    commit('logout')
}
};

// mutations
const mutations = {
  setUserId(state, id ) {
    state.id = id;
  },

  setIsAdmin(state, isAdmin) {
    state.isAdmin = isAdmin;
  },
  setToken(state, t) {
    state.token = t;
  },
  logout(state) {
    state.id = '';
    state.isAdmin = '';
    state.token = '';
  }
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
