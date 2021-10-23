using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinionsDB
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(Configuration.connectionString);

            using(conn)
            {
                await conn.OpenAsync();

                // await VillainName(conn);

                // await MinionNamesAsync(conn);

                // await AddMinionAsync(conn);

                // await ChangeTownNamesInCountryAsync(conn);

                // await RemoveVillainAnReleaseMinions(conn);

                // await PrintMinionNamesAsyncs(conn);
            }
            
            
        }

        /* PROBLEM 02 */

        private static async Task VillainName(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(Queries.VILLAIN_NAMES, conn);

            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Console.WriteLine($"{reader.GetValue(0)} - {reader.GetValue(1)}");
            }
        }

        /* PROBLEM 03 */

        private static async Task MinionNamesAsync(SqlConnection conn)
        {
            Console.WriteLine("Enter villain id:");

            int villainId = int.Parse(Console.ReadLine());

            SqlCommand cmdVillainName = new SqlCommand(Queries.ViLLAIN_NAME_BY_ID, conn);

            cmdVillainName.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader reader = await cmdVillainName.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            string villainName = string.Empty;

            while (await reader.ReadAsync())
            {
                villainName = reader["Name"].ToString();
            }

            await reader.CloseAsync();
            

            SqlCommand cmdMinionsNames = new SqlCommand(Queries.MINIONS_NAMES, conn);

            cmdMinionsNames.Parameters.AddWithValue("@Id", villainId);

            reader = await cmdMinionsNames.ExecuteReaderAsync();

            Console.WriteLine($"Villain: {villainName}");

            if (!reader.HasRows)
            {
                Console.WriteLine("(no minions)");
                return;
            }

            while (await reader.ReadAsync())
            {
                Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
            }

        }

        /* PROBLEM 04 */

        private static async Task AddMinionAsync(SqlConnection conn)
        {

            string[] minionInfo = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();

            string[] villainInfo = Console.ReadLine()
                                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                          .ToArray();

            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];

            string villainName = villainInfo[1];

            SqlCommand selectTown = new SqlCommand(Queries.SELECT_TOWN, conn);

            selectTown.Parameters.AddWithValue("@townName", minionTown);

            object townIdObject = await selectTown.ExecuteScalarAsync();

            if (townIdObject == null)
            {
                SqlCommand insertTown = new SqlCommand(Queries.INSERT_TOWN, conn);

                insertTown.Parameters.AddWithValue("@townName", minionTown);

                int rowsAffected = await insertTown.ExecuteNonQueryAsync();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("Error while insert town");
                    return;
                }

                townIdObject = await selectTown.ExecuteScalarAsync();

                Console.WriteLine($"Town {minionTown} was added to the database.");
            }

            int townId = (int)townIdObject;

            SqlCommand selectVillain = new SqlCommand(Queries.SELECT_VILLAINID_BY_NAME, conn);

            selectVillain.Parameters.AddWithValue("@Name", villainName);

            object villainIdObject = await selectVillain.ExecuteScalarAsync();

            if(villainIdObject == null)
            {
                SqlCommand insertVillain = new SqlCommand(Queries.INSERT_VILLAIN, conn);

                insertVillain.Parameters.AddWithValue("@villainName", villainName);

                int rowsAffected = await insertVillain.ExecuteNonQueryAsync();

                if(rowsAffected == 0)
                {
                    Console.WriteLine("Error while insert villain");
                    return;
                }

                villainIdObject = await selectVillain.ExecuteScalarAsync();

                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            int villainId = (int)villainIdObject;

            SqlCommand selectMinion = new SqlCommand(Queries.SELECT_MINION_BY_NAME, conn);

            selectMinion.Parameters.AddWithValue("@Name", minionName);

            object minionIdObject = await selectMinion.ExecuteScalarAsync();

            if(minionIdObject == null)
            {
                SqlCommand insertMinion = new SqlCommand(Queries.INSERT_MINION, conn);

                insertMinion.Parameters.AddWithValue("@name", minionName);
                insertMinion.Parameters.AddWithValue("@age", minionAge);
                insertMinion.Parameters.AddWithValue("@townId", townId);

                int rowsAffected = await insertMinion.ExecuteNonQueryAsync();

                if(rowsAffected == 0)
                {
                    Console.WriteLine("Error while insert minion");
                    return;
                }

                minionIdObject = await selectMinion.ExecuteScalarAsync();
            }

            int minionId = (int)minionIdObject;

            SqlCommand villainOwnMinion = new SqlCommand(Queries.VILLAIN_OWN_MINION, conn);

            villainOwnMinion.Parameters.AddWithValue("@minionId", minionId);
            villainOwnMinion.Parameters.AddWithValue("@villainId", villainId);

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        /* PROBLEM 05 */

        private static async Task ChangeTownNamesInCountryAsync(SqlConnection conn)
        {
            string countryName = Console.ReadLine();

            SqlCommand updateTowns = new SqlCommand(Queries.UPDATE_TOWNS_BY_COUNTRY_NAME, conn);

            updateTowns.Parameters.AddWithValue("@countryName", countryName);

            int rowsAffected = await updateTowns.ExecuteNonQueryAsync();

            if(rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }

            SqlCommand selectUpdatedTowns = new SqlCommand(Queries.UPDATED_TOWNS_IN_UPPERCASE, conn);

            selectUpdatedTowns.Parameters.AddWithValue("@countryName", countryName);

            SqlDataReader reader = await selectUpdatedTowns.ExecuteReaderAsync();

            Console.WriteLine($"{rowsAffected} town names were affected.");

            int counter = 0;

            string[] towns = new string[rowsAffected];

            while (await reader.ReadAsync())
            {
                towns[counter] = reader["Name"].ToString();
                counter++;
            }

            Console.WriteLine(string.Join(", ", towns));
        }

        /* PROBLEM 06 */

        private static async Task RemoveVillainAnReleaseMinions(SqlConnection conn)
        {

            int villainId = int.Parse(Console.ReadLine());

            SqlCommand selectVillainById = new SqlCommand(Queries.SELECT_VILAIN_BY_ID, conn);

            selectVillainById.Parameters.AddWithValue("@villainId", villainId);

            object villainName = await selectVillainById.ExecuteScalarAsync();

            if(villainName is null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            SqlCommand releaseVillainMinions = new SqlCommand(Queries.DELETE_MINIONS_FROM_VILLAINMINIONS, conn);

            releaseVillainMinions.Parameters.AddWithValue("@villainId", villainId);

            int rowsAffected = (int)releaseVillainMinions.ExecuteNonQuery();

            SqlCommand deleteVillainById = new SqlCommand(Queries.DELETE_VILLAIN_BY_ID, conn);

            deleteVillainById.Parameters.AddWithValue("@villainId", villainId);

            await deleteVillainById.ExecuteScalarAsync();

            Console.WriteLine($"{villainName} was deleted.");
            Console.WriteLine($"{rowsAffected} minions were released.");

        }

        /* PROBLEM 07 */

        private static async Task PrintMinionNamesAsyncs(SqlConnection conn)
        {
            SqlCommand selectAllMinionNames = new SqlCommand(Queries.SELECT_ALL_MINIONS_NAMES, conn);

            SqlDataReader reader = await selectAllMinionNames.ExecuteReaderAsync();

            using (reader)
            {
                List<string> minionNames = new List<string>();

                while (await reader.ReadAsync())
                {
                    minionNames.Add(reader["Name"].ToString());
                }

                while (minionNames.Count > 0)
                {
                    Console.WriteLine(minionNames[0]);

                    minionNames.RemoveAt(0);

                    if(minionNames.Count == 0)
                    {
                        break;
                    }

                    Console.WriteLine(minionNames[minionNames.Count - 1]);

                    minionNames.RemoveAt(minionNames.Count - 1);
                }
            }
        }

    }
}
