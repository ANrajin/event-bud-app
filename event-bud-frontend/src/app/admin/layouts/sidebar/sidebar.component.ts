import { Component, ElementRef, EventEmitter, OnInit, Output } from '@angular/core';
import { AppRoutes } from 'src/app/app.routes';
import { AdminRoutes, SettingRoutes } from '../../admin.routes';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
  
export class SidebarComponent implements OnInit {
  collapsed: boolean = false;
  readonly appRoutes = AppRoutes;
  readonly adminRoutes = AdminRoutes;
  readonly settingRoutes = SettingRoutes;

  @Output() sidebarCollapsed = new EventEmitter<boolean>();

  constructor(private readonly elementRef: ElementRef) { }
  
  ngOnInit(): void {
  }

  sidebarCollapsedHandler = () => {
    this.collapsed = !this.collapsed;
    this.sidebarCollapsed.emit(this.collapsed);
    
    const subMenu = this.elementRef.nativeElement.querySelectorAll(".sub-menu");

    subMenu.forEach((subMenu: Element) => {
      if(subMenu.getAttribute('aria-expanded') == 'true')
        subMenu.setAttribute('aria-expanded', 'false');

      subMenu.toggleAttribute('icon-hidden');
    });
  }

  subMenuToggleHandler = (event:MouseEvent) => {
    const elem = event.target as HTMLElement;
    const subMenu = elem.closest("a.sub-menu") as Element;

    if(subMenu.getAttribute('aria-expanded') == 'false')
      subMenu.setAttribute('aria-expanded', 'true');
    else
      subMenu.setAttribute('aria-expanded', 'false');
  }

  prepareRoute(...paths: string[])
  {
    return '/' + paths.filter(Boolean).join('/');
  }
}
