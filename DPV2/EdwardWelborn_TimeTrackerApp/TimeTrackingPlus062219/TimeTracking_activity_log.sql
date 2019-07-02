-- MySQL dump 10.13  Distrib 8.0.16, for macos10.14 (x86_64)
--
-- Host: localhost    Database: TimeTracking
-- ------------------------------------------------------
-- Server version	5.7.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `activity_log`
--

DROP TABLE IF EXISTS `activity_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `activity_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `calendar_day` int(11) DEFAULT NULL,
  `calendar_date` int(11) DEFAULT NULL,
  `day_name` int(11) DEFAULT NULL,
  `category_description` int(11) DEFAULT NULL,
  `activity_description` int(11) DEFAULT NULL,
  `time_spent_on_activity` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `user_idx` (`user_id`),
  KEY `numericalDay_idx` (`calendar_day`),
  KEY `date_idx` (`calendar_date`),
  KEY `dayOfWeek_idx` (`day_name`),
  KEY `timeSpent_idx` (`time_spent_on_activity`),
  KEY `activityDescription_idx` (`activity_description`),
  KEY `i. activityCategory` (`category_description`),
  CONSTRAINT `activityDescription` FOREIGN KEY (`activity_description`) REFERENCES `activity_descriptions` (`activity_description_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `date` FOREIGN KEY (`calendar_date`) REFERENCES `tracked_calendar_dates` (`calendar_date_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `dayOfWeek` FOREIGN KEY (`day_name`) REFERENCES `days_of_week` (`day_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `i. activityCategory` FOREIGN KEY (`category_description`) REFERENCES `activity_categories` (`activity_category_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `numericalDay` FOREIGN KEY (`calendar_day`) REFERENCES `tracked_calendar_days` (`calendar_day_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `timeSpent` FOREIGN KEY (`time_spent_on_activity`) REFERENCES `activity_times` (`activity_time_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `user` FOREIGN KEY (`user_id`) REFERENCES `time_tracker_users` (`user_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activity_log`
--

LOCK TABLES `activity_log` WRITE;
/*!40000 ALTER TABLE `activity_log` DISABLE KEYS */;
INSERT INTO `activity_log` VALUES (1,1,1,1,1,1,1,1),(2,0,15,0,1,6,2,89);
/*!40000 ALTER TABLE `activity_log` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-06-22 12:48:23
