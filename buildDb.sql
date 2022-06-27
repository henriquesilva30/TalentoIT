create table users (
                       "id_user" serial constraint id_user primary key,
                       email varchar(100) not null,
                       pass varchar(100) not null,
                       nome_user varchar(100),
                       tipo_user VARCHAR(100) not null,
                       media_horas FLOAT,
                       morada VARCHAR(100),
                       nif VARCHAR(100)
);

alter table users owner to postgres;

create table clientes (
                       "id_cliente" serial constraint id_cliente primary key,
                       nome varchar(100) not null,
                       nif varchar(100) not null,
                       email varchar(100) not null
);

alter table clientes owner to postgres;

create table skills (
                        "id_skill" serial constraint id_skill primary key,
                        nome_skill varchar(100) not null,
                        area varchar(100) not null
);

alter table skills owner to postgres;

create table proposta (
                          "id_proposta" serial constraint id_proposta primary key,
                          nome_proposta varchar(100) not null,
                          tipo_talento varchar(100) not null,
                          expr_minima varchar(100) not null,
                          total_horas varchar(100) not null,
                          descricao varchar(100) not null,
                          "id_user" integer constraint id_user_fk references users on delete cascade
);

alter table proposta owner to postgres;

create table perfil_talento (
                                "id_perfil_talento" serial constraint id_perfil_talento primary key,
                                nome_talento varchar(100) not null,
                                preco_hora varchar(100) not null,
                                email varchar(100) not null,
                                flag varchar(100) not null
);

alter table perfil_talento owner to postgres;

create table proposta_user (
                               "id_proposta_user" serial constraint id_proposta_user primary key,
                               "id_user" integer constraint id_user_fk references users on delete cascade,
                               "id_proposta" integer constraint id_proposta_fk references proposta on delete cascade
);

alter table proposta_user owner to postgres;

create table proposta_skill (
                                "id_proposta_skill" serial constraint id_proposta_skill primary key,
                                "id_skill" integer constraint id_skill_fk references skills on delete cascade,
                                "id_proposta" integer constraint id_proposta_fk references proposta on delete cascade
);

alter table proposta_skill owner to postgres;

create table user_skill (
                            "id_user_skill" serial constraint id_user_skill primary key,
                            "id_skill" integer constraint id_skill_fk references skills,
                            "id_user" integer constraint id_user_fk references users
);

alter table user_skill owner to postgres;

create table talento_skill (
                               "id_talento_skill" serial constraint id_talento_skill primary key,
                               "id_skill" integer constraint id_skill_fk references skills,
                               "id_perfil_talento" integer constraint id_perfil_talento_fk references perfil_talento
);

alter table talento_skill owner to postgres;

create table perfil_detalhe (
                                "id_perfil_detalhe" serial constraint id_perfil_detalhe primary key,
                                titulo_exp varchar(100) not null,
                                nome_empresa varchar(100) not null,
                                ano_inico varchar(100) not null,
                                ano_fim varchar(100) not null,
                                "id_perfil_talento" integer constraint id_perfil_talento_fk references perfil_talento
);

alter table talento_skill owner to postgres;

INSERT INTO users (email, pass, nome_user, tipo_user, morada, nif)
VALUES ('email','pass','nome','tipo','morada','nif');



DELETE FROM users
WHERE email='email';  

