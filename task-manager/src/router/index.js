import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import TaskRecords from '@/components/TaskRecords'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/task-records',
      name: 'TaskRecords',
      component: TaskRecords
      //,meta: {
      //  requiresAuth: true
      //}
    },
    {
      path: '/',
      name: 'Hello',
      component: Hello
    }
  ]
})
