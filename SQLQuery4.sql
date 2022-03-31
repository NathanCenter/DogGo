 SELECT w.Id, w.Name, w.ImageUrl, w. NeighborhoodId, n.Name
FROM Walker w left join Neighborhood N
  on N.Id=w.NeighborhoodId                      
  WHERE Id = @id