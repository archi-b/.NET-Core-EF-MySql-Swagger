﻿CREATE TABLE IF NOT EXISTS `dbloja`.`tableUsuario` (
  `IDUsuario` INT(11) NOT NULL AUTO_INCREMENT,
  `Email` VARCHAR(100) NULL DEFAULT NULL,
  `Login` VARCHAR(50) NOT NULL,
  `Senha` VARCHAR(50) NOT NULL,
  `Cpf` VARCHAR(14) NULL DEFAULT NULL,
  PRIMARY KEY (`IDUsuario`),
  UNIQUE INDEX `Login_UNIQUE` (`Login` ASC),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;