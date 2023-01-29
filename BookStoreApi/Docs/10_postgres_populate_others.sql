--select * from customers;

/*Insert all 2000 customers*/
INSERT INTO customer_address (customer_id, address_id, status_id)
SELECT c.id,
       (SELECT id
    FROM address
    WHERE c=c
    ORDER BY RANDOM()
    LIMIT 1),
    1
FROM customers c;


/*Add a second active address for 750 of those customers*/
INSERT INTO customer_address (customer_id, address_id, status_id)
SELECT customer_id, id, 1
FROM (
         SELECT ca.customer_id,
                (SELECT id
                 FROM address
                    WHERE ca=ca
                 ORDER BY RANDOM()
                 LIMIT 1) AS id
         FROM customer_address ca
         WHERE ca=ca
         ORDER BY RANDOM()

     ) sub
WHERE NOT EXISTS (
    SELECT 1
    FROM customer_address c
    WHERE c.customer_id = sub.customer_id
    AND c.address_id = sub.id
    )
LIMIT 750;


/*Add an inactive address for customers.*/
INSERT INTO customer_address (customer_id, address_id, status_id)
SELECT customer_id, id, 2
FROM (
         SELECT ca.customer_id,
                (SELECT id
                 FROM address
                WHERE ca=ca
                 ORDER BY RANDOM()
                 LIMIT 1) AS id
         FROM customer_address ca
         WHERE ca=ca
         ORDER BY RANDOM()

     ) sub
WHERE NOT EXISTS (
    SELECT 1
    FROM customer_address c
    WHERE c.customer_id = sub.customer_id
    AND c.address_id = sub.id
    )
LIMIT 400;



/*Add an active address for 200 customers.*/
INSERT INTO customer_address (customer_id, address_id, status_id)
SELECT customer_id, id, 1
FROM (
         SELECT ca.customer_id,
                (SELECT id
                 FROM address
                WHERE ca=ca
                 ORDER BY RANDOM()
                 LIMIT 1) AS id
         FROM customer_address ca
         WHERE ca=ca
         ORDER BY RANDOM()

     ) sub
WHERE NOT EXISTS (
    SELECT 1
    FROM customer_address c
    WHERE c.customer_id = sub.customer_id
    AND c.address_id = sub.id
    )
LIMIT 200;
