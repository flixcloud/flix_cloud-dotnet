Flix Cloud API Sample Python Library
====================================

Version: 0.2  
Date:    May 7, 2009

A sample Python client library for interacting with the [On2 Flix Cloud](http://flixcloud.com) API.

See [http://flixcloud.com/api](http://flixcloud.com/api) for more details about the API.


## CONTENTS

* FlixCloud - this is the code of the C# client library
* InvokeDemo - a console application that uses the FlixCloud library to send a request to the server 
* FlixCloudNotification - sample service that handles the notifications send from the Flix Cloud upon job finish

To run the InvokeDemo application you will need the .NET Framework 3.5 and Visual Studio 2008 on your computer. You must also download and import the Flix Cloud SSL certificate to your Windows store and properly configure the Flix Cloud certificate in the app.config file (clientCertificate section).

To run the FlixCloudNotification service you will need to host it under Internet Information Service (IIS). We have tested it under Windows XP, Windows Server 2003 and and Windows Server 2008. See the PDF sample in the doc subdirectory for more details.