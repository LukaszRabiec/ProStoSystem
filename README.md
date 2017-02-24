# ProStoSystem
Products Storage System is an ASP.NET MVC5 app that helps you manage your small product warehouse.

## Configuration
### Add secrets file
You need to add a file `secrets.config` in [main web project](src/ProStoSystem), with the following content:
```xml
<appSettings>
  <add key="adminEmail" value="ADMIN_ACCOUNT_EMAIL"/>
  <add key="adminPassword" value="ADMIN_ACCOUNT_PASSWORD"/>
</appSettings>
```
**Type your data in `values` only, do not change `keys`!**
