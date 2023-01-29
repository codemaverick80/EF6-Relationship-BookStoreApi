SELECT author_id,COUNT(author_id)
FROM book_author
group by author_id
HAVING COUNT(author_id) > 1
ORDER BY author_id ASC;