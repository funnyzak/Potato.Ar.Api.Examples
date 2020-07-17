using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;

namespace Potato.Ar.Api.Examples.Common
{
    public class ConfigProvider
    {
        private readonly OrderedDictionary _configuration = new OrderedDictionary();

        public ConfigProvider(string[] args)
        {
            // parse command line arguments
            _configuration.Add("Command line arguments", ParseCliArguments(args));

            // parse properties from ./examples.properties
            _configuration.Add("Local properties file", ParsePropertiesFile("."));

            // parse environment variables
            _configuration.Add("Environment variables", ParseEnvironmentVariables());

            _configuration.Add("System-wide properties file",
                ParsePropertiesFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)));
        }

        public string GetAppKey()
        {
            return GetOrThrowException("APP_KEY",
                "Your App key for the POTATO API.");
        }

        public string GetAppSecret()
        {
            return GetOrThrowException("APP_SECRET",
                "Your App Secret for the POTATO API.");
        }

        /* This generic method will enable addition and use of new config settings in a simple way */
        public string GetParameterByKey(string keyName)
        {
            return GetOrThrowException(keyName, "Configuration Parameter '" + keyName + "'");
        }

        private string GetOrThrowException(String key, String description)
        {
            foreach (var configurationName in _configuration.Keys)
            {
                var subConfiguration = (Dictionary<string, string>)_configuration[configurationName];

                if (!subConfiguration.ContainsKey(key))
                {
                    continue;
                }

                var value = subConfiguration[key];
                Console.WriteLine($"Retrieved '{key}' from '{configurationName}' config source: '{value}'");
                return value;
            }

            throw new ArgumentException(key, description);
        }

        private Dictionary<string, string> ParseEnvironmentVariables()
        {
            var environmentVariables = new Dictionary<string, string>();
            foreach (DictionaryEntry environmentVariable in Environment.GetEnvironmentVariables())
            {
                if (environmentVariable.Key == null || environmentVariable.Value == null)
                    continue;

                var key = (string)environmentVariable.Key;
                var value = (string)environmentVariable.Value;

                environmentVariables[key] = value;
            }

            return environmentVariables;
        }

        private Dictionary<string, string> ParsePropertiesFile(string filePath)
        {
            var fileProperties = new Dictionary<string, string>();

            try
            {
                foreach (var row in File.ReadAllLines(Path.Combine(filePath, "examples.properties")))
                {
                    var rowSplitted = row.Split('=');

                    // Don't add comment lines
                    if (row.Trim().StartsWith("#") || rowSplitted.Length != 2 || string.IsNullOrEmpty(rowSplitted[0]))
                    {
                        continue;
                    }

                    fileProperties.Add(rowSplitted[0], rowSplitted[1]);
                }
            }
            catch (FileNotFoundException)
            {
                // ignore exception if the file was not found
            }

            return fileProperties;
        }

        private Dictionary<string, string> ParseCliArguments(string[] args)
        {
            return args
                .Select(arg => arg.Split('='))
                .Where(arg => arg.Length == 2 && !string.IsNullOrEmpty(arg[0]))
                .ToDictionary(item => item[0], value => value[1]);
        }
    }
}
