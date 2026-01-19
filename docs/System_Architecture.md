# System Architecture  

The system follows a three-layer architecture:  

## 1. Frontend (Client Layer)  

The frontend is a web interface developed using:  

- HTML  
- CSS  
- JavaScript  

It provides:  

- Login page  
- Admin dashboard  
- Attack monitoring page  
- System logs page  

The frontend communicates with the backend via REST APIs.  

## 2. Backend (Application Layer)  

The backend is built using ASP.NET Core Web API. It is responsible for:  

- User authentication  
- Processing requests from the frontend  
- Detecting suspicious activities  
- Logging security events  
- Blocking malicious IP addresses  

Main components:  

- Authentication Module  
- Monitoring Module  
- Logging Module  
- Blocking Module  

## 3. Database (Data Layer)  

The system uses SQL Server with the following main tables:  

- Users  
- Attacks  
- Logs  
- Blocked_IPs  

The database stores all security-related data for analysis and reporting.  
