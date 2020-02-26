# GeoIP-API-Implementation
A console program which pulls geolocation data from 2 different API's. 

# How does it work?
After downloading the package you can either move to ApiImplementation/bin/Debug and open the ApiImplementation.exe or, if you're interested in looking at the code, run ApplicationTest.sln via Visual Studio IDE.

Once running, the ApiHelper will setup a HTTP client, making it possible for the program to communicate with
the API.
https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/ApiImplementation/ApiHelper.cs  

The user will be asked for an IP or a Hostname. Upon entering this, "GetGeoIpInfo" is called with a parameter
(the ip or hostname provided), which will prompt the user to choose a desired API. Either IPStack or IP.API.  
https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/ApiImplementation/GeoIpService.cs  
![Product Image 1](https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/images/Product1.PNG?raw=true "Enter Ip or Hostname")  

This is done by entering "1" or "2" into the console.  
![Product Image 2](https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/images/Product2.PNG?raw=true "Choose API")  
If the input is neither of these, the user will
be given an error message, and the program will prompt the user once again to choose an API.  
![Error Message](https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/images/Error%20Message.PNG?raw=true "Error message")  
Once the desired API has been chosen, the url variable will be generated.  
https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/ApiImplementation/GeoIpService.cs#L41  

Assuming that we have a correct IP or Hostname, and the API is available, the user is able to popupale the object
with data, which is then transferred to the "GeoIpInfo" object.  
https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/ApiImplementation/GeoIpService.cs#L53  
![Product Image 3](https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/images/Product3.PNG?raw=true "Data is displayed") 

There are three models/object classes used for this process  
IPStack:    https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/ApiImplementation/IpStackModel.cs  
IP.API:     https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/ApiImplementation/IpApiModel.cs  
GeoIpInfo:  https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/ApiImplementation/GeoIpInfo.cs  
Since the task was to use the specific "GeoIpInfo" model, the API's did not exactly match the property names, 
which is the reason I resorted to making two objects that handled each API, which would then assign their
properties to the "GeoIpInfo".  

Finally, the data requested will be shown in the console.

In case something goes wrong, like the API host being down or the users internet not being available, we get an error message.  
![No Internet Image](https://github.com/nvsfuz/GeoIP-API-Implementation/blob/master/images/ErrorNoInternet.PNG?raw=true "No internet error")

# Author
Nicklas V. Sams
