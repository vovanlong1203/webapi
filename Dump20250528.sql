CREATE DATABASE  IF NOT EXISTS `exam` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `exam`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: exam
-- ------------------------------------------------------
-- Server version	8.0.36

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `answers`
--

DROP TABLE IF EXISTS `answers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `answers` (
  `AnswerId` int NOT NULL AUTO_INCREMENT,
  `QuestionId` int NOT NULL,
  `AnswerText` text NOT NULL,
  `IsCorrect` tinyint(1) NOT NULL,
  `Order` int NOT NULL,
  PRIMARY KEY (`AnswerId`),
  KEY `idx_answers_questionid` (`QuestionId`),
  CONSTRAINT `answers_ibfk_1` FOREIGN KEY (`QuestionId`) REFERENCES `questions` (`QuestionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `answers`
--

LOCK TABLES `answers` WRITE;
/*!40000 ALTER TABLE `answers` DISABLE KEYS */;
/*!40000 ALTER TABLE `answers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attemptanswers`
--

DROP TABLE IF EXISTS `attemptanswers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `attemptanswers` (
  `AttemptAnswerId` int NOT NULL AUTO_INCREMENT,
  `AttemptId` int NOT NULL,
  `QuestionId` int NOT NULL,
  `AnswerId` int DEFAULT NULL,
  `UserAnswerText` text,
  `IsCorrect` tinyint(1) DEFAULT NULL,
  `PointsEarned` decimal(4,2) DEFAULT NULL,
  PRIMARY KEY (`AttemptAnswerId`),
  KEY `QuestionId` (`QuestionId`),
  KEY `AnswerId` (`AnswerId`),
  KEY `idx_attempt_answers_attemptid` (`AttemptId`),
  CONSTRAINT `attemptanswers_ibfk_1` FOREIGN KEY (`AttemptId`) REFERENCES `examattempts` (`AttemptId`),
  CONSTRAINT `attemptanswers_ibfk_2` FOREIGN KEY (`QuestionId`) REFERENCES `questions` (`QuestionId`),
  CONSTRAINT `attemptanswers_ibfk_3` FOREIGN KEY (`AnswerId`) REFERENCES `answers` (`AnswerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attemptanswers`
--

LOCK TABLES `attemptanswers` WRITE;
/*!40000 ALTER TABLE `attemptanswers` DISABLE KEYS */;
/*!40000 ALTER TABLE `attemptanswers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classes` (
  `ClassId` int NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(50) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ClassId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes` VALUES (1,'Toán','Môn Toán','2025-05-03 14:53:13'),(2,'Lý','Môn Lý','2025-05-03 14:53:58'),(3,'Hóa','Môn hóa','2025-05-03 14:54:31');
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `examattempts`
--

DROP TABLE IF EXISTS `examattempts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `examattempts` (
  `AttemptId` int NOT NULL AUTO_INCREMENT,
  `ExamId` int NOT NULL,
  `UserId` int NOT NULL,
  `StartTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `EndTime` datetime DEFAULT NULL,
  `Status` enum('InProgress','Completed','TimedOut') NOT NULL,
  `Score` decimal(5,2) DEFAULT NULL,
  PRIMARY KEY (`AttemptId`),
  KEY `ExamId` (`ExamId`),
  KEY `idx_exam_attempts_userid_examid` (`UserId`,`ExamId`),
  CONSTRAINT `examattempts_ibfk_1` FOREIGN KEY (`ExamId`) REFERENCES `exams` (`ExamId`),
  CONSTRAINT `examattempts_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `examattempts`
--

LOCK TABLES `examattempts` WRITE;
/*!40000 ALTER TABLE `examattempts` DISABLE KEYS */;
/*!40000 ALTER TABLE `examattempts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `examresults`
--

DROP TABLE IF EXISTS `examresults`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `examresults` (
  `ResultId` int NOT NULL AUTO_INCREMENT,
  `AttemptId` int NOT NULL,
  `UserId` int NOT NULL,
  `ExamId` int NOT NULL,
  `TotalScore` decimal(5,2) NOT NULL,
  `CompletedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Remarks` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`ResultId`),
  KEY `AttemptId` (`AttemptId`),
  KEY `UserId` (`UserId`),
  KEY `ExamId` (`ExamId`),
  CONSTRAINT `examresults_ibfk_1` FOREIGN KEY (`AttemptId`) REFERENCES `examattempts` (`AttemptId`),
  CONSTRAINT `examresults_ibfk_2` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`),
  CONSTRAINT `examresults_ibfk_3` FOREIGN KEY (`ExamId`) REFERENCES `exams` (`ExamId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `examresults`
--

LOCK TABLES `examresults` WRITE;
/*!40000 ALTER TABLE `examresults` DISABLE KEYS */;
/*!40000 ALTER TABLE `examresults` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exams`
--

DROP TABLE IF EXISTS `exams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `exams` (
  `ExamId` int NOT NULL AUTO_INCREMENT,
  `SubjectId` int NOT NULL,
  `Title` varchar(200) NOT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `Duration` int NOT NULL,
  `StartTime` datetime DEFAULT NULL,
  `EndTime` datetime DEFAULT NULL,
  `TotalQuestions` int NOT NULL,
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ExamId`),
  KEY `SubjectId` (`SubjectId`),
  KEY `CreatedBy` (`CreatedBy`),
  CONSTRAINT `exams_ibfk_1` FOREIGN KEY (`SubjectId`) REFERENCES `subjects` (`SubjectId`),
  CONSTRAINT `exams_ibfk_2` FOREIGN KEY (`CreatedBy`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exams`
--

LOCK TABLES `exams` WRITE;
/*!40000 ALTER TABLE `exams` DISABLE KEYS */;
/*!40000 ALTER TABLE `exams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `questions` (
  `QuestionId` int NOT NULL AUTO_INCREMENT,
  `ExamId` int DEFAULT NULL,
  `SubjectId` int NOT NULL,
  `QuestionText` text NOT NULL,
  `QuestionType` enum('MultipleChoice','TrueFalse','FillIn') NOT NULL,
  `Points` decimal(4,2) NOT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`QuestionId`),
  KEY `SubjectId` (`SubjectId`),
  KEY `idx_questions_examid` (`ExamId`),
  CONSTRAINT `questions_ibfk_1` FOREIGN KEY (`ExamId`) REFERENCES `exams` (`ExamId`),
  CONSTRAINT `questions_ibfk_2` FOREIGN KEY (`SubjectId`) REFERENCES `subjects` (`SubjectId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions`
--

LOCK TABLES `questions` WRITE;
/*!40000 ALTER TABLE `questions` DISABLE KEYS */;
/*!40000 ALTER TABLE `questions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subjects`
--

DROP TABLE IF EXISTS `subjects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subjects` (
  `SubjectId` int NOT NULL AUTO_INCREMENT,
  `SubjectName` varchar(50) NOT NULL,
  `Description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`SubjectId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subjects`
--

LOCK TABLES `subjects` WRITE;
/*!40000 ALTER TABLE `subjects` DISABLE KEYS */;
/*!40000 ALTER TABLE `subjects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `PasswordHash` varchar(256) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `FullName` varchar(100) NOT NULL,
  `Role` enum('Student','Teacher','Admin') NOT NULL,
  `ClassId` int DEFAULT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `Username` (`Username`),
  UNIQUE KEY `Email` (`Email`),
  KEY `ClassId` (`ClassId`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`ClassId`) REFERENCES `classes` (`ClassId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-28  7:58:47
