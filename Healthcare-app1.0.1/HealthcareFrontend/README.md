# HealthcareFrontend

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 19.1.5.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Karma](https://karma-runner.github.io) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.


# Setting Up Frontend
1️ Clone the Frontend Repository
If you haven't already, clone the frontend repository:
```git clone https://github.com/your-org/healthcare-frontend.git
cd healthcare-frontend
```

2️ Install Dependencies
Navigate to the frontend directory and install the necessary dependencies:
```
npm install
```

3️ Configure API URL
Ensure that the frontend is pointing to the correct backend API. Open src/environments/environment.ts and set the API base URL to your local backend:
```
typescript

export const environment = {
  production: false,
  apiUrl: 'http://localhost:5000/api'
};
```

4️ Run the Frontend Locally
Now you can run the frontend development server:
```
ng serve --open
```
The frontend should now be available at http://localhost:4200.
