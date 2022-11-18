import { ref } from 'vue';
import { useApi } from '@/composables/useApi';

/* eslint-disable no-param-reassign */
// eslint-disable-next-line
export function getData() {
  const chartData = ref({
    labels: [],
    datasets: [
      {
        label: '',
        backgroundColor: '#F28C28',
        data: []
      }
    ]
  });
  const Horas = async () => {
    const { get } = useApi();
    const info = ref([]);
    const d = ref([]);
    const result = await get('/api/Shippings/charts');
    if (!result.success) {
      console.log('hola');
    } else {
      chartData.value.labels = [];
      chartData.value.datasets = [];
      info.value = result.data;
      info.value.forEach((element) => {
            console.log(element);
            chartData.value.labels.push(new Date(element.fecha).toLocaleDateString());
            d.value.push(element.shippings);
      });
      chartData.value.datasets = [{
        label: 'Envíos',
        backgroundColor: '#F28C28',
        data: d.value
      }];
    }
  };

  return {
    Horas,
    chartData
  };
}