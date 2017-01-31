#!/bin/bash
mysqldump --routines --no-data -u root -ppassword TaskHistory > TaskHistory.sql

./TestDatabaseLoad.sh
