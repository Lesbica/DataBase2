CREATE VIEW [dbo].[View]
	AS SELECT [Various_plants].[Бі /Триномінальна назва], [Catalogue].Розміри, [Area].[Назва ділянки], [Catalogue].Посадка
	FROM [Various_plants], [Catalogue], [Area]
	where [Various_plants].Id = [Catalogue].Різновид and [Area].[Id] = [Catalogue].Ділянка