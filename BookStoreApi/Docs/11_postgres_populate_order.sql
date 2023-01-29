/* Add 2500 orders*/
INSERT INTO orders (order_date, customer_id, shipping_method_id, address_id)
SELECT
    (NOW() - FLOOR(RANDOM() * 365 * 3 * 24 * 60 * 60) * '1 second'::interval) AS order_date,
    c.id,
    FLOOR(1 + RANDOM() * 4) AS shipping_method_id,
    ca.address_id
FROM customers c
INNER JOIN customer_address ca ON c.id = ca.customer_id
LIMIT 2500;



/* Add more orders*/
INSERT INTO orders (order_date, customer_id, shipping_method_id, address_id)
SELECT
    (NOW() - FLOOR(RANDOM() * 365 * 3 * 24 * 60 * 60) * '1 second'::interval) AS order_date,
    c.id,
    FLOOR(1 + RANDOM() * 4) AS shipping_method_id,
    ca.address_id
FROM customers c
INNER JOIN customer_address ca ON c.id = ca.customer_id
LIMIT 1500;



INSERT INTO orders (order_date, customer_id, shipping_method_id, address_id)
SELECT
    (NOW() - FLOOR(RANDOM() * 365 * 3 * 24 * 60 * 60) * '1 second'::interval) AS order_date,
    c.id,
    FLOOR(1 + RANDOM() * 4) AS shipping_method_id,
    ca.address_id
FROM customers c
INNER JOIN customer_address ca ON c.id = ca.customer_id
LIMIT 1200;



INSERT INTO orders (order_date, customer_id, shipping_method_id, address_id)
SELECT
    (NOW() - FLOOR(RANDOM() * 365 * 3 * 24 * 60 * 60) * '1 second'::interval) AS order_date,
    c.id,
    FLOOR(1 + RANDOM() * 4) AS shipping_method_id,
    ca.address_id
FROM customers c
INNER JOIN customer_address ca ON c.id = ca.customer_id
LIMIT 900;



INSERT INTO orders (order_date, customer_id, shipping_method_id, address_id)
SELECT
    (NOW() - FLOOR(RANDOM() * 365 * 3 * 24 * 60 * 60) * '1 second'::interval) AS order_date,
    c.id,
    FLOOR(1 + RANDOM() * 4) AS shipping_method_id,
    ca.address_id
FROM customers c
INNER JOIN customer_address ca ON c.id = ca.customer_id
LIMIT 600;



INSERT INTO orders (order_date, customer_id, shipping_method_id, address_id)
SELECT
    (NOW() - FLOOR(RANDOM() * 365 * 3 * 24 * 60 * 60) * '1 second'::interval) AS order_date,
    c.id,
    FLOOR(1 + RANDOM() * 4) AS shipping_method_id,
    ca.address_id
FROM customers c
INNER JOIN customer_address ca ON c.id = ca.customer_id
LIMIT 400;



INSERT INTO orders (order_date, customer_id, shipping_method_id, address_id)
SELECT
    (NOW() - FLOOR(RANDOM() * 365 * 3 * 24 * 60 * 60) * '1 second'::interval) AS order_date,
    c.id,
    FLOOR(1 + RANDOM() * 4) AS shipping_method_id,
    ca.address_id
FROM customers c
INNER JOIN customer_address ca ON c.id = ca.customer_id
LIMIT 300;


INSERT INTO orders (order_date, customer_id, shipping_method_id, address_id)
SELECT
    (NOW() - FLOOR(RANDOM() * 365 * 3 * 24 * 60 * 60) * '1 second'::interval) AS order_date,
    c.id,
    FLOOR(1 + RANDOM() * 4) AS shipping_method_id,
    ca.address_id
FROM customers c
INNER JOIN customer_address ca ON c.id = ca.customer_id
LIMIT 100;

INSERT INTO orders (order_date, customer_id, shipping_method_id, address_id)
SELECT
    (NOW() - FLOOR(RANDOM() * 365 * 3 * 24 * 60 * 60) * '1 second'::interval) AS order_date,
    c.id,
    FLOOR(1 + RANDOM() * 4) AS shipping_method_id,
    ca.address_id
FROM customers c
INNER JOIN customer_address ca ON c.id = ca.customer_id
LIMIT 50;