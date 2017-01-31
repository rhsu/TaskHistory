TaskHistory
-------

Application using MySql, ASP.NET, MVC5, and Monodevelop to track a user's task. 

History coming soon...

Dependencies
--------

TaskHistory is recommended to install on Monodevelop using Ubuntu 16.04. See https://www.monodevelop.com for more info on how to install mono.

You should also install `mysql`. It is recommended to do so through `sudo apt-get install tasksel`. However any other installation of `mysql` works as well.

You will also need `bower` to load the scripts and styles. `sudo npm -g install bower`

Setup
----
The project should compile and run on `monodevelop`. 

The database uses settings on my local machine where I set username to `root` and password to `password`. You can override this by changing these values in the web.config. Or you can change the `ConfigurationProvider.cs` class to return a valid connection string.

The project uses bower to manage javascript and css dependencies. To install the styles, navigate to the AngularProto project and run `bower install`

Note that: `TaskHistory.csproj` is an old application and will be phased out. Do not run that application as it contains old features and may not work correctly.

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

Issues
--------
The bower package is very broken and may install angular 1.6.x which the current router does not support. 
In case anything happens please clone https://github.com/rhsu/TaskHistoryBowerBackup and use that as the bower package until a fix has been made. 
The stable angular that this project requires is 1.5.x
