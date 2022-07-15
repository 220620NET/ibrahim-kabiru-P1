create schema;
 
create schema project;

create table project.users(
users_id int identity,
username varchar(24) unique not null,
password varchar(30) not null,
user_role varchar(20) not null
primary key(users_id)
);

drop table project.users;

create table project.tickets(
tickets_id int identity,
author int foreign key references project.users(users_id),
resolver int foreign key references project.users(users_id),
description varchar(200),
status varchar(12),
amount double precision,
primary key(tickets_id)
);
drop table project.tickets;
 
select * from project.users;

insert into project.users(username, password, user_role) values ('shile', 'perg2345', 'employee');

insert into project.users(username, password, user_role) values ('chile', 'greg4325', 'manager');

