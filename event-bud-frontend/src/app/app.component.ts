import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'event-bud-frontend';
  collapsed: boolean = false;

  constructor(private renderer: Renderer2, private elementRef: ElementRef){}
  
  ngOnInit(): void {}

  sidebarCollapsedHandler = () => {
    this.collapsed = !this.collapsed;

    const subMenuItems = this.elementRef.nativeElement.querySelectorAll(".sub-menu-item");
    const subMenuIcons = this.elementRef.nativeElement.querySelectorAll(".sub-menu-icon");

    if (this.collapsed) {
      subMenuItems.forEach((subMenuItem:Element) => {
        this.renderer.addClass(subMenuItem, '!max-h-0');
      });

      subMenuIcons.forEach((subMenuIcon:Element) => {
        this.renderer.addClass(subMenuIcon, '!hidden');
      });
    }
    else
    {
      subMenuItems.forEach((subMenuItem:Element) => {
        this.renderer.removeClass(subMenuItem, '!max-h-0');
      });

      subMenuIcons.forEach((subMenuIcon:Element) => {
        this.renderer.removeClass(subMenuIcon, '!hidden');
      });
    }
  }

  subMenuToggleHandler = (event:MouseEvent) => {
    const elem = event.target as HTMLElement;
    const targetElem = elem.closest("a.sub-menu")?.nextSibling as Element;
    const arrow = elem.closest("a.sub-menu")?.children[1].children[0] as Element;

    if (targetElem && targetElem?.classList.contains("max-h-0"))
    {
      this.renderer.addClass(targetElem, "max-h-96");
      this.renderer.removeClass(targetElem, "max-h-0");
    }
    else
    {
      this.renderer.addClass(targetElem, "max-h-0");
      this.renderer.removeClass(targetElem, "max-h-96");
    }

    if (arrow && arrow.classList.contains("!rotate-180")) this.renderer.removeClass(arrow, "!rotate-180");
    else this.renderer.addClass(arrow, "!rotate-180");
  }
}
