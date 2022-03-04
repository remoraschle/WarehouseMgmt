# WarehouseMgmt

## instruction

www.youtube.com/.........



## SQL - Reqursive Hierarchy for ArticleGroups
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
