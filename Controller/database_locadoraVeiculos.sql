drop database if exists locadora_veiculos;
create database locadora_veiculos;

use locadora_veiculos;
create table if not exists clientes(
/* ulong C# format ---> decimal(20, 0)
    uint C# format ---> bigint */
id_cli bigint AUTO_INCREMENT PRIMARY KEY,
cpf varchar(11) UNIQUE NOT NULL,
nome text NOT NULL,
cnh varchar(11) UNIQUE NOT NULL,
num_tel decimal(20, 0) UNIQUE NOT NULL,
email varchar(77) UNIQUE NOT NULL,
logradouro text NOT NULL,
numero bigint NOT NULL,
complemento varchar(15)
);

use locadora_veiculos;
create table if not exists veiculos(
id_veiculo int AUTO_INCREMENT PRIMARY KEY,
placa varchar(7) UNIQUE NOT NULL,
cidade_registro text NOT NULL,
placa_mercosul boolean NOT NULL,
modelo varchar(15) NOT NULL,
marca varchar(15) NOT NULL,
cor varchar(20) NOT NULL,
ano int NOT NULL,
status_veiculo text NOT NULL
);

use locadora_veiculos;
create table locacoes(
id_locacao int AUTO_INCREMENT PRIMARY KEY,
cpf varchar(11) UNIQUE NOT NULL,
placa varchar(7) UNIQUE NOT NULL,
valor_locacao double NOT NULL,
data_retirada datetime,
data_entrega datetime
);

ALTER TABLE locacoes ADD FOREIGN KEY (cpf) REFERENCES clientes(cpf);
ALTER TABLE locacoes ADD FOREIGN KEY (placa) REFERENCES veiculos(placa);


INSERT INTO clientes(id_cli, cpf, nome, cnh, num_tel, email, logradouro, numero, complemento) VALUES
(1, '11111111111', 'Roberto', '22222222222', 1199999999, 'robert@email.com','Rua Ubarla', 253, ''),
(2, '22222222222', 'Joana', '51515151515', 1485023695,  'joanaDark@email.com','Rua Paris', 4124, ''),
(3, '33333333333', 'Luis', '686895369165', 1265782395,  'luisinho@email.com','Avenida Oute', 42, ''),
(4, '44444444444', 'Camila', '24863517523', 1654725846,  'camilaEmail@email.com','Rua Lot', 6, ''),
(5, '55555555555', 'Ruan', '15398263458', 1248635214,  'ruanEmail@email.com','Avenida Jok', 64536, '');

INSERT INTO veiculos(id_veiculo, placa, cidade_registro, placa_mercosul, modelo, marca, cor, ano, status_veiculo) VALUES
(1, 'GAS6158', 'Araraquara', '0','HB20 1.6 Confort', 'Hyundai','Azul', '2014', 'Disponivel'),
(2, 'SAD5613', 'São Paulo', '0','PRISMA 1.0 ECO JOY', 'Preto', 'Chevrolet', '2019', 'Disponivel'),
(3, 'BCD3456', 'Campinas', '0', 'GOL 1.6 MSI', 'Volkswagen', 'Vermelho', '2017','Disponivel'),
(4, 'QTP5F71', 'Brasil', '1', 'GOL 1.6 MSI', 'Volkswagen', 'Preto', '2019','Disponivel'),
(5, 'CXZ7B41', 'Brasil', '1', 'HB20 1.0', 'Hyundai', 'Cinza', '2021','Disponivel');

INSERT INTO locacoes(id_locacao, cpf, placa, valor_locacao, data_retirada, data_entrega) VALUES 
(1, '11111111111',  'CXZ7B41', '25.6', '2020/05/05', '2020/06/05'),
(2, '22222222222', 'QTP5F71', '30', '2020/03/15', '2020/05/15'),
(3, '33333333333', 'BCD3456', '10', '2020/02/08', '2020/05/08'),
(4, '44444444444', 'SAD5613', '85', '2020/05/03', '2020/09/03'),
(5, '55555555555', 'GAS6158', '63.5', '2020/10/11', '2021/01/11');

