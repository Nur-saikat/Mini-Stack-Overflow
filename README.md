Project: Mini Stack Overflow
Objective
Build a simplified Stack Overflow-like application with basic features such as user authentication, question creation, answering questions, voting, and displaying results.
________________________________________
Project Requirements
1. Functional Requirements
1.	User Authentication
○	Implement user registration and login functionality.
○	Users must be logged in to:
■	Create questions.
■	Post answers.
■	Vote on questions or answers.
○	Basic user profile:
■	Username
■	Email (unique)
■	Password (hashed using a secure method like ASP.NET Core Identity or a similar library).
2.	Question Management
○	Users should be able to create a question with the following fields:
■	Title
■	Description
■	Tags (optional, comma-separated)
○	Display a list of all questions on the home page with:
■	Title
■	Number of answers
■	Total votes (sum of upvotes and downvotes)
3.	Answer Management
○	Logged-in users should be able to add answers to a question.
○	Answers should include:
■	Answer text
■	The username of the logged-in user who posted the answer.
○	Display all answers for a question below the question details.
4.	Voting System
○	Logged-in users should be able to upvote or downvote both questions and answers.
○	Each user can vote only once per question or answer (upvote or downvote).
○	Total votes (upvotes - downvotes) should be displayed.
5.	Filtering and Sorting
○	Questions can be filtered by tags.
○	Questions can be sorted by:
■	Most answered
■	Most voted
■	Newest
________________________________________
2. Non-Functional Requirements
1.	Technology Stack
○	Use .NET Core (ASP.NET Core MVC or API).
○	Use Entity Framework Core for database interactions.
○	Use a SQL Server database.
○	Frontend can use Razor Pages, Bootstrap, or basic HTML/CSS framework for simplicity.
2.	Design Considerations
○	Responsive design for desktop and mobile views.
○	Minimal UI is acceptable but should be clean and functional.
3.	Code Quality
○	Use proper naming conventions.
○	Ensure code readability and maintainability (e.g., comments where necessary).
○	Follow the MVC or layered architecture patterns.
4.	Authentication Security
○	Use password hashing and validation.
○	Implement session or JWT-based authentication for secure user sessions.
5.	Time Constraint
○	The project must be completed within 2–3 days.
________________________________________
Project Deliverables
1.	Source Code
○	Share the project repository (e.g., GitHub, GitLab, or zip file).
○	Provide a README.md file with instructions on how to run the project.
2.	Database
○	Include the SQL script or database migration files for creating necessary tables.
3.	Features Checklist
○	Provide a checklist of features implemented, including any additional ones beyond the requirements.
________________________________________
Evaluation Criteria
1.	Core Features Implementation
○	Completeness and correctness of the required features.
2.	Code Quality
○	Clarity, organization, and adherence to best practices.
3.	Database Design
○	Proper table structure with relationships (e.g., users, questions, and answers).
4.	User Experience
○	Usability and design of the application.
5.	Authentication Security
○	Proper implementation of secure user authentication.
6.	Creativity
○	Any extra features or unique approaches.
________________________________________
Bonus (Optional)
1.	Add pagination for questions and answers.
2.	Allow users to mark an answer as "Accepted" for a question.
3.	Include an admin panel for managing questions and users.

