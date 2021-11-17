CREATE TABLE `zones` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Type` int(11) DEFAULT NULL COMMENT '1:省,2:市,3:区',
  `Code` varchar(64) DEFAULT NULL,
  `Name` varchar(64) DEFAULT NULL,
  `ParentCode` varchar(64) DEFAULT NULL,
  `ParentName` varchar(64) DEFAULT NULL,
  `FullName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=22514 DEFAULT CHARSET=utf8;