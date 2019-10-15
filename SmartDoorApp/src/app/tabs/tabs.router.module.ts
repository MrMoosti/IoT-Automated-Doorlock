import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TabsPage } from './tabs.page';

const routes: Routes = [
  {
    path: 'tabs',
    component: TabsPage,
    children: [
      {
        path: 'logs',
        children: [
          {
            path: '',
            loadChildren: () =>
              import('../logs/logs.module').then(m => m.LogsPageModule)
          }
        ]
      },
      {
        path: 'door-state',
        children: [
          {
            path: '',
            loadChildren: () =>
              import('../door-state/door-state.module').then(m => m.DoorStatePageModule)
          }
        ]
      },
      {
        path: 'cpu-temp',
        children: [
          {
            path: '',
            loadChildren: () =>
              import('../cpu-temp/cpu-temp.module').then(m => m.CpuTempPageModule)
          }
        ]
      },
      {
        path: '',
        redirectTo: '/tabs/door-state',
        pathMatch: 'full'
      }
    ]
  },
  {
    path: '',
    redirectTo: '/tabs/door-state',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TabsPageRoutingModule {}
