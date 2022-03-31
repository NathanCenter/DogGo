 INSERT INTO Dog([Name], Breed, Notes, ImageUrl, OwnerId)
                    OUTPUT INSERTED.ID
                    VALUES (@name, @breed, @notes, imageurl, @ownerId)
UPDATE Dog SET [Name] = @name, Breed = @breed, Notes = @notes, ImageUrl = @imageUrl, 
OwnerId = ownerId
WHERE Id = @id