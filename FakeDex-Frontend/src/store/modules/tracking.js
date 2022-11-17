function trackingDefault() {
    return {
      id: "",
      shippingId: "",
      center: {
        LN: '',
        LT: ''
      },
      location: '',
      isSelect: false,
      status: ''
    };
  }
  
  const state = trackingDefault();
  
  const getters = {
    Id: (state, getters, rootState) => {
      return state.id;
    },
    shippingId: (state, getters, rootState) => {
      return state.shippingId;
    },
    isSelect: (state, getters, rootState) => {
        return state.isSelect;
      },
      center: (state, getters, rootState) => {
        return state.center;
      },
      location: (state, getters, rootState) => {
        return state.location;
      },
      status: (state, getters, rootState) => {
        return state.status;
      }
  };
  
  // actions
  const actions = {
    setId ({ commit, state }, id) {
      commit('setId', id)
      state.id = id;
    },
    setShippId({ commit, state }, id) {
      commit('setShippId', id)
      state.shippingId = id;
    },
    setSelect({ commit, state }, is) {
        commit('setSelect', is)
        state.isSelect = is;
      },
      setCenter({ commit, state }, c) {
        commit('setCenter', c)
        state.center = c;
      },
      setLocation({ commit, state }, l) {
        commit('setLocation', l)
        state.center = l;
      },
      setStatus({ commit, state }, l) {
        commit('setStatus', l)
        state.status = l;
      }
  };
  
  // mutations
  const mutations = {
    setId(state, id ) {
      state.id = id;
    },
    setShippId(state, id ) {
        state.shippingId = id;
      },
    setSelect(state, is) {
      state.isSelect = is;
    },
    setCenter(state, c ) {
      state.center = c;
    },
  setLocation(state, l) {
    state.location = l;
  },
  setStatus(state, l) {
    state.status = l;
  }
  };
  
  export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,
  };
  