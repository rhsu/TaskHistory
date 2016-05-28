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

You will also need `bower` to load the scripts and styles. `sudo npm -g install bower`

In addition, `phpmyadmin` is recommended to help develop database operations, but it is not required to run the application.

Setup
----
The project should compile and run on `monodevelop`. To install the database, navigate to the database folder and run the `LoadDatabase.sh` shell script.

The database uses settings on my local machine where I set username to `root` and password to `password`. You can override this by changing these values in the web.config. Or you can change the `ConfigurationProvider.cs` class to return a valid connection string.

The project uses bower to manage javascript and css dependencies. To install the styles, navigate to the TaskHistory project and run `bower install`
