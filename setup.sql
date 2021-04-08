USE artistsaf;

--  CREATE TABLE artists
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL UNIQUE,
--   description VARCHAR(255),
--   birthyear INT NOT NULL,

--   PRIMARY KEY (id)
-- );

-- SELECT * FROM artists;

-- INSERT INTO artists
-- (name, description, birthyear)
-- VALUES
-- ("Alex Van Gogh", "Paints really super well", 1994)

CREATE TABLE songs
(
    id INT NOT NULL AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    year INT NOT NULL,
    artistId INT NOT NULL,

    PRIMARY KEY (id),

    FOREIGN KEY (artistId)
        REFERENCES artists (id)
        ON DELETE CASCADE
);