namespace ej2_web_api_crud.Models
{
    public static class DataSource
    {
        private static IList<Event>? _eventsData { get; set; }

        public static IList<Event> GetEvents()
        {
            if (_eventsData != null)
            {
                return _eventsData;
            }

            _eventsData = new List<Event>();

            Event related = new Event
            {
                Id = 1,
                Subject = "Explosion of Betelgeuse Star",
                Location = "Space Centre USA",
                StartTime = new DateTime(2022, 12, 5, 9, 30, 0),
                EndTime = new DateTime(2022, 12, 5, 11, 0, 0),
                PersonId = 1
            };
            _eventsData.Add(related);

            Event events = new Event
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                Location = "Newyork City",
                StartTime = new DateTime(2022, 12, 6, 12, 0, 0),
                EndTime = new DateTime(2022, 12, 6, 14, 0, 0),
                PersonId = 2
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                Location = "Space Centre USA",
                StartTime = new DateTime(2022, 12, 7, 9, 30, 0),
                EndTime = new DateTime(2022, 12, 7, 11, 0, 0),
                PersonId = 3
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 4,
                Subject = "Meteor Showers in 2018",
                Location = "Space Centre USA",
                StartTime = new DateTime(2022, 12, 8, 13, 0, 0),
                EndTime = new DateTime(2022, 12, 8, 14, 30, 0),
                PersonId = 1
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                Location = "Space Centre USA",
                StartTime = new DateTime(2022, 12, 9, 12, 0, 0),
                EndTime = new DateTime(2022, 12, 9, 14, 0, 0),
                PersonId = 2
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 6,
                Subject = "Mysteries of Bermuda Triangle",
                Location = "Bermuda",
                StartTime = new DateTime(2022, 12, 9, 9, 30, 0),
                EndTime = new DateTime(2022, 12, 9, 11, 0, 0),
                PersonId = 3
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 7,
                Subject = "Glaciers and Snowflakes",
                Location = "Himalayas",
                StartTime = new DateTime(2022, 12, 10, 11, 0, 0),
                EndTime = new DateTime(2022, 12, 10, 12, 30, 0),
                PersonId = 1
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 8,
                Subject = "Life on Mars",
                Location = "Space Centre USA",
                StartTime = new DateTime(2022, 12, 11, 9, 0, 0),
                EndTime = new DateTime(2022, 12, 11, 10, 0, 0),
                PersonId = 2
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 9,
                Subject = "Alien Civilization",
                Location = "Space Centre USA",
                StartTime = new DateTime(2022, 12, 13, 11, 0, 0),
                EndTime = new DateTime(2022, 12, 13, 13, 0, 0),
                PersonId = 7
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 10,
                Subject = "Alien kjsbdjsas",
                Location = "Space Centre USA",
                StartTime = new DateTime(2022, 12, 15, 11, 0, 0),
                EndTime = new DateTime(2022, 12, 15, 13, 0, 0),
                PersonId = 10
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 11,
                Subject = "America",
                Location = "Space USA",
                StartTime = new DateTime(2022, 12, 16, 11, 0, 0),
                EndTime = new DateTime(2022, 12, 16, 13, 0, 0),
                PersonId = 9
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 12,
                Subject = "India",
                Location = "New Delhi",
                StartTime = new DateTime(2023, 12, 18, 11, 0, 0),
                EndTime = new DateTime(2023, 12, 18, 13, 0, 0),
                PersonId = 6
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 13,
                Subject = "Explosion of Betelgeuse Star",
                Location = "Space Center USA",
                StartTime = new DateTime(2023, 1, 5, 3, 0, 0),
                EndTime = new DateTime(2023, 1, 5, 4, 30, 0),
                PersonId = 1
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 14,
                Subject = "Star",
                Location = "Space Center USA",
                StartTime = new DateTime(2023, 1, 1, 18, 0, 0),
                EndTime = new DateTime(2023, 1, 2, 22, 30, 0),
                PersonId = 2
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 15,
                Subject = "Betelgeuse Star",
                Location = "Space Center USA",
                StartTime = new DateTime(2023, 1, 3, 10, 0, 0),
                EndTime = new DateTime(2023, 1, 5, 12, 30, 0),
                PersonId = 3
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 16,
                Subject = "Explosion",
                Location = "Space Center USA",
                StartTime = new DateTime(2023, 1, 1, 18, 0, 0),
                EndTime = new DateTime(2023, 1, 1, 22, 30, 0),
                PersonId = 3
            };
            _eventsData.Add(events);

            events = new Event
            {
                Id = 17,
                Subject = "Explosion of Betelgeuse Star",
                Location = "Space Center USA",
                StartTime = new DateTime(2023, 1, 3, 10, 0, 0),
                EndTime = new DateTime(2023, 1, 3, 12, 30, 0),
                PersonId = 3
            };
            _eventsData.Add(events);

            return _eventsData;
        }
    }
}
