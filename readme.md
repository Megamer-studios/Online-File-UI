
# Project Overview (WARNING! This can be exploited with JS injections and HTTP requests)

This project is a Blazor-based web application that facilitates authentication, file handling (upload, delete), and user interaction through dynamic UI components. It leverages multiple technologies including **Blazor**, **Tailwind CSS**, **Logto Authentication**, and **Kestrel** for server hosting.

---

### 1. **HTML File (index.html)**

This file is the entry point of the application, setting up the HTML page structure, styling, and script references.

#### Key Components:
- **Bootstrap & Tailwind CSS**: Used for styling and responsiveness.
- **Blazor WebAssembly**: `blazor.web.js` script enables Blazor functionality on the page.
- **Logto Authentication**: A custom authentication library for user login.
  
#### Code Breakdown:
- `<!DOCTYPE html>`: Declares this file as an HTML5 document.
- `<head>`: Contains meta information and links to external resources like stylesheets, the favicon, and JavaScript libraries.
- `<body>`: Contains the main app routes, defined by Blazor, and a script to load Blazor’s WebAssembly runtime.

### 2. **Configuration File (appsettings.json)**

This JSON configuration file defines the **Kestrel** web server settings, logging, and host restrictions.

#### Key Components:
- **Kestrel Endpoints**: Configures the web server to listen on port 5000.
- **Logging**: Defines the log levels for various namespaces.
- **Allowed Hosts**: Specifies which host names are allowed to make requests.

### 3. **Program File (Program.cs)**

This is the core C# backend file for setting up the Blazor application, configuring services, and setting up the HTTP request pipeline.

#### Key Components:
- **Authentication Setup**: Configures authentication using Logto and a custom authentication endpoint, `AppId`, and `AppSecret`.
- **Routing**: Maps routes like `/SignIn` and `/SignOut` for user authentication.
- **Middleware**: Configures exception handling, static files, and anti-forgery.

### 4. **UI Page (Home.razor)**

This Blazor page displays a user interface to interact with files and manage authentication. It includes dynamic UI components and conditional rendering based on the user's authentication state.

#### Key Features:
- **User Authentication**: Checks if the user is authenticated and displays different content based on the result.
- **File Import**: Provides an option to import files into the app.
- **File Display**: Dynamically lists files from a directory (`wwwroot/Items`) and displays images or filenames.
- **Admin Privileges**: Only users with a specific `UserId` can delete files and perform administrative actions.

#### Code Breakdown:
- **Conditional Rendering**: If the user is authenticated and matches the owner’s `UserId`, they can see debugging information and access delete options.
- **File Import**: Users can import files by selecting them through an `<InputFile />` component.
- **File Handling**: Displays all files in a grid, with image support for `.png`, `.jpeg`, `.jpg`, and `.gif` file types.

### 5. **Delete Page (Delete.razor)**

This page provides functionality to delete files from the server for users with administrative privileges.

#### Key Features:
- **Delete Files**: Displays files in a grid format. Clicking on a file triggers its deletion.
- **Confirmation**: Displays a warning message when the user enters delete mode.
- **Redirect**: After deletion, the page reloads to reflect changes.

---

### How to Set Up & Run the Project

1. **Install Dependencies**:
   - Ensure you have **.NET SDK** installed on your system.
   - Install **Tailwind CSS** and other external dependencies as defined in the HTML file.

2. **Set Up Logto Authentication**:
   - Replace the placeholders `PUT ENDPOINT HERE`, `PUT APPID HERE`, and `PUT APPSECRET HERE` with your actual Logto credentials.

3. **File Handling**:
   - Place any files you wish to interact with in the `wwwroot/Items` directory.

4. **Run the Application**:
   - Use the following commands to build and run the Blazor app:
     ```bash
     dotnet build
     dotnet run
     ```

5. **Navigate to the App**:
   - Once the app is running, visit `http://localhost:5000` in your browser.
   - Use the "Sign In" button to authenticate and begin interacting with the app.

---

### File Management and Functionality

#### Importing Files:
- Users can import files via the file input button, which will upload the file to the `wwwroot/Items` directory.
  
#### Deleting Files:
- Admin users (identified by a specific `UserId`) can delete files from the list by clicking the file name.
- A confirmation warning is shown on the delete page to prevent accidental deletions.

#### Authentication:
- The app checks if the user is authenticated using Logto authentication and adjusts the UI accordingly (showing sign-in/sign-out buttons and allowing administrative privileges only for authorized users).

---

### Conclusion

This project demonstrates a full-stack Blazor application with file management, authentication, and a dynamic user interface. It is ideal for building secure, interactive applications with Blazor and integrates well with external authentication services like Logto. The user interface is responsive and styled using Tailwind CSS, with full support for file handling operations.
