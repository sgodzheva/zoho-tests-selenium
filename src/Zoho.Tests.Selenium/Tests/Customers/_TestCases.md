## TC-1 Test the customer creation of type "Business"
Precondition: The user has an account and is logged in.

Test Case Steps:
- Open the "Customers" page: https://invoice.zohocloud.ca/app/110000477898#/contacts
- Click on the "+New" button
- Select the "Business" radio button
- Fill in the "Privacy Contact" fields for "First Name" and "Last Name" (e.g. "First Name: Ingrid", "Last Name: Nygard" )
- Fill in the "Company Name" field (e.g. "Automated Tests LTD")
- Choose from the drop-down menu a "Customer Display Name" (e.g. "Automated Tests LTD")
- Click the "Save" button

Expected Results:
The user should be redirected to the "Customers" page where the newly created customer should be open.
The page title should correspond to the company name.
The active tab name should match the company name.
The "Customer Type" should be "Business".


## TC-2 Test the customer creation of type "Individual"
Precondition: The user has an account and is logged in.

Test Case Steps:
- Open the "Customers" page: https://invoice.zohocloud.ca/app/110000477898#/contacts
- Click on the "+New" button
- Select the "Individual" radio button
- Fill in the "Privacy Contact" fields  for "First Name" and "Last Name" (e.g. "First Name: Erik", "Last Name: Ericsson")
- Choose from the drop-down menu a "Customer Display Name" (e.g. "Erik Ericsson")
- Click the "Save" button

Expected Results:
The user should be redirected to the "Customers" page where the newly created customer should be open.
The page title should correspond to the customer's name.
The active tab name should match the customer's name.
The "Customer Type" should be "Individual".

Additional Information/Considerations:
Execute the test case by choosing the option "{Last Name}, {First Name}" for a "Customer Display Name" 


## TC-3 Test the "Search in Customers" functionality using a "Customer Display Name" 
Preconditions:
The user has an account and is logged in. 
There should be a registered customer of type "Individual".

Test Case Steps:
- Open the "Customers" page: https://invoice.zohocloud.ca/app/110000477898#/contacts
- Fill in the customer's display name in the search field (e.g. "Forsberg, Einar")
- Press "Enter"

Expected Result:
On the "Customers" page, results should only include the searched "Display Name".