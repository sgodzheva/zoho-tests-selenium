## TC-1 Test an invoice creation, by populating the most essential fields and using the simplified view
Preconditions:
The user has an account and is logged in.
There should be an already created customer ("Individual") and an item ("Service").

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Bergfalk, Fredrik")
- Choose the option "Due on Receipt" from the "Terms" drop-down
- Choose an item from the drop-down menu, by clicking in the "Item Details" text field (e.g. "Exploratory Testing Services, Rate:$140.00")
- Click on the "Save as Draft" button

Expected Results:
The user should be redirected to the "Invoices" page where the newly created invoice should be open.
The page title should correspond to the invoice number.
The customer name under "Bill to" should match the selected name during the creation, as well as the shown item's name and details in the "Item & Description" table.
The "Invoice Date" should match the default option, which is the date of invoice creation (e.g. yyyy/mm/dd).
The invoice "Due Date" should also match the date of creation.
The "Terms" should correspond to the chosen option during the invoice creation (e.g."Due on Receipt").
The "Balance Due", the "Sub Total" and "Total" amounts should equal the number in the "Amount" column.

## TC-2 Test an invoice creation with more than one item and using the simplified view
Preconditions:
The user has an account and is logged in.
There should be an already created customer ("Individual") and items ("Service").

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Olander, Gottfrid")
- Choose the option "Due on Receipt" from the "Terms" drop-down
- Choose more than one item from the drop-down menu, by clicking in the "Item Details" text field (e.g. "A/B Testing Services 1, Rate:$200.00" & "A/B Testing Services 2, Rate:$200.00")
- Click on the "Save as Draft" button

Expected Results:
The user should be redirected to the "Invoices" page where the newly created invoice should be open.
The page title should correspond to the invoice number.
The customer name under "Bill to" should match the selected name during the creation, as well as the shown item's name and details in the "Item & Description" table.
The "Invoice Date" should match the default option, which is the date of invoice creation (e.g. yyyy/mm/dd).
The invoice "Due Date" should also match the date of creation.
The "Terms" should correspond to the chosen option during the invoice creation (e.g."Due on Receipt").
The number of items on the invoice should match the ones selected.
The "Balance Due", the "Sub Total" and "Total" amounts should be the same and should be equal to the sum of all item amounts.

## TC-3 Test the closing feature of the "New Invoice Page"
Preconditions:
The user has an account and is logged in.

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Click on the "X" button

Expected Results:
The user should be redirected to the "Invoices" page.
The button for adding a new invoice should be visible on the screen.

## TC-4 Test interrupting the invoice creation by closing the "New Invoice Page"
Preconditions:
The user has an account and is logged in.

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Choose from the "Terms" drop-down menu: "Due end of the month"
- Click the "X" button

Expected Results:
A notification pop-up should appear at the top of the screen asking:"Leave this page? If you leave, your unsaved changes will be discarded."
By clicking on the "Leave & Discard Changes" button the customer should be redirected to the "Invoices" page.
By clicking on the "Stay Here" button, the customer should stay on the "New Invoices" page and should be able to continue filling out the form.