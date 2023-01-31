

create or replace function get_country()

returns setof public.country

as $$
    
select * from public.country;

$$
LANGUAGE SQL;


 -- Calling function   
select * from get_country();


--- OR return table with specific columns


create or replace function get_country_table()
returns table (
	id integer,
	name varchar(100)	
)
as $$

select id, country_name from public.country;

$$ LANGUAGE SQL;

select * from get_country_table();