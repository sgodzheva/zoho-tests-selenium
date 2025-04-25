## TC-1 Test adding a non-billable expense.
Preconditions: 
The user has an account and is logged in.

Test Case Steps:
- Open the "Expenses" page: https://invoice.zohocloud.ca/app/110000477898#/expenses
- Click on the "+New" button
- Choose a category from the "Category Name" drop-down menu (e.g. "IT and Internet Expenses")
- Populate the "Amount" field with an amount(e.g. "62.26")
- Click on the "Save" button

Expected Result:
The customer should be redirected to the "Expenses" page, where the newly created expense is opened.
A confirmation message should appear at the top of the screen stating: "The expense has been recorded."
The Expense details should be displayed and the "NON-BILLABLE" status should be shown.
