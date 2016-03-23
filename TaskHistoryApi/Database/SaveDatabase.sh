#!/bin/bash
mysqldump --routines --no-data -u root -p TaskHistory > TaskHistory.sql
