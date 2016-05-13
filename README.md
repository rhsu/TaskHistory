TaskHistory
-------

Application using MySql, ASP.NET, MVC5, and Monodevelop to track a user's task. 

History coming soon...

Dependencies
--------

TaskHistory is recommended to install on Monodevelop using Ubuntu 14.04. See https://www.monodevelop.com for more info on how to install mono.

To install on Ubuntu, use `sudo apt-get install mono-complete monodevelop mono-xsp4 npm`

The package `mono-complete` comes from the monodevelop website.

You should also install `mysql`. It is recommended to do so through `sudo apt-get install tasksel`. However any other installation of `mysql` works as well.

In addition, `phpmyadmin` is recommended to help develop database operations, but it is not required to run the application.

Setup
----
The project should compile and run on `monodevelop`. To install the database, navigate to the database folder and run the `LoadDatabase.sh` shell script.

The project uses bower to manage javascript and css dependencies. Navigate to the TaskHistory project and run `bower install`
