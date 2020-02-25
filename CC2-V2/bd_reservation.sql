create database CC2_V2
use CC2_V2
create table Clients
(
CodeClient int primary key,
Nom varchar(50),
Prenom varchar(50),
Adresse varchar(50),
Ville varchar(50),
CP varchar(50),
Pays varchar(50),
Tel varchar(50),
Email varchar(50)
)

create table Categories
(
CodeCategorie int primary key,
Description varchar(220),
)
drop table Categorie
create table Classes
(
CodeClasse int primary key,
NbreEtoiles int
)
create table Tarifer
(
CodeCategorie int foreign key references Categories(CodeCategorie),
CodeClasse  int foreign key references Classes(CodeClasse ),
constraint pk primary key(CodeCategorie,CodeClasse)
)
create table Hotels
(
NHotel int primary key,
NomH varchar(50),
AdresseH varchar(50),
CPH varchar(50),
TelH varchar(50),
CodeClasse  int foreign key references Classes(CodeClasse)
)
drop table Chambres
create table Chambres
(
NChambre int primary key,
TelH varchar(50),
CodeCategorie int foreign key references Categories(CodeCategorie),
NHotel  int foreign key references Hotels(NHotel)
)
create table Reservations
(
NReservation int primary key,
DateDebut Date,
DateFin Date,
DatePaye Date,
Montant float,
NChambre int foreign key references Chambres(NChambre),
CodeClient int foreign key references Clients(CodeClient)
)
create table Consommations
(
NConsommation int primary key,
DateConsommation Date,
HeureConsommation int,
CodeClient int foreign key references Clients(CodeClient)
)

create table Prestations
(
CodePrestation int primary key,
DesignationPres varchar(220)
)

create table Offre
(
PrixPrestation float,
CodePrestation int foreign key references Prestations(CodePrestation),
NHotel  int foreign key references Hotels(NHotel),
constraint pk1 primary key(CodePrestation,NHotel)
)
create table Concerner
(
CodePrestation int foreign key references Prestations(CodePrestation),
NHotel  int foreign key references Hotels(NHotel),
constraint pk2 primary key(NHotel,CodePrestation)
)

insert into Clients values(1,'Mehdi','Taher','Derb Sultan','casa','Stagiaire','Casablanca','06xxxxxxxx','mehdi@gmail.com')
insert into Clients values(2,'Amina','Taher','Derb Sultan','casa','Stagiaire','Casablanca','06xxxxxxxx','mehdi@gmail.com')
insert into Clients values(3,'Ali','Taher','Derb Sultan','casa','Stagiaire','Casablanca','06xxxxxxxx','mehdi@gmail.com')

insert into Chambres values(100,'05xxxxxxxx',400,200)
insert into Chambres values(101,'05xxxxxxxx',401,201)

insert into Hotels values(200,'Marina','Centre Ville','Hotel','05xxxxxxxx',300)
insert into Hotels values(201,'Allal','Centre Ville','Hotel','05xxxxxxxx',301)

insert into Classes values(300,5)
insert into Classes values(301,2)

insert into Categories values(400,'Très Bon!')
insert into Categories values(401,'Mauvais!')

delete Chambres