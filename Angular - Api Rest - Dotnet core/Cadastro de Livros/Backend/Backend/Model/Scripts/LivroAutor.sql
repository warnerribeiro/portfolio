CREATE OR ALTER VIEW LivroAutores
AS
SELECT DISTINCT
	au.Nome,
	l.Titulo,
	l.Editora,
	l.Edicao,
	l.AnoPublicacao,
	ass.Descricao
FROM 
	Autor au
		inner join LivroAutor lau on au.AutorId = lau.AutorId
		inner join Livro l on lau.LivroId = l.LivroId
		inner join LivroAssunto las on las.LivroId = las.LivroId
		inner join Assunto ass on las.AssuntoId = ass.AssuntoId