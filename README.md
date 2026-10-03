## Transaction Analyser
This is a C# console application that aims to record, categorise and analyse personal expenses.
The application uses a rule-based categorisation system to automatically classify transaction descriptions into categories such as Groceries, Transport, Shopping and Entertainment. Users can also teach the application new categorisation rules, which are saved and loaded for future use.

## Features
- Add and view expenses
- Calculate total and average spending
- Automatically categorise transactions
- Display spending by category
- Teach the application new categorisation rules
- Save and load learned categorisation rules between sessions
- Export transaction data using CSV
- Generate spending summaries

## Automatic Categorisation
The application uses predefined rules to automatically categorise common transaction descriptions. It checks the description for known keywords and assigns the corresponding category. This provides a baseline set of categorisation rules for common transactions without requiring the user to manually categorise every expense.

## User-Driven Learning
If a transaction does not match an existing categorisation rule, the application asks the user to select an appropriate category. After the user selects a category, the application creates a new CategorisationRule. The new rule is then stored so that the application can recognise the transaction in the future.

## Persistent Rules
Learned rules are stored in a CSV file. When the application starts, previously saved rules are loaded back into memory. This means that learned rules are not lost when the application closes.

## Current Development
This project is actively being developed, with ongoing improvements focusing on code maintainability and application structure.
