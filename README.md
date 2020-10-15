# Auth
Auth repository contains workflow for working with authentication and authorization. \
Various concepts like IdentityServer4, OAuth, OpenID Connect, external providers are covered through the code.

Next branchses are available:
- `simple-client-credentials` - [Protecting an API using Client Credentials](https://identityserver4.readthedocs.io/en/latest/quickstarts/1_client_credentials.html)
- `interactive-ui-external-auth` - [Interactive Applications with ASP.NET Core](https://identityserver4.readthedocs.io/en/latest/quickstarts/2_interactive_aspnetcore.html)
- `api-access-from-mvc-client` - [ASP.NET Core and API access](https://identityserver4.readthedocs.io/en/latest/quickstarts/3_aspnetcore_and_apis.html)
- `javascript-client` - [Adding a JavaScript client](https://identityserver4.readthedocs.io/en/latest/quickstarts/4_javascript_client.html)

Available projects from the solution will be available through the ports:
 - `IdentityServer`: 5001
 - `Api` : 6001
 - `MvcClient` : 5002
 - `JavaScriptClient` : 5003
 - `ReactClient` : 5003 (ReactClient is not configured for work with IdentityServer, it's just initial project)
