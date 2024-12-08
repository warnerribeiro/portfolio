import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SubjectComponent } from './components/registers/subject/subject.component';
import { SubjectlistComponent } from './components/lists/subjectlist/subjectlist.component';
import { AuthorlistComponent } from './components/lists/authorlist/authorlist.component';
import { BooklistComponent } from './components/lists/booklist/booklist.component';
import { AuthorComponent } from './components/registers/author/author.component';
import { BookComponent } from './components/registers/book/book.component';

const routes: Routes = [
  { path: 'authorlist', component: AuthorlistComponent },
  { path: 'booklist', component: BooklistComponent },
  { path: 'subjectlist', component: SubjectlistComponent },
  { path: 'author', component: AuthorComponent },
  { path: 'author/:id', component: AuthorComponent },
  { path: 'subject', component: SubjectComponent },
  { path: 'subject/:id', component: SubjectComponent },
  { path: 'book', component: BookComponent },
  { path: 'book/:id', component: BookComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
