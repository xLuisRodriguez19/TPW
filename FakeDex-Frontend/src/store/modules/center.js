function centerDefault() {
    return {
      LNG: -109.932298,
      LAT: 27.4846619
    };
  }
  
  const state = centerDefault();
  
  const getters = {
    LNG: () => state.LNG,
    LAT: () => state.LAT,
  };
  
  // actions
  const actions = {
    setLNG ({ commit, state }, o) {
      commit('setLNG', o);
      state.LNG = o;
    },
    setLAT({ commit, state }, p) {
      commit('setLAT', p);
      state.LAT = p;
    }
  };
  
  // mutations
  const mutations = {
    setLNG(state, o ) {
        state.LNG = o;
    },
  
    setLAT(state, p) {
      state.LAT = p;
    },
  };
  
  export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
  };
  