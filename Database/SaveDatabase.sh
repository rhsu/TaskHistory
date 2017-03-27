#!/bin/bash
mysqldump --routines --no-data -u root -ppassword TaskHistory | sed 's/ AUTO_INCREMENT=[0-9]*//g' > TaskHistory.sql

./TestDatabaseLoad.sh
