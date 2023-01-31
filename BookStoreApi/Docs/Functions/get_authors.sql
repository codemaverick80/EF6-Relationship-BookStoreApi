CREATE OR REPLACE FUNCTION public.get_authors()
    RETURNS TABLE
    (
    id integer, 
    author_name character varying, 
    book_id integer, 
    book_title character varying, 
    num_pages integer, 
    publication_date date, 
    isbn character varying
    ) 
LANGUAGE 'plpgsql'
AS $BODY$
#variable_conflict use_column
begin
return query
SELECT
    author.id as id,
    author.author_name,
    book_auth_link.book_id,
    book_auth_link.title,
    book_auth_link.num_pages,
    book_auth_link.publication_date,
    book_auth_link.isbn
FROM (
         SELECT id,author_name FROM authors WHERE NOT (is_deleted) LIMIT 10
     ) AS author
         LEFT JOIN (
    SELECT book.id as book_id, book.title, book.num_pages, book.publication_date, book.isbn, ba.author_id
    FROM book_author AS ba
             INNER JOIN (
        SELECT id, title, num_pages, publication_date, isbn FROM books WHERE NOT (is_deleted)
    ) AS book ON ba.book_id = book.id
    WHERE NOT (ba.is_deleted)
) AS book_auth_link ON author.id = book_auth_link.author_id
ORDER BY author.id, book_auth_link.author_id, book_auth_link.book_id;
end;
$BODY$;


    --- OR
CREATE OR REPLACE FUNCTION public.get_authors()
    RETURNS TABLE
	(
		id integer, 
		author_name character varying, 
		book_id integer, 
		book_title character varying, 
		num_pages integer, 
		publication_date date, 
		isbn character varying
	)

AS $$
#variable_conflict use_column

BEGIN
return query
SELECT
    author.id as id,
    author.author_name,
    book_auth_link.book_id,
    book_auth_link.title,
    book_auth_link.num_pages,
    book_auth_link.publication_date,
    book_auth_link.isbn
FROM (
         SELECT id,author_name FROM authors WHERE NOT (is_deleted) LIMIT 10
     ) AS author
         LEFT JOIN (
    SELECT book.id as book_id, book.title, book.num_pages, book.publication_date, book.isbn, ba.author_id
    FROM book_author AS ba
             INNER JOIN (
        SELECT id, title, num_pages, publication_date, isbn FROM books WHERE NOT (is_deleted)
    ) AS book ON ba.book_id = book.id
    WHERE NOT (ba.is_deleted)
) AS book_auth_link ON author.id = book_auth_link.author_id
ORDER BY author.id, book_auth_link.author_id, book_auth_link.book_id;
END;
$$ LANGUAGE 'plpgsql';
    
--- How to call function

select * FROM public.get_authors();

select public.get_authors();