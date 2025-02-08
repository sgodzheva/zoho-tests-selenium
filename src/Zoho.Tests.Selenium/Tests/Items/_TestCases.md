## TC-1 Test the item creation of type "Goods" 
Precondition: The user has an account and is logged in.

Test Case Steps:
- Open the "Items" page: https://invoice.zohocloud.ca/app/110000477898#/inventory/items
- Click on the "+New" button
- Select the "Goods" radio button
- Populate the item's name in the "Name" field (e.g. "Canon PIXMA TS3720 All-in-One Printer")
- Populate an amount in the "Selling Price" field (e.g. "59.97")
- Click the "Save" button

Expected Results:
The user should be redirected to the "Items" page where the newly created item should be open.
The page title should correspond to the item's name.
The active tab name should match the item's name.
The "Item Type" should be "Sales Items".
The "Selling Price" should match the item's price.


## TC-2 Test the item creation of type "Service"
Precondition: The user has an account and is logged in.

Test Case Steps:
- Open the "Items" page: https://invoice.zohocloud.ca/app/110000477898#/inventory/items
- Click on the "+New" button
- Select the "Service" radio button
- Populate the item's name in the "Name" field (e.g. "End-to-end Testing Services")
- Populate an amount in the "Selling Price" field (e.g. "100")
- Click the "Save" button

Expected Results:
The user should be redirected to the "Items" page where the newly created item should be open.
The page title should correspond to the item's name.
The active tab name should match the item's name.
The "Item Type" should be "Sales Items (Service)".
The "Selling Price" should match the item's price.

## TC-3 Validate the history tab entry creation, when creating a new item
Preconditions:
The user has an account and is logged in.
There should be an already created item ("Goods").

Test Case Steps:
- Open the "Items" page: https://invoice.zohocloud.ca/app/110000477898#/inventory/items
- Select an item
- Click on the "History" tab

Expected Result:
An entry log should be visible, showing the creation date and the creator(e.g. "yyyy/mm/dd hh:mm AM/PM" & "created by-[username]")

## TC-4 Validate the history tab entry creation, when updating an item
Preconditions:
The user has an account and is logged in.
There should be an already created item ("Goods").

Test Case Steps:
- Open the "Items" page: https://invoice.zohocloud.ca/app/110000477898#/inventory/items
- Select an item
- Click on the "Edit" button
- Change the item's Selling Price (e.g. from "99.99" to "101.99")
- Click the "Save" button
- Click on the "History" tab

Expected Result:
A new entry log should be visible, showing the edit date and the creator(e.g. "yyyy/mm/dd hh:mm AM/PM" & "updated by-[username]")