## TC-1 Test a payment receipt creation with an existing customer with no invoices
Preconditions: 
The user has an account and is logged in.
There should be an already created customer ("Individual") 

Test Case Steps:
- Open the "Payments Received" page: https://invoice.zohocloud.ca/app/110000477898#/paymentsreceived
- Click on the "+New" button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Robertsson, Doris")
- Populate the "Amount Received" field with an amount(e.g. "20.00")
- Click on the "Save" button
- Click on the "Continue to Save" button on the notification pop-up

Expected Results:
The customer should be redirected to the "Payments Received" page, where the newly created payment receipt should be open.
The active payment receipt should have a title matching the auto-generated payment receipt number during the creation.
The "Payment Date" should match the default option, which is the date of the payment creation (e.g. yyyy/mm/dd).
The "Payment Mode" should match the default option, during the customer payment creation (e.g."Cash").
The customer name under "Received From" should match the selected name during the creation.
The Payment Receipt should display a field called "Over Payment" with the used amount during the creation. This amount should be equal to the one in the "Amount Received" field.

## TC-2 Test deleting an existing payment receipt
Preconditions:
The user has an account and is logged in.
There should be an already created customer ("Individual") 
There should be an already created payment receipt for that customer.

Test Case Steps:
- Open the "Payments Received" page: https://invoice.zohocloud.ca/app/110000477898#/paymentsreceived
- Select the payment receipt from the table by clicking on it
- Click on the kebab menu button from the navigation 
- Click the "Delete" button
- Click the "OK" button on the alert pop-up

Expected Results:
A confirmation message should appear at the top of the screen stating: "The payment has been deleted"
The deleted payment should not appear in the "All Received Payments" table.

# TC-3 Test refunding a payment with an excess amount refund type
Preconditions:
The user has an account and is logged in.
There should be an already created customer ("Individual") 
There should be an already created payment receipt for that customer.

Test Case Steps:
- Open the "Payments Received" page: https://invoice.zohocloud.ca/app/110000477898#/paymentsreceived
- Select the payment receipt from the table by clicking on it
- Click on the kebab menu button from the navigation 
- Click the "Refund" button
- Select "Excess Amount Refund" option from the "Refund Type" dropdown
- Enter the amount in the "Amount" field (e.g. "400") -  it should match excess amount
- Click the "Save" button

Expected Results:
A confirmation message should appear at the top of the screen stating: "The refund information for this payment has been saved."
The Payment Receipt should display a field called "Payment Refund" with the used amount during the creation. This amount should be equal to the one in the "Amount Received" field.
A "Refund History" section should appear on the active payment receipt.
In the "All Received Payments" Table the "Unused Amount" for the payment should be "0". 


