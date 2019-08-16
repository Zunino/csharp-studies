/**
 * Decided to play with the JSON library used by Softplan's Commons library with the intention of
 * writing a helper for creating GraphQL queries and mutations.
 *
 * Newtonsoft JSON: https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
 *
 * Andre Zunino <neyzunino@gmail.com>
 * 16 August 2019
 */

using System;
using System.IO;
using _13_newtonsoft_json.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _13_newtonsoft_json
{
    public struct GraphQLQuery
    {
        public GraphQLQuery(string query)
        {
            Query = query;
        }
        public string Query { get; }
    }

    class Program
    {
        private static JsonSerializerSettings jsonSettings;

        static Program() 
        {
            jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new StringEnumConverter());
        }

        private static void GamesExample()
        {
            var rockstar = new Publisher("Rockstar Games", "Rockstar", Country.USA);
            var rdr = new Game("Red Dead Redemption", 2010, rockstar);
            var rdr2 = new Game("Red Dead Redemption 2", 2018, rockstar);

            // Using JsonSerializer directly
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new StringEnumConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            var writer = new StringWriter();
            serializer.Serialize(writer, rockstar);
            Console.WriteLine($"Rockstar: {writer.ToString()}");
            writer = new StringWriter();
            serializer.Serialize(writer, rdr);
            Console.WriteLine($"RDR: {writer.ToString()}");
            writer = new StringWriter();
            serializer.Serialize(writer, rdr2);
            Console.WriteLine($"RDR2: {writer.ToString()}");

            // Serialization using JsonConvert (wrapper around JsonSerializer)
            Console.WriteLine($"Rockstar: {JsonConvert.SerializeObject(rockstar, jsonSettings)}");
            Console.WriteLine($"RDR: {JsonConvert.SerializeObject(rdr, jsonSettings)}");
            Console.WriteLine($"RDR2: {JsonConvert.SerializeObject(rdr2, jsonSettings)}");
        }

        private static void GraphQLExample()
        {
            var query = @"processos { items { id } }";
            var graphQLQuery = new GraphQLQuery(query);
            Console.WriteLine($"Query: {JsonConvert.SerializeObject(graphQLQuery, jsonSettings)}");
        }

        static void Main(string[] args)
        {
            //GamesExample();
            GraphQLExample();
        }
    }
}
