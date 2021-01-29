#ASASAAS
# managererp This is the repository for an ERP instance manager, that will be available on AWS. This manager is being built in C # .NET Core.


ASASAAS PROJECT

The first and most important thing is the current task that results in choosing how all Odoo instances will be managed ...

In this task I am implementing Openerp inside containers.
To separate the instances of each customer / service within the EC2 instance.

Basically the client accesses the amazon DNS. and is redirected to the specific port that the container will be allocated to.

Example, port 8069, 8070.

Regarding the question of the domain, purchased by you or the customer, it is possible at providers such as Locaweb, Hostgator and etc. to redirect the domain access to any IPV4 address on the web, in this case we would use the EC2.

It will be necessary to create Odoo Modules with the concept of Self Service, thinking about this I created a Generic container listening to port 7069 on the Amazon server, this container will be used by company for creation of other customized containers because according to the concept that we will be establishing each customer should only use the module they buy, and for that we will already leave the modules configured to serve customers. Therefore, all new modules will start from a clone of the generic 7069 port module.

To access the Devops module, enter the IPV4 of EC2 followed by port 7069 example: 192.168.0.1:7069
WARNING: When an EC2 instance is restarted, IPV4 also updates, which may change the host to access the AWS instance.

GITHUB:

We will use GITHUB to version the Webapi that does the operations on EC2 via HTTP verb.

It will also be used to version the Manager's Frontend that will communicate with the backend (Lack of development);

And especially after finishing this stage of the project which is very complex, we will store all the customized Odoo modules, to facilitate new editions using GIT instead of defragmenting ready-made images and after editing versioning the modifications to the GIT Branch and generating a Container image and store in DOCKER HUB.


DOCKER HUB:

Similar to Github, however it hosts container images;
The docker hub will contain personalized images from Odoo and Postgres, every time we edit a module, we must pass the ODOO to a new container mirror that will be stored in Dockerhub and later will be instantiated for a new user.

WEBAPI ARCHITECTURE:

DDD Architecture was defined for the webapi, so there is a division in the project where layers are nested below each other and communicate according to a hierarchy.

LAYER API.APPLICATION (Aplication is a Webapi, see Domain / Service / Crosscutting);
API.CROSSCUTTING LAYER (Crosscutting is a classlib, belongs to Data Infrastructure, covers Domain / Service / Data layer responsible for communicating with the BD ORM);
API.DATA LAYER (Data is a classlib, belongs to Data Infrastructure, Enlarges Domain, layer that is a pillar for BD mapping contains migrations);
API.DOMAIN LAYER (Domain is a classlib, contains the entity and interface);
API.SERVICES LAYER (Services is a classlib, encompasses Domain / Data, contains business rules that do not act directly on the bank);
Aplication.Sln (It is a solution, which contains all layers);

UNDERSTANDING HOW BACKEND WORKS (WEB API MANAGER)

HTTP POST ------------------------------------------------ --------

To start new client instances, the Backend on the Server performs the steps below:
odoo11config_Customername.rar

The odoo11config_Customername.rar file facilitates the implementation of Odoo instances like AS A SAAS.

FIRST EXTRACT THE CONFIGURATION FILE FOLDER!

Rename the folder with the name of the client instance that the installation should be destined for.

Access the file path through the terminal and access the folder.

using a text editor, change the Odoo installation port in the "docker-compose.yml" file, save and proceed.

In the next step, remembering that the image destined for the ERP is in a private directory in the Docker Hub of Apeninos, for this login with the command:

$ DOCKER LOGIN

Run the creation of OpenErp instances as AS A SAAS with the command:

$ DOCKER-COMPOSE use

After these steps we will have Odoo started as an AS A SAAS.

LACK END {

HTTP PUT ---------------------------------------- Word was created, but it is not exposed! It will be used later.

HTTP GET ----------------------------------------

HTTP DELETE -------------------------------------
}

PUBLISHING THE WEBAPI ON THE SERVER:

First install the Dotnet SDK and Dotnet Runtime on the Server

To publish the application:

dotnet publish -o awssite

Once this is done, the publish folder must be accessible on the server.

On Amazon Linux 2 AMI (HVM)

Install Apache with the command:

yum install httpd mod_ssl

On the server, access the folder where the virtual host configuration file should be:

cd /etc/httpd/conf.d

Create the host configuration file
sudo vim webapimanager.conf

..................................................................
The file must have the structure:

<VIRTUAL HOST *: 80>
 ProxyPreserveHost On
 ProxyPass / http://127.0.0.1/16000/
 ProxyPassReverse / http://127.0.0.1:53000/
 ErrorLog /var/log/httpd/hellomvc-error.log
 CustomLog /var/log/httpd/hellomvc-access.log common
</VirtualHost>
..................................................................


After making the configuration, save and close the file.

Now proceed to test the httpd configuration

sudo service httpd configtest

Now restart Apache:

sudo systemctl restart httpd
sudo systemctl enable httpd

See the status of the httpd server:
sudo service httpd status

...
Done the previous steps now access the publish folder.

cd / awssite

Now proceed with the application launch on the server:

dotnet Application.dll

On Ubuntu Server 16.04 LTS (HVM)

Install Apache with the command:

sudo apt-get update
sudo apt-get install apache2

sudo systemctl stop apache2.service
sudo systemctl start apache2.service
sudo systemctl enable apache2.service

On the server, access the folder where the virtual host configuration file should be:

cd / etc / apache2 / sites-available /

Create the host configuration file

sudo vim Apache2Proxy.conf

The file must have the structure:

.......................................................................
<VirtualHost *: 80>
  ErrorLog $ {APACHE_LOG_DIR} /error.log
  CustomLog $ {APACHE_LOG_DIR} /access.log combined
  ProxyPreserveHost On
  ProxyPass / http://127.0.0.1/16000/
  ProxyPassReverse / http://127.0.0.1:53000/
</VirtualHost>
........................................................................



After making the configuration, save and close the file.

Activate the Host:
sudo a2enmod proxy
sudo a2enmod proxy_http

In the ports.conf file add Port 5000 and 5001

Now restart Apache:

sudo a2ensite Apache2Proxy.conf

sudo systemctl restart apache2.service

Test the configuration:

cd / etc / apache2
apache2ctl configtest

AFTER CONFIGURING THE HOST 5000 DOOR IT IS ALREADY POSSIBLE TO ACCESS WEBAPI IN BROWSER REMOTE.

To do this, access the Publish folder, Pause the APACHE2 execution, run the dotnet pointing to the published application and then immediately restart the Apache2 Service.
