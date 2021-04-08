/*
 Navicat Premium Data Transfer

 Source Server         : 本地
 Source Server Type    : MySQL
 Source Server Version : 50728
 Source Host           : localhost:3306
 Source Schema         : sys

 Target Server Type    : MySQL
 Target Server Version : 50728
 File Encoding         : 65001

 Date: 03/03/2021 13:25:06
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for course
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course`  (
  `Id` int(11) NOT NULL,
  `StudentId` int(11) NULL DEFAULT NULL,
  `CourseName` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Score` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of course
-- ----------------------------
INSERT INTO `course` VALUES (1, 1, '语文', 90);
INSERT INTO `course` VALUES (2, 1, '数学', 100);
INSERT INTO `course` VALUES (3, 1, '英语 ', 88);
INSERT INTO `course` VALUES (4, 2, '语文', 80);
INSERT INTO `course` VALUES (5, 2, '英语', 60);

SET FOREIGN_KEY_CHECKS = 1;
