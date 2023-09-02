import { formatDate } from '@angular/common';
import { Component, ElementRef, OnInit, Renderer2 } from '@angular/core';
import { Chart, registerables } from 'chart.js';
Chart.register(...registerables);

import { CalendarOptions } from '@fullcalendar/core'; // useful for typechecking
import dayGridPlugin from '@fullcalendar/daygrid';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'event-bud-frontend';
  collapsed: boolean = false;
  eventDate: any = formatDate(new Date(), 'MMM dd, yyyy', 'en');

  calendarOptions: CalendarOptions = {
    initialView: 'dayGridMonth',
    plugins: [dayGridPlugin]
  };

  constructor(private renderer: Renderer2, private elementRef: ElementRef){}
  
  ngOnInit(): void {
    var myChart = new Chart("areaWiseSale", {
      type: 'doughnut',
      data: {
          labels: ['Red', 'Blue', 'Yellow', 'Green'],
          datasets: [{
              label: '# of Votes',
              data: [12, 19, 3, 5],
              backgroundColor: [
                  'rgba(255, 99, 132, 0.2)',
                  'rgba(54, 162, 235, 0.2)',
                  'rgba(255, 206, 86, 0.2)',
                  'rgba(75, 192, 192, 0.2)',
              ],
          }]
      },
      options: {
        scales: {
          x: {
            display: false
          },
          y: {
            display: false
          },
        },
        plugins: {
          legend: {
            position: 'right',
            align: 'center',
          },
        },
      },
    });
  }

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
