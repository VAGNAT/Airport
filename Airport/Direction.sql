/****** Script for SelectTopNRows command from SSMS  ******/
SELECT ac.Name as AirName
      ,d.City as City
      ,MIN(Price)
      ,DATEPART(DW,p.Day)
  FROM Planes as p,Destinations as d, AirCompanies as ac
  WHERE p.DestinationId = d.Id AND p.AirCompanyId = ac.Id AND p.Day BETWEEN '29-11-21 00:00' AND '06-12-21 00:00'
  GROUP BY ac.Name, d.City, DATEPART(DW,p.Day)
  