import { Component } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent{
  title = 'event-bud-frontend';
  collapsed: boolean = false;

  constructor() { }
  
  onSidebarCollapsed(data: boolean)
  {
    this.collapsed = data;
  }
}
