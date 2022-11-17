<template>
    <div class="overflow-x-auto w-full shadow-md sm:rounded-lg m-5">
      <table class="w-full text-sm text-left text-purple-500">
        <thead
          class="text-xs text-purple-700 uppercase bg-gray-100"
        >
          <tr>
            <th scope="col" class="py-3 px-6">Origen</th>
            <th scope="col" class="py-3 px-6">Envía</th>
            <th scope="col" class="py-3 px-6">Destino</th>
            <th scope="col" class="py-3 px-6">Recibe</th>
            <th scope="col" class="py-3 px-6"></th>
          </tr>
        </thead>
        <tbody>
          <tr class="bg-white border-b">
            <th
              scope="row"
              class="py-4 px-6 font-medium text-purple-900 whitespace-nowrap"
            >
              {{id}}
            </th>
            <td class="py-4 px-6">{{nameO}}</td>
            <td class="py-4 px-6">{{addressD}}</td>
            <td class="py-4 px-6">{{nameD}}</td>
            <td class="py-4 px-6">
              <a
                href="#"
                class="font-medium text-orange-600 hover:underline"
                >Ver</a
              >
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </template>
  <script>
  
  export default {
    props:{
        id: Object
    },
    setup(props){
      console.log(props.id);
    }
  }
  </script>