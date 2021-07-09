-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           5.7.31 - MySQL Community Server (GPL)
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              11.1.0.6116
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para padaria_linguagens
CREATE DATABASE IF NOT EXISTS `padaria_linguagens` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `padaria_linguagens`;

-- Copiando estrutura para tabela padaria_linguagens.clientes
CREATE TABLE IF NOT EXISTS `clientes` (
  `cpf` varchar(14) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `endereco` varchar(99) NOT NULL,
  `telefone` varchar(15) NOT NULL,
  PRIMARY KEY (`cpf`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Copiando dados para a tabela padaria_linguagens.clientes: ~7 rows (aproximadamente)
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
REPLACE INTO `clientes` (`cpf`, `nome`, `endereco`, `telefone`) VALUES
	('127.008.970-64', 'Gabriel Barbosa', 'Rua Lenda', '3822-9999'),
	('253.854.171-90', 'Maria Joaquina', 'Rua Bartolomeu', '9999-5234'),
	('531.936.866-62', 'Helena Santos', 'Rua Sorocaba', '7777-7777'),
	('601.355.198-70', 'Julesca Santos', 'Rua AWDWA', '1234-4567'),
	('628.012.933-00', 'Josualdo Silva', 'Rua Batman', '9555-4521'),
	('725.758.484-23', 'Cirilo Paiva', 'Rua Dois', '8888-8888');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;

-- Copiando estrutura para procedure padaria_linguagens.deletaCliente
DELIMITER //
CREATE PROCEDURE `deletaCliente`(cpfRem varchar(15))
BEGIN
DELETE FROM `padaria_linguagens`.`clientes`
    WHERE cpf = cpfRem;
COMMIT;

END//
DELIMITER ;

-- Copiando estrutura para procedure padaria_linguagens.insereCliente
DELIMITER //
CREATE PROCEDURE `insereCliente`(cpf varchar(15), nome varchar(45), endereco varchar(99), telefone varchar(15))
BEGIN
INSERT INTO `padaria_linguagens`.`clientes`
(`cpf`,
`nome`,
`endereco`,
`telefone`)
VALUES
(cpf,
nome,
endereco,
telefone);

END//
DELIMITER ;

-- Copiando estrutura para procedure padaria_linguagens.listaClientes
DELIMITER //
CREATE PROCEDURE `listaClientes`()
BEGIN
select * from clientes;
END//
DELIMITER ;

-- Copiando estrutura para procedure padaria_linguagens.updateCliente
DELIMITER //
CREATE PROCEDURE `updateCliente`(nome varchar(45), endereco varchar(99), telefone varchar(15), id varchar(15))
BEGIN
UPDATE `padaria_linguagens`.`clientes`
SET
`cpf` = cpf,
`nome` = nome,
`endereco` = endereco,
`telefone` = telefone
WHERE `cpf` = id;

END//
DELIMITER ;

-- Copiando estrutura para tabela padaria_linguagens.usuarios
CREATE TABLE IF NOT EXISTS `usuarios` (
  `idusuario` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `senha` varchar(100) NOT NULL,
  PRIMARY KEY (`idusuario`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- Copiando dados para a tabela padaria_linguagens.usuarios: 1 rows
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
REPLACE INTO `usuarios` (`idusuario`, `nome`, `senha`) VALUES
	(1, 'adm', 'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3'),
	(2, 'marcelo', 'b3a8e0e1f9ab1bfe3a36f231f676f78bb30a519d2b21e6c530c0eee8ebb4a5d0'),
	(3, 'Juquinha', '8d23cf6c86e834a7aa6eded54c26ce2bb2e74903538c61bdd5d2197997ab2f72'),
	(4, 'Maria', 'c7e616822f366fb1b5e0756af498cc11d2c0862edcb32ca65882f622ff39de1b'),
	(5, 'Joao', '5e968ce47ce4a17e3823c29332a39d049a8d0afb08d157eb6224625f92671a51'),
	(6, 'Leo', '9a72c24f2fd76561729110d804c69f38a7088f2ec41fdf8fbfea20d07e8bcff8'),
	(7, 'Jorge', '9b871512327c09ce91dd649b3f96a63b7408ef267c8cc5710114e629730cb61f');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
