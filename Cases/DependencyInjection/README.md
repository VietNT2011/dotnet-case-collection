# Dependency injection

`ReminderService` depends on the behavior it needs, not a concrete delivery mechanism. Production code can use an email adapter while tests use a recording fake.
