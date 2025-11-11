-- Drop User table if it exists
DROP TABLE IF EXISTS "users";

-- Drop Mail table if it exists
DROP TABLE IF EXISTS "mail";

/*Table for storing users*/
CREATE TABLE "users" (
    id SERIAL PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL
);

INSERT INTO "users" (id, username, email, password) VALUES
    (1, 'Alice', 'alice@example.com', 'Qwerty123'),
    (2, 'Bob', 'bob@example.com', 'Qwerty123'),
    (3, 'Charlie', 'charlie@example.com', 'Qwerty123'),
    (4, 'David', 'david@example.com', 'Qwerty123');

SELECT * FROM "users";


/*Table for storing emails*/
CREATE TABLE "mail" (
    id SERIAL PRIMARY KEY,
    fromEmail VARCHAR(50) NOT NULL,
    toEmail VARCHAR(50) NOT NULL,
    subject VARCHAR(50) NOT NULL,
	body VARCHAR(250) NOT NULL,
	time_sent TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO "mail" (fromEmail, toEmail, subject, body)
VALUES
    ('alice@example.com', 'bob@example.com', 'Regarding Project Update', 'Hi Bob, Just wanted to share the latest project updates.'),
    ('bob@example.com', 'charlie@example.com', 'Meeting Reminder', 'Dear Charlie, Our weekly team meeting is scheduled for tomorrow at 10 AM.'),
    ('charlie@example.com', 'david@example.com', 'Invitation to Webinar', 'Hello David, You are invited to our upcoming webinar on data analytics.'),
    ('david@example.com', 'alice@example.com', 'Job Application Status', 'Dear Alice, Thank you for applying. We will review your application and get back to you soon.'),
    ('alice@example.com', 'charlie@example.com', 'Feedback Request', 'Hi Charlie, Could you please provide feedback on the recent product demo?'),
    ('charlie@example.com', 'bob@example.com', 'Travel Itinerary', 'Bob, here is your travel itinerary for the upcoming conference.');

SELECT * FROM "mail";