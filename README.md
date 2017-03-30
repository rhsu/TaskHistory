TaskHistory
-------

Application using MySql, ASP.NET, MVC5, and Monodevelop to track a user's task.

History coming soon...

Dependencies
--------

TaskHistory is recommended to install on Monodevelop using Ubuntu 16.04. See https://www.monodevelop.com for more info on how to install mono.

You will also need install `mysql`. It is recommended to do so through `sudo apt-get install tasksel`. However any other installation of `mysql` works as well.

You will also need `bower` to load the scripts and styles. To install bower run: `sudo npm -g install bower`

Setup
----
The project should compile and run on `monodevelop` as is.

The database uses settings on my local machine where I set username to `root` and password to `password`. You can override this by changing these values in the `web.config`. Or you can change the `ConfigurationProvider.cs` class to return a valid connection string.

The project uses bower to manage javascript and css dependencies. To install the styles, navigate to the `TaskHistory.WebApp` project and run `bower install`

Database
--------
There are two databases that this application uses. It is recommended to login to mysql and create them. (This process will be automated in the future).

The easiest way to do this is by running

- `mysql -u root -ppassword`
- `CREATE DATABASE TaskHistory;`
- `CREATE DATABASE TaskHistoryTest;`
- exit out of mysql `ctrl + d`
- run the two Database load scripts in the Database directory: `./LoadDatabase.sh` and `./TestDatabaseLoad.sh`

All changes to the database can be ran via `./SaveDatabase.sh`. Do note that this will also automatically update the the `TaskHistoryTest` database.

Utilities
---------
There are a couple of utility shell scripts written to facilitate developing the application. These are:

- `Database/DB-reset.sh`: this should rarely be used. Because the save script will not delete stored procedures and tables which already exist in the database, this script will hard reset everything to remove extraneous/orphaned database objects
- `Database/SaveDatabase.sh`: dumps the current schema into `TaskHistory.sql`. To save time, this will also load the test database.
- `Database/LoadDatabase.sh`: loads the current schema `TaskHistory.sql` into TaskHistory database
- `Database/TestDatabaseLoad.sh`: same as `LoadDatabase.sh` but for the Test database
- `Scripts/kill8080.sh`: kills the port 8080. This usually occurs when monodevelop crashes for whatever reason but doesn't free up the port 8080.

Admin Tool
----------
See `AdminUserProvider.cs` for login credentials or for changing the login credentials. By default, these are username: `admin` and password `password`.

Currently the admin tool allows setting feature flags (which may enable hidden secret features) or create a default user. See `DefaultUserProvider.cs` for the default user login credentials. By default, this is username: `robert` and password `password`.
