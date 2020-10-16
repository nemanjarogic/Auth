# Auth
Auth repository contains workflow for working with authentication and authorization. \
Various concepts like IdentityServer4, OAuth, OpenID Connect, external providers are covered through the code.

Next branchses are available:
1. `simple-client-credentials` - [Protecting an API using Client Credentials](https://identityserver4.readthedocs.io/en/latest/quickstarts/1_client_credentials.html)
2. `interactive-ui-external-auth` - [Interactive Applications with ASP.NET Core](https://identityserver4.readthedocs.io/en/latest/quickstarts/2_interactive_aspnetcore.html)
3. `api-access-from-mvc-client` - [ASP.NET Core and API access](https://identityserver4.readthedocs.io/en/latest/quickstarts/3_aspnetcore_and_apis.html)
4. `javascript-client` - [Adding a JavaScript client](https://identityserver4.readthedocs.io/en/latest/quickstarts/4_javascript_client.html)
5. `entity-framework` - [Using EntityFramework Core for configuration and operational data](https://identityserver4.readthedocs.io/en/latest/quickstarts/5_entityframework.html)
6. `identity` - [Using ASP.NET Core Identity](https://identityserver4.readthedocs.io/en/latest/quickstarts/6_aspnet_identity.html)

Available projects from the solution will be available through the ports:
 - `IdentityServer`: 5001
 - `IdentityServerAspNetIdentity`: 5001 (run only one of the identity servers)
 
 - `Api` : 6001
 - `MvcClient` : 5002
 - `JavaScriptClient` : 5003
 - `ReactClient` : 6003 (ReactClient is not configured for work with IdentityServer, it's just initial project)
