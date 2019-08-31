# MDMS-Maintenance-Department-Management-System
System For management a maintenace department in a company

Description

This is a simple Maintenance Department Management System 
Mostly for tracing cost repairs of the company's vehicles.
Users can Register and Login but need authorization from Admin to be able to use their functionality 
else they only view only Profile
When they get authorization:
User can create Internal Repair - User can have only One Active repair;
View all repairs, view all parts and use available parts on repair.
User can view vehicle details.
The administrator can add Vehicle, edit vehicle or remove a vehicle.
The administrator can view all Users and give or remove authorization and Remove Users.
The administrator can Add MontySalary to a User and edit Paymen.
The administrator can create Part, add the parts to stock, edit Part.
The Administrator can create multiple External Repairs.
The administrator can view Reports, create custom Report.

Entities:

User (Admin - Department Manager, User - Mechanic)
  - Id (string)
  - Username (string)
  - Password (string)
  - Email (string)
  - FirstName (string)
  - LastName (string)
  - Phone Number (string)
  - BaseSalary (decimal)  
  - AdditionalPaymentPerHour (decimal)  
  - IsAuthorized (bool)
  - IsDeleted (bool)
  
MonthlySalary  
  - Month (Int) 
  - Year  (Int) 					 
  - AdditionalOnHourPayment (decimal)  
  - BaseSalary (decimal)  
  - TotalSalary (decimal)  
  - HoursWorked (double)
  - Mechanic (user)
  
Vehicle
  - Id (string)
  - Model (string)
  - Make (string)
  - VSN (string)
  - Pricture (string)
  - Engine Number (string)
  - Registration Number (string)
  - AccuiredBy (VehicleProvider)
  - AccuiredOn (DateTime)
  - Depreciation (decimal)
  - Price (decimal)
  - Mileage (int)
  - VehicleType (enum) (Truck/Loader/Lift/Trailer/Car etc . . .)
  - VehicleProvider (enum) 
  - ManufacturedOn (dateTime)
  - Repairs List<Repair>
  - Is Active (bool)
  - Is In Repair (bool)
 
Part
  - Id (string)
  - Name (string)
  - Price (Desimal)
  - AcquiredFrom (Provider)
  - UsedOn (InternalRepairPart)
  - Stock (int)
  - UsedCount (int)
  
Repair
  - Id (string)
  - Name (string)
  - Description (string)
  - Vehicle (Vehicle)
  - RepairedSystem (Engine, GearBox, Electrical, Hydraulic, Chassis, Breaking, BodyWork)
  - Mileage (int) (km, motor hours)
  - Mechanic (User)
  - Started (DateTime)
  - Finished (DateTime)
  - Internal Repair -  UsedParts (List<InternalRepairPart>), HoursWorked
  - External Repair -  External Repair Provider, Labor Cost, Parts Cost
  - RepairCost 
  
 Report
  - Id (string)
  - Name (string)
  - StartYear (int)
  - EndYear (int)
  - StartMonth (int)
  - EndMonth (int)
  - ReportType (enum) (Month,Quarter,Year,Custom)
  - VehicleInReport (List<Vehicle>)
  - SalariesINREport (List<MontlySalaries>)
  
