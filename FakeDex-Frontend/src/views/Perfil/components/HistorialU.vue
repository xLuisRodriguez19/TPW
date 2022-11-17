<template>
    <div class="overflow-x-auto w-auto shadow-md sm:rounded-lg" v-if="!hasError">
      <table class="w-auto text-sm text-left text-purple-500">
        <thead class="text-xs text-purple-700 uppercase bg-gray-100">
          <tr>
            <th scope="col" class="py-3">No. Seguimiento</th>
            <th scope="col" class="py-3 px-6">Origen</th>
          <th scope="col" class="py-3 px-6">Destino</th>
          <th scope="col" class="py-3 px-6">Status</th>
        </tr>
      </thead>
      <tbody>
        <tr class="bg-white border-b" v-for="t of id" :key="t">
          <th
            scope="row"
            class="text-center py-4 font-medium text-purple-900 whitespace-nowrap"
          >
            {{ t.id }}
          </th>
          <th
            scope="row"
            class="truncate py-4 px-6 font-medium text-purple-900 whitespace-nowrap "
          >
            {{ t.addressO }}
          </th>
          <th
            scope="row"
            class="truncate py-4 px-3 font-medium text-purple-900 whitespace-nowrap "
          >
            {{ t.addressD }}
          </th>
          <th
            scope="row"
            class="truncate py-4 px-3  font-medium text-purple-900 whitespace-nowrap"
          >
            {{ Status[t.status] }}
          </th>
        </tr>
        </tbody>
      </table>
    </div>
    <div v-else>
        <h1 class="text-3xl text-black">No hay nada para mostrar :C</h1>
    </div>
  </template>
  <script>
  import { getShippingUser } from '../../Envios/composables/useShipping';
  import { Status } from '@/utils/constants';

  export default {
    setup() {
        const { searchShippingById, id, hasError } = getShippingUser();
        searchShippingById();
        return{
            searchShippingById,
            id,
            hasError,
            Status
        }
    }
  };
  </script>
  