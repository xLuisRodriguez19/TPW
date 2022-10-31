import { createRouter, createWebHistory } from "vue-router";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      component: () => import('../views/Layout.vue'),
      children: [{
        path: '',
        name: "Landing",
        component: () => import('../views/Landing.vue')
      },
      {
        path: '/envios',
        name: "Envios",
        component: () => import('../views/Envios/Envios.vue')
      },
      {
        path: '/rastreo',
        name: "Rastreo",
        component: () => import('../views/Rastreo/Rastreo.vue')
      },
      {
        path: '/contact',
        name: "Contacto",
        component: () => import('../views/Contact/Contact.vue')
      },
      {
        path: '/sucursales',
        name: "Sucursales",
        component: () => import('../views/Sucursales/Sucursales.vue')
      },
      {
        path: '/login',
        name: "Login",
        component: () => import('../views/Login/Login.vue')
      },
      {
        path: '/user',
        name: "Profile",
        component: () => import('../views/Perfil/Perfil.vue')
      }
    ]
    }
  ],
});

export default router;
