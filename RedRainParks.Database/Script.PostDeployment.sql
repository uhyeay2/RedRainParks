/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
 
 -- Seed States
 BEGIN
 PRINT('Preparing to seed states')
 -- TempStatesTable that holds the data to be inserted into StateLookup table
 CREATE TABLE #TempStatesTable ( Id INT PRIMARY KEY IDENTITY(1, 1), StateDetails NVARCHAR(MAX) )
 INSERT INTO #TempStatesTable (StateDetails) Values 
    ('AL, Alabama, Alabama'),                     ('AK, Alaska, Alaska'),                      ('AZ , Arizona, Arizona'),
    ('AR, Arkansas, Arkansas'),                   ('AS, American Samoa, American Samoa'),      ('CA, California, California'), 
    ('CO, Colorado, Colorado'),                   ('CT, Connecticut, Conécticut'),             ('DE, Delaware, Delaware'), 
    ('DC, District of Columbia, Distrito Federal de Columbia'),                                ('FL, Florida, Florida'), 
    ('GA, Georgia, Georgia'),                     ('GU, Guam, Guam'),                          ('HI, Hawaii, Hawái'), 
    ('ID, Idaho, Ídaho'),                         ('IL, Illinois, Ilinóis'),                   ('IN, Indiana, Indiana'), 
    ('IA, Iowa, Iowa'),                           ('KS, Kansas, Kansas'),                      ('KY, Kentucky, Kentucky'), 
    ('LA, Louisiana, Luisiana'),                  ('ME, Maine, Maine'),                        ('MD, Maryland, Máriland'), 
    ('MA, Massachusetts, Masachusets'),           ('MI, Michigan, Míchigan'),                  ('MN, Minnesota, Minesota'), 
    ('MS, Mississippi, Misisipi'),                ('MO, Missouri, Misuri'),                    ('MT, Montana, Montana'), 
    ('NE, Nebraska, Nebraska'),                   ('NV, Nevada, Nevada'),                      ('NH, New Hampshire, Nuevo Hampshire'), 
    ('NJ, New Jersey, Nueva Jersey'),             ('NM, New Mexico, Nuevo México'),            ('NY, New York, Nueva York'), 
    ('NC, North Carolina, Carolina del Norte'),   ('ND, North Dakota, Dakota del Norte'), 
    ('CM, Northern Mariana Islands, Northern Mariana Islands'),                                ('OH , Ohio, Ohio'),
    ('OK, Oklahoma, Oklahoma'),                   ('OR Oregon, Oregón'),                       ('PA, Pennsylvania, Pensilvania'),
    ('PR, Puerto Rico, Puerto Rico'),             ('RI, Rhode Island, Isla de Rode'),          ('SC, South Carolina, Carolina del Sur'),
    ('SD, South Dakota, Dakota del Sur'),         ('TN, Tennessee, Tenesí'),                   ('TX, Texas, Texas'),
    ('TT, Trust Territories, Trust Territories'), ('UT, Utah, Utah'),                          ('VT, Vermont, Vermont'),
    ('VA, Virginia, Virginia'),                   ('VI, Virgin Islands, Virginia Occidental'), ('WA, Washington, Wáshington'), 
    ('WV, West Virginia, West Virginia'),         ('WI, Wisconsin, Wisconsin'),                ('WY, Wyoming, Wyoming') 

-- Declare and Set Counter/MaxCount for looping through TempStatesTable
DECLARE @Counter int, @MaxCount int 
SELECT @Counter = MIN(Id), @MaxCount = MAX(Id) FROM #TempStatesTable

WHILE(@Counter IS NOT NULL AND @Counter <= @MaxCount)
BEGIN
    -- Get State from TempStatesTable using Counter
    DECLARE @State NVARCHAR(MAX) = (Select StateDetails from #TempStatesTable WHERE Id = @Counter)

    -- Declare and Set Abbreviation, EnglishDisplay, and SpanishDisplay
    DECLARE @Abbreviation varchar(2) = SUBSTRING(@State, 1, 2);     -- Abbreviation will always be two characters
    DECLARE @Displays NVARCHAR(MAX) = RIGHT(@State, LEN(@State) - 4);   -- All 'English, Spanish' start at Index 4
    DECLARE @English NVARCHAR(MAX) = SUBSTRING(@Displays, 1, CHARINDEX(', ', @Displays, 0) - 1);    --English will be from beginning to ', ' 
    DECLARE @Spanish NVARCHAR(MAX) = RIGHT(@Displays, LEN(@Displays) - CHARINDEX(', ', @Displays, 0));  -- Spanish will be after ', ' until the end
    PRINT('Checking ' + @STATE)
    -- Insert State If Not Exists
    If NOT EXISTS( SELECT * FROM StateLookup WHERE Abbreviation = @Abbreviation )
    BEGIN
        INSERT INTO StateLookUp (Abbreviation, EnglishDisplay, SpanishDisplay)
            VALUES (@Abbreviation, @English, @Spanish)
            PRINT('Inserted ' + @State)
    END

    SET @Counter = @Counter + 1
END

DROP TABLE #TempStatesTable
PRINT('Finished seeding states')
END