import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5012/api',
});

export default api;
