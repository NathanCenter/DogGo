SELECT  d.Id,d.Name,d.Breed,d.Notes,d.ImageUrl, d.OwnerId, o.Name as OwnerName
 FROM Dog d left join Owner o
    on  d.OwnerId= o.Id;