CREATE TABLE `MyGameDB` (
`id` INT( 10 ) NOT NULL AUTO_INCREMENT PRIMARY KEY ,
`name` VARCHAR( 30 ) NOT NULL ,
`password` VARCHAR( 50 ) NOT NULL,
`kills` INT( 11 ) NOT NULL,
`deaths` INT( 11 )NOT NULL,
`score` INT( 11 )NOT NULL
) ENGINE = innodb;