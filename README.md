# Gnip for .NET
Gnip for .NET is a solution made up of individual projects that can be used to access and manage data from Gnip APIs.

Support for PowerTrack & SearchAPI is complete.
Historical PowerTrack job management is complete.  Downloading of Historical PowerTrack files is still in development.

The projects use [JSON.NET](http://www.newtonsoft.com/json) for deserializing into an Activity object and serializing text commands into JSON objects.

**Projects included in the solution:**

**Gnip.Powertrack** 

* GnipStreamReader class for establishing persistent connection to PowerTrack stream.
* Rules class & methods for managing rules (Get / Add / Delete)

**StreamTest**

* A simple console application demonstrating the proper implementation of the GnipStreamReader class to establish and maintain a connection to PowerTrack.

**PowerTrack.Net**

* Windows Forms application demonstrating use of the GnipStreamReader and Rules API classes as well as Historical PowerTrack job management.


**Gnip.SearchAPI**

* Classes used to call create and return data via SearchAPI - both counts and data endpoints.

**Gnip.Utilities**

* REST call utility static class used by Rules, Search and HPT RESTful calls.
* JSON classes for Gnip Activity Object.


**Gnip.HistoricalPowerTrack**

* Windows Forms application demonstrating use of Gnip.Powertrack.Historical 

Contact [SteveDz](mailto:stevedz@twitter.com) with any questions.
