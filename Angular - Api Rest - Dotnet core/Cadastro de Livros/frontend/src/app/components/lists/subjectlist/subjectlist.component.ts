import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'src/app/interfaces/subject';
import { SubjectService } from 'src/app/services/subject.service';

@Component({
  selector: 'app-subjectlist',
  templateUrl: './subjectlist.component.html',
  styleUrls: ['./subjectlist.component.css'],
})
export class SubjectlistComponent {
  public loading!: boolean;
  public assuntos!: Subject[];
  /**
   *
   */
  constructor(
    private readonly subjectService: SubjectService,
    private readonly router: Router
  ) {}

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.loading = true;
    console.time('GetAll Subjects');
    this.subjectService.getAll().subscribe({
      next: (response: Subject[]) => {
        this.assuntos = response;
      },
      error: (error) => {
        console.log('GetAll Subjects Error ==>', error);
      },
      complete: () => {
        this.loading = false;
        console.table(this.assuntos);
        console.timeEnd('GetAll Subjects');
      },
    });
  }

  delete(subject: Subject) {
    this.subjectService.delete(subject.subjectId).subscribe({
      next: (response: Subject[]) => {
        console.log('delete===>', response);
      },
      error: (error) => {
        console.log('delteerror===>', error);
      },
      complete: () => {
        this.getList();
      },
    });
  }

  update(subject: Subject) {
    this.router.navigateByUrl('/subject/' + subject.subjectId);
  }
}
