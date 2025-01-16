# Description

## Installation

## Usage

## Features

## Technologies Used

Backend: .NET Core, Entity Framework Core

Frontend:

Database: PostgreSQL

Authentication: Amazon Cognito (User Management), JWT (Authorization), AWS IAM(Identity and Access Management)


## Folder Structure

## API Endpoints

## Security Considerations

**AWS Credintials**: Do not hard-code AWS credentials in the code. Use environment variables or the AWS SDK's default credential provider chain for secure credential management.

**Token Expiry**: Cognito's JWT tokens have an expiration time. Make sure you handle token refresh securely, especially for long-running sessions.

**Secure Passwords**: Ensure users create strong passwords, and consider implementing additional verification mechanisms (e.g., multi-factor authentication) using Cognito.

**Least Privilege**: Follow the principle of least privilege when assigning IAM roles and permissions to users and services.

**Data Encryption**: Use encryption at rest and in transit to protect sensitive data.

**Logging**: Implement logging to monitor and track user activity and system behavior.

**Monitoring**: Use (TBD) to monitor system performance, set up alarms, and respond to incidents.

## Testing



## Contributing