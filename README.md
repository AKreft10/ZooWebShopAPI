
![Logo](https://i.ibb.co/0QPbzk0/73db85dead404783ba67d2c116fc907e.png)


# ZooShop

The ZooWebShop app is a simple online store for pet owners.


## Stack
- .NET 6
- SQL Server
- Quest PDF
- Cloudinary
- FluentEmail
- CQRS
- MediatR
- FluentValidation

## Features (User)
- Register account
- Activate account (by activation link on users email)
- Reset password (by reset password link on users email)
- Get paginated product list
- Add product to cart 
- Create new order
- Pay for order 
- Generate invoice for order
- Send an invoice via email
- Auto upload invoice on the cloud

## Features (Admin)
- Grant an Admin role for a User
- Create/Update/Delete products
- Create/Update/Delete categories
- Add products to categories


## Invoices
Invoices are auto-generated for every user order after the payment process. The template
for invoice has been created with QuestPDF, and looks like this:

![alt text](https://i.ibb.co/TKC2mXN/invocie.png)
## API documentation

The API documentation is available at `~api/swagger`

