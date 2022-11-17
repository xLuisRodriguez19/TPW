function deliveryDefault() {
    return {
      Origin: [],
      Posting: [],
    };
  }
  
  const state = deliveryDefault();
  
  const getters = {
    Origin: () => state.Origin,
    Posting: () => state.Posting,
  };
  
  // actions
  const actions = {
    setOrigin ({ commit, state }, o) {
      commit('setOrigin', o)
      state.Origin = o;
    },
    setPosting({ commit, state }, p) {
      commit('setPosting', p)
      state.Posting = p;
    }
  };
  
  // mutations
  const mutations = {
    setOrigin(state, o ) {
      state.Origin = o;
    },
  
    setPosting(state, p) {
      state.Posting = p;
    },
  };
  
  export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
  };
  