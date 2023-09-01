import { formatDate } from '@angular/common';
import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'event-bud-frontend';
  collapsed: boolean = false;
  eventDate: any = formatDate(new Date(), 'MMM dd, yyyy', 'en');

  constructor(private renderer: Renderer2, private elementRef: ElementRef){}
  
  ngOnInit(): void {}

  sidebarCollapsedHandler = () => {
    this.collapsed = !this.collapsed;

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
}
