create table Objeto (
    cdobjeto varchar(7) not null,
    deobjeto varchar(32) not null,
    constraint objeto_pk primary key (cdobjeto)
);

create table Etiqueta (
    id int not null,
    deetiqueta varchar(32) not null,
    constraint etiqueta_pk primary key (id)
);

create table ObjetoEtiqueta (
    cdobjeto varchar(7) not null,
    idetiqueta int not null,
    constraint objeto_etiqueta_pk primary key (cdobjeto, idetiqueta),
    constraint objeto_fk foreign key (cdobjeto) references Objeto (cdobjeto),
    constraint etiqueta_fk foreign key (idetiqueta) references Etiqueta (id)
);

insert into Objeto values ('OBJ0001', 'Intimação ABC123');
insert into Objeto values ('OBJ0002', 'Intimação DEF456');

insert into Etiqueta values (1, 'Etiqueta verde');
insert into Etiqueta values (2, 'Etiqueta amarela');

insert into ObjetoEtiqueta values ('OBJ0001', 1);
insert into ObjetoEtiqueta values ('OBJ0002', 1);
insert into ObjetoEtiqueta values ('OBJ0002', 2);