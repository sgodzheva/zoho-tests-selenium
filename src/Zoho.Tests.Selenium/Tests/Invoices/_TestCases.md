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
Preconditions: The user has an account and is logged in.

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Click on the "X" button

Expected Results:
The user should be redirected to the "Invoices" page.
The button for adding a new invoice should be visible on the screen.

## TC-4 Test interrupting the invoice creation by closing the "New Invoice Page"
Preconditions: The user has an account and is logged in.

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Choose from the "Terms" drop-down menu: "Due end of the month"
- Click the "X" button

Expected Results:
A notification pop-up should appear at the top of the screen asking:"Leave this page? If you leave, your unsaved changes will be discarded."
By clicking on the "Leave & Discard Changes" button the customer should be redirected to the "Invoices" page.
By clicking on the "Stay Here" button, the customer should stay on the "New Invoices" page and should be able to continue filling out the form.

## TC-5 Test searching a customer ('Customer Name' field) that does not exist, when creating an invoice.
Preconditions: The user has an account and is logged in.

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Click on the 'Customer Name' field
- Enter an invalid customer name (e.g. "invalid-name")

Expected Results:
Below the search field, a message stating: "NO RESULTS FOUND" should be displayed.
A 'New Customer' modal window should appear, when clicking anywhere on the screen.

## TC-6 Test searching an existing customer ('Customer Name' field), when creating an invoice.
Preconditions:
The user has an account and is logged in.
There should be an already created customer ("Individual").

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Click on the 'Customer Name' field
- Enter an existing customer name (e.g. "Larson")

Expected Result:
The customer name should be displayed in the drop-down suggestions and the user should be able to select it.

## TC-7 Validate the format of the 'Invoice#', when creating a new invoice
Preconditions:
The user has an account and is logged in.

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button

Expected Result:
The "Invoice#" field should be filled with automatically generated invoice number in the format "INV-0000xx" (e.g. "INV-000036")

## TC-8 Test creating an invoice without an invoice number
Preconditions:
The user has an account and is logged in.

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Delete the auto-generated number in the "Invoice#" field 
- Click the "Save as Draft" button

Expected Results:
A pop-up should appear, confirming invoice number preferences configuration.
The invoice number should be automatically populated after closing the pop-up.

## TC-9 Test creating an invoice without an "Invoice Date"
Preconditions:
The user has an account and is logged in.

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Delete the initial date in the "Invoice Date" field 
- Click the "Save as Draft" button

Expected Result:
An error massage should appear, stating: "Choose a valid Invoice Date".

## TC-10 Test creating an invoice without a "Due Date"
Preconditions:
The user has an account and is logged in.
There should be an already created customer ("Individual") and item ("Service").

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Johansson, Folke")
- Delete the initial due date in the "Due Date" field
- Choose an item from the drop-down menu, by clicking in the "Item Details" text field (e.g. "System Testing Services, Rate:$300.00")
- Click the "Save as Draft" button  

Expected results:
The user is redirected to the "Invoices" page, where the newly created invoice is open.
The "Due Date" is shown on the invoice and matches the "Invoice date".

## TC-11 Test creating an invoice without items
Preconditions:
The user has an account and is logged in.
There should be an already created customer ("Individual")

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Fisker, Agnetha")
- Click the "Save as Draft" button  

Expected Result:
An error message should appear, stating: "Enter the valid item name or description.".

## TC-12 Validate the removal of an item during an invoice creation
Preconditions:
The user has an account and is logged in.
There should be an already created item ("Service").

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Choose an item from the drop-down menu, by clicking in the "Item Details" text field (e.g. "Sanity Testing Services, Rate:$75.00", "")
- Delete the item, using the 'X' button (on the right side of the "Item Amount" column)

Expected Result:
The item should be removed from the "Item Table".

## TC-13 Test "Add Items in Bulk" feature at the "New Invoice" page. 
Preconditions:
The user has an account and is logged in.
There should be already created items ("Service").

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Click on the "Add Items in Bulk" button
- Select multiple items from the modal list (e.g. "Usability Testing Services 1, Rate:$400.00" & "Usability Testing Services 2, Rate:$400.00")
- Click the "Add Items" button

Expected Result:
All items should appear as separate rows in the "Item Table".

## TC-14 Test adding 'Customer Notes', when creating an invoice.
Preconditions:
The user has an account and is logged in.
There should be an already created customer ("Individual") and item ("Service").

Test Case Steps:
- Open the "Invoices" page: https://invoice.zohocloud.ca/app/110000477898#/invoices
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Martinsson, Anders")
- Choose an item from the drop-down menu, by clicking in the "Item Details" text field (e.g. "Canary Testing Services, Rate:$230.00")
- Enter a text in the 'Customer Notes' field.
- Click the "Save as Draft" button  

Expected Result:
The note should be visible at the bottom of the newly created invoice under the header 'Notes'.
