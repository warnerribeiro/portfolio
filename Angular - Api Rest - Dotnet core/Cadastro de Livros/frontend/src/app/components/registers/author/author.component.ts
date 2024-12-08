import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Author } from 'src/app/interfaces/author';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent {
  public autor!: Author;
  private id!: number;

  private readonly formBuilder = inject(FormBuilder);
  private readonly authorService = inject(AuthorService);
  private readonly route = inject(ActivatedRoute);
  private readonly router = inject(Router);

  protected form = this.formBuilder.group(
    {
      name: this.formBuilder.control('', {
        validators: [Validators.required],
        nonNullable: true
      }),
    }
  );

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (id) {
      this.authorService.get(id).subscribe({
        next: (response: Author) => {
          this.form.get('name')?.setValue(response.name);
          this.id = response.authorId;
        },
        error: (error) => {
          console.log('Error getting the author!', error);
        },
        complete: () => { }
      });
    }
  }

  onSubmit() {
    const author: Author = {
      authorId: this.id ?? 0,
      name: this.form.value.name ?? ""
    }

    if (this.id) {
      this.update(author);
    } else {
      this.add(author);
    }
  }

  add(author: Author) {
    this.authorService.post(author).subscribe({
      next: (response: Author) => {
        console.log('Author saved!', response);
        this.autor = response;
        this.router.navigateByUrl("/authorlist")
      },
      error: (error) => {
        console.log('Error saving the author!', error);
      },
      complete: () => { }
    });
  }

  update(author: Author) {
    this.authorService.put(this.id, author).subscribe({
      next: (response: Author) => {
        console.log('Author updated!', response);
        this.autor = response;
        this.router.navigateByUrl("/authorlist")
      },
      error: (error: any) => {
        console.log('Error updating the author!', error);
      },
      complete: () => { }
    });
  }
}
