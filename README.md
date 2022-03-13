# WarehouseMgmt

## instruction

https://youtu.be/3UaKNvHhxvo



## SQL

### Reqursive Hierarchy for ArticleGroups
```md


WITH CTE_ArticleGroupHierarchy (
	ArticleGroupId, ArticleGroupParentId, GroupLevel, Hierarchy )
AS (
	SELECT	Id ,
            ArticleGroupParentId ,
            0 AS GroupLevel,
			Name
    FROM dbo.ArticleGroups
    WHERE ArticleGroupParentId IS NULL
    
    UNION ALL
    SELECT	ag.Id,
            ag.ArticleGroupParentId,
            cte.GroupLevel + 1,
			cte.Hierarchy + ' --> ' + ag.Name
    FROM dbo.ArticleGroups AS ag
    INNER JOIN CTE_ArticleGroupHierarchy AS cte
		ON ag.ArticleGroupParentId = cte.ArticleGroupId
)
SELECT	ArticleGroupId ,
        ArticleGroupParentId ,
        GroupLevel,
		Hierarchy
FROM CTE_ArticleGroupHierarchy
GO
```

### Pivot attempt
```md
;WITH CTE_Sales AS
	(
		SELECT 
			c.Id AS CustomerId,
			o.Id AS OrderId,
			o.Date AS OrderDate,
			op.ArticleId AS ArticleId,
			op.Quantity AS Quantity,
			a.Price AS ArticlePrice,
			a.Price * op.Quantity AS PriceTot,
			SUM(a.Price * op.Quantity) OVER(PARTITION BY OrderId ORDER BY CustomerId) AS OrderPrice,
			ag.Id AS ArticleGroupId,
			ag.Name AS ArticleGroupName,
			YEAR(o.Date) [OYear], 
			MONTH(o.Date) [OMonth], 
			DATENAME(MONTH,o.Date) [OMonthName]
		FROM Customers AS c
		JOIN Orders AS o ON c.Id = o.CustomerId
		JOIN OrderPositions AS op ON o.Id = op.OrderId
		JOIN Articles AS a ON op.ArticleId = a.Id
		JOIN ArticleGroups AS ag ON a.ArticleGroupId = ag.Id
	)
	SELECT 
		CustomerId, 
		OrderId, 
		OrderDate,
		DATENAME(MONTH, OrderDate) AS [MONTH],
		ArticleId, 
		Quantity, 
		ArticlePrice, 
		PriceTot,
		OrderPrice,
		ArticleGroupId,
		ArticleGroupName,
		OYear,
		OMonth,
		OMonthName,
		CASE 
			WHEN OMonth = 1 THEN 'Q1'
			WHEN OMonth = 2 THEN 'Q1'
			WHEN OMonth = 3 THEN 'Q1'
			WHEN OMonth = 4 THEN 'Q2'
			WHEN OMonth = 5 THEN 'Q2'
			WHEN OMonth = 6 THEN 'Q2'
			WHEN OMonth = 7 THEN 'Q3'
			WHEN OMonth = 8 THEN 'Q3'
			WHEN OMonth = 9 THEN 'Q3'
			WHEN OMonth = 10 THEN 'Q4'
			WHEN OMonth = 11 THEN 'Q4'
			WHEN OMonth = 12 THEN 'Q4'
		END AS Quartal
	FROM 
		CTE_Sales
```

## known issues

-TreeView in WPF

-PIVOT VIEW
