import { BookValue } from "./bookvalue";

export interface Book {
    bookId: number;
    title: string;
    publisher: string;
    edition: number;
    yearOfPublication: string;
    bookAuthor: {authorId: number, bookId: number}[];
    bookSubject: {subjectId: number, bookId: number}[];
    bookValue: BookValue[];
}