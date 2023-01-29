
/* Select batch of records, random book and random price between 0 and 20.*/
SELECT
    o.id,
   (SELECT id
     FROM books
        WHERE o=o
     ORDER BY RANDOM()
     LIMIT 1) AS id,
    ROUND(CAST(RANDOM() * 20 AS numeric), 2) AS price
FROM orders o;

SELECT
    o.id,
    FLOOR(RANDOM() * 11127) AS id,
    ROUND(CAST(RANDOM() * 20 AS numeric), 2) AS price
FROM orders o;



/* Add a line for all orders*/

INSERT INTO order_line (order_id, book_id, price)
SELECT
    o.id,
    FLOOR(RANDOM() * 11127) AS book_id,
    ROUND(CAST(RANDOM() * 20 AS numeric), 2) AS price
FROM orders o;



/* Add a line for some orders*/

INSERT INTO order_line (order_id, book_id, price)
SELECT
    o.id,
    FLOOR(RANDOM() * 11127) AS book_id,
    ROUND(CAST(RANDOM() * 20 AS numeric), 2) AS price
FROM orders o
ORDER BY RANDOM()
LIMIT 4000;



INSERT INTO order_line (order_id, book_id, price)
SELECT
    o.id,
    FLOOR(RANDOM() * 11127) AS book_id,
    ROUND(CAST(RANDOM() * 20 AS numeric), 2) AS price
FROM orders o
ORDER BY RANDOM()
LIMIT 2000;


INSERT INTO order_line (order_id, book_id, price)
SELECT
    o.id,
    FLOOR(RANDOM() * 11127) AS book_id,
    ROUND(CAST(RANDOM() * 20 AS numeric), 2) AS price
FROM orders o
ORDER BY RANDOM()
LIMIT 1000;


INSERT INTO order_line (order_id, book_id, price)
SELECT
    o.id,
    FLOOR(RANDOM() * 11127) AS book_id,
    ROUND(CAST(RANDOM() * 20 AS numeric), 2) AS price
FROM orders o
ORDER BY RANDOM()
LIMIT 300;


INSERT INTO order_line (order_id, book_id, price)
SELECT
    o.id,
    FLOOR(RANDOM() * 11127) AS book_id,
    ROUND(CAST(RANDOM() * 20 AS numeric), 2) AS price
FROM orders o
ORDER BY RANDOM()
LIMIT 500;


INSERT INTO order_line (order_id, book_id, price)
SELECT
    o.id,
    FLOOR(RANDOM() * 11127) AS book_id,
    ROUND(CAST(RANDOM() * 20 AS numeric), 2) AS price
FROM orders o
ORDER BY RANDOM()
LIMIT 50;