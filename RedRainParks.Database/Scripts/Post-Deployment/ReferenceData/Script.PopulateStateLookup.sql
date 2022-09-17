
DROP PROCEDURE IF EXISTS [dbo].[__Populate_dbo_StateLookup] 
GO

CREATE PROCEDURE [dbo].[__Populate_dbo_StateLookup] AS
BEGIN

	PRINT 'Populating States in [dbo].[StateLookup]';

	IF OBJECT_ID('tempdb.dbo.#dbo_StateLookup') IS NOT NULL DROP TABLE #dbo_StateLookup;

	SELECT [Id], [Abbreviation], [EnglishDisplay], [SpanishDisplay] INTO #dbo_StateLookup FROM [dbo].[StateLookup] WHERE 0 = 1;

	SET IDENTITY_INSERT #dbo_StateLookup ON;

	INSERT INTO #dbo_StateLookup ([Id], [Abbreviation], [EnglishDisplay], [SpanishDisplay])
		SELECT [Id], [Abbreviation], [EnglishDisplay], [SpanishDisplay]	
			FROM ( VALUES
				(1, 'AL', 'Alabama', 'Alabama'),					
				(2, 'AK', 'Alaska', 'Alaska'),			
				(3, 'AZ', 'Arizona', 'Arizona'), 
				(4, 'AR', 'Arkansas', 'Arkansas'),			
				(5, 'AS', 'American Samoa', 'American Samoa'),		
				(6, 'CA', 'California', 'California'),
				(7, 'CO', 'Colorado', 'Colorado'),				
				(8, 'CT', 'Connecticut', 'Conécticut'),			
				(9, 'DE', 'Delaware', 'Delaware'),
				(10, 'DC', 'District of Columbia', 'Distrito Federal de Columbia'),		
				(11, 'FL', 'Florida', 'Florida'),
				(12, 'GA', 'Georgia', 'Georgia'),				
				(13, 'GU', 'Guam', 'Guam'),							
				(14, 'HI', 'Hawaii', 'Hawái'),
				(15, 'ID', 'Idaho', 'Ídaho'),					
				(16, 'IL', 'Illinois', 'Ilinóis'),				
				(17, 'IN', 'Indiana', 'Indiana'),
				(18, 'IA', 'Iowa', 'Iowa'),						
				(19, 'KS', 'Kansas', 'Kansas'),					
				(20, 'KY', 'Kentucky', 'Kentucky'),
				(21, 'LA', 'Louisiana', 'Luisiana'),			
				(22, 'ME', 'Maine', 'Maine'),					
				(23, 'MD', 'Maryland', 'Máriland'), 
				(24, 'MA', 'Massachusetts', 'Masachusets'),		
				(25, 'MI', 'Michigan', 'Míchigan'),				
				(26, 'MN', 'Minnesota', 'Minesota'),
				(27, 'MS', 'Mississippi', 'Misisipi'),			
				(28, 'MO', 'Missouri', 'Misuri'),				
				(29, 'MT', 'Montana', 'Montana'),
				(30, 'NE', 'Nebraska', 'Nebraska'),				
				(31, 'NV', 'Nevada', 'Nevada')	,				
				(32, 'NH', 'New Hampshire', 'Nuevo Hampshire'),
				(33, 'NJ', 'New Jersey', 'Nueva Jersey'),		
				(34, 'NM', 'New Mexico', 'Nuevo México'),			
				(35, 'NY', 'New York', 'Nueva York'),
				(36, 'NC', 'North Carolina', 'Carolina del Norte'), 
				(37, 'ND', 'North Dakota', 'Dakota del Norte'),		
				(38, 'CM', 'Northern Mariana Islands', 'Northern Mariana Islands'),
				(39, 'OH', 'Ohio', 'Ohio'),						
				(40, 'OK', 'Oklahoma', 'Oklahoma'),					
				(41, 'OR', 'Oregon', 'Oregón'),
				(42, 'PA', 'Pennsylvania', 'Pensilvania'),			
				(43, 'PR', 'Puerto Rico', 'Puerto Rico'),			
				(44, 'RI', 'Rhode Island', 'Isla de Rode'),
				(45, 'SC', 'South Carolina', 'Carolina del Sur'),	
				(46, 'SD', 'South Dakota', 'Dakota del Sur'),		
				(47, 'TN', 'Tennessee', 'Tenesí'),
				(48, 'TX', 'Texas', 'Texas'),						
				(49, 'TT', 'Trust Territories', 'Trust Territories'),
				(50, 'UT', 'Utah', 'Utah'),
				(51, 'VT', 'Vermont', 'Vermont'),				
				(52, 'VA', 'Virginia', 'Virginia'),				
				(53, 'VI', 'Virgin Islands', 'Virginia Occidental'),
				(54, 'WA', 'Washington', 'Wáshington'),			
				(55, 'WV', 'West Virginia', 'West Virginia'),		
				(56, 'WI', 'Wisconsin', 'Wisconsin'),
				(57, 'WY', 'Wyoming', 'Wyoming')
			) AS v ([Id], [Abbreviation], [EnglishDisplay], [SpanishDisplay]);

	SET IDENTITY_INSERT #dbo_StateLookup OFF;

	WITH cte_data as (SELECT [Id], [Abbreviation], [EnglishDisplay], [SpanishDisplay] FROM #dbo_StateLookup)
	MERGE [dbo].[StateLookup] as t
		USING cte_data as s ON t.[Id] = s.[Id]
		WHEN NOT MATCHED BY TARGET THEN
			INSERT ([Abbreviation], [EnglishDisplay], [SpanishDisplay])
				VALUES (s.[Abbreviation], s.[EnglishDisplay], s.[SpanishDisplay])
		WHEN MATCHED 
			THEN UPDATE SET 
				[Abbreviation] = s.[Abbreviation], 
				[EnglishDisplay] = s.[EnglishDisplay],
				[SpanishDisplay] = s.[SpanishDisplay]
	;

	SET IDENTITY_INSERT [dbo].StateLookup OFF;

	DROP TABLE #dbo_StateLookup;

	PRINT 'Finished Populating State Data in dbo.StateLookup'
END
GO