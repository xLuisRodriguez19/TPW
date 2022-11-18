<template>
    <div class="mt-20 flex flex-col w-full items-center justify-center h-96 ">
      <div class="flex">
        <h1 class="text-black text-3xl">Estádisticas de pedidos</h1>
      </div>
      <div class="mt-20 flex w-full items-center justify-center">
        <div>
        <bar-chart
            :chart-options="chartOptions"
            :chart-data="chartData"
        />
        </div>
    </div>
    </div>
</template>
<script>
import BarChart from '../Admin/composables/BarChart';
import { getData } from '../Admin/composables/useChart';

export default {
  name: 'Chart',
  components: {
    BarChart
  },
  setup() {
    const chartOptions = {
      responsive: true,
      maintainAspectRatio: false
    };
    const { Horas,
    chartData } = getData();

    Horas();
    return{
        Horas,
        chartData,
        chartOptions
    }
  }
};
</script>
