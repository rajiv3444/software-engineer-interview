
# API: Payment Plan Calculator

The API is calculating the installment for payment plan (the charge amount with its date) for an order amount, with choosen (prferrd) installment count and frequency of days to pay the installment.



## Acknowledgements

 - [User Story - Readme](https://github.com/quadpay/software-engineer-interview#readme)
 


## API Reference

#### Get the payment plan (with charge amount and payment dates)

```http
  GET /api/Paymentplan/payment-plan
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `orderAmount` | `number` | Order amount to calculate the payment plan |
| `installmentCount` | `number` | Number of installment user wish to pay for |
| `frequencyOfDaysCount` | `number` | Number of days after which the installment will repeat for next payment |



## Run Locally

Clone the project

```bash
  git clone https://github.com/rajiv3444/software-engineer-interview
```

Go to the project directory

```bash
  cd your-project-directory-you-cloned
  cd \software-engineer-interview\SoftwareEngineerInterview\CSharp\Zip.InstallmentsService
```

Launc the project
 - Open visual Studio (2022)
 - Alternatevely you can use Visual Stdio Code
 - Open the file Zip.InstallmentsService.sln


Build the project
 - Go to 'Build' >> 'Build Solution' on Visual Studio
 - alternately you can use the command
 ```bash
 dotnet build
 ```

Run the API
- Press **F5** while Visual Stdio is in Open
- alternately you can use the command
 ```bash
 dotnet run
 ```
 




## Authors

- [@Rajiv Bhardwaj](https://github.com/rajiv3444)
- [@Altimetric / QadPay](https://github.com/quadpay)



## 🚀 About Me
I'm a full stack web developer with technologies stacks of:
 - .Net
 - Angular
 - Azure
 - MS SQL
 - Javascript
 - HTML
 - CSS

