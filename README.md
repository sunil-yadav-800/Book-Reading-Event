# Book Reading Event

## Requirements
- **Home Page**
   - Displays all public events as hyperlinks. There should be 2 columns, one for past events and one for future events.
   - Clicking hyperlink takes user to event details page.
   - Logged in users see additional header items: “My events”, “Events invited to”, “Create event”.
   - Anonymous users can only view public events.
---
![Home Page](https://github.com/sunil-yadav-800/Book-Reading-Event/blob/main/BookReadingApp/Images/Home.png)

---
- **Event details Page**
---
![Event details](https://github.com/sunil-yadav-800/Book-Reading-Event/blob/main/BookReadingApp/Images/EventDetails.png)

---
- **A book reading event has**
  - Title of the book, date of the event, location and start time.
  - Optionally, the event organizer may also specify the duration, description and other details.
- **The event can be marked as public or private.**
- **The event creator can add people to the event by specifying their email. Multiple people can be invited by specifying multiple, comma-separated emails.**
- **Users can register on the website to create their own events.**
---
![Create Event](https://github.com/sunil-yadav-800/Book-Reading-Event/blob/main/BookReadingApp/Images/CreateEvent.png)

---
- **Events invited to**
   - (visible to logged in users) will list all events as hyperlinks where the current logged in user was invited to (by matching email). Even private events are shown here if the user was invited. Hyperlinks redirect to event details page.
---
![Events invited to](https://github.com/sunil-yadav-800/Book-Reading-Event/blob/main/BookReadingApp/Images/EventsInvitedTo.png)

---
-	**My events**
  - (visible to logged in users) shows all events created by user, sorted by newest event-start-date first. There should be an “Edit” link in front of each entry which allows to edit the event.
---
![My events](https://github.com/sunil-yadav-800/Book-Reading-Event/blob/main/BookReadingApp/Images/MyEvents.png)

---
- **Edit the event**
   - User can edit only the events that (s)he created!
   - Past events can't be edited.
---
![Edit my event](https://github.com/sunil-yadav-800/Book-Reading-Event/blob/main/BookReadingApp/Images/EditMyEvent.png)

---
- **User can give comment/s to any event.**

## Technology stack used:
 Asp .net MVC 5.0, Entity framework core, Sql server
