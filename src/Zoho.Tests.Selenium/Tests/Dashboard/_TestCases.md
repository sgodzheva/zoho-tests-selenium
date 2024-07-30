## TC-11 Test opening the dashboard page with the signed in user.
Precondition:
The user is signed in.

Test Case Steps:
- Open: https://invoice.zohocloud.ca/app/110000477898#/home/dashboard

Expected Results:
The user should be redirected to the "Zoho Invoice" home page.
The "Home" button from the sidebar navigation menu should be active and the "Dashboard" tab on the screen should be underlined.
The page title should be "Dashboard | Zoho Invoice"

## TC-12 Test the "Sign in" functionality with valid credentials
Precondition:
The user needs to be registered.

Test Case Steps:
- Open: https://www.zoho.com/ca/invoice
- Click on the "Sign in" button from the header
- Enter a valid email address in the username field
- Click on the "Next" button
- Enter a valid password in the password field
- Click on the "Sign in" button

Expected Result:
The user should be redirected to the "Zoho Invoice" dashboard page.