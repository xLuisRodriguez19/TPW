import axios from 'axios';

const apiService = axios.create({
    baseURL: import.meta.env.VITE_API,
    timeout: 10000
});

export default apiService;