import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Author } from 'src/app/interfaces/author';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-authorlist',
  templateUrl: './authorlist.component.html',
  styleUrls: ['./authorlist.component.css'],
})
export class AuthorlistComponent {
  public loading!: boolean;
  public autor!: Author[];
  /**
   *
   */
  constructor(
    private readonly authorService: AuthorService,
    private readonly router: Router
  ) {}

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.loading = true;
    console.time('GetAll Author');
    this.authorService.getAll().subscribe({
      next: (response: Author[]) => {
        this.autor = response;
      },
      error: (error) => {
        console.log('GetAll Authors Error ==>', error);
      },
      complete: () => {
        this.loading = false;
        console.table(this.autor);
        console.timeEnd('GetAll Author');
      },
    });
  }

  delete(id: number) {
    this.authorService.delete(id).subscribe({
      next: (response: Author[]) => {
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

  update(id: number) {
    this.router.navigateByUrl('/author/' + id);
  }
}
