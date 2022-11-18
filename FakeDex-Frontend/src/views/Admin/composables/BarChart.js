import { defineComponent, ref, h } from 'vue';
import { Bar } from 'vue-chartjs';
import {
  Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale
} from 'chart.js';

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale);

export default defineComponent({
  name: 'BarChart',
  components: {
    Bar
  },
  props: {
    chartId: {
      type: String,
      default: 'bar-chart'
    },
    width: {
      type: Number,
      default: 400
    },
    height: {
      type: Number,
      default: 400
    },
    cssClasses: {
      default: '',
      type: String
    },
    styles: {
      type: Object,
      default: () => {}
    },
    plugins: {
      type: Object,
      default: () => {}
    }
  },
  setup(props) {
    const chartData = ref({
      labels: [],
      datasets: [
        {
          label: 'Envios',
          backgroundColor: '#F28C28',
          data: []
        }
      ]
    });
    const chartOptions = {
      responsive: true,
      maintainAspectRatio: false
    };

    return () => h(Bar, {
      chartData,
      chartOptions,
      width: props.width,
      height: props.height,
      cssClasses: props.cssClasses,
      styles: props.styles,
      plugins: props.plugins
    });
  }
});
