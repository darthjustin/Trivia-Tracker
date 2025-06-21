USE trivia_tracker;


SET FOREIGN_KEY_CHECKS = 0;
SET @tarray = NULL;
SELECT GROUP_CONCAT('`', table_name, '`') INTO @tarray
  FROM information_schema.tables WHERE table_schema = (SELECT DATABASE());
SELECT IFNULL(@tarray,'dummy') INTO @tarray;
SET @tarray = CONCAT('DROP TABLE IF EXISTS ', @tarray);
PREPARE stmt FROM @tarray;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;
SET FOREIGN_KEY_CHECKS = 1;

--
-- Table structure for table `players`
--

DROP TABLE IF EXISTS `players`;

CREATE TABLE `players` (
                         `player_id` int(10) NOT NULL AUTO_INCREMENT,
                         `first_name` varchar(50) DEFAULT NULL,
                         `last_Name` varchar(50) DEFAULT NULL,
                         `user_name` varchar(50) DEFAULT NULL,
                         `created_at` datetime DEFAULT CURRENT_TIMESTAMP,
                         `last_game_played` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
                         `last_game_id` int(50) DEFAULT NULL,
                         `total_score` int(10) DEFAULT 0,
                         `games_played` int(10) DEFAULT 0,
                         `total_guesses` int(10) DEFAULT 0,
                         `total_correct` int(10) DEFAULT 0,
                         `best_game_score` int(10) DEFAULT 0,
                         `best_game_id` int(10) DEFAULT 0,
                         PRIMARY KEY (`player_id`),
                         UNIQUE KEY `user_name` (`user_name`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `games`
--

DROP TABLE IF EXISTS `games`;
CREATE TABLE `games` (
                            `game_id` int(10) NOT NULL AUTO_INCREMENT,
                            `game_date` varchar(50) NOT NULL,
                            `final_question_multiplier` boolean DEFAULT FALSE,
                            PRIMARY KEY (`game_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `questions`
--

DROP TABLE IF EXISTS `questions`;

CREATE TABLE `questions` (
                             `question_id` int(10) NOT NULL AUTO_INCREMENT,
                             `game_id` int(10) NOT NULL,
                             `round_num` int(10) CHECK (round_num IN (1, 2, 3, 4)),
                             `category` varchar(50) DEFAULT NULL,
                             `question_text` varchar(50) DEFAULT NULL,
                             `correct_answer` varchar(50) DEFAULT NULL,
                             `question_type` text CHECK (question_type IN ('multiple', 'fill', 'bonus', 'final')),
                             PRIMARY KEY (`question_id`),
                             CONSTRAINT questions_ibfk_1 FOREIGN KEY (`game_id`) REFERENCES `games` (`game_id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=1000 DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `responses`
--

DROP TABLE IF EXISTS `responses`;

CREATE TABLE `responses` (
                            `response_id` int(10) NOT NULL AUTO_INCREMENT,
                            `question_id` int(10) NOT NULL,
                            `player_id`   int(10) NOT NULL,
                            `player_answer` varchar(50) DEFAULT NULL,
                            `is_correct` boolean DEFAULT FALSE,
                            `is_bonus_used` boolean DEFAULT FALSE,
                            PRIMARY KEY (`response_id`),
                            FOREIGN KEY (`question_id`) REFERENCES `questions` (`question_id`),
                            FOREIGN KEY (`player_id`) REFERENCES `players` (`player_id`)
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=utf8mb4;

CREATE TRIGGER before_insert_response
BEFORE INSERT ON responses
FOR EACH ROW
SET NEW.is_correct = 
    (SELECT CASE 
        WHEN NEW.player_answer = q.correct_answer THEN TRUE
        ELSE FALSE
    END
    FROM questions q
    WHERE q.question_id = NEW.question_id);

-- test data for players

INSERT INTO players VALUES(1, 'test', 'test', 'user1', NOW(), NOW(), 2, 420, 2, 14, 4, 420, 2);

-- test data for games

INSERT INTO games VALUES(1,	'3/8/25', FALSE);

-- test data for questions

INSERT INTO questions VALUES(1,	1, 1, 'Movies', 'Movie Question 1', 'A', 'multiple');
INSERT INTO questions VALUES(2,	1, 1, 'Movies', 'Movie Question 1', 'D', 'multiple');
INSERT INTO questions VALUES(3,	1, 1, 'Movies', 'Movie Question 1', 'D', 'multiple');
INSERT INTO questions VALUES(4,	1, 1, 'Movies', 'Movie Question 1', 'C', 'multiple');
INSERT INTO questions VALUES(5,	1, 1, 'Movies', 'Movie Question 1', 'JFK', 'bonus');

-- test data for responses

INSERT INTO responses VALUES(1, 1, 1, 'A', 0, FALSE);
INSERT INTO responses VALUES(2, 2, 1, 'A', 0, FALSE);
INSERT INTO responses VALUES(3, 3, 1, 'D', 0, FALSE);
INSERT INTO responses VALUES(4, 4, 1, 'A', 0, FALSE);
INSERT INTO responses VALUES(5, 5, 1, 'JFK', 0, FALSE);