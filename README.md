# PatientManagement
This solution contains a .NET Minimal API project for managing patient data.

# PatientManagement.Api
This is a simple .NET Minimal API that retrieves patient summary by ID using an in-memory data source.

Endpoint
GET /api/patients/{id}

Retrieves a patient by ID.

Example Request
GET https://localhost:{port}/api/patients/1

Response

200 OK
{
  "id": 1,
  "nhsNumber": "6344534421",
  "name": "TestName1",
  "dateOfBirth": "1990-03-10T00:00:00",
  "gpPractice": "TestPractice1"
}

Example Request 
GET https://localhost:{port}/api/patients/99

Response
404 NOT FOUND
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.5",
  "title": "Patient not found",
  "status": 404,
  "detail": "The Requested Patient was not found."
}

# Design Notes
The API uses a service layer (IPatientService) to keep logic testable
Repository layer is included for separation of concerns
404 (Not Found) responses are handled explicitly within endpoints using structured ProblemDetails responses
In-memory data is used for simplicity

# API Documentation (Swagger)
The API includes Swagger UI for interactive documentation and testing.

After running the application, navigate to:
https://localhost:{port}/swagger

# PatientManagement.Api.Tests
Unit tests are implemented using xUnit and FakeItEasy.

# Technologies
- .NET 8
- ASP.NET Core Minimal API
- Swagger / OpenAPI
- xUnit
- FakeItEasy
