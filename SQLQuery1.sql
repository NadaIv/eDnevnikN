select p.[Ime],p.[Prezime],p.[KorisnickoIme],p.[Lozinka],p.[Status],o.NazivPredmeta
from [dbo].[Profesori] as p
left outer join [dbo].[Predm_Prof] as pp
on p.ID = pp.ProfesoriID
left outer join [dbo].[Predmeti] as o
on o.PredmetiID=pp.PredmetiID
