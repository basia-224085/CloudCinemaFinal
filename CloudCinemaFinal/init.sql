CREATE TABLE [dbo].[Genre] (
    [genre_id] INT           IDENTITY (1, 1) NOT NULL,
    [name]     NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([genre_id] ASC)
);

CREATE TABLE [dbo].[Hours] (
    [hour_id] INT           IDENTITY (1, 1) NOT NULL,
    [hour]    NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([hour_id] ASC)
);

CREATE TABLE [dbo].[Screening_rooms] (
    [screening_room_id] INT           IDENTITY (1, 1) NOT NULL,
    [name]              NVARCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([screening_room_id] ASC)
);

CREATE TABLE [dbo].[Showtimes] (
    [showtime_id]       INT NOT NULL,
    [hour_id]           INT NOT NULL,
    [screening_room_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([showtime_id] ASC),
    FOREIGN KEY ([hour_id]) REFERENCES [dbo].[Hours] ([hour_id]),
    FOREIGN KEY ([screening_room_id]) REFERENCES [dbo].[Screening_rooms] ([screening_room_id])
);

CREATE TABLE [dbo].[Seat] (
    [seat_id]  INT IDENTITY (1, 1) NOT NULL,
    [movie_id] INT NOT NULL,
    [column]   INT NOT NULL,
    [row]      INT NOT NULL,
    [reserved] BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([seat_id] ASC),
    FOREIGN KEY ([movie_id]) REFERENCES [dbo].[Movies] ([movie_id])
);

CREATE TABLE [dbo].[Movies] (
    [movie_id]       INT             IDENTITY (1, 1) NOT NULL,
    [genre_id]       INT             NOT NULL,
    [title]          NVARCHAR (60)   NOT NULL,
    [trailer]        NVARCHAR (100)  NULL,
    [price_per_seat] NUMERIC (2, 2)  NOT NULL,
    [description]    NVARCHAR (2000) NULL,
    [duration]       INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([movie_id] ASC),
    FOREIGN KEY ([genre_id]) REFERENCES [dbo].[Genre] ([genre_id])
);

CREATE TABLE [dbo].[Reservations] (
    [reservation_id] INT            IDENTITY (1, 1) NOT NULL,
    [seat_id]        INT            NOT NULL,
    [total_price]    NUMERIC (3, 2) NOT NULL,
    [email]          NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([reservation_id] ASC),
    FOREIGN KEY ([seat_id]) REFERENCES [dbo].[Seat] ([seat_id])
);

CREATE TABLE [dbo].[Schedule] (
    [date]        DATETIME NOT NULL,
    [showtime_id] INT      NOT NULL,
    [movie_id]    INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([date] ASC),
    FOREIGN KEY ([showtime_id]) REFERENCES [dbo].[Showtimes] ([showtime_id]),
    FOREIGN KEY ([movie_id]) REFERENCES [dbo].[Movies] ([movie_id])
);


