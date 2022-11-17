function shippingDefault() {
  return {
    shippingId: "",
    NameO: {
      Name: "",
      LastName: ""
    },
    AddressO: {
      Address: "",
      CP: "",
      City: "",
      State: ""
    },
    NameD: {
      Name: "",
      LastName: ""
    },
    AddressD: {
      Address: "",
      CP: "",
      City: "",
      State: ""
    },
    PriceP: "",
    PriceD: "",
    Total: "",
    Fecha: ""
  };
}

const state = shippingDefault();

const getters = {
  shippingId: () => state.shippingId,
  nameO: () => state.NameO,
  AddressO: () => state.AddressO,
  nameD: () => state.nameD,
  AddressD: () => state.AddressD,
  PriceP: () => state.PriceP,
  PriceD: () => state.PriceD,
  Total: () => state.Total,
  Fecha: () => state.Fecha
};

// actions
const actions = {
  setShippingId({ commit, state }, id) {
    commit("setShippingId", id);
    state.id = id;
  },
  setNameO({ commit, state }, name) {

    commit("setNameO", name);
    state.nameO = name;
  },
  setAddressO({ commit, state }, AddressO) {
    commit("setAddressO", AddressO);
    state.AddressO = AddressO;
  },
  setNameD({ commit, state }, NameD) {
    commit("setNameD", NameD);
    state.NameD = NameD;
  },
  setAddressD({ commit, state }, AddressD) {
    commit("setAddressD", AddressD);
    state.AddressD = AddressD;
  },
  setPriceP({ commit, state }, PriceP) {
    commit("setPriceP", PriceP);
    state.PriceP = PriceP;
  },
  setPriceD({ commit, state }, PriceD) {
    commit("setPriceD", PriceD);
    state.PriceD = PriceD;
  },
  setTotal({ commit, state }) {
    commit("setTotal");
  },
  setFecha({ commit, state }, Fecha) {
    commit("setFecha", Fecha);
    state.Fecha = Fecha;
  },
  reset({commit}){
    commit('clearData');
  },
  setShipping({commit}, shipp){
    commit('setShipping', shipp);
  }
};

// mutations
const mutations = {
  setShippingId(state, id) {
    state.id = id;
  },
  setNameO(state, name) {
    state.nameO = name
  },
  setAddressO(state, AddressO) {
    state.AddressO = AddressO;
  },
  setNameD(state,  {NameD}) {
    state.NameD = NameD;
  },
  setAddressD(state,  AddressD) {
    state.AddressD = AddressD;
  },
  setPriceP(state,  PriceP) {
    state.PriceP = PriceP;
  },
  setPriceD(state,  PriceD) {
    state.PriceD = PriceD;
  },
  setTotal(state) {
    state.Total = Number(state.PriceD) + state.PriceP;
  },
  setFecha(state,  Fecha) {
    state.Fecha = Fecha;
  },
  clearData(state){
    state.id = '';
    state.nameO = '';
    state.AddressO = '';
    state.nameD = '';
    state.AddressD = '';
    state.PriceD = '';
    state.PriceP = '';
    state.Total = '';
    state.Fecha = '';
  },
  setShipping(state, ship){
    state.value = ship
  }
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
