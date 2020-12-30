select distinct movie_id from Schedule
where movie_date = 1

insert into Schedule(movie_date, showtime_id, movie_id, seat_id)
values(1, 1, 12, null);