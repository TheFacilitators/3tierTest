DROP SCHEMA IF EXISTS stincubator CASCADE;
CREATE SCHEMA stincubator;
SET SCHEMA 'stincubator';

CREATE TABLE "users" (
  username varchar UNIQUE PRIMARY KEY ,
  password varchar(50)
);

INSERT INTO "users" VALUES('Allie', '1234');
INSERT INTO "users" VALUES('Jody', '1234');
INSERT INTO "users" VALUES('Lili', '1234');
INSERT INTO "users" VALUES('Rei', '1234');


