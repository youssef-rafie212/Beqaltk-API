# [Beqaltk API]

A RESTful API for a mobile ecommerce application "Beqaltk"

## Introduction

Beqaltk API is an ASP.NET Core Web API designed to act as the backend service for the mobile application.

## Some Features

- Authentication using JWT
- Authorization
- Payments using Strip
- API features (pagination, sorting, filtering, searching)
- Services validations
- Emails
- Fake Delivery API
- Clean architecture and API documentation

## Getting Started

To get started with this project, follow these steps:

### Prerequisites

- [.NET SDK 6.0 or later]
- [Sql Server]

### Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/youssef-rafie212/Beqaltk-API.git
   ```
2. **Navigate to the project directory**

3. **Restore Dependencies**
 
	```bash
	dotnet restore
	```
 
 ### Configuration

 **The application uses environment variables for configuration. Set the following environment variables as needed:**

 - BEQALTK_DEV_DB_DEFAULT_URL = "Your DB conncetion string"
 - BEQALTK_DEV_JWT_SECRET = "Your JWT secret key"
 - BEQALTK_DEV_JWT_ISSUER = "Your JWT trusted issuer"
 - BEQALTK_DEV_STRIPE_SECRET = "Your Stripe secret key"
 - BEQALTK_DEV_EMAIL = "Your account for sending emails (any real account)"
 - BEQALTK_DEV_PASSWORD = "Your account password or app password if you made one"

 ### Running The Application

 **Navigate to the GroceryAPI folder and run:**
  ```bash
	dotnet run
  ```

  ### API Documentation

  Link : https://documenter.getpostman.com/view/29387971/2sA3rwNa6e

  ## License

  This project is licensed under the MIT License.
  