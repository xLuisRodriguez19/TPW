function sessionDefault() {
    return {
      session: false
    };
  }
  
  const state = sessionDefault();
  
  const getters = {
    session: (state, getters, rootState) => {
      return state.session;
    }
  };
  
  // actions
  const actions = {
    isSession ({ commit, state }, session) {
      commit('setSession', session)
      state.session = session;
    },
    reset({ commit, state }) {
        commit('logout')
        state.session = false;
    }
  };
  
  // mutations
  const mutations = {
    setSession(state, session ) {
      state.session = session;
    },
  
    logout(state) {
      state.session = false;
    },
  };
  
  export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
  };