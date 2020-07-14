import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('../views/Home.vue')
  },
  {
    path: '/novapessoa',
    name: 'NovaPessoa',
    component: () => import('../views/NovaPessoa.vue')
  },
  {
    path: '/editarpessoa/:id',
    name: 'Editaressoa',
    component: () => import('../views/EditarPessoa.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
