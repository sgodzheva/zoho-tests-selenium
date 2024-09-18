## TC-1 Test a quote creation, by populating the most essential fields, using the simplified view
Preconditions:
The user has an account and is logged in.
There should be an already created customer("Individual") and an item("Service").

Test Case Steps:
- Open the "Quotes" page: https://invoice.zohocloud.ca/app/110000477898#/quotes
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Haraldson, Leif")
- Choose an item from the drop-down menu, by clicking in the "Item Details" text field (e.g. "Smoke Testing Services, Rate:$150.75")
- Click on the "Save as Draft" button

Expected Results:
The user should be redirected to the "Quotes" page where the newly created quote should be open.
The page title should correspond to the quote number.
The customer name under "Bill to" should match the selected name during the creation, as well as the shown item's name and details in the "Item & Description" table.
The "Sub Total" and "Total" amounts should be calculated correctly.

  
## TC-2 Test a quote creation, with a discounted item from type "Service", using the simplified view
Preconditions:
The user has an account and is logged in.
There should be an already created customer("Individual") and an item("Service").

Test Case Steps:
- Open the "Quotes" page: https://invoice.zohocloud.ca/app/110000477898#/quotes
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Gustavsson, Jarl")
- Choose an item from the drop-down menu, by clicking in the "Item Details" text field (e.g. "GUI Testing Services, Rate:$240.75")
- Populate the discount number in the "Discount" column and choose the rate by clicking on the drop-down menu (e.g. "10%") 
- Click on the "Save as Draft" button

Expected Results:
The user should be redirected to the "Quotes" page where the newly created quote should be open.
The page title should correspond to the quote number.
The item's name, quantity, rate and discount should match the selected ones during the creation.
The "Item Amount" should be calculated correctly based on the item's rate and discount (e.g. "10.00% discount on $240.75 gives an amount of $216.67")
The "Sub Total" and "Total" amounts should match the number from the "Amount" column.

Additional Information/Considerations:
Execute the test case with discounts:
- "1%" => The "Item Amount", the "Sub Total" and "Total" amounts should match the rate number.
- "0%" => The "Discount" column should not be visible in the "Item & Description" table.
- "99%" => The "Item Amount", the "Sub Total" and "Total" amounts should be calculated correctly.
- "100%" => The "Sub Total" and "Total" amounts should be 0.00.
- "-5%" => Negative discount number should be ignored and the quote should be saved as if there is no discount.


## TC-3 Test a basic quote creation with an item with a negative "Selling Price"
Preconditions:
The user has an account and is logged in. 
There should be an already created customer("Individual") and an item("Service") with a negative "Selling Price".

Test Case Steps:
- Open the "Quotes" page: https://invoice.zohocloud.ca/app/110000477898#/quotes
- Click on the "+New" button
- Select the "Use Simplified View" radio button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Rosenberg, Hilda")
- Choose an item from the drop-down menu, by clicking in the "Item Details" text field (e.g. "User Acceptance Testing Services, Rate:$-50.00")
- Click on the "Save as Draft" button

Expected Result:
The user should not be able to save the quote.
An error message should appear at the top of the screen stating: "Please ensure that the total amount is greater than or equal to zero."

## TC-4 Test a quote creation with shipping charges
Preconditions: 
The user has an account and is logged in.
There should be an already created customer("Individual") and an item("Goods").

Test Case Steps:
- Open the "Quotes" page: https://invoice.zohocloud.ca/app/110000477898#/quotes
- Click on the "+New" button
- Deselect the "Use Simplified View" radio button
- Choose a customer from the "Customer Name" drop-down menu (e.g. "Thorsten, Freya")
- Choose an item from the drop-down menu, by clicking in the "Item Details" text field (e.g. "Combo Pack Ink Cartridges, Rate:$43.97")
- Populate the shipping costs amount in the "Shipping Charges" field (e.g. "15")
- Click on the "Save as Draft" button

Expected Results:
The user should be redirected to the "Quotes" page where the newly created quote should be open.
The page title should correspond to the quote number.
The item's details should match the ones during the creation process.
The "Sub Total" amount should match the "Item Amount"
The "Total" amount should be the sum of "Sub Total" amount and the "Shipping Charge" amount. (e.g. "Sub Total: $43.97, Shipping Charge: $15.00 => Total: 43.97 + 15.00 = $58.97")

Additional Information/Considerations:
Execute the test case by populating "0" in the ""Shipping Charges" field. The "Item Amount", the "Sub Total" and "Total" amounts should be the same.