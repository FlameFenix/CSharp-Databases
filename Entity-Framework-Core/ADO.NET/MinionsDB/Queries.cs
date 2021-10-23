using System;
using System.Collections.Generic;
using System.Text;

namespace MinionsDB
{
    public class Queries
    {
        public const string VILLAIN_NAMES = @"SELECT v.[Name], COUNT(mv.[VillainId]) AS [MinionsCount]
                                                FROM [Villains] AS v 
                                                JOIN [MinionsVillains] AS mv ON v.[Id] = mv.[VillainId]
                                               GROUP BY v.[Id], v.[Name]
                                              HAVING COUNT(mv.[VillainId]) > 3 
                                               ORDER BY COUNT(mv.[VillainId])";

        public const string ViLLAIN_NAME_BY_ID = @"SELECT [Name] FROM Villains WHERE [Id] = @Id";

        public const string MINIONS_NAMES = @"SELECT ROW_NUMBER() OVER (ORDER BY m.[Name]) as RowNum,
                                                     m.[Name], 
                                                     m.[Age]
                                                FROM [MinionsVillains] AS mv
                                                JOIN [Minions] As m ON mv.[MinionId] = m.[Id]
                                               WHERE mv.[VillainId] = @Id
                                            ORDER BY m.[Name]";

        public const string SELECT_VILLAINID_BY_NAME = @"SELECT Id FROM Villains WHERE Name = @Name";

        public const string INSERT_VILLAIN = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string SELECT_TOWN = @"SELECT Id FROM Towns WHERE Name = @townName";

        public const string INSERT_TOWN = @"INSERT INTO Towns (Name) VALUES (@townName)";

        public const string SELECT_MINION_BY_NAME = @"SELECT Id FROM Minions WHERE Name = @Name";

        public const string INSERT_MINION = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public const string VILLAIN_OWN_MINION = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

        public const string UPDATE_TOWNS_BY_COUNTRY_NAME = @"UPDATE Towns
                                                                SET Name = UPPER(Name)
                                                              WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string UPDATED_TOWNS_IN_UPPERCASE = @" SELECT t.Name 
                                                              FROM Towns as t
                                                              JOIN Countries AS c ON c.Id = t.CountryCode
                                                             WHERE c.Name = @countryName";

        public const string SELECT_VILAIN_BY_ID = @"SELECT [Name] FROM Villains WHERE Id = @villainId";

        public const string DELETE_MINIONS_FROM_VILLAINMINIONS = @"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId";

        public const string DELETE_VILLAIN_BY_ID = @"DELETE FROM Villains
      WHERE Id = @villainId";

        public const string SELECT_ALL_MINIONS_NAMES = @"SELECT Name FROM Minions";
    }
}
